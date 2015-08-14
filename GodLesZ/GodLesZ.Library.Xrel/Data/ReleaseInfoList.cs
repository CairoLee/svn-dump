using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;

namespace GodLesZ.Library.Xrel.Data {

    public class ReleaseInfoList : List<ReleaseInfo> {

        public int CurrentPage {
            get;
            protected set;
        }

        public int PerPage {
            get;
            protected set;
        }

        public int TotalPages {
            get;
            protected set;
        }

        public int TotalResults {
            get;
            protected set;
        }


        public static ReleaseInfoList FromXml(XDocument doc) {
            var list = new ReleaseInfoList();
            if (doc.Root == null || doc.Root.Name != "releases") {
                return null;
            }

            list.CurrentPage = int.Parse(doc.Root.XPathSelectElement("pagination/current_page").Value);
            list.PerPage = int.Parse(doc.Root.XPathSelectElement("pagination/per_page").Value);
            list.TotalPages = int.Parse(doc.Root.XPathSelectElement("pagination/total_pages").Value);
            list.TotalResults = int.Parse(doc.Root.Element("total_count").Value);
            var xmlList = doc.Root.XPathSelectElements("list/release");
            list.AddRange(xmlList.Select(entry => new ReleaseInfo {
                Id = entry.Element("id").Value
            }));

            return list;
        }

    }

}