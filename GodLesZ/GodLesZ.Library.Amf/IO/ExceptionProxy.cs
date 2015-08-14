using System;
using System.Reflection;

#if !(NET_1_1)
using System.Collections.Generic;
#endif
using GodLesZ.Library.Amf.AMF3;
using GodLesZ.Library.Amf.Configuration;

namespace GodLesZ.Library.Amf.IO {
	class ExceptionProxy : ObjectProxy {
		public override ClassDefinition GetClassDefinition(object instance) {
			Type type = instance.GetType();
			BindingFlags bindingAttr = BindingFlags.Public | BindingFlags.Instance;
			PropertyInfo[] propertyInfos = type.GetProperties(bindingAttr);
#if !(NET_1_1)
			List<ClassMember> classMemberList = new List<ClassMember>();
#else
            ArrayList classMemberList = new ArrayList();
#endif
			for (int i = 0; i < propertyInfos.Length; i++) {
				PropertyInfo propertyInfo = propertyInfos[i];
				if (propertyInfo.Name != "HelpLink" && propertyInfo.Name != "TargetSite") {
					ClassMember classMember = new ClassMember(propertyInfo.Name, bindingAttr, propertyInfo.MemberType, null);
					classMemberList.Add(classMember);
				}
			}
			string customClassName = type.FullName;
			customClassName = FluorineConfiguration.Instance.GetCustomClass(customClassName);
#if !(NET_1_1)
			ClassMember[] classMembers = classMemberList.ToArray();
#else
			ClassMember[] classMembers = classMemberList.ToArray(typeof(ClassMember)) as ClassMember[];
#endif
			ClassDefinition classDefinition = new ClassDefinition(customClassName, classMembers, GetIsExternalizable(instance), GetIsDynamic(instance));
			return classDefinition;
		}
	}
}
