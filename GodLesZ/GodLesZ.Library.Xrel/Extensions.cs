using System;
using System.Linq;
using System.Reflection;

namespace GodLesZ.Library.Xrel {

    public static class TypeExtensions {

        public static string GetCustomAttributeValue<T>(this Type type, string defaultValue = "") where T : Attribute {
            var attributes = type.GetCustomAttributes(typeof(T), true);
            return attributes.Length == 0 ? defaultValue : attributes[0].ToString();

        }

        public static T GetAttribute<T>(this Enum enumValue) where T : Attribute {
            var memberInfo = enumValue.GetType().GetMember(enumValue.ToString()).FirstOrDefault();
            if (memberInfo == null) {
                return null;
            }

            return (T)memberInfo.GetCustomAttributes(typeof(T), false).FirstOrDefault();

        }

    }

}