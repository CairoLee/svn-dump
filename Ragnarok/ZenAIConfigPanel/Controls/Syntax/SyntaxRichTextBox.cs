using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Moonlight {
	public partial class SyntaxRichTextBox : RichTextBox {
		private const int WM_COPY = 0x301;
		private const int WM_CUT = 0x300;
		private const int WM_PASTE = 0x302;
		private const int WM_CLEAR = 0x303;
		private const int WM_UNDO = 0x304;
		private const int EM_UNDO = 0xC7;
		private const int EM_CANUNDO = 0xC6;
		private const int WM_PAINT = 0x000F;
		private const int WM_CHAR = 0x102;

		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool PostMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);


		private SyntaxHighlighter mSyntaxHighLighter = new SyntaxHighlighter();

		private bool mEnablePainting = true;

		private List<string> mCodeWordsKeywords;
		private List<string> mCodeWordsTypes;
		private List<string> mCodeWordsFunctions;
		private List<string> mCodeWordsComments;
		private List<string> mCodeWordsScopeOperators;

		private Color mCodeColorKeyword = Color.Blue;
		private Color mCodeColorType = Color.CornflowerBlue;
		private Color mCodeColorFunction = Color.CornflowerBlue;
		private Color mCodeColorComment = Color.Green;
		private Color mCodeColorPlainText = Color.Black;

		/// <summary>
		/// Gets or Sets the keywords used for syntax highlightning and intellisense.
		/// </summary>
		[Browsable(true), Category("CodeTexbox"), Description("Gets or Sets the keywords used for syntax highlightning and intellisense.")]
		[Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
		public List<string> CodeWordsKeywords {
			get { return mCodeWordsKeywords; }
			set { mCodeWordsKeywords = value; }
		}

		/// <summary>
		/// Gets or Sets the types used for syntax highlightning and intellisense.
		/// </summary>
		[Browsable(true), Category("CodeTexbox"), Description("Gets or Sets the types used for syntax highlightning and intellisense.")]
		[Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
		public List<string> CodeWordsTypes {
			get { return mCodeWordsTypes; }
			set { mCodeWordsTypes = value; }
		}

		/// <summary>
		/// Gets or Sets the functions used for syntax highlightning and intellisense.
		/// </summary>
		[Browsable(true), Category("CodeTexbox"), Description("Gets or Sets the functions used for syntax highlightning and intellisense.")]
		[Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
		public List<string> CodeWordsFunctions {
			get { return mCodeWordsFunctions; }
			set { mCodeWordsFunctions = value; }
		}

		/// <summary>
		/// Gets or Sets the comment strings used for syntax highlightning.
		/// </summary>
		[Browsable(true), Category("CodeTexbox"), Description("Gets or Sets the comment strings used for syntax highlightning.")]
		[Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
		public List<string> CodeWordsComments {
			get { return mCodeWordsComments; }
			set { mCodeWordsComments = value; }
		}

		/// <summary>
		/// Gets or Sets the object separator strings used for intellisense.
		/// </summary>
		[Browsable(true), Category("CodeTexbox"), Description("Gets or Sets the object separator strings used for intellisense.")]
		[Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
		public List<string> CodeWordsScopeOperators {
			get { return mCodeWordsScopeOperators; }
			set { mCodeWordsScopeOperators = value; }
		}


		/// <summary>
		/// Gets or Sets the color of plain texts for syntax highlightning.
		/// </summary>
		[Browsable(true), Category("CodeTexbox"), Description("Gets or Sets the color of plain texts for syntax highlightning.")]
		public Color CodeColorPlainText {
			get { return mCodeColorPlainText; }
			set { mCodeColorPlainText = value; }
		}

		/// <summary>
		/// Gets or Sets the color of keywords for syntax highlightning.
		/// </summary>
		[Browsable(true), Category("CodeTexbox"), Description("Gets or Sets the color of keywords for syntax highlightning.")]
		public Color CodeColorKeyword {
			get { return mCodeColorKeyword; }
			set { mCodeColorKeyword = value; }
		}

		/// <summary>
		/// Gets or Sets the color of types for syntax highlightning.
		/// </summary>
		[Browsable(true), Category("CodeTexbox"), Description("Gets or Sets the color of types for syntax highlightning.")]
		public Color CodeColorType {
			get { return mCodeColorType; }
			set { mCodeColorType = value; }
		}

		/// <summary>
		/// Gets or Sets the color of functions for syntax highlightning.
		/// </summary>
		[Browsable(true), Category("CodeTexbox"), Description("Gets or Sets the color of functions for syntax highlightning.")]
		public Color CodeColorFunction {
			get { return mCodeColorFunction; }
			set { mCodeColorFunction = value; }
		}

		/// <summary>
		/// Gets or Sets the color of comments for syntax highlightning.
		/// </summary>
		[Browsable(true), Category("CodeTexbox"), Description("Gets or Sets the color of comments for syntax highlightning.")]
		public Color CodeColorComment {
			get { return mCodeColorComment; }
			set { mCodeColorComment = value; }
		}


		/// <summary>
		/// Enables or disables the control's paint event.
		/// </summary>
		internal bool EnablePainting {
			get { return mEnablePainting; }
			set { mEnablePainting = value; }
		}


		public SyntaxRichTextBox() {
			InitializeComponent();

			AcceptsTab = true;
			Font = new Font(FontFamily.GenericMonospace, 9f);

			EnableAutoDragDrop = false;
			DetectUrls = false;
			WordWrap = false;
			AutoWordSelection = true;

			mCodeWordsKeywords = new List<string>();
			mCodeWordsTypes = new List<string>();
			mCodeWordsFunctions = new List<string>();
			mCodeWordsComments = new List<string>();
			mCodeWordsScopeOperators = new List<string>();
		}


		public void UpdateSyntaxHightlight() {
			mSyntaxHighLighter.Update(this);
			mSyntaxHighLighter.DoSyntaxHightlightAllLines(this);
		}


		protected override void OnPaint(PaintEventArgs pe) {
			if (EnablePainting) {
				base.OnPaint(pe);
			}
		}

		protected override void OnTextChanged(EventArgs e) {
			mSyntaxHighLighter.DoSyntaxHightlightCurrentLine(this);

			base.OnTextChanged(e);
		}


		/// <summary>
		/// Let control enable and disable it's drawing...
		/// </summary>
		/// <param name="m"></param>
		protected override void WndProc(ref System.Windows.Forms.Message m) {
			switch (m.Msg) {
				case WM_PAINT:
					if (mEnablePainting) {
						base.WndProc(ref m);
					} else {
						m.Result = IntPtr.Zero;
					}
					break;

				case WM_PASTE:
					int selectionStart = this.SelectionStart;
					int selectionLength = 0;

					string text = Clipboard.GetText();

					#region Hack to find out correct selection length
					// Hack...
					// The text's length readed from the clipboard doesn't match the length pasted to the richTextBox
					// So I used a dummy richtextbox, to find out the correct length of the text...
					RichTextBox rtxt = new RichTextBox();
					rtxt.SelectionStart = 0;
					rtxt.SelectedText = text;
					selectionLength = rtxt.Text.Length;
					#endregion

					// Paste text from the clipboard...
					this.SelectedText = text;

					mSyntaxHighLighter.DoSyntaxHightlightSelection(this, selectionStart, selectionLength);
					break;


				default:
					base.WndProc(ref m);
					break;
			}
		}
		/// <summary>
		/// I needed this for the WM_PASTE event to fire...
		/// </summary>
		/// <param name="m"></param>
		/// <param name="keyData"></param>
		/// <returns></returns>
		protected override bool ProcessCmdKey(ref Message m, Keys keyData) {
			switch (keyData) {
				#region Paste
				case Keys.Control | Keys.V: {
						PostMessage(this.Handle, WM_PASTE, IntPtr.Zero, IntPtr.Zero);
						return true;
					}
				case Keys.Shift | Keys.Insert: {
						PostMessage(this.Handle, WM_PASTE, IntPtr.Zero, IntPtr.Zero);
						return true;
					}
				#endregion

				#region Copy
				case Keys.Control | Keys.C: {
						PostMessage(this.Handle, WM_COPY, IntPtr.Zero, IntPtr.Zero);
						return true;
					}
				case Keys.Control | Keys.Insert: {
						PostMessage(this.Handle, WM_COPY, IntPtr.Zero, IntPtr.Zero);
						return true;
					}
				#endregion

				#region Cut
				case Keys.Control | Keys.X: {
						PostMessage(this.Handle, WM_CUT, IntPtr.Zero, IntPtr.Zero);
						return true;
					}
				case Keys.Shift | Keys.Delete: {
						PostMessage(this.Handle, WM_CUT, IntPtr.Zero, IntPtr.Zero);
						return true;
					}
				#endregion

				#region Delete
				case Keys.Control | Keys.Delete: {
						PostMessage(this.Handle, WM_CLEAR, IntPtr.Zero, IntPtr.Zero);
						return true;
					}
				#endregion

				#region Undo
				case Keys.Control | Keys.Z: {
						PostMessage(this.Handle, WM_UNDO, IntPtr.Zero, IntPtr.Zero);
						return true;
					}
				#endregion

				default:
					return base.ProcessCmdKey(ref m, keyData);
			}
		}

	}

}
