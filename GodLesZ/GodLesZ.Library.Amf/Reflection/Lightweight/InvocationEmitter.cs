
using System;
using System.Reflection;

namespace GodLesZ.Library.Amf.Reflection.Lightweight {
	/// <summary>
	/// Base class for invocation emitters.
	/// </summary>
	abstract class InvocationEmitter : AbstractEmitter {
		protected InvocationEmitter(Type targetType, BindingFlags flags, MemberTypes memberTypes, Type[] parameterTypes, MemberInfo memberInfo)
			: base(targetType, flags, memberTypes, parameterTypes, memberInfo) {
		}

		protected byte CreateLocalsForByRefParams(byte paramArrayIndex, MethodBase invocationInfo) {
			byte numberOfByRefParams = 0;
			ParameterInfo[] parameters = invocationInfo.GetParameters();
			for (int i = 0; i < ParameterTypes.Length; i++) {
				Type paramType = ParameterTypes[i];
				if (paramType.IsByRef) {
					Type type = paramType.GetElementType();
					Emit.DeclareLocal(type);
					if (!parameters[i].IsOut) // no initialization necessary is 'out' parameter
                    {
						Emit.ldarg(paramArrayIndex)
							.ldc_i4(i)
							.ldelem_ref
							.CastFromObject(type)
							.stloc(numberOfByRefParams)
							.end();
					}
					numberOfByRefParams++;
				}
			}
			return numberOfByRefParams;
		}

		protected void PushParamsOrLocalsToStack(int paramArrayIndex) {
			byte currentByRefParam = 0;
			for (int i = 0; i < ParameterTypes.Length; i++) {
				Type paramType = ParameterTypes[i];
				if (paramType.IsByRef) {
					Emit.ldloca_s(currentByRefParam++);
				} else {
					Emit.ldarg(paramArrayIndex)
						.ldc_i4(i)
						.ldelem_ref
						.CastFromObject(paramType);
				}
			}
		}

		protected void AssignByRefParamsToArray(int paramArrayIndex) {
			byte currentByRefParam = 0;
			for (int i = 0; i < ParameterTypes.Length; i++) {
				Type paramType = ParameterTypes[i];
				if (paramType.IsByRef) {
					Emit.ldarg(paramArrayIndex)
						.ldc_i4(i)
						.ldloc(currentByRefParam++)
						.boxIfValueType(paramType.GetElementType())
						.stelem_ref
						.end();
				}
			}
		}
	}
}
