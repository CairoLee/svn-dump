using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using GodLesZ.Library.Logging;

namespace eAthenaStudio.Library.Plugin {

	public class PluginBase : IPlugin, IDisposable {
		protected frmPluginClient mOwner;
		protected bool mActive = false;
		internal string mName = "Base";
		internal string mDescription = "";
		internal string mAuthor = "";
		internal Version mVersion = new Version(1, 0);

		internal Image mMenuImage;
		protected Image mButtonImage;
		protected Image mButtonImageHover;

		#region Plugin Info's
		[Browsable(false)]
		public virtual string Name {
			get { return mName; }
		}

		[Browsable(false)]
		public virtual string Description {
			get { return mDescription; }
		}

		[Browsable(false)]
		public virtual string Author {
			get { return mAuthor; }
		}

		[Browsable(false)]
		public virtual Version Version {
			get { return mVersion; }
		}
		#endregion

		[Browsable(false)]
		public virtual Image MenuImage {
			get { return mMenuImage; }
			set { mMenuImage = value; }
		}

		[Browsable(false)]
		public virtual Image ButtonImage {
			get { return mButtonImage; }
		}

		[Browsable(false)]
		public virtual Image ButtonImageHover {
			get { return mButtonImageHover; }
		}


		[Browsable(false)]
		public ILog Logger {
			get;
			protected set;
		}

		public frmPluginClient Client {
			get { return mOwner; }
		}

		public eAthenaStudio.Library.IniParser.IniData Settings {
			get { return mOwner.Settings; }
		}

		public ILog ClientLogger {
			get { return mOwner.Logger; }
		}



		[Save, Category("General")]
		public virtual bool Active {
			get { return mActive; }
			set { mActive = value; }
		}



		public event PluginActiveChangedHandler PluginActiveChanged;
		public event PluginAddPageHandler PluginAddPage;
		public event EventHandler PluginPageClose;


		public PluginBase(frmPluginClient Owner) {
			mOwner = Owner;
		}

		public PluginBase(frmPluginClient Owner, string Name, string Description, string Author, Version Version) {
			mOwner = Owner;
			mName = Name;
			mDescription = Description;
			mAuthor = Author;
			mVersion = Version;

			if (mName != "Base") {
				Logger = LogManager.GetLogger("eaStudio.Plugin." + mName);
				Logger.Debug(mName + " [" + mDescription + "] - © by " + mAuthor);
				Logger.Debug("Plugin wird initialisiert");
			}
		}



		public virtual void Dispose() {
			Logger.Debug("Plugin wird beendet..");
		}

		public virtual void OnPluginActiveChanged() {
			if (PluginActiveChanged != null)
				PluginActiveChanged(this);
		}

		public virtual void OnPluginAddPage(Form Owner, List<string> PluginArgs) {
			if (PluginAddPage != null)
				PluginAddPage(this, null, PluginArgs);
		}

		public virtual void OnPluginAddPage(Form Owner) {
			List<string> args = new List<string>();
			OnPluginAddPage(Owner, args);
		}

		public virtual void OnPluginPageClose() {
			if (PluginPageClose != null)
				PluginPageClose(this, EventArgs.Empty);
		}

	}

}
