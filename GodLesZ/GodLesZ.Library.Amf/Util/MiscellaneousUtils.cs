using System;
using System.Collections;
using System.ComponentModel;
using System.Reflection;

namespace GodLesZ.Library.Amf.Util {
	internal abstract class MiscellaneousUtils {
		protected MiscellaneousUtils() { }

		public static string GetDescription(object o) {
			ValidationUtils.ArgumentNotNull(o, "o");

			ICustomAttributeProvider attributeProvider = o as ICustomAttributeProvider;

			// object passed in isn't an attribute provider
			// if value is an enum value, get value field member, otherwise get values type
			if (attributeProvider == null) {
				Type valueType = o.GetType();

				if (valueType.IsEnum)
					attributeProvider = valueType.GetField(o.ToString());
				else
					attributeProvider = valueType;
			}

			DescriptionAttribute descriptionAttribute = ReflectionUtils.GetAttribute(typeof(DescriptionAttribute), attributeProvider) as DescriptionAttribute;

			if (descriptionAttribute != null)
				return descriptionAttribute.Description;
			else
				throw new Exception(string.Format("No DescriptionAttribute on '{0}'.", o.GetType()));
		}

		public static string[] GetDescriptions(IList values) {
			ValidationUtils.ArgumentNotNull(values, "values");

			string[] descriptions = new string[values.Count];

			for (int i = 0; i < values.Count; i++) {
				descriptions[i] = GetDescription(values[i]);
			}

			return descriptions;
		}

		public static string ToString(object value) {
			return (value != null) ? value.ToString() : "{null}";
		}
	}
}
