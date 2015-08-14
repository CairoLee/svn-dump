
#if !(NET_1_1) && !(NET_2_0) && !(SILVERLIGHT)

using System;
using System.Collections.Generic;
using System.Reflection;
using GodLesZ.Library.Amf.AMF3;
using GodLesZ.Library.Amf.Configuration;
using GodLesZ.Library.Amf.Util;

namespace GodLesZ.Library.Amf.IO {
	class EntityObjectProxy : ObjectProxy {
		public override ClassDefinition GetClassDefinition(object instance) {
			//EntityObject eo = instance as EntityObject;
			Type type = instance.GetType();
			BindingFlags flags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty | BindingFlags.DeclaredOnly;
			MemberInfo[] memberInfos = ReflectionUtils.FindMembers(type, MemberTypes.Property, flags, typeof(System.Runtime.Serialization.DataMemberAttribute));
			List<ClassMember> classMemberList = new List<ClassMember>();
			for (int i = 0; i < memberInfos.Length; i++) {
				MemberInfo memberInfo = memberInfos[i];
				PropertyInfo pi = memberInfo as PropertyInfo;
				//Do not serialize EntityReferences
				if (pi.PropertyType.IsSubclassOf(typeof(System.Data.Objects.DataClasses.EntityReference)))
					continue;
				object[] attributes = memberInfo.GetCustomAttributes(false);
				ClassMember classMember = new ClassMember(memberInfo.Name, flags, memberInfo.MemberType, attributes);
				classMemberList.Add(classMember);
			}
			string customClassName = type.FullName;
			customClassName = FluorineConfiguration.Instance.GetCustomClass(customClassName);
			ClassMember[] classMembers = classMemberList.ToArray();
			ClassDefinition classDefinition = new ClassDefinition(customClassName, classMembers, GetIsExternalizable(instance), GetIsDynamic(instance));
			return classDefinition;
		}
	}
}

#endif
