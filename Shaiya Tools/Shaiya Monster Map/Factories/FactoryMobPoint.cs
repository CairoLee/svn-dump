using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using FinalSoftware.MySql;
using ShaiyaMonsterMap.Structs;
using ShaiyaMonsterMap.Enumerations;
using ShaiyaMonsterMap.Forms;
using ShaiyaMonsterMap.Helper;
using System.Drawing;

namespace ShaiyaMonsterMap {

	public partial class FactoryMobPoint : FactoryMain {
		public static string MapRessource = "ShaiyaMonsterMap.Resources.maps.{0}.png";
		public SMobMapRule ActiveMapRule = SMobMapRule.GetRule( EMap.Reikeuseu );


		public FactoryMobPoint( ListView lv, PictureBox pic ) {
			ListView = lv;
			Image = pic;

			ListView.DrawSubItem += new DrawListViewSubItemEventHandler( ListView_DrawSubItem );
			ListView.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler( ListView_DrawColumnHeader );
			ListView.OwnerDraw = true;
		}


		public void LoadList( string Mapname ) {
			ClearList();

			Points = new SMobPoints( Mapname.ToEMap() );
			ActiveMapRule = SMobMapRule.GetRule( Points.Map );
			ResultTable table = Mysql.Query( "SELECT * FROM `shaiya_mob_db` WHERE mapname = '" + Mapname + "'" );
			if( table.Rows.Count == 0 )
				return;

			if( ListView != null )
				ListView.BeginUpdate();
			for( int i = 0; i < table.Rows.Count; i++ ) {
				ResultRow row = table.Rows[ i ];
				SMobPoint p = new SMobPoint();
				p.ID = row[ "id" ].GetInt();
				p.X = row[ "pos_x" ].GetInt();
				p.Y = row[ "pos_y" ].GetInt();
				p.Name = row[ "name" ].GetString();
				p.Level = row[ "level" ].GetString();
				p.Anzahl = row[ "anzahl" ].GetString();
				p.Element = row[ "element" ].GetEnum<EMobElement>();
				p.IsBoss = row[ "boss" ].GetInt() == 1;
				p.InfoDesc = row[ "info" ].GetString();

				if( p.Anzahl.IndexOf( "Boss" ) != -1 )
					p.IsBoss = true;

				AddToList( p );
			}
			if( ListView != null )
				ListView.EndUpdate();

		}

		public override void AddToList( IPoint Point ) {
			SMobPoint p = Point as SMobPoint;
			int i = Points.Count;
			Points.Add( p );

			if( ListView == null )
				return;

			ListView.Items.Add( FactoryMobPoint.BuildListItem( this, i, p ) );
		}

		public void ClearList() {
			if( ListView != null ) {
				ListView.SelectedIndices.Clear();
				ListView.Items.Clear();
			}

			Points.Clear();

			if( Image != null )
				Image.Invalidate();
		}

		#region SQL Save & Delete
		public void DeletePoint( int i ) {
			int id = Points[ i ].ID;

			Points.RemoveAt( i );
			for( int j = 0; j < ListView.Items.Count; j++ )
				if( int.Parse( ListView.Items[ j ].Tag.ToString() ) == i ) {
					ListView.Items.RemoveAt( j );
					break;
				}

			if( Image != null )
				Image.Invalidate();

			if( id < 1 ) // not added to SQL
				return;

			CreateBackup();

			Mysql.QuerySimple( "DELETE FROM `shaiya_mob_db` WHERE id = {0}", id );
		}

