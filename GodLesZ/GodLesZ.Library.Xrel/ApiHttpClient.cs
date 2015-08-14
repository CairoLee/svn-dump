using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace GodLesZ.Library.Xrel {

    public class ApiHttpClient {

        public EResultFormat ResultFormat {
            get;
            set;
        }

        public string ResultFormatValue {
            get { return ResultFormat.GetAttribute<ValueAttribute>().Value; }
        }


        public ApiHttpClient(EResultFormat resultFormat) {
            ResultFormat = resultFormat;
        }


        public XDocument BrowseCategory(ECategoryName categoryName, EExtendedInfoType extInfoType = EExtendedInfoType.None) {
            var url = new UriQueryBuilder(string.Format("http://api.xrel.to/api/release/browse_category.{0}", ResultFormatValue));
            var client = new WebClient();
            url.QueryString.Add("category_name", categoryName.GetAttribute<ValueAttribute>().Value);
            if (extInfoType != EExtendedInfoType.None) {
                url.QueryString.Add("ext_info_type", extInfoType.GetAttribute<ValueAttribute>().Value);
            }

            var resultString = client.DownloadString(url.ToString());
            if (string.IsNullOrEmpty(resultString)) {
                return null;
            }

            using (var memStream = new MemoryStream()) {
                var buf = Encoding.UTF8.GetBytes(resultString);
                memStream.Write(buf, 0, buf.Length);
                memStream.Position = 0;
                return XDocument.Load(memStream);
            }
        }

    }

}