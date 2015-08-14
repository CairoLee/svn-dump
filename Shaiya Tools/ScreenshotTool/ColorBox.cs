using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace Shaiya_Screenshot_Tool {

	public partial class ColorBox : UserControl {

		#region ColorComboButton
		private class ColorComboButton : CheckBox {
			#region ColorRadioButton
			/// <summary>
			/// a button style radio button that shows a color
			/// </summary>
			private class ColorRadioButton : RadioButton {
				public ColorRadioButton( Color color, Color backColor ) {
					this.ClientSize = new Size( 20, 20 );
					this.Appearance = Appearance.Button;
					this.Name = "button1";
					this.Visible = true;
					this.ForeColor = color;
					this.FlatAppearance.BorderColor = backColor;
					this.FlatAppearance.BorderSize = 0;
					this.FlatStyle = FlatStyle.Flat;

					this.Paint += new System.Windows.Forms.PaintEventHandler( OnPaintButton );
				}

				private void OnPaintButton( object sender, PaintEventArgs e ) {
					Rectangle colorRect = new Rectangle( ClientRectangle.Left + 4, ClientRectangle.Top + 4, ClientRectangle.Width - 9, ClientRectangle.Height - 9 );
					e.Graphics.FillRectangle( new SolidBrush( this.ForeColor ), colorRect );
					e.Graphics.DrawRectangle( new Pen( Color.Black ), colorRect );
				}
			}
			#endregion

			#region PopupWindow
			///<summary>
			///this is the popup window.  This window will be the parent of the 
			///window with the color controls on it
			///</summary>
			private class PopupWindow : ToolStripDropDown {
				public event ColorChangedHandler ColorChanged;
				private ToolStripControlHost host;
				private ColorPopup content;

				public Color SelectedColor {
					get { return content.SelectedColor; }
				}

				public PopupWindow( ColorPopup content ) {
					if( content == null ) {
						throw new ArgumentNullException( "content" );
					}
					this.content = content;
					this.AutoSize = false;
					this.DoubleBuffered = true;
					this.ResizeRedraw = true;
					//create a host that will host the content
					host = new ToolStripControlHost( content );

					this.Padding = Margin = host.Padding = host.Margin = Padding.Empty;
					this.MinimumSize = content.MinimumSize;
					content.MinimumSize = content.Size;
					MaximumSize = new Size( content.Size.Width + 1, content.Size.Height + 1 );
					content.MaximumSize = new Size( content.Size.Width + 1, content.Size.Height + 1 );
					Size = new Size( content.Size.Width + 1, content.Size.Height + 1 );

					content.Location = Point.Empty;

					//add the host to the list
					Items.Add( host );
				}

				protected override void OnClosed( ToolStripDropDownClosedEventArgs e ) {
					//when the window close tell the parent that the color changed
					if( ColorChanged != null ) {
						ColorChanged( this, new ColorChangeArgs( this.SelectedColor ) );
					}
				}
			}
			#endregion

			#region ColorPopup
			///<summary>
			///this class represends the control that has all the color radio buttons.
			///this control gets embedded into the PopupWindow class.
			///</summary>
			private class ColorPopup : UserControl {
				private Color[] mColors = { Color.Black, Color.Gray, Color.Maroon, Color.Olive, Color.Green, Color.Teal, Color.Navy, Color.Purple, Color.White, Color.Silver, Color.Red, Color.Yellow, Color.Lime, Color.Aqua, Color.Blue, Color.Fuchsia };
				private Color[] mExtendedColors = { Color.Black, Color.Brown, Color.Olive, Color.DarkGreen, Color.FromArgb( 0x00, 0x033, 0x66 ), Color.DarkBlue, Color.Indigo, Color.FromArgb( 0x33, 0x33, 0x33 ), Color.DarkRed, Color.Orange, Color.FromArgb( 0x80, 0x80, 0 ), Color.Green, Color.Teal, Color.Blue, Color.FromArgb( 0x66, 0x66, 0x99 ), Color.FromArgb( 0x80, 0x80, 0x80 ), Color.Red, Color.FromArgb( 0xFF, 0x99, 0x00 ), Color.Lime, Color.SeaGreen, Color.Aqua, Color.LightBlue, Color.Violet, Color.FromArgb( 0x99, 0x99, 0x99 ), Color.Pink, Color.Gold, Color.Yellow, Color.FromArgb( 0x00, 0xFF, 0x00 ), Color.Turquoise, Color.SkyBlue, Color.Plum, Color.FromArgb( 0xC0, 0xC0, 0xC0 ), Color.FromArgb( 0xFF, 0x99, 0xCC ), Color.Tan, Color.LightYellow, Color.LightGreen, Color.FromArgb( 0xCC, 0xFF, 0xFF ), Color.FromArgb( 0x99, 0xCC, 0xFF ), Color.Lavender, Color.White };
				private ColorRadioButton[] mButtons;
				private Color mSelectedColor = Color.Black;
				private Boolean mExtended = false;
				private Boolean mMoreColorButton = false;
				private Button mBtnMoreColor = null;
				private int mColorsPerRow = 4;

				public Boolean ExtendedColors {
					set {
						mExtended = value;
						SetupButtons();
					}
					get { return mExtended; }
				}

				public Boolean MoreColorButton {
					set {
						mMoreColorButton = value;
						SetupButtons();
					}
					get { return mMoreColorButton; }
				}

				public int ColorsPerRow {
					set {
						mColorsPerRow = value;
						SetupButtons();
					}
					get { return mColorsPerRow; }
				}

				public Color[] Colors {
					set {
						mColors = value;
						SetupButtons();
					}
					get { return mColors; }
				}

				///<summary>
				///get or set the selected color
				///</summary>
				public Color SelectedColor {
					get { return mSelectedColor; }
					set {
						mSelectedColor = value;
						Color[] colors = mExtended ? this.mExtendedColors : this.mColors;
						for( int i = 0; i < colors.Length; i++ ) {
							mButtons[ i ].Checked = mSelectedColor == colors[ i ];
						}
					}
				}

				private void InitializeComponent() {
					this.SuspendLayout();
					this.Name = "Color Popup";
					this.Text = "";
					this.ResumeLayout( false );
				}

				public ColorPopup() {
					InitializeComponent();

					SetupButtons();

					this.Paint += new System.Windows.Forms.PaintEventHandler( OnPaintBorder );
				}

				//place the buttons on the window.
				private void SetupButtons() {
					Controls.Clear();


					int x = 3;
					int y = 3;
					Color[] colors = mExtended ? this.mExtendedColors : this.mColors;
					this.mButtons = new ColorRadioButton[ colors.Length ];
					int widht = ( ( colors.Length / mColorsPerRow ) * 21 ) + 6 + 10; // Padding left/right
					
					for( int i = 0; i < colors.Length; i++ ) {
						if( i > 0 && i % mColorsPerRow == 0 ) {
							y += 20;
							x = 3;
						}
						mButtons[ i ] = new ColorRadioButton( colors[ i ], this.BackColor );
						mButtons[ i ].Location = new Point( x, y );
						mButtons[ i ].Click += new EventHandler( BtnClicked );
						if( mSelectedColor == colors[ i ] ) 
							mButtons[ i ].Checked = true;

						Controls.Add( mButtons[ i ] );
						x += 20;
					}

					this.ClientSize = new System.Drawing.Size( widht, y + 23 );

					if( mMoreColorButton == false )
						return;

					mBtnMoreColor = new Button();
					mBtnMoreColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
					mBtnMoreColor.Text = "More Colors...";
					mBtnMoreColor.Location = new Point( 3, y + 20 );
					mBtnMoreColor.ClientSize = new Size( mExtended ? 160 : 80, 24 );
					mBtnMoreColor.Click += new EventHandler( OnMoreClicked );
					Controls.Add( mBtnMoreColor );
				}

				private void OnPaintBorder( object sender, PaintEventArgs e ) {
					e.Graphics.DrawRectangle( new Pen( Color.Black ), ClientRectangle );
				}

				public void BtnClicked( object sender, EventArgs e ) {
					mSelectedColor = ( (ColorRadioButton)sender ).ForeColor;
					( (ToolStripDropDown)Parent ).Close();
				}

				public void OnMoreClicked( object sender, EventArgs e ) {
					ColorDialog dlg = new ColorDialog();
					dlg.Color = SelectedColor;
					if( dlg.ShowDialog( this ) == DialogResult.OK ) {
						mSelectedColor = dlg.Color;
					}
					( (ToolStripDropDown)Parent ).Close();
				}
			}
			#endregion

			private PopupWindow popupWnd;
			private ColorPopup colors = new ColorPopup();
			private Color selectedColor = Color.Black;
			private Timer timer = new Timer();

			public event ColorChangedHandler ColorChanged;

			/// <summary>
			/// Set or get the selected color
			/// </summary>
			public Color SelectedColor {
				get { return selectedColor; }
				set {
					selectedColor = value;
					colors.SelectedColor = value;
				}
			}

			/// <summary>
			/// Set whether the control is in extended color mode or normal mode
			/// </summary>
			public Boolean Extended {
				set { colors.ExtendedColors = value; }
				get { return colors.ExtendedColors; }
			}

			public Boolean MoreColorButton {
				set { colors.MoreColorButton = value; }
				get { return colors.MoreColorButton; }
			}

			public int ColorsPerRow {
				set { colors.ColorsPerRow = value; }
				get { return colors.ColorsPerRow; }
			}

			public Color[] Colors {
				set { colors.Colors = value; }
				get { return colors.Colors; }
			}

			#region constructor
			public ColorComboButton()
				: this( false, Color.Black ) {
			}

			public ColorComboButton( Boolean extended, Color selectedColor ) {
				this.SuspendLayout();
				// 
				// ColorCombo
				// 
				this.Appearance = System.Windows.Forms.Appearance.Button;
				this.AutoSize = false;
				this.Size = new Size( 103, 23 );
				this.Text = "";
				this.Paint += new System.Windows.Forms.PaintEventHandler( this.ColorCombo_Paint );
				this.Click += new System.EventHandler( this.ColorCombo_Click );

				timer.Tick += new EventHandler( OnCheckStatus );
				timer.Interval = 30;
				timer.Start();
				colors.ExtendedColors = extended;
				colors.SelectedColor = this.selectedColor = selectedColor;
				this.ResumeLayout( false );
			}
			#endregion

			#region Methods
			private void ColorCombo_Click( object sender, EventArgs e ) {
				if( !this.Checked )
					return;

				//create a popup window
				popupWnd = new PopupWindow( colors );

				//calculate its position in screen coordinates
				Rectangle rect = Bounds;
				rect = this.Parent.RectangleToScreen( rect );
				Point pt = new System.Drawing.Point( rect.Left, rect.Bottom );

				//tell it that we want the ColorChanged event
				popupWnd.ColorChanged += new ColorChangedHandler( OnColorChanged );

				//show the popup
				popupWnd.Show( pt );
				//disable the button so that the user can't click it
				//while the popup is being displayed
				this.Enabled = false;
			}

			protected void OnColorChanged( object sender, ColorChangeArgs e ) {
				//if a someone wants the event, and the color has actually changed
				//call the event handler
				if( ColorChanged != null && e.color != this.selectedColor ) {
					this.selectedColor = e.color;
					ColorChanged( this, e );
				} else {
					this.selectedColor = e.color;
				}
			}

			//paint the button
			private void ColorCombo_Paint( object sender, PaintEventArgs e ) {
				Rectangle rect = new Rectangle( ( ClientRectangle.Right ) - 18, ClientRectangle.Top, 18, ClientRectangle.Height );
				DrawArrow( e.Graphics, rect );
				Rectangle colorRect = new Rectangle( ClientRectangle.Left + 5, ClientRectangle.Top + 5, ClientRectangle.Width - 21, ClientRectangle.Height - 11 );
				DrawColor( e.Graphics, colorRect, selectedColor );
			}

			//draw the drop down arrow on the right side of the button
			private void DrawArrow( Graphics dc, Rectangle rect ) {
				Point[] ptsArrow = new Point[ 3 ];

				int x = rect.Left + ( rect.Right - rect.Left ) / 2;
				int y = rect.Top + ( rect.Bottom - rect.Top ) / 2;

				ptsArrow[ 0 ].X = x - 4;
				ptsArrow[ 0 ].Y = y - 2;
				ptsArrow[ 1 ].X = x + 4;
				ptsArrow[ 1 ].Y = y - 2;
				ptsArrow[ 2 ].X = x;
				ptsArrow[ 2 ].Y = y + 2;

				SolidBrush brush = new SolidBrush( Color.FromArgb( this.Enabled ? 255 : 100, Color.Black ) );

				dc.FillPolygon( brush, ptsArrow );
			}

			//draw the rectangle in the middle of the button showing the selected color
			private void DrawColor( Graphics dc, Rectangle rect, Color color ) {
				SolidBrush brush = new SolidBrush( Color.FromArgb( 255, color ) );
				dc.FillRectangle( brush, rect );
				Pen blackPen = new Pen( Color.Black );
				dc.DrawRectangle( blackPen, rect );
			}

			//This is the timer call back function.  It checks to see 
			//if the popup went from a visible state to an close state
			//if so then it will uncheck and enable the button
			private void OnCheckStatus( Object myObject, EventArgs myEventArgs ) {
				if( popupWnd != null && !popupWnd.Visible ) {
					this.Checked = false;
					this.Enabled = true;
				}
			}
			#endregion
		}

		#endregion

		#region Properties
		[Category( "Behavior" )]
		[Description( "Set or get the selected color" )]
		[Browsable( true )]
		public Color SelectedColor {
			get { return button.SelectedColor; }
			set { button.SelectedColor = value; }
		}

		[Category( "Behavior" )]
		[Description( "Set whether the control is in extended color mode or normal mode" )]
		[DefaultValue( false )]
		[Browsable( true )]
		public Boolean ExtendedColors {
			set { button.Extended = value; }
			get { return button.Extended; }
		}

		[Category( "Behavior" )]
		[Description( "Set whether the control should using the more Colors Button" )]
		[DefaultValue( false )]
		[Browsable( true )]
		public Boolean MoreColorButton {
			set { button.MoreColorButton = value; }
			get { return button.MoreColorButton; }
		}

		[Category( "Behavior" )]
		[Description( "Set the Color count per Row" )]
		[DefaultValue( 4 )]
		[Browsable( true )]
		public int ColorsPerRow {
			set { button.ColorsPerRow = value; }
			get { return button.ColorsPerRow; }
		}

		public Color[] Colors {
			set { button.Colors = value; }
			get { return button.Colors; }
		}
		#endregion

		/// <summary>
		/// color change event handler
		/// </summary>
		public event ColorChangedHandler ColorChanged;

		public ColorBox() {
			InitializeComponent();
			//setup event handler to catch the ColorChanged message from the 
			//color popup 
			button.ColorChanged += new ColorChangedHandler( button_ColorChanged );
		}

		public void button_ColorChanged( object sender, ColorChangeArgs e ) {
			if( ColorChanged != null ) {
				ColorChanged( this, e );
			}
		}

		private void ColorComboBox_SizeChanged( object sender, EventArgs e ) {
			button.Location = new Point( 0, 0 );
			button.Size = this.Size;
		}
	}

	#region EventArgs and delegate
	//define the color changed event argument
	public class ColorChangeArgs : System.EventArgs {
		public ColorChangeArgs( Color color ) {
			this.color = color;
		}
		//the selected color
		public Color color;
	}
	//event handler delegate
	public delegate void ColorChangedHandler( object sender, ColorChangeArgs e );
	#endregion


}
