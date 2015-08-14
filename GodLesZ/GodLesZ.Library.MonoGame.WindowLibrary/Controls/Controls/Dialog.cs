
namespace GodLesZ.Library.Xna.WindowLibrary.Controls {

	public class Dialog : Window {

		private Panel pnlTop = null;
		private Label lblCapt = null;
		private Label lblDesc = null;
		private Panel pnlBottom = null;

		public Panel TopPanel {
			get { return pnlTop; }
		}

		public Panel BottomPanel {
			get { return pnlBottom; }
		}

		public Label Caption {
			get { return lblCapt; }
		}

		public Label Description {
			get { return lblDesc; }
		}


		public Dialog(Manager manager)
			: base(manager) {
			pnlTop = new Panel(manager);
			pnlTop.Anchor = EAnchors.Left | EAnchors.Top | EAnchors.Right;
			pnlTop.Init();
			pnlTop.Parent = this;
			pnlTop.Width = ClientWidth;
			pnlTop.Height = 64;
			pnlTop.BevelBorder = EBevelBorder.Bottom;

			lblCapt = new Label(manager);
			lblCapt.Init();
			lblCapt.Parent = pnlTop;
			lblCapt.Width = lblCapt.Parent.ClientWidth - 16;
			lblCapt.Text = "Caption";
			lblCapt.Left = 8;
			lblCapt.Top = 8;
			lblCapt.Alignment = EAlignment.TopLeft;
			lblCapt.Anchor = EAnchors.Left | EAnchors.Top | EAnchors.Right;

			lblDesc = new Label(manager);
			lblDesc.Init();
			lblDesc.Parent = pnlTop;
			lblDesc.Width = lblDesc.Parent.ClientWidth - 16;
			lblDesc.Left = 8;
			lblDesc.Text = "Description text.";
			lblDesc.Alignment = EAlignment.TopLeft;
			lblDesc.Anchor = EAnchors.Left | EAnchors.Top | EAnchors.Right;

			pnlBottom = new Panel(manager);
			pnlBottom.Init();
			pnlBottom.Parent = this;
			pnlBottom.Width = ClientWidth;
			pnlBottom.Height = 24 + 16;
			pnlBottom.Top = ClientHeight - pnlBottom.Height;
			pnlBottom.BevelBorder = EBevelBorder.Top;
			pnlBottom.Anchor = EAnchors.Left | EAnchors.Bottom | EAnchors.Right;

		}

		public override void Init() {
			base.Init();

			SkinLayer lc = new SkinLayer(lblCapt.Skin.Layers[0]);
			lc.Text.Font.Resource = Manager.Skin.Fonts[Manager.Skin.Controls["Dialog"].Layers["TopPanel"].Attributes["CaptFont"].Value].Resource;
			lc.Text.Colors.Enabled = Utilities.ParseColor(Manager.Skin.Controls["Dialog"].Layers["TopPanel"].Attributes["CaptFontColor"].Value);

			SkinLayer ld = new SkinLayer(lblDesc.Skin.Layers[0]);
			ld.Text.Font.Resource = Manager.Skin.Fonts[Manager.Skin.Controls["Dialog"].Layers["TopPanel"].Attributes["DescFont"].Value].Resource;
			ld.Text.Colors.Enabled = Utilities.ParseColor(Manager.Skin.Controls["Dialog"].Layers["TopPanel"].Attributes["DescFontColor"].Value);

			pnlTop.Color = Utilities.ParseColor(Manager.Skin.Controls["Dialog"].Layers["TopPanel"].Attributes["Color"].Value);
			pnlTop.BevelMargin = int.Parse(Manager.Skin.Controls["Dialog"].Layers["TopPanel"].Attributes["BevelMargin"].Value);
			pnlTop.BevelStyle = Utilities.ParseBevelStyle(Manager.Skin.Controls["Dialog"].Layers["TopPanel"].Attributes["BevelStyle"].Value);

			lblCapt.Skin = new SkinControl(lblCapt.Skin);
			lblCapt.Skin.Layers[0] = lc;
			lblCapt.Height = Manager.Skin.Fonts[Manager.Skin.Controls["Dialog"].Layers["TopPanel"].Attributes["CaptFont"].Value].Height;

			lblDesc.Skin = new SkinControl(lblDesc.Skin);
			lblDesc.Skin.Layers[0] = ld;
			lblDesc.Height = Manager.Skin.Fonts[Manager.Skin.Controls["Dialog"].Layers["TopPanel"].Attributes["DescFont"].Value].Height;
			lblDesc.Top = lblCapt.Top + lblCapt.Height + 4;
			lblDesc.Height = lblDesc.Parent.ClientHeight - lblDesc.Top - 8;

			pnlBottom.Color = Utilities.ParseColor(Manager.Skin.Controls["Dialog"].Layers["BottomPanel"].Attributes["Color"].Value);
			pnlBottom.BevelMargin = int.Parse(Manager.Skin.Controls["Dialog"].Layers["BottomPanel"].Attributes["BevelMargin"].Value);
			pnlBottom.BevelStyle = Utilities.ParseBevelStyle(Manager.Skin.Controls["Dialog"].Layers["BottomPanel"].Attributes["BevelStyle"].Value);
		}

	}

}
