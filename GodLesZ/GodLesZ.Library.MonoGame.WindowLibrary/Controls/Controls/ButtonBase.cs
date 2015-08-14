
namespace GodLesZ.Library.Xna.WindowLibrary.Controls {

	///  <include file='Documents/ButtonBase.xml' path='ButtonBase/Class[@name="ButtonBase"]/*' />          
	public abstract class ButtonBase : Control {


		public override EControlState ControlState {
			get {
				if (DesignMode)
					return EControlState.Enabled;
				else if (Suspended)
					return EControlState.Disabled;
				else {
					if (!Enabled)
						return EControlState.Disabled;

					if ((Pressed[(int)EMouseButton.Left] && Inside) || (Focused && (Pressed[(int)GamePadActions.Press] || Pressed[(int)EMouseButton.None])))
						return EControlState.Pressed;
					else if (Hovered && Inside)
						return EControlState.Hovered;
					else if ((Focused && !Inside) || (Hovered && !Inside) || (Focused && !Hovered && Inside))
						return EControlState.Focused;
					else
						return EControlState.Enabled;
				}
			}
		}


		protected ButtonBase(Manager manager)
			: base(manager) {
			SetDefaultSize(72, 24);
			DoubleClicks = false;
		}

		public override void Init() {
			base.Init();
		}

		protected override void OnClick(EventArgs e) {
			MouseEventArgs ex = (e is MouseEventArgs) ? (MouseEventArgs)e : new MouseEventArgs();
			if (ex.Button == EMouseButton.Left || ex.Button == EMouseButton.None) {
				base.OnClick(e);
			}
		}

	}


}