		public void SavePoints( bool Backup ) {
			bool backUped = false;
			// delete all?
			if( Points.Points.Count == 0 ) {
				string mName = Points.Map.ToName().MysqlEscape();
				if( CountMobsOnMap( mName ) == 0 )
					return;
				if( HelperMsg.Ask( "ACHTUNG\nAlle Monster der Map \"" + Points.Map.ToName() + "\" werden gelöscht!\n\nMöchtest du das tun?", "Alle Monster löschen?" ) != true )
					return;

				if( Backup == true )
					CreateBackup();
				Mysql.QuerySimple( "DELETE FROM `shaiya_mob_db` WHERE mapname = '{0}'", mName );
				return;
			}

			foreach( SMobPoint p in Points.Points ) {
				if( p.ID > 0 && p.Changed == false )
					continue;

				if( Backup == true && backUped == false ) {
					CreateBackup();
					backUped = true;
				}

				if( p.ID > 0 )
					Mysql.QuerySimple( "UPDATE `shaiya_mob_db` SET `pos_x` = {0}, `pos_y` = {1}, `name` = '{2}', `mapname` = '{3}', `level` = '{4}', `anzahl` = '{5}', `element` = '{6}', `boss` = {7}, `info` = '{8}' WHERE `id` = {9}", p.X, p.Y, p.Name.MysqlEscape(), Points.Map.ToName().MysqlEscape(), p.Level.MysqlEscape(), p.Anzahl.MysqlEscape(), p.Element.ToString(), ( p.IsBoss ? 1 : 0 ), p.InfoDesc.MysqlEscape(), p.ID );
				else {
					if( PointExists( p ) == false )
						Mysql.QuerySimple( "INSERT INTO `shaiya_mob_db` VALUES( NULL, {0}, {1}, '{2}', '{3}', '{4}', '{5}', '{6}', {7}, '{8}' );", p.X, p.Y, p.Name.MysqlEscape(), Points.Map.ToName().MysqlEscape(), p.Level.MysqlEscape(), p.Anzahl.MysqlEscape(), p.Element.ToString(), ( p.IsBoss ? 1 : 0 ), p.InfoDesc.MysqlEscape() );
					else {
						HelperMsg.Error( "Mob \"" + p.Name + "\" existiert schon in der Datenbank an der selben Position!\nFalls dies nicht beabsichtigt war, wende dich bitte an GodLesZ", "SQL Warnung" );
					}
				}

			}

		}

		public void CreateBackup() {
			ResultTable table = Mysql.Query( "SELECT * FROM `shaiya_mob_db`" );
			if( table.Rows.Count == 0 )
				return;

			string savePath = AppDomain.CurrentDomain.BaseDirectory + "Backup\\MobDB_" + DateTime.Now.ToString().Replace( '.', '_' ).Replace( ':', '_' ) + ".sql";
			System.IO.Directory.CreateDirectory( AppDomain.CurrentDomain.BaseDirectory + "Backup\\" );
			System.IO.FileInfo info = new System.IO.FileInfo( savePath );
			using( System.IO.TextWriter writer = info.CreateText() ) {
				writer.WriteLine( "TRUNCATE TABLE `shaiya_mob_db`;" );
				writer.WriteLine( "INSERT INTO `shaiya_mob_db` ( `id`, `pos_x`, `pos_y`, `name`, `mapname`, `level`, `anzahl`, `element`, `boss`, `info` ) VALUES" );
				for( int i = 0; i < table.Rows.Count; i++ ) {
					ResultRow row = table.Rows[ i ];
					writer.Write( "( " + row[ "id" ].GetInt() + ", " + row[ "pos_x" ].GetInt() + ", " + row[ "pos_y" ].GetInt() + ", '" + row[ "name" ].GetString() + "', '" + row[ "mapname" ].GetString() + "', '" + row[ "level" ].GetString() + "', '" + row[ "anzahl" ].GetString() + "', '" + row[ "element" ].GetString() + "', " + row[ "boss" ].GetByte() + ", '" + row[ "info" ].GetString() + "' )" );
					if( i < table.Rows.Count - 1 )
						writer.WriteLine( "," );
				}
				writer.WriteLine( ";" );
			}

		}

		private int CountMobsOnMap( string Mapname ) {
			return Mysql.QueryCount( "SELECT COUNT(id) AS count FROM `shaiya_mob_db` WHERE mapname = '{0}'", Mapname );
		}
		private bool PointExists( SMobPoint p ) {
			return Mysql.QueryCount( "SELECT COUNT(id) AS count FROM `shaiya_mob_db` WHERE name = '{0}' AND mapname = '{1}' AND pos_x = {2} AND pos_y = {3}", p.Name.MysqlEscape(), Points.Map.ToName().MysqlEscape(), p.RectX, p.RectY ) > 0;
		}

