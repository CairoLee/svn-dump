using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SpriteRename {

	public class Program {
		const string Folder_M = @"D:\Desktop\insane_sprite\data\sprite\ÀÎ°£Á·\¸öÅë\³²\";
		const string Folder_F = @"D:\Desktop\insane_sprite\data\sprite\ÀÎ°£Á·\¸öÅë\¿©\";
		const string Folder_New = @"D:\Desktop\insane_sprite\new_sprite\";
		private static List<string> mFiles_M = new List<string>();
		private static List<string> mFiles_F = new List<string>();
		private static Dictionary<int, string> mNames = new Dictionary<int, string>();

		public static void Main( string[] args ) {
			mNames.Add( 0, "ÃÊº¸ÀÚ" ); // Job_Novice
			mNames.Add( 1, "°Ë»ç" ); // Job_Swordman
			mNames.Add( 2, "¸¶¹ý»ç" ); // Job_Mage
			mNames.Add( 3, "±Ã¼ö" ); // Job_Archer
			mNames.Add( 4, "¼ºÁ÷ÀÚ" ); // Job_Acolyte
			mNames.Add( 5, "»óÀÎ" ); // Job_Merchant
			mNames.Add( 6, "µµµÏ" ); // Job_Thief
			mNames.Add( 7, "±â»ç" ); // Job_Knight
			mNames.Add( 8, "ÇÁ¸®½ºÆ®" ); // Job_Priest
			mNames.Add( 9, "À§Àúµå" ); // Job_Wizard
			mNames.Add( 10, "Á¦Ã¶°ø" ); // Job_Blacksmith
			mNames.Add( 11, "±â»ç" ); // Job_Hunter
			mNames.Add( 12, "¾î¼¼½Å" ); // Job_Assassin
			mNames.Add( 13, "ÆäÄÚÆäÄÚ_±â»ç" ); // Job_Knight2
			mNames.Add( 14, "Å©·ç¼¼ÀÌ´õ" ); // Job_Crusader
			mNames.Add( 15, "¸ùÅ©" ); // Job_Monk
			mNames.Add( 16, "¼¼ÀÌÁö" ); // Job_Sage
			mNames.Add( 17, "·Î±×" ); // Job_Rogue
			mNames.Add( 18, "¿¬±Ý¼ú»ç" ); // Job_Alchemist
			mNames.Add( 19, "¹Ùµå" ); // Job_Bard
			mNames.Add( 20, "¹«Èñ" ); // Job_Dancer
			mNames.Add( 21, "½ÅÆäÄÚÅ©·ç¼¼ÀÌ´õ" ); // Job_Crusader2
			mNames.Add( 22, "°áÈ¥" ); // Job_Wedding
			mNames.Add( 23, "½´ÆÛ³ëºñ½º" ); // Job_SuperNovice
			mNames.Add( 24, "°Ç³Ê" ); // Job_Gunslinger
			mNames.Add( 25, "´ÑÀÚ" ); // Job_Ninja
			mNames.Add( 26, "»êÅ¸" ); // Job_Xmas

			mNames.Add( 4001, "ÃÊº¸ÀÚ" ); // Job_Novice_High
			mNames.Add( 4002, "°Ë»ç" ); // Job_Swordman_High
			mNames.Add( 4003, "¸¶¹ý»ç" ); // Job_Mage_High
			mNames.Add( 4004, "±Ã¼ö" ); // Job_Archer_High
			mNames.Add( 4005, "¼ºÁ÷ÀÚ" ); // Job_Acolyte_High
			mNames.Add( 4006, "»óÀÎ" ); // Job_Merchant_High
			mNames.Add( 4007, "µµµÏ" ); // Job_Thief_High
			mNames.Add( 4008, "·Îµå³ªÀÌÆ®" ); // Job_Lord_Knight
			mNames.Add( 4009, "ÇÏÀÌÇÁ¸®" ); // Job_High_Priest
			mNames.Add( 4010, "ÇÏÀÌÀ§Àúµå" ); // Job_High_Wizard
			mNames.Add( 4011, "È­ÀÌÆ®½º¹Ì½º" ); // Job_Whitesmith
			mNames.Add( 4012, "½º³ªÀÌÆÛ" ); // Job_Sniper
			mNames.Add( 4013, "¾î½Ø½ÅÅ©·Î½º" ); // Job_Assassin_Cross
			mNames.Add( 4014, "·ÎµåÆäÄÚ" ); // Job_Lord_Knight2
			mNames.Add( 4015, "ÆÈ¶óµò" ); // Job_Paladin
			mNames.Add( 4016, "Ã¨ÇÇ¿Â" ); // Job_Champion
			mNames.Add( 4017, "ÇÁ·ÎÆä¼­" ); // Job_Professor
			mNames.Add( 4018, "½ºÅäÄ¿" ); // Job_Stalker
			mNames.Add( 4019, "Å©¸®¿¡ÀÌÅÍ" ); // Job_Creator
			mNames.Add( 4020, "Å¬¶ó¿î" ); // Job_Clown
			mNames.Add( 4021, "Áý½Ã" ); // Job_Gypsy
			mNames.Add( 4022, "ÆäÄÚÆÈ¶óµò" ); // Job_Paladin2

			mNames.Add( 4023, "ÃÊº¸ÀÚ" ); // Job_Baby
			mNames.Add( 4024, "°Ë»ç" ); // Job_Baby_Swordman
			mNames.Add( 4025, "¸¶¹ý»ç" ); // Job_Baby_Mage
			mNames.Add( 4026, "±Ã¼ö" ); // Job_Baby_Archer
			mNames.Add( 4027, "¼ºÁ÷ÀÚ" ); // Job_Baby_Acolyte
			mNames.Add( 4028, "»óÀÎ" ); // Job_Baby_Merchant
			mNames.Add( 4029, "µµµÏ" ); // Job_Baby_Thief
			mNames.Add( 4030, "±â»ç" ); // Job_Baby_Knight
			mNames.Add( 4031, "ÇÁ¸®½ºÆ®" ); // Job_Baby_Priest
			mNames.Add( 4032, "À§Àúµå" ); // Job_Baby_Wizard
			mNames.Add( 4033, "Á¦Ã¶°ø" ); // Job_Baby_Blacksmith
			mNames.Add( 4034, "±â»ç" ); // Job_Baby_Hunter
			mNames.Add( 4035, "¾î¼¼½Å" ); // Job_Baby_Assassin
			mNames.Add( 4036, "ÆäÄÚÆäÄÚ_±â»ç" ); // Job_Baby_Knight2
			mNames.Add( 4037, "Å©·ç¼¼ÀÌ´õ" ); // Job_Baby_Crusader
			mNames.Add( 4038, "¸ùÅ©" ); // Job_Baby_Monk
			mNames.Add( 4039, "¼¼ÀÌÁö" ); // Job_Baby_Sage
			mNames.Add( 4040, "·Î±×" ); // Job_Baby_Rogue
			mNames.Add( 4041, "¿¬±Ý¼ú»ç" ); // Job_Baby_Alchemist
			mNames.Add( 4042, "¹Ùµå" ); // Job_Baby_Bard
			mNames.Add( 4043, "¹«Èñ" ); // Job_Baby_Dancer
			mNames.Add( 4044, "½ÅÆäÄÚÅ©·ç¼¼ÀÌ´õ" ); // Job_Baby_Crusader2
			mNames.Add( 4045, "½´ÆÛ³ëºñ½º" ); // Job_Super_Baby

			mNames.Add( 4046, "ÅÂ±Ç¼Ò³â" ); // Job_Taekwon
			mNames.Add( 4047, "±Ç¼º" ); // Job_Star_Gladiator
			mNames.Add( 4048, "±Ç¼ºÀ¶ÇÕ" ); // Job_Star_Gladiator2
			mNames.Add( 4049, "¼Ò¿ï¸µÄ¿" ); // Job_Soul_Linker

			mNames.Add( 9999, "¿î¿µÀÚ" ); // GM


			CacheFiles();


			foreach( int JobID in mNames.Keys ) {

				string filename_M = mNames[ JobID ] + "_³²";
				string filename_F = mNames[ JobID ] + "_¿©";


				TryRename( mFiles_M, Folder_M, 'm', filename_M, JobID );
				TryRename( mFiles_F, Folder_F, 'f', filename_F, JobID );
			}

			Console.Read();

		}


		private static void TryRename( List<string> List, string TargetFolder, char Sex, string filename, int JobID ) {
			int index = List.IndexOf( filename );
			if( index == -1 ) {
				Console.WriteLine( "Sprite[" + new String( Sex, 1 ).ToUpper() + "] \"" + filename + "\" not found (ID " + JobID + ")" );
				return;
			}

			File.Copy( TargetFolder + List[ index ] + ".spr", Folder_New + JobID + "_" + Sex + ".spr" );
			File.Copy( TargetFolder + List[ index ] + ".act", Folder_New + JobID + "_" + Sex + ".act" );
		}



		private static void CacheFiles() {
			mFiles_M.AddRange( Directory.GetFiles( Folder_M, "*.spr" ) );
			mFiles_F.AddRange( Directory.GetFiles( Folder_F, "*.spr" ) );

			for( int i = 0; i < mFiles_M.Count; i++ ) {
				mFiles_M[ i ] = mFiles_M[ i ].Replace( Folder_M, "" ).Replace( ".spr", "" );
			}
			for( int i = 0; i < mFiles_F.Count; i++ ) {
				mFiles_F[ i ] = mFiles_F[ i ].Replace( Folder_F, "" ).Replace( ".spr", "" );
			}
		}

	}

}
