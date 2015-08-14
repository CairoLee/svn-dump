
using System;
using System.Reflection;
using System.Reflection.Emit;

namespace GodLesZ.Library.Amf.Reflection.Lightweight {
	/// <summary>
	/// Base class for reflection emitters.
	/// </summary>
	abstract class AbstractEmitter {
		private DynamicMethod _method;
		private EmitHelper _emit;
		private readonly Type _targetType;
		private readonly BindingFlags _bindingFlags;
		private readonly MemberTypes _memberTypes;
		private readonly Type[] _parameterTypes;
		private readonly MemberInfo _memberInfo;

		protected AbstractEmitter(Type targetType, BindingFlags bindingFlags, MemberTypes memberTypes, Type[] parameterTypes, MemberInfo memberInfo) {
			_targetType = targetType;
			_bindingFlags = bindingFlags;
			_memberTypes = memberTypes;
			_parameterTypes = parameterTypes;
			_memberInfo = memberInfo;
		}

		public MemberInfo MemberInfo {
			get { return _memberInfo; }
		}

		public MemberTypes MemberTypes {
			get { return _memberTypes; }
		}

		public BindingFlags Flags {
			get { return _bindingFlags; }
		}

		public EmitHelper Emit {
			get { return _emit; }
		}

		public Type[] ParameterTypes {
			get { return _parameterTypes; }
		}

		public Type TargetType {
			get { return _targetType; }
		}

		public DynamicMethod Method {
			get { return _method; }
		}

		internal Delegate GetDelegate() {
			_method = CreateDynamicMethod();
			_emit = new EmitHelper(Method.GetILGenerator());
			Delegate @delegate = CreateDelegate();
			return @delegate;
		}

		protected internal abstract DynamicMethod CreateDynamicMethod();


		protected internal static DynamicMethod CreateDynamicMethod(string name, Type targetType, Type returnType, Type[] paramTypes) {
			return new DynamicMethod(name, MethodAttributes.Static | MethodAttributes.Public, CallingConventions.Standard, returnType, paramTypes,
				targetType.IsArray ? targetType.GetElementType() : targetType, true);
		}

		protected internal abstract Delegate CreateDelegate();
	}
}
