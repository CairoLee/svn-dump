using System;

namespace GodLesZ.eAthenaEditor.Library.Gui.CompletionWindow {

	public interface ICompletionData {
		int ImageIndex {
			get;
		}

		string Text {
			get;
			set;
		}

		string Description {
			get;
		}

		/// <summary>
		/// Gets a priority value for the completion data item.
		/// When selecting items by their start characters, the item with the highest
		/// priority is selected first.
		/// </summary>
		double Priority {
			get;
		}

		/// <summary>
		/// Insert the element represented by the completion data into the text
		/// editor.
		/// </summary>
		/// <param name="textArea">TextArea to insert the completion data in.</param>
		/// <param name="ch">Character that should be inserted after the completion data.
		/// \0 when no character should be inserted.</param>
		/// <returns>Returns true when the insert action has processed the character
		/// <paramref name="ch"/>; false when the character was not processed.</returns>
		bool InsertAction(TextArea textArea, char ch);
	}

	public class DefaultCompletionData : ICompletionData {
		private string mText;
		private string description;
		private int imageIndex;
		private double priority;

		public int ImageIndex {
			get { return imageIndex; }
		}

		public string Text {
			get { return mText; }
			set { mText = value; }
		}

		public string Description {
			get { return description; }
		}


		public double Priority {
			get { return priority; }
			set { priority = value; }
		}


		public DefaultCompletionData(string text, string description, int imageIndex) {
			this.mText = text;
			this.description = description;
			this.imageIndex = imageIndex;
		}

		public virtual bool InsertAction(TextArea textArea, char ch) {
			textArea.InsertString(mText);
			return false;
		}


		public static int Compare(ICompletionData a, ICompletionData b) {
			if (a == null)
				throw new ArgumentNullException("a");
			if (b == null)
				throw new ArgumentNullException("b");
			return string.Compare(a.Text, b.Text, StringComparison.InvariantCultureIgnoreCase);
		}

	}

}
