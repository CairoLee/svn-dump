using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace Ragnarok3D.Editor {
	class XMLReader {
		XmlDocument xmlDoc;
		XmlElement rootNode;

		public XMLReader() {
		}

		public void CreateDocument() {
			xmlDoc = new XmlDocument();
			XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration( "1.0", "utf-8", null );
			xmlDoc.InsertBefore( xmlDeclaration, xmlDoc.DocumentElement );
		}

		public void SetRoot( string root ) {
			// Create the root element
			rootNode = xmlDoc.CreateElement( root );
			xmlDoc.AppendChild( rootNode );

			// Set attribute name and value!
			rootNode.SetAttribute( "ID", "01" );
		}

		public void Open( string file ) {
			if( File.Exists( file ) ) {
				if( xmlDoc == null )
					CreateDocument();
				xmlDoc.Load( file );
			} else
				Console.WriteLine( "File not found (" + file + ")." );
		}

		public void Save( string file ) {
			xmlDoc.Save( file );
		}

		public string GetElementValue( string name ) {
			try {
				string data = xmlDoc.DocumentElement[ name ].InnerText.Trim().Replace( "\r\n", "" ).Replace( "\t", "" );
				return data;
			} catch {
				Console.WriteLine( "Could not find element: " + name );
				return string.Empty;
			}
		}

		public void AddElement( string name, string value ) {
			XmlElement elementNode = xmlDoc.CreateElement( name );
			rootNode.AppendChild( elementNode );

			XmlText elementValue = xmlDoc.CreateTextNode( value );
			elementNode.AppendChild( elementValue );
		}
	}
}
