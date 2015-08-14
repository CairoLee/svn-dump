using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

#if (!XBOX && !XBOX_FAKE)
using System.Windows.Forms;
#endif

namespace GodLesZ.Library.Xna.WindowLibrary.Controls {

	public class Skin : Component {
		SkinXmlDocument doc = null;
		private string name = null;
		private Version version = null;
		private SkinInfo info;
		private SkinList<SkinControl> controls = null;
		private SkinList<SkinFont> fonts = null;
		private SkinList<SkinCursor> cursors = null;
		private SkinList<SkinImage> images = null;
		private SkinList<SkinAttribute> attributes = null;
		private ArchiveManager content = null;

		public virtual string Name { get { return name; } }
		public virtual Version Version { get { return version; } }
		public virtual SkinInfo Info { get { return info; } }
		public virtual SkinList<SkinControl> Controls { get { return controls; } }
		public virtual SkinList<SkinFont> Fonts { get { return fonts; } }
		public virtual SkinList<SkinCursor> Cursors { get { return cursors; } }
		public virtual SkinList<SkinImage> Images { get { return images; } }
		public virtual SkinList<SkinAttribute> Attributes { get { return attributes; } }

		public Skin(Manager manager, string name)
			: base(manager) {
			this.name = name;
			content = new ArchiveManager(Manager.Game.Services, GetArchiveLocation(name + Manager.SkinExtension));
			content.RootDirectory = GetFolder();
			doc = new SkinXmlDocument();
			controls = new SkinList<SkinControl>();
			fonts = new SkinList<SkinFont>();
			images = new SkinList<SkinImage>();
			cursors = new SkinList<SkinCursor>();
			attributes = new SkinList<SkinAttribute>();

			LoadSkin(null, content.UseArchive);

			string folder = GetAddonsFolder();
			if (folder == "") {
				content.UseArchive = true;
				folder = "Addons\\";
			} else {
				content.UseArchive = false;
			}

			string[] addons = content.GetDirectories(folder);

			if (addons != null && addons.Length > 0) {
				for (int i = 0; i < addons.Length; i++) {
					DirectoryInfo d = new DirectoryInfo(GetAddonsFolder() + addons[i]);
					if (!((d.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden) || content.UseArchive) {
						LoadSkin(addons[i].Replace("\\", ""), content.UseArchive);
					}
				}
			}
		}

		protected override void Dispose(bool disposing) {
			if (disposing) {
				if (content != null) {
					content.Unload();
					content.Dispose();
					content = null;
				}
			}

			base.Dispose(disposing);
		}

		private string GetArchiveLocation(string name) {
			string path = Path.GetFullPath(Manager.SkinDirectory) + Path.GetFileNameWithoutExtension(name) + "\\";
			if (!Directory.Exists(path) || !File.Exists(path + "Skin.xnb")) {
				path = Path.GetFullPath(Manager.SkinDirectory) + name;
				return path;
			}

			return null;
		}

		private string GetFolder() {
			string path = Path.GetFullPath(Manager.SkinDirectory) + name + "\\";
			if (!Directory.Exists(path) || !File.Exists(path + "Skin.xnb")) {
				path = "";
			}

			return path;
		}

		private string GetAddonsFolder() {
			string path = Path.GetFullPath(Manager.SkinDirectory) + name + "\\Addons\\";
			if (!Directory.Exists(path)) {
				path = Path.GetFullPath(".\\Content\\Skins\\") + name + "\\Addons\\";
				if (!Directory.Exists(path)) {
					path = Path.GetFullPath(".\\Skins\\") + name + "\\Addons\\";
				}
			}

			return path;
		}

		private string GetFolder(string type) {
			return GetFolder() + type + "\\";
		}

		private string GetAsset(string type, string asset, string addon) {
			string ret = GetFolder(type) + asset;
			if (addon != null && addon != "") {
				ret = GetAddonsFolder() + addon + "\\" + type + "\\" + asset;
			}
			return ret;
		}

		public override void Init() {
			base.Init();

			for (int i = 0; i < fonts.Count; i++) {
				content.UseArchive = fonts[i].Archive;
				string asset = GetAsset("Fonts", fonts[i].Asset, fonts[i].Addon);
				asset = content.UseArchive ? asset : Path.GetFullPath(asset);
				(fonts[i].Resource) = content.Load<SpriteFont>(asset);
			}

#if (!XBOX && !XBOX_FAKE)
			for (int i = 0; i < cursors.Count; i++) {
				content.UseArchive = cursors[i].Archive;
				string asset = GetAsset("Cursors", cursors[i].Asset, cursors[i].Addon);
				asset = content.UseArchive ? asset : Path.GetFullPath(asset);
				cursors[i].Resource = content.Load<Cursor>(asset);
			}
#endif

			for (int i = 0; i < images.Count; i++) {
				content.UseArchive = images[i].Archive;
				string asset = GetAsset("Images", images[i].Asset, images[i].Addon);
				asset = content.UseArchive ? asset : Path.GetFullPath(asset);
				images[i].Resource = content.Load<Texture2D>(asset);
			}

			for (int i = 0; i < controls.Count; i++) {
				for (int j = 0; j < controls[i].Layers.Count; j++) {
					if (controls[i].Layers[j].Image.Name != null) {
						controls[i].Layers[j].Image = images[controls[i].Layers[j].Image.Name];
					} else {
						controls[i].Layers[j].Image = images[0];
					}

					if (controls[i].Layers[j].Text.Name != null) {
						controls[i].Layers[j].Text.Font = fonts[controls[i].Layers[j].Text.Name];
					} else {
						controls[i].Layers[j].Text.Font = fonts[0];
					}
				}
			}
		}

		private string ReadAttribute(XmlElement element, string attrib, string defval, bool needed) {
			if (element != null && element.HasAttribute(attrib)) {
				return element.Attributes[attrib].Value;
			} else if (needed) {
				throw new Exception("Missing required attribute \"" + attrib + "\" in the skin file.");
			}
			return defval;
		}

		private void ReadAttribute(ref string retval, bool inherited, XmlElement element, string attrib, string defval, bool needed) {
			if (element != null && element.HasAttribute(attrib)) {
				retval = element.Attributes[attrib].Value;
			} else if (inherited) {
			} else if (needed) {
				throw new Exception("Missing required attribute \"" + attrib + "\" in the skin file.");
			} else {
				retval = defval;
			}
		}

		private int ReadAttributeInt(XmlElement element, string attrib, int defval, bool needed) {
			return int.Parse(ReadAttribute(element, attrib, defval.ToString(), needed));
		}

		private void ReadAttributeInt(ref int retval, bool inherited, XmlElement element, string attrib, int defval, bool needed) {
			string tmp = retval.ToString();
			ReadAttribute(ref tmp, inherited, element, attrib, defval.ToString(), needed);
			retval = int.Parse(tmp);
		}

		private bool ReadAttributeBool(XmlElement element, string attrib, bool defval, bool needed) {
			return bool.Parse(ReadAttribute(element, attrib, defval.ToString(), needed));
		}

		private void ReadAttributeBool(ref bool retval, bool inherited, XmlElement element, string attrib, bool defval, bool needed) {
			string tmp = retval.ToString();
			ReadAttribute(ref tmp, inherited, element, attrib, defval.ToString(), needed);
			retval = bool.Parse(tmp);
		}

		private byte ReadAttributeByte(XmlElement element, string attrib, byte defval, bool needed) {
			return byte.Parse(ReadAttribute(element, attrib, defval.ToString(), needed));
		}

		private void ReadAttributeByte(ref byte retval, bool inherited, XmlElement element, string attrib, byte defval, bool needed) {
			string tmp = retval.ToString();
			ReadAttribute(ref tmp, inherited, element, attrib, defval.ToString(), needed);
			retval = byte.Parse(tmp);
		}

		private string ColorToString(Color c) {
			return string.Format("{0};{1};{2};{3}", c.R, c.G, c.B, c.A);
		}

		private void ReadAttributeColor(ref Color retval, bool inherited, XmlElement element, string attrib, Color defval, bool needed) {
			string tmp = ColorToString(retval);
			ReadAttribute(ref tmp, inherited, element, attrib, ColorToString(defval), needed);
			retval = Utilities.ParseColor(tmp);
		}


		private void LoadSkin(string addon, bool archive) {
			try {
				bool isaddon = addon != null && addon != "";
				string file = GetFolder();
				if (isaddon) {
					file = GetAddonsFolder() + addon + "\\";
				}
				file += "Skin";

				file = archive ? file : Path.GetFullPath(file);
				doc = content.Load<SkinXmlDocument>(file);

				XmlElement e = doc["Skin"];
				if (e != null) {
					string xname = ReadAttribute(e, "Name", null, true);
					if (!isaddon) {
						if (name.ToLower() != xname.ToLower()) {
							throw new Exception("Skin name defined in the skin file doesn't match requested skin.");
						} else {
							name = xname;
						}
					} else {
						if (addon.ToLower() != xname.ToLower()) {
							throw new Exception("Skin name defined in the skin file doesn't match addon name.");
						}
					}

					Version xversion = null;
					try {
						xversion = new Version(ReadAttribute(e, "Version", "0.0.0.0", false));
					} catch (Exception x) {
						throw new Exception("Unable to resolve skin file version. " + x.Message);
					}

					if (xversion != Manager._SkinVersion) {
						throw new Exception("This version of Window Library Controls can only read skin files in version of " + Manager._SkinVersion.ToString() + ".");
					} else if (!isaddon) {
						version = xversion;
					}

					if (!isaddon) {
						XmlElement ei = e["Info"];
						if (ei != null) {
							if (ei["Name"] != null)
								info.Name = ei["Name"].InnerText;
							if (ei["Description"] != null)
								info.Description = ei["Description"].InnerText;
							if (ei["Author"] != null)
								info.Author = ei["Author"].InnerText;
							if (ei["Version"] != null)
								info.Version = ei["Version"].InnerText;
						}
					}

					LoadImages(addon, archive);
					LoadFonts(addon, archive);
					LoadCursors(addon, archive);
					LoadSkinAttributes();
					LoadControls();
				}
			} catch (Exception x) {
				throw new Exception("Unable to load skin file. " + x.Message);
			}
		}

		private void LoadSkinAttributes() {
			if (doc["Skin"]["Attributes"] == null)
				return;

			XmlNodeList l = doc["Skin"]["Attributes"].GetElementsByTagName("Attribute");

			if (l != null && l.Count > 0) {
				foreach (XmlElement e in l) {
					SkinAttribute sa = new SkinAttribute();
					sa.Name = ReadAttribute(e, "Name", null, true);
					sa.Value = ReadAttribute(e, "Value", null, true);
					attributes.Add(sa);
				}
			}
		}

		private void LoadControls() {
			if (doc["Skin"]["Controls"] == null)
				return;


			XmlNodeList l = doc["Skin"]["Controls"].GetElementsByTagName("Control");

			if (l != null && l.Count > 0) {
				foreach (XmlElement e in l) {
					SkinControl sc = null;
					string parent = ReadAttribute(e, "Inherits", null, false);
					bool inh = false;

					if (parent != null) {
						sc = new SkinControl(controls[parent]);
						sc.Inherits = parent;
						inh = true;
					} else {
						sc = new SkinControl();
					}

					ReadAttribute(ref sc.Name, inh, e, "Name", null, true);

					ReadAttributeInt(ref sc.DefaultSize.Width, inh, e["DefaultSize"], "Width", 0, false);
					ReadAttributeInt(ref sc.DefaultSize.Height, inh, e["DefaultSize"], "Height", 0, false);

					ReadAttributeInt(ref sc.MinimumSize.Width, inh, e["MinimumSize"], "Width", 0, false);
					ReadAttributeInt(ref sc.MinimumSize.Height, inh, e["MinimumSize"], "Height", 0, false);

					ReadAttributeInt(ref sc.OriginMargins.Left, inh, e["OriginMargins"], "Left", 0, false);
					ReadAttributeInt(ref sc.OriginMargins.Top, inh, e["OriginMargins"], "Top", 0, false);
					ReadAttributeInt(ref sc.OriginMargins.Right, inh, e["OriginMargins"], "Right", 0, false);
					ReadAttributeInt(ref sc.OriginMargins.Bottom, inh, e["OriginMargins"], "Bottom", 0, false);

					ReadAttributeInt(ref sc.ClientMargins.Left, inh, e["ClientMargins"], "Left", 0, false);
					ReadAttributeInt(ref sc.ClientMargins.Top, inh, e["ClientMargins"], "Top", 0, false);
					ReadAttributeInt(ref sc.ClientMargins.Right, inh, e["ClientMargins"], "Right", 0, false);
					ReadAttributeInt(ref sc.ClientMargins.Bottom, inh, e["ClientMargins"], "Bottom", 0, false);

					ReadAttributeInt(ref sc.ResizerSize, inh, e["ResizerSize"], "Value", 0, false);

					if (e["Layers"] != null) {
						XmlNodeList l2 = e["Layers"].GetElementsByTagName("Layer");
						if (l2 != null && l2.Count > 0) {
							LoadLayers(sc, l2);
						}
					}
					if (e["Attributes"] != null) {
						XmlNodeList l3 = e["Attributes"].GetElementsByTagName("Attribute");
						if (l3 != null && l3.Count > 0) {
							LoadControlAttributes(sc, l3);
						}
					}
					controls.Add(sc);
				}
			}
		}

		private void LoadFonts(string addon, bool archive) {
			if (doc["Skin"]["Fonts"] == null)
				return;

			XmlNodeList l = doc["Skin"]["Fonts"].GetElementsByTagName("Font");
			if (l != null && l.Count > 0) {
				foreach (XmlElement e in l) {
					SkinFont sf = new SkinFont();
					sf.Name = ReadAttribute(e, "Name", null, true);
					sf.Archive = archive;
					sf.Asset = ReadAttribute(e, "Asset", null, true);
					sf.Addon = addon;
					fonts.Add(sf);
				}
			}
		}

		private void LoadCursors(string addon, bool archive) {
			if (doc["Skin"]["Cursors"] == null)
				return;

			XmlNodeList l = doc["Skin"]["Cursors"].GetElementsByTagName("Cursor");
			if (l != null && l.Count > 0) {
				foreach (XmlElement e in l) {
					SkinCursor sc = new SkinCursor();
					sc.Name = ReadAttribute(e, "Name", null, true);
					sc.Archive = archive;
					sc.Asset = ReadAttribute(e, "Asset", null, true);
					sc.Addon = addon;
					cursors.Add(sc);
				}
			}
		}

		private void LoadImages(string addon, bool archive) {
			if (doc["Skin"]["Images"] == null)
				return;
			XmlNodeList l = doc["Skin"]["Images"].GetElementsByTagName("Image");
			if (l != null && l.Count > 0) {
				foreach (XmlElement e in l) {
					SkinImage si = new SkinImage();
					si.Name = ReadAttribute(e, "Name", null, true);
					si.Archive = archive;
					si.Asset = ReadAttribute(e, "Asset", null, true);
					si.Addon = addon;
					images.Add(si);
				}
			}
		}

		private void LoadLayers(SkinControl sc, XmlNodeList l) {
			foreach (XmlElement e in l) {
				string name = ReadAttribute(e, "Name", null, true);
				bool over = ReadAttributeBool(e, "Override", false, false);
				SkinLayer sl = sc.Layers[name];
				bool inh = true;

				if (sl == null) {
					sl = new SkinLayer();
					inh = false;
				}

				if (inh && over) {
					sl = new SkinLayer();
					sc.Layers[name] = sl;
				}

				ReadAttribute(ref sl.Name, inh, e, "Name", null, true);
				ReadAttribute(ref sl.Image.Name, inh, e, "Image", "Control", false);
				ReadAttributeInt(ref sl.Width, inh, e, "Width", 0, false);
				ReadAttributeInt(ref sl.Height, inh, e, "Height", 0, false);

				string tmp = sl.Alignment.ToString();
				ReadAttribute(ref tmp, inh, e, "Alignment", "MiddleCenter", false);
				sl.Alignment = (EAlignment)Enum.Parse(typeof(EAlignment), tmp, true);

				ReadAttributeInt(ref sl.OffsetX, inh, e, "OffsetX", 0, false);
				ReadAttributeInt(ref sl.OffsetY, inh, e, "OffsetY", 0, false);

				ReadAttributeInt(ref sl.SizingMargins.Left, inh, e["SizingMargins"], "Left", 0, false);
				ReadAttributeInt(ref sl.SizingMargins.Top, inh, e["SizingMargins"], "Top", 0, false);
				ReadAttributeInt(ref sl.SizingMargins.Right, inh, e["SizingMargins"], "Right", 0, false);
				ReadAttributeInt(ref sl.SizingMargins.Bottom, inh, e["SizingMargins"], "Bottom", 0, false);

				ReadAttributeInt(ref sl.ContentMargins.Left, inh, e["ContentMargins"], "Left", 0, false);
				ReadAttributeInt(ref sl.ContentMargins.Top, inh, e["ContentMargins"], "Top", 0, false);
				ReadAttributeInt(ref sl.ContentMargins.Right, inh, e["ContentMargins"], "Right", 0, false);
				ReadAttributeInt(ref sl.ContentMargins.Bottom, inh, e["ContentMargins"], "Bottom", 0, false);

				if (e["States"] != null) {
					ReadAttributeInt(ref sl.States.Enabled.Index, inh, e["States"]["Enabled"], "Index", 0, false);
					int di = sl.States.Enabled.Index;
					ReadAttributeInt(ref sl.States.Hovered.Index, inh, e["States"]["Hovered"], "Index", di, false);
					ReadAttributeInt(ref sl.States.Pressed.Index, inh, e["States"]["Pressed"], "Index", di, false);
					ReadAttributeInt(ref sl.States.Focused.Index, inh, e["States"]["Focused"], "Index", di, false);
					ReadAttributeInt(ref sl.States.Disabled.Index, inh, e["States"]["Disabled"], "Index", di, false);

					ReadAttributeColor(ref sl.States.Enabled.Color, inh, e["States"]["Enabled"], "Color", Color.White, false);
					Color dc = sl.States.Enabled.Color;
					ReadAttributeColor(ref sl.States.Hovered.Color, inh, e["States"]["Hovered"], "Color", dc, false);
					ReadAttributeColor(ref sl.States.Pressed.Color, inh, e["States"]["Pressed"], "Color", dc, false);
					ReadAttributeColor(ref sl.States.Focused.Color, inh, e["States"]["Focused"], "Color", dc, false);
					ReadAttributeColor(ref sl.States.Disabled.Color, inh, e["States"]["Disabled"], "Color", dc, false);

					ReadAttributeBool(ref sl.States.Enabled.Overlay, inh, e["States"]["Enabled"], "Overlay", false, false);
					bool dv = sl.States.Enabled.Overlay;
					ReadAttributeBool(ref sl.States.Hovered.Overlay, inh, e["States"]["Hovered"], "Overlay", dv, false);
					ReadAttributeBool(ref sl.States.Pressed.Overlay, inh, e["States"]["Pressed"], "Overlay", dv, false);
					ReadAttributeBool(ref sl.States.Focused.Overlay, inh, e["States"]["Focused"], "Overlay", dv, false);
					ReadAttributeBool(ref sl.States.Disabled.Overlay, inh, e["States"]["Disabled"], "Overlay", dv, false);
				}

				if (e["Overlays"] != null) {
					ReadAttributeInt(ref sl.Overlays.Enabled.Index, inh, e["Overlays"]["Enabled"], "Index", 0, false);
					int di = sl.Overlays.Enabled.Index;
					ReadAttributeInt(ref sl.Overlays.Hovered.Index, inh, e["Overlays"]["Hovered"], "Index", di, false);
					ReadAttributeInt(ref sl.Overlays.Pressed.Index, inh, e["Overlays"]["Pressed"], "Index", di, false);
					ReadAttributeInt(ref sl.Overlays.Focused.Index, inh, e["Overlays"]["Focused"], "Index", di, false);
					ReadAttributeInt(ref sl.Overlays.Disabled.Index, inh, e["Overlays"]["Disabled"], "Index", di, false);

					ReadAttributeColor(ref sl.Overlays.Enabled.Color, inh, e["Overlays"]["Enabled"], "Color", Color.White, false);
					Color dc = sl.Overlays.Enabled.Color;
					ReadAttributeColor(ref sl.Overlays.Hovered.Color, inh, e["Overlays"]["Hovered"], "Color", dc, false);
					ReadAttributeColor(ref sl.Overlays.Pressed.Color, inh, e["Overlays"]["Pressed"], "Color", dc, false);
					ReadAttributeColor(ref sl.Overlays.Focused.Color, inh, e["Overlays"]["Focused"], "Color", dc, false);
					ReadAttributeColor(ref sl.Overlays.Disabled.Color, inh, e["Overlays"]["Disabled"], "Color", dc, false);
				}

				if (e["Text"] != null) {
					ReadAttribute(ref sl.Text.Name, inh, e["Text"], "Font", null, true);
					ReadAttributeInt(ref sl.Text.OffsetX, inh, e["Text"], "OffsetX", 0, false);
					ReadAttributeInt(ref sl.Text.OffsetY, inh, e["Text"], "OffsetY", 0, false);

					tmp = sl.Text.Alignment.ToString();
					ReadAttribute(ref tmp, inh, e["Text"], "Alignment", "MiddleCenter", false);
					sl.Text.Alignment = (EAlignment)Enum.Parse(typeof(EAlignment), tmp, true);

					LoadColors(inh, e["Text"], ref sl.Text.Colors);
				}
				if (e["Attributes"] != null) {
					XmlNodeList l2 = e["Attributes"].GetElementsByTagName("Attribute");
					if (l2 != null && l2.Count > 0) {
						LoadLayerAttributes(sl, l2);
					}
				}
				if (!inh)
					sc.Layers.Add(sl);
			}
		}

		private void LoadColors(bool inherited, XmlElement e, ref SkinStates<Color> colors) {
			if (e != null) {
				ReadAttributeColor(ref colors.Enabled, inherited, e["Colors"]["Enabled"], "Color", Color.White, false);
				ReadAttributeColor(ref colors.Hovered, inherited, e["Colors"]["Hovered"], "Color", colors.Enabled, false);
				ReadAttributeColor(ref colors.Pressed, inherited, e["Colors"]["Pressed"], "Color", colors.Enabled, false);
				ReadAttributeColor(ref colors.Focused, inherited, e["Colors"]["Focused"], "Color", colors.Enabled, false);
				ReadAttributeColor(ref colors.Disabled, inherited, e["Colors"]["Disabled"], "Color", colors.Enabled, false);
			}
		}

		private void LoadControlAttributes(SkinControl sc, XmlNodeList l) {
			foreach (XmlElement e in l) {
				string name = ReadAttribute(e, "Name", null, true);
				SkinAttribute sa = sc.Attributes[name];
				bool inh = true;

				if (sa == null) {
					sa = new SkinAttribute();
					inh = false;
				}

				sa.Name = name;
				ReadAttribute(ref sa.Value, inh, e, "Value", null, true);

				if (!inh)
					sc.Attributes.Add(sa);
			}
		}

		private void LoadLayerAttributes(SkinLayer sl, XmlNodeList l) {
			foreach (XmlElement e in l) {
				string name = ReadAttribute(e, "Name", null, true);
				SkinAttribute sa = sl.Attributes[name];
				bool inh = true;

				if (sa == null) {
					sa = new SkinAttribute();
					inh = false;
				}

				sa.Name = name;
				ReadAttribute(ref sa.Value, inh, e, "Value", null, true);

				if (!inh)
					sl.Attributes.Add(sa);
			}
		}

	}

}
