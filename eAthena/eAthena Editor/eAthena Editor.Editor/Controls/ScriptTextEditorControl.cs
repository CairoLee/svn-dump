using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GodLesZ.eAthenaEditor.Library;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.ComponentModel;
using GodLesZ.eAthenaEditor.Library.Document;
using GodLesZ.eAthenaEditor.Editor.Syntax;

namespace GodLesZ.eAthenaEditor.Editor.Controls {

	public class ScriptTextEditorControl : TextEditorControl {

		public ScriptTextEditorControl()
			: base() {

			Document.UpdateCommited -= base.CommitUpdateRequested;
			Controls.Remove(textAreaPanel);
			textAreaPanel.Controls.Remove(primaryTextArea);
			
			Document = (new ScriptDocumentFactory()).CreateDocument();
			Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("eAthena");
			Document.UpdateCommited += new EventHandler(Document_CommitUpdateRequested);


			primaryTextArea = new TextAreaControl(this);
			activeTextAreaControl = primaryTextArea;
			primaryTextArea.TextArea.GotFocus += delegate {
				SetActiveTextAreaControl(primaryTextArea);
			};
			primaryTextArea.Dock = DockStyle.Fill;
			textAreaPanel.Controls.Add(primaryTextArea);
			InitializeTextAreaControl(primaryTextArea);
			Controls.Add(textAreaPanel);
			ResizeRedraw = true;
			OptionsChanged();
		}


		protected void Document_CommitUpdateRequested(object sender, EventArgs e) {
			if (IsInUpdate) {
				return;
			}
			foreach (TextAreaUpdate update in Document.UpdateQueue) {
				switch (update.TextAreaUpdateType) {
					case TextAreaUpdateType.PositionToEnd:
						this.primaryTextArea.TextArea.UpdateToEnd(update.Position.Y);
						if (this.secondaryTextArea != null) {
							this.secondaryTextArea.TextArea.UpdateToEnd(update.Position.Y);
						}
						break;
					case TextAreaUpdateType.PositionToLineEnd:
					case TextAreaUpdateType.SingleLine:
						this.primaryTextArea.TextArea.UpdateLine(update.Position.Y);
						if (this.secondaryTextArea != null) {
							this.secondaryTextArea.TextArea.UpdateLine(update.Position.Y);
						}
						break;
					case TextAreaUpdateType.SinglePosition:
						this.primaryTextArea.TextArea.UpdateLine(update.Position.Y, update.Position.X, update.Position.X);
						if (this.secondaryTextArea != null) {
							this.secondaryTextArea.TextArea.UpdateLine(update.Position.Y, update.Position.X, update.Position.X);
						}
						break;
					case TextAreaUpdateType.LinesBetween:
						this.primaryTextArea.TextArea.UpdateLines(update.Position.X, update.Position.Y);
						if (this.secondaryTextArea != null) {
							this.secondaryTextArea.TextArea.UpdateLines(update.Position.X, update.Position.Y);
						}
						break;
					case TextAreaUpdateType.WholeTextArea:
						this.primaryTextArea.TextArea.Invalidate();
						if (this.secondaryTextArea != null) {
							this.secondaryTextArea.TextArea.Invalidate();
						}
						break;
				}
			}

			Document.UpdateQueue.Clear();
		}


	}

}