		#endregion

		public void DrawPoints( System.Drawing.Graphics g, List<int> markedPoints, bool ShowName ) {
			for( int i = 0; i < Points.Count; i++ )
				DrawPoint( g, Points[ i ] as SMobPoint, markedPoints.Count, markedPoints.Contains( i ), ShowName );
		}

		public void DrawPoint( Graphics g, SMobPoint p, int markedCount, bool marked, bool ShowName ) {
			int imgIndex = p.RuleLevelToIndex( this );
			p.Marked = marked;
			if( Properties.Settings.Default.MarkedStandAlone == true && markedCount > 0 && p.Marked == false )
				return;

			g.DrawImage( SMobPoints.MobImages[ imgIndex ], p.RectX, p.RectY, SMobPoint.ImageSize, SMobPoint.ImageSize );
			if( p.Marked == true && !Properties.Settings.Default.MarkedStandAlone )
				g.DrawImage( p.Gif.GetNextFrame(), p.RectX - SMobPoint.MarkedDiffSize, p.RectY - SMobPoint.MarkedDiffSize, SMobPoint.MarkedImageSize, SMobPoint.MarkedImageSize );
			// Boss Overlay
			if( p.IsBoss == true )
				g.DrawImage( Properties.Resources.MobBoss, p.RectX - SMobPoint.BossDiffSize, p.RectY - SMobPoint.BossDiffSize, SMobPoint.BossImageSize, SMobPoint.BossImageSize );

			if( ShowName == false )
				return;

			// Point.X & .Y build's the Image Center, RectX & RectY the Top-Left Corner
			Font drawFont = new Font( "Tahoma", 8f );
			SizeF nameSize = g.MeasureString( p.Name, drawFont );
			Point drawAt = new Point( p.RectX + ( SMobPoint.ImageSize / 2 ) - (int)( nameSize.Width / 2 ), p.RectY - (int)nameSize.Height );

			g.DrawString( p.Name, drawFont, Brushes.White, drawAt.X + 1, drawAt.Y + 1 );
			g.DrawString( p.Name, drawFont, Brushes.Black, drawAt );

		}
		

		private void ListView_DrawSubItem( object sender, DrawListViewSubItemEventArgs e ) {
			if( e.ColumnIndex != 2 ) {
				e.DrawDefault = true;
				return;
			}

			int pIndex = (int)e.Item.Tag;
			SMobPoint p = Points[ pIndex ] as SMobPoint;
			if( p.Element == EMobElement.Unbekannt ) {
				e.DrawDefault = true;
				return;
			}

			if( ListView.SelectedIndices.Contains( e.ItemIndex ) )
				e.Graphics.FillRectangle( Brushes.RoyalBlue, e.Bounds );
			using( Image img = p.Element.ToImage() ) {
				e.Graphics.DrawImage( img, new Rectangle( e.Bounds.X + ( e.Bounds.Width / 2 ) - img.Width / 2, e.Bounds.Y + ( e.Bounds.Height / 2 ) - img.Height / 2, img.Width, img.Height ) );
			}
		}

		private void ListView_DrawColumnHeader( object sender, DrawListViewColumnHeaderEventArgs e ) {
			e.DrawDefault = true;
		}




		public static ListViewItem BuildListItem( FactoryMobPoint mobFac, int PointNum, SMobPoint p ) {
			ListViewItem item = new ListViewItem( new string[] { p.Name, p.Level, p.Element.ToName( true ), p.Anzahl } );
			item.Tag = PointNum;
			item.ToolTipText = string.Format( "{0} ({1}) | {2} [{3}]", p.Name, p.Level, p.Element, p.Anzahl );
			item.ImageIndex = p.RuleLevelToIndex( mobFac );

			return item;
		}

	}

}
