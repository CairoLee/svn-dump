using System;
using System.Reflection;
using System.Collections.Generic;
#if !SILVERLIGHT
using log4net;
#endif
using GodLesZ.Library.Amf.AMF3;
using GodLesZ.Library.Amf.Exceptions;

namespace GodLesZ.Library.Amf.IO {
	class ASObjectProxy : IObjectProxy {
#if !SILVERLIGHT
		private static readonly ILog log = LogManager.GetLogger(typeof(ASObjectProxy));
#endif

		#region IObjectProxy Members

		public bool GetIsExternalizable(object instance) {
			return false;
		}

		public bool GetIsDynamic(object instance) {
			if (instance != null) {
				if (instance is ASObject)
					return (instance as ASObject).IsTypedObject;
				throw new ArgumentException();
			}
			throw new NullReferenceException();
		}

		public ClassDefinition GetClassDefinition(object instance) {
			if (instance is ASObject) {
				ClassDefinition classDefinition;
				ASObject aso = instance as ASObject;
				if (aso.IsTypedObject) {
					ClassMember[] classMemberList = new ClassMember[aso.Count];
					int i = 0;
					foreach (KeyValuePair<string, object> entry in aso) {
						ClassMember classMember = new ClassMember(entry.Key, BindingFlags.Default, MemberTypes.Custom, null);
						classMemberList[i] = classMember;
						i++;
					}
					string customClassName = aso.TypeName;
					classDefinition = new ClassDefinition(customClassName, classMemberList, false, false);
				} else {
					string customClassName = string.Empty;
					classDefinition = new ClassDefinition(customClassName, ClassDefinition.EmptyClassMembers, false, true);
				}
				if (log.IsDebugEnabled)
					log.Debug(string.Format("Creating class definition for AS object {0}", aso));
				return classDefinition;
			}
			throw new ArgumentException();
		}

		public object GetValue(object instance, ClassMember member) {
			if (instance is ASObject) {
				ASObject aso = instance as ASObject;
				if (aso.ContainsKey(member.Name))
					return aso[member.Name];
				string msg = __Res.GetString(__Res.Reflection_MemberNotFound, string.Format("ASObject[{0}]", member.Name));
				if (log.IsDebugEnabled) {
					log.Debug(string.Format("Member {0} not found in AS object {1}", member.Name, aso));
				}
				throw new FluorineException(msg);
			}
			throw new ArgumentException();
		}

		public void SetValue(object instance, ClassMember member, object value) {
			if (instance is ASObject) {
				ASObject aso = instance as ASObject;
				aso[member.Name] = value;
			}
			throw new ArgumentException();
		}

		#endregion
	}
}
