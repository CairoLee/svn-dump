using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

namespace MarketTool.Library {

	public class TemplateBuilder {
		public static string DirBase = "";
		public static string DirWeapon = @"Weapon\";
		public static string DirArmor = @"Armor\";
		public static string DirLapis = @"Lapis\";
		public static string DirApItem = @"ApItem\";
		public static string DirEtc = @"Etc\";

		private static XmlSerializer mXml = new XmlSerializer( typeof( ITemplate ) );
		private static Dictionary<string, ITemplate> mCache = new Dictionary<string, ITemplate>();
		private static bool mInitialized = false;


		public TemplateBuilder() {
		}


		public static ITemplate GetTemplate( string Keyname ) {
			if( mCache.ContainsKey( Keyname ) == false )
				return null;
			return mCache[ Keyname ];
		}


		public static void SaveTemplate( ITemplate Template, EItemType Type ) {
			string filePath = GetTemplatePath( Type, Template ) + ".tpl";

			if( File.Exists( filePath ) )
				File.Delete( filePath );
			using( FileStream fs = File.OpenWrite( filePath ) )
				mXml.Serialize( fs, Template );
		}

		public static void LoadTemplates( EventHandler OnClick, OnAddItemHandler OnAdd, ToolStripMenuItem Weapon, ToolStripMenuItem Armor, ToolStripMenuItem Lapi, ToolStripMenuItem APItem, ToolStripMenuItem ETCItem ) {
			LoadTemplates( DirWeapon, Weapon, OnClick, OnAdd );
			LoadTemplates( DirArmor, Armor, OnClick, OnAdd );
			LoadTemplates( DirLapis, Lapi, OnClick, OnAdd );
			LoadTemplates( DirApItem, APItem, OnClick, OnAdd );
			LoadTemplates( DirEtc, ETCItem, OnClick, OnAdd );
		}

		public static void LoadTemplates( string DirPath, ToolStripMenuItem Menu, EventHandler OnClick, OnAddItemHandler OnAdd ) {
			List<string> files = new List<string>( Directory.GetFiles( DirPath, "*.tpl" ) );
			ITemplate tpl;

			files.Sort();
			Menu.DropDownItems.Clear();
			for( int i = 0; i < files.Count; i++ ) {
				string fileName = Path.GetFileNameWithoutExtension( files[ i ] );
				using( FileStream fs = File.OpenRead( files[ i ] ) )
					tpl = (ITemplate)mXml.Deserialize( fs );

				if( tpl == null ) {
					// Error Message?
					continue;
				}

				CacheTemplate( tpl );

				ToolStripMenuItem item = BuildMenuItem( fileName, tpl, OnClick );
				if( OnAdd != null ) 
					item = OnAdd( tpl, item );

				Menu.DropDownItems.Add( item );
			}

		}

		#region Initialize
		public static void Initialize() {
			if( mInitialized == true )
				return;
			mInitialized = true;
			DirBase = AppDomain.CurrentDomain.BaseDirectory + @"\Templates\";
			DirWeapon = DirBase + DirWeapon;
			DirArmor = DirBase + DirArmor;
			DirLapis = DirBase + DirLapis;
			DirApItem = DirBase + DirApItem;
			DirEtc = DirBase + DirEtc;

			EnsureDirectorys();
		}

		private static void EnsureDirectorys() {
			Directory.CreateDirectory( DirBase );
			Directory.CreateDirectory( DirWeapon );
			Directory.CreateDirectory( DirArmor );
			Directory.CreateDirectory( DirLapis );
			Directory.CreateDirectory( DirApItem );
			Directory.CreateDirectory( DirEtc );
		}
		#endregion


		#region Helper
		private static ToolStripMenuItem BuildMenuItem( string Filename, ITemplate tpl, EventHandler OnClick ) {
			ToolStripMenuItem item = new ToolStripMenuItem();
			item.Text = tpl.ToName();
			item.AutoSize = true;
			item.Tag = tpl.ToFilename(); // to fetch it later back from Cache, saved with ToFilename()
			item.Click += OnClick;

			return item;
		}

		private static string GetTemplatePath( EItemType Type, ITemplate Template ) {
			string path = "";
			switch( Type ) {
				default:
					throw new Exception( "Unknown EItemType! Can't setup TemplatePath" );

				case EItemType.Waffe:
					path = DirWeapon;
					break;
				case EItemType.Rüstung:
					path = DirArmor;
					break;
				case EItemType.Lapis:
					path = DirLapis;
					break;
				case EItemType.APItem:
					path = DirApItem;
					break;
				case EItemType.EtcItem:
					path = DirEtc;
					break;
			}

			path += Template.ToFilename();
			return path;
		}

		private static void CacheTemplate( ITemplate tpl ) {
			string key = tpl.ToFilename();
			if( mCache.ContainsKey( key ) == true ) {
				mCache[ key ] = tpl;
				return;
			}
			mCache.Add( key, tpl );
		}
		#endregion

	}


	public delegate ToolStripMenuItem OnAddItemHandler( ITemplate Template, ToolStripMenuItem Item );

}
