using System;
using System.IO;
using System.Xml;
using Microsoft.Xna.Framework.Content;

#if (!XBOX && !XBOX_FAKE)
using System.Windows.Forms;
#endif

namespace GodLesZ.Library.Xna.WindowLibrary.Controls {

	public class LayoutXmlDocument : XmlDocument { }
	public class SkinXmlDocument : XmlDocument { }


	public class SkinReader : ContentTypeReader<SkinXmlDocument> {

		protected override SkinXmlDocument Read(ContentReader input, SkinXmlDocument existingInstance) {
			if (existingInstance == null) {
				SkinXmlDocument doc = new SkinXmlDocument();
				doc.LoadXml(input.ReadString());
				return doc;
			} else {
				existingInstance.LoadXml(input.ReadString());
			}

			return existingInstance;
		}

	}

	public class LayoutReader : ContentTypeReader<LayoutXmlDocument> {

		protected override LayoutXmlDocument Read(ContentReader input, LayoutXmlDocument existingInstance) {
			if (existingInstance == null) {
				LayoutXmlDocument doc = new LayoutXmlDocument();
				doc.LoadXml(input.ReadString());
				return doc;
			} else {
				existingInstance.LoadXml(input.ReadString());
			}

			return existingInstance;
		}

	}

#if (!XBOX && !XBOX_FAKE)

	public class CursorReader : ContentTypeReader<Cursor> {

		protected override Cursor Read(ContentReader input, Cursor existingInstance) {
			if (existingInstance == null) {
				int count = input.ReadInt32();
				byte[] data = input.ReadBytes(count);

				string path = Path.GetTempFileName();
				File.WriteAllBytes(path, data);

				IntPtr handle = NativeMethods.LoadCursor(path);
				Cursor cur = new Cursor(handle);
				File.Delete(path);

				return cur;
			} else {
			}

			return existingInstance;
		}

	}

#endif

}

