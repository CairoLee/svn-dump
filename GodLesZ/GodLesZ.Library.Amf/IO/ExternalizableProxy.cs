using System;

#if !(NET_1_1)

#endif
#if !SILVERLIGHT

#endif
using GodLesZ.Library.Amf.AMF3;
using GodLesZ.Library.Amf.Configuration;

namespace GodLesZ.Library.Amf.IO {
	class ExternalizableProxy : IObjectProxy {
		#region IObjectProxy Members

		public bool GetIsExternalizable(object instance) {
			return true;
		}

		public bool GetIsDynamic(object instance) {
			return false;
		}

		public ClassDefinition GetClassDefinition(object instance) {
			Type type = instance.GetType();
			string customClassName = type.FullName;
			customClassName = FluorineConfiguration.Instance.GetCustomClass(customClassName);
			ClassDefinition classDefinition = new ClassDefinition(customClassName, ClassDefinition.EmptyClassMembers, true, false);
			return classDefinition;
		}

		public object GetValue(object instance, ClassMember member) {
			throw new NotSupportedException();
		}

		public void SetValue(object instance, ClassMember member, object value) {
			throw new NotSupportedException();
		}

		#endregion
	}
}
