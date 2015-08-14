
#if !(NET_1_1)

#endif
#if !SILVERLIGHT

#endif
using GodLesZ.Library.Amf.AMF3;

namespace GodLesZ.Library.Amf.IO {
	public interface IObjectProxy {
		bool GetIsExternalizable(object instance);
		bool GetIsDynamic(object instance);
		ClassDefinition GetClassDefinition(object instance);
		object GetValue(object instance, ClassMember member);
		void SetValue(object instance, ClassMember member, object value);
	}
}
