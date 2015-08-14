using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace eA_Script_VarParser {

	public class ScriptParser {
		public const string REGEX_B_OPEN = "[ ]*[(]?[ ]*";
		public const string REGEX_B_CLOSE = "[ ]*[)]?[ ]*";
		public const string REGEX_KOMMA = "[ ]*,[ ]*";
		public const string REGEX_MESSAGE = "mes" + REGEX_B_OPEN + "\"([^\"]*)\"" + REGEX_B_CLOSE;
		public const string REGEX_ANNOUNCE = "announce" + REGEX_B_OPEN + "\"([^\"]*)\"" + REGEX_KOMMA + "[^\n]*" + REGEX_B_CLOSE;
		public const string REGEX_MAPANNOUNCE = "mapannounce" + REGEX_B_OPEN + "\"[^\"]*\"" + REGEX_KOMMA + "\"([^\"]*)\"" + REGEX_KOMMA + "[^\n]*" + REGEX_B_CLOSE;

		private string mScriptpath;

		private ParserLine[] mLines;
		private Dictionary<int, ScriptMessage> mDuplicates;

		public string Scriptpath {
			get { return mScriptpath; }
			set { mScriptpath = value; }
		}

		public ParserLine[] Lines {
			get { return mLines; }
			set { mLines = value; }
		}

		public string NpcName {
			get;
			set;
		}

		public ScriptMessageCollection Messages {
			get;
			set;
		}

		public Dictionary<int, ScriptMessage> Duplicates {
			get { return mDuplicates; }
		}


		public ScriptParser() {
			Messages = new ScriptMessageCollection();
			mDuplicates = new Dictionary<int, ScriptMessage>();
		}


		public void Parse() {

			for( int i = 0; i < mLines.Length; i++ ) {
				string Line = mLines[ i ].Line.Trim().Replace( "\\\"", "'" ); // mes "123 \"bla\" blubb";
				if( Line.Length == 0 )
					continue;

				string dup = Line.ToLower().Trim();
				string npcMessage = "";
				string constName = "";
				Match m;
				if( dup.Contains( "mes" ) == true )
					m = Regex.Match( Line, ScriptParser.REGEX_MESSAGE + ";", RegexOptions.IgnoreCase );
				else if( dup.Contains( "mapannounce" ) == true )
					m = Regex.Match( Line, ScriptParser.REGEX_MAPANNOUNCE + ";", RegexOptions.IgnoreCase );
				else if( dup.Contains( "announce" ) == true )
					m = Regex.Match( Line, ScriptParser.REGEX_ANNOUNCE + ";", RegexOptions.IgnoreCase );
				else
					continue;

				if( m.Success == false )
					continue;
				if( m.Groups.Count < 2 )
					continue;
				if( m.Groups[ 1 ].Captures.Count == 0 )
					continue;

				npcMessage = m.Groups[ 1 ].Captures[ 0 ].Value;
				if( npcMessage.Trim().Length == 0 ) // empty mes, no need to Translate 
					continue;
				constName = "";
				if( BuildNameKey( npcMessage, out constName ) == false )
					continue;

				ScriptMessage msg = new ScriptMessage( mLines[ i ].Index, npcMessage, constName );
				if( Messages.ContainsKey( msg.Constant ) == true ) {
					mDuplicates.Add( mLines[ i ].Index, Messages[ msg.Constant ] );
					continue;
				}
				Messages.Add( constName, msg );
			}

		}





		public static bool BuildNameKey( string Text, out string Const ) {
			Const = "";
			Text = Text.ToLower();
			for( int i = 0; i < Text.Length; i++ ) {
				if( Text[ i ] == ' ' || Text[ i ] == '[' || Text[ i ] == ']' )
					Const += "_";
				else if( ( Text[ i ] >= 'a' && Text[ i ] <= 'z' ) || ( Text[ i ] >= '0' && Text[ i ] <= '9' ) )
					Const += Text[ i ];
			}

			if( Const.Length == 0 )
				return false; // no text to translate i think..

			//if( Const.Length > 25 )
			//	Const = Const.Substring( 0, 25 );

			if( Const.Length < 3 )
				Const = "SHORT_STRING_" + Const;

			Const = "__L_" + Const.ToUpper();
			return true;
		}

	}

}
