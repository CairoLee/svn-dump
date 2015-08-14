using System.Collections.Generic;
using System.Dynamic;
using System.Xml;

namespace GodLesZ.Library.Data.Xml {

    public static class XmlDocumentExtensions {

        public static dynamic ToObject(this XmlDocument document) {
            var root = document.DocumentElement;
            return ToObject(root, new ExpandoObject());
        }


        private static dynamic ToObject(XmlNode node, ExpandoObject config, int count = 1) {
            var parent = config as IDictionary<string, object>;
            if (node.Attributes != null) {
                foreach (XmlAttribute nodeAttribute in node.Attributes) {
                    var nodeAttrName = nodeAttribute.Name;
                    parent[nodeAttrName] = nodeAttribute.Value;
                }
            }

            foreach (XmlNode nodeChild in node.ChildNodes) {
                if (IsTextOrCDataSection(nodeChild)) {
                    parent["Value"] = nodeChild.Value;
                    continue;
                }

                var nodeChildName = nodeChild.Name;
                if (parent.ContainsKey(nodeChildName)) {
                    parent[nodeChildName + "_" + count] = ToObject(nodeChild, new ExpandoObject(), count++);
                    continue;
                }

                parent[nodeChildName] = ToObject(nodeChild, new ExpandoObject());
            }
            return config;
        }


        private static bool IsTextOrCDataSection(XmlNode node) {
            return node.Name == "#text" || node.Name == "#cdata-section";
        }

    }

}