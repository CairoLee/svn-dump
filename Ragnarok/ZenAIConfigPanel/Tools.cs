using System;
using System.Reflection;
using ZenAIConfigPanel.Library;

namespace ZenAIConfigPanel {

	public static class Tools {

		public static string GetDescription(object enumerationValue) {
			object descObj = GetAttribute(enumerationValue, typeof(ConfigDescriptionAttribute));
			if (descObj is ConfigDescriptionAttribute)
				return ((ConfigDescriptionAttribute)descObj).Description;

			return descObj.ToString();
		}

		public static string GetConfigName(object enumerationValue) {
			object descObj = GetAttribute(enumerationValue, typeof(ConfigDescriptionAttribute));
			if (descObj is ConfigDescriptionAttribute)
				return ((ConfigDescriptionAttribute)descObj).ConfigName;

			return descObj.ToString();
		}


		public static object GetAttribute(object enumerationValue, Type AttType) {
			Type type = enumerationValue.GetType();
			if (!type.IsEnum)
				return enumerationValue.ToString();

			MemberInfo[] memberInfo = type.GetMember(enumerationValue.ToString());
			if (memberInfo != null && memberInfo.Length > 0) {
				object[] attrs = memberInfo[0].GetCustomAttributes(AttType, false);
				if (attrs != null && attrs.Length > 0) {
					for (int i = 0; i < attrs.Length; i++) {
						if (attrs[i].GetType() == AttType)
							return attrs[i];
					}
				}
			}

			return enumerationValue.ToString();
		}

	}

}
