using Microsoft.Xna.Framework;

namespace GodLesZ.Library.Xna.WindowLibrary.Controls {

	public class ModalContainer : Container {

		private EModalResult modalResult = EModalResult.None;
		private ModalContainer lastModal = null;

		public override bool Visible {
			get {
				return base.Visible;
			}
			set {
				if (value)
					Focused = true;
				base.Visible = value;
			}
		}

		public virtual bool IsModal {
			get { return Manager.ModalWindow == this; }
		}

		public virtual EModalResult ModalResult {
			get {
				return modalResult;
			}
			set {
				modalResult = value;
			}
		}

		public event WindowClosingEventHandler Closing;
		public event WindowClosedEventHandler Closed;

		public ModalContainer(Manager manager)
			: base(manager) {
			Manager.Input.GamePadDown += new GamePadEventHandler(Input_GamePadDown);
			GamePadActions = new EWindowGamePadActions();
		}

		public virtual void ShowModal() {
			lastModal = Manager.ModalWindow;
			Manager.ModalWindow = this;
			Manager.Input.KeyDown += new KeyEventHandler(Input_KeyDown);
			Manager.Input.GamePadDown += new GamePadEventHandler(Input_GamePadDown);
		}

		public virtual void Close() {
			WindowClosingEventArgs ex = new WindowClosingEventArgs();
			OnClosing(ex);
			if (!ex.Cancel) {
				Manager.Input.KeyDown -= Input_KeyDown;
				Manager.Input.GamePadDown -= Input_GamePadDown;
				Manager.ModalWindow = lastModal;
				if (lastModal != null)
					lastModal.Focused = true;
				Hide();
				WindowClosedEventArgs ev = new WindowClosedEventArgs();
				OnClosed(ev);

				if (ev.Dispose) {
					this.Dispose();
				}
			}
		}

		public virtual void Close(EModalResult modalResult) {
			ModalResult = modalResult;
			Close();
		}

		protected virtual void OnClosing(WindowClosingEventArgs e) {
			if (Closing != null)
				Closing.Invoke(this, e);
		}

		protected virtual void OnClosed(WindowClosedEventArgs e) {
			if (Closed != null)
				Closed.Invoke(this, e);
		}

		void Input_KeyDown(object sender, KeyEventArgs e) {
			if (Visible && (Manager.FocusedControl != null && Manager.FocusedControl.Root == this) &&
				e.Key == Microsoft.Xna.Framework.Input.Keys.Escape) {
				//Close(ModalResult.Cancel);
			}
		}

		void Input_GamePadDown(object sender, GamePadEventArgs e) {
			if (Visible && (Manager.FocusedControl != null && Manager.FocusedControl.Root == this)) {
				if (e.Button == (GamePadActions as EWindowGamePadActions).Accept) {
					Close(EModalResult.Ok);
				} else if (e.Button == (GamePadActions as EWindowGamePadActions).Cancel) {
					Close(EModalResult.Cancel);
				}
			}
		}

	}

}
