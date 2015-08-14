
using System;
using System.Reflection;
using System.Reflection.Emit;
using GodLesZ.Library.Amf.Util;

namespace GodLesZ.Library.Amf.Reflection.Lightweight {
	/// <summary>
	/// Constructor emitter.
	/// </summary>
	class CtorInvocationEmitter : InvocationEmitter {
		public CtorInvocationEmitter(ConstructorInfo ctorInfo, BindingFlags bindingFlags)
			: this(ctorInfo.DeclaringType, bindingFlags, ReflectionUtils.ToTypeArray(ctorInfo.GetParameters()), ctorInfo) {
		}

		public CtorInvocationEmitter(Type targetType, BindingFlags bindingFlags, Type[] paramTypes)
			: this(targetType, bindingFlags, paramTypes, null) {
		}

		private CtorInvocationEmitter(Type targetType, BindingFlags flags, Type[] parameterTypes, ConstructorInfo ctorInfo)
			: base(targetType, flags, MemberTypes.Constructor, parameterTypes, ctorInfo) {
		}

		protected internal override DynamicMethod CreateDynamicMethod() {
			return CreateDynamicMethod("ctor", TargetType, typeof(object), new Type[] { typeof(object) });
		}

		protected internal override Delegate CreateDelegate() {
			if (ReflectionUtils.IsTargetTypeStruct(TargetType) && ReflectionUtils.IsEmptyTypeList(ParameterTypes)) {
				// No-arg struct needs special initialization
				Emit.DeclareLocal(TargetType);      // TargetType tmp
				Emit.ldloca_s(0)                    // &tmp
					.initobj(TargetType)            // init_obj(&tmp)
					.ldloc_0.end();                 // load tmp
			} else if (TargetType.IsArray) {
				Emit.ldarg_0                                  // load args[] (method arguments)
					.ldc_i4_0                                 // load 0
					.ldelem_ref                               // load args[0] (length)
					.unbox_any(typeof(int))                   // unbox stack
					.newarr(TargetType.GetElementType());     // new T[args[0]]
			} else {
				ConstructorInfo ctorInfo = TargetType.GetConstructor(Flags, null, ParameterTypes, null);
				byte startUsableLocalIndex = 0;
				if (ReflectionUtils.HasRefParam(ParameterTypes)) {
					startUsableLocalIndex = CreateLocalsForByRefParams(0, ctorInfo); // create by_ref_locals from argument array
					Emit.DeclareLocal(TargetType);                    // TargetType tmp;
				}

				PushParamsOrLocalsToStack(0);               // push arguments and by_ref_locals
				Emit.newobj(ctorInfo);                      // ctor (<stack>)

				if (ReflectionUtils.HasRefParam(ParameterTypes)) {
					Emit.stloc(startUsableLocalIndex);      // tmp = <stack>;
					AssignByRefParamsToArray(0);            // store by_ref_locals back to argument array
					Emit.ldloc(startUsableLocalIndex);      // tmp
				}
			}
			Emit.boxIfValueType(TargetType)
				.ret();                                // return (box)<stack>;
			return Method.CreateDelegate(typeof(ConstructorInvoker));
		}
	}
}
