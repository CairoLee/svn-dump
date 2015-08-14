
using System;
using System.Collections;
using System.Reflection;
using GodLesZ.Library.Amf.IO;

namespace GodLesZ.Library.Amf.Diagnostic {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class DescribeService {
		AMFBody _amfBody;

		public DescribeService(AMFBody amfBody) {
			_amfBody = amfBody;
		}

		public Hashtable GetDescription() {
			Hashtable hashtable = new Hashtable();
			if (_amfBody != null) {
				hashtable["version"] = "1.0";
				hashtable["address"] = _amfBody.TypeName;
				Type type = TypeHelper.Locate(_amfBody.TypeName);
				hashtable["description"] = "Service description not found.";
				ArrayList functions = new ArrayList();
				if (type != null) {
					object[] attributes = type.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
					if (attributes != null && attributes.Length > 0) {
						System.ComponentModel.DescriptionAttribute descriptionAttribute = attributes[0] as System.ComponentModel.DescriptionAttribute;
						hashtable["description"] = descriptionAttribute.Description;
					}

					foreach (MethodInfo methodInfo in type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)) {
						if (TypeHelper.SkipMethod(methodInfo))
							continue;

						string description = TypeHelper.GetDescription(methodInfo);

						Hashtable functionHashtable = new Hashtable();
						functionHashtable["name"] = methodInfo.Name;
						functionHashtable["version"] = "1.0";
						functionHashtable["description"] = description;
						if (methodInfo.ReturnType.Name == "Void")
							functionHashtable["returns"] = "undefined";
						else
							functionHashtable["returns"] = methodInfo.ReturnType.Name;

						ArrayList parameters = new ArrayList();
						functionHashtable["arguments"] = parameters;

						if (methodInfo.GetParameters() != null && methodInfo.GetParameters().Length > 0) {
							foreach (ParameterInfo parameterInfo in methodInfo.GetParameters()) {
								Hashtable parameter = new Hashtable();
								parameter["name"] = parameterInfo.Name;
								parameter["required"] = true;
								if (parameterInfo.ParameterType.IsArray) {
									parameter["type"] = "Array";
								} else {
									parameter["type"] = parameterInfo.ParameterType.Name;
								}
								parameters.Add(parameter);
							}
						}

						functions.Add(functionHashtable);
					}

				}
				hashtable["functions"] = functions;
			}
			return hashtable;
		}
	}
}
