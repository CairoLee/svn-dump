using System;
using System.Drawing;
using System.Windows.Forms;

namespace GodLesZ.eAthenaEditor.Library.Gui.CompletionWindow {

	/// <summary>
	/// Description of AbstractCompletionWindow.
	/// </summary>
	public abstract class AbstractCompletionWindow : System.Windows.Forms.Form {
		protected TextEditorControl mEditorControl;
		protected Size mDrawingSize;
		private Rectangle mWorkingScreen;
		private Form mParentForm;


		protected AbstractCompletionWindow(Form parentForm, TextEditorControl control) {
			mWorkingScreen = Screen.GetWorkingArea(parentForm);
			//			SetStyle(ControlStyles.Selectable, false);
			this.mParentForm = parentForm;
			this.mEditorControl = control;

			SetLocation();
			StartPosition = FormStartPosition.Manual;
			FormBorderStyle = FormBorderStyle.None;
			ShowInTaskbar = false;
			MinimumSize = new Size(1, 1);
			Size = new Size(1, 1);
		}

		protected virtual void SetLocation() {
			TextArea textArea = mEditorControl.ActiveTextAreaControl.TextArea;
			TextLocation caretPos = textArea.Caret.Position;

			int xpos = textArea.TextView.GetDrawingXPos(caretPos.Y, caretPos.X);
			int rulerHeight = textArea.TextEditorProperties.ShowHorizontalRuler ? textArea.TextView.FontHeight : 0;
			Point pos = new Point(textArea.TextView.DrawingPosition.X + xpos,
														textArea.TextView.DrawingPosition.Y + (textArea.Document.GetVisibleLine(caretPos.Y)) * textArea.TextView.FontHeight
														- textArea.TextView.TextArea.VirtualTop.Y + textArea.TextView.FontHeight + rulerHeight);

			Point location = mEditorControl.ActiveTextAreaControl.PointToScreen(pos);

			// set bounds
			Rectangle bounds = new Rectangle(location, mDrawingSize);

			if (!mWorkingScreen.Contains(bounds)) {
				if (bounds.Right > mWorkingScreen.Right) {
					bounds.X = mWorkingScreen.Right - bounds.Width;
				}
				if (bounds.Left < mWorkingScreen.Left) {
					bounds.X = mWorkingScreen.Left;
				}
				if (bounds.Top < mWorkingScreen.Top) {
					bounds.Y = mWorkingScreen.Top;
				}
				if (bounds.Bottom > mWorkingScreen.Bottom) {
					bounds.Y = bounds.Y - bounds.Height - mEditorControl.ActiveTextAreaControl.TextArea.TextView.FontHeight;
					if (bounds.Bottom > mWorkingScreen.Bottom) {
						bounds.Y = mWorkingScreen.Bottom - bounds.Height;
					}
				}
			}
			Bounds = bounds;
		}

		protected override CreateParams CreateParams {
			get {
				CreateParams p = base.CreateParams;
				AddShadowToWindow(p);
				return p;
			}
		}

		static int shadowStatus;

		/// <summary>
		/// Adds a shadow to the create params if it is supported by the operating system.
		/// </summary>
		public static void AddShadowToWindow(CreateParams createParams) {
			if (shadowStatus == 0) {
				// Test OS version
				shadowStatus = -1; // shadow not supported
				if (Environment.OSVersion.Platform == PlatformID.Win32NT) {
					Version ver = Environment.OSVersion.Version;
					if (ver.Major > 5 || ver.Major == 5 && ver.Minor >= 1) {
						shadowStatus = 1;
					}
				}
			}
			if (shadowStatus == 1) {
				createParams.ClassStyle |= 0x00020000; // set CS_DROPSHADOW
			}
		}

		protected override bool ShowWithoutActivation {
			get {
				return true;
			}
		}

		protected void ShowCompletionWindow() {
			Owner = mParentForm;
			Enabled = true;
			this.Show();

			mEditorControl.Focus();

			if (mParentForm != null) {
				mParentForm.LocationChanged += new EventHandler(this.ParentFormLocationChanged);
			}

			mEditorControl.ActiveTextAreaControl.VScrollBar.ValueChanged += new EventHandler(ParentFormLocationChanged);
			mEditorControl.ActiveTextAreaControl.HScrollBar.ValueChanged += new EventHandler(ParentFormLocationChanged);
			mEditorControl.ActiveTextAreaControl.TextArea.DoProcessDialogKey += new DialogKeyProcessor(ProcessTextAreaKey);
			mEditorControl.ActiveTextAreaControl.Caret.PositionChanged += new EventHandler(CaretOffsetChanged);
			mEditorControl.ActiveTextAreaControl.TextArea.LostFocus += new EventHandler(this.TextEditorLostFocus);
			mEditorControl.Resize += new EventHandler(ParentFormLocationChanged);

			foreach (Control c in Controls) {
				c.MouseMove += ControlMouseMove;
			}
		}

		void ParentFormLocationChanged(object sender, EventArgs e) {
			SetLocation();
		}

		public virtual bool ProcessKeyEvent(char ch) {
			return false;
		}

		protected virtual bool ProcessTextAreaKey(Keys keyData) {
			if (!Visible) {
				return false;
			}
			switch (keyData) {
				case Keys.Escape:
					Close();
					return true;
			}
			return false;
		}

		protected virtual void CaretOffsetChanged(object sender, EventArgs e) {
		}

		protected void TextEditorLostFocus(object sender, EventArgs e) {
			if (!mEditorControl.ActiveTextAreaControl.TextArea.Focused && !this.ContainsFocus) {
				Close();
			}
		}

		protected override void OnClosed(EventArgs e) {
			base.OnClosed(e);

			// take out the inserted methods
			mParentForm.LocationChanged -= new EventHandler(ParentFormLocationChanged);

			foreach (Control c in Controls) {
				c.MouseMove -= ControlMouseMove;
			}

			if (mEditorControl.ActiveTextAreaControl.VScrollBar != null) {
				mEditorControl.ActiveTextAreaControl.VScrollBar.ValueChanged -= new EventHandler(ParentFormLocationChanged);
			}
			if (mEditorControl.ActiveTextAreaControl.HScrollBar != null) {
				mEditorControl.ActiveTextAreaControl.HScrollBar.ValueChanged -= new EventHandler(ParentFormLocationChanged);
			}

			mEditorControl.ActiveTextAreaControl.TextArea.LostFocus -= new EventHandler(this.TextEditorLostFocus);
			mEditorControl.ActiveTextAreaControl.Caret.PositionChanged -= new EventHandler(CaretOffsetChanged);
			mEditorControl.ActiveTextAreaControl.TextArea.DoProcessDialogKey -= new DialogKeyProcessor(ProcessTextAreaKey);
			mEditorControl.Resize -= new EventHandler(ParentFormLocationChanged);
			Dispose();
		}

		protected override void OnMouseMove(MouseEventArgs e) {
			base.OnMouseMove(e);
			ControlMouseMove(this, e);
		}

		/// <summary>
		/// Invoked when the mouse moves over this form or any child control.
		/// Shows the mouse cursor on the text area if it has been hidden.
		/// </summary>
		/// <remarks>
		/// Derived classes should attach this handler to the MouseMove event
		/// of all created controls which are not added to the Controls
		/// collection.
		/// </remarks>
		protected void ControlMouseMove(object sender, MouseEventArgs e) {
			mEditorControl.ActiveTextAreaControl.TextArea.ShowHiddenCursor(false);
		}
	}
}
