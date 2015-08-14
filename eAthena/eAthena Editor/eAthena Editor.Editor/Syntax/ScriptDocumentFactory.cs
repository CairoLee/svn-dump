using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GodLesZ.eAthenaEditor.Library.Document;

namespace GodLesZ.eAthenaEditor.Editor.Syntax {

	class ScriptDocumentFactory {

		/// <remarks>
		/// Creates a new <see cref="IDocument"/> object. Only create
		/// <see cref="IDocument"/> with this method.
		/// </remarks>
		public IDocument CreateDocument() {
			ScriptDocument doc = new ScriptDocument();
			doc.TextBufferStrategy = new GapTextBufferStrategy();
			doc.FormattingStrategy = new ScriptFormattingStrategy();
			doc.LineManager = new LineManager(doc, null);
			doc.FoldingManager = new FoldingManager(doc, doc.LineManager);
			doc.FoldingManager.FoldingStrategy = null; //new ParserFoldingStrategy();
			doc.MarkerStrategy = new MarkerStrategy(doc);
			doc.BookmarkManager = new BookmarkManager(doc, doc.LineManager);
			doc.FunctionMarkerManager = new ScriptEntityManager();
			return doc;
		}

		/// <summary>
		/// Creates a new document and loads the given file
		/// </summary>
		public IDocument CreateFromTextBuffer(ITextBufferStrategy textBuffer) {
			ScriptDocument doc = (ScriptDocument)CreateDocument();
			doc.TextContent = textBuffer.GetText(0, textBuffer.Length);
			doc.TextBufferStrategy = textBuffer;
			return doc;
		}

		/// <summary>
		/// Creates a new document and loads the given file
		/// </summary>
		public IDocument CreateFromFile(string fileName) {
			IDocument document = CreateDocument();
			document.TextContent = GodLesZ.eAthenaEditor.Library.Util.FileReader.ReadFileContent(fileName, Encoding.Default);
			return document;
		}

	}

}
