using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace FreeWorld.Engine.WindowLibrary {
	
	public enum EFormState {
		Restoring,
		Restored,
		Minimizing,
		Minimized,
		Maximizing,
		Maximized
	}

	public enum EFormProcState {
		Opening,
		Popping,
		Opened,
		Closing,
		Closed
	}

	public enum EBtnState {
		None = 0,
		MouseOver = 1,
		MouseOut = 2,
		Pressed = 4,
		Released = 8
	}

	public enum EControlType {
		None = 0,
		Animation,
		Button,
		Checkbox,
		Combo,
		ImageBox,
		Label,
		Listbox,
		ProgressBar,
		RadioButton,
		Scrollbar,
		Slider,
		Textbox,
		TextButton,
	}

	public enum EComboBoxState {
		Opened,
		Closed
	}

	public enum EProgressBarStyle {
		Continuous,
		Blocks
	}

	public enum EScrollBarAxis {
		Horizontal,
		Vertical
	}




	public enum EFormStyle {
		Default = 0,
		Vista
	}

	public class SFormStyle {
		private EFormStyle mName;
		private Vector2 mTitlePosition;
		private bool mTitleShadow = true;


		public EFormStyle Name {
			get { return mName; }
			set { mName = value; }
		}

		public Vector2 TitlePosition {
			get { return mTitlePosition; }
			set { mTitlePosition = value; }
		}

		public bool TitleShadow {
			get { return mTitleShadow; }
			set { mTitleShadow = value; }
		}

		
		
		public SFormStyle() {
			mName = EFormStyle.Default;
			mTitlePosition = Vector2.Zero;
		}

		public SFormStyle( EFormStyle Style, Vector2 Pos ) {
			mName = Style;
			mTitlePosition = Pos;
		}

		public SFormStyle( EFormStyle Style, Vector2 Pos, bool Shadow ) {
			mName = Style;
			mTitlePosition = Pos;
			mTitleShadow = Shadow;
		}

		public override string ToString() {
			return mName.ToString();
		}

	}

}
