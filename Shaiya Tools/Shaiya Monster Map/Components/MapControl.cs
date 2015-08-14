using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ShaiyaMonsterMap.Structs;
using ShaiyaMonsterMap.Forms;
using ShaiyaMonsterMap.Enumerations;

namespace ShaiyaMonsterMap.Components {

	public partial class MapControl : UserControl {
		public static bool CanEdit = false;
		public static List<MapControl> Instances = new List<MapControl>();

		private ListViewColumnSorter mListViewColumnSorter = new ListViewColumnSorter();

		private string mMapname = "";
		private System.Reflection.Assembly mAssembly;
		private FactoryMobPoint mFactory;
		private List<int> mMarkedMobs = new List<int>();

		public FactoryMobPoint Factory {
			get { return mFactory; }
		}

		public string Mapname {
			get { return mMapname; }
		}

		public IPointList MobPoints {
			get { return mFactory.Points; }
		}


		public MapControl() {
			InitializeComponent();

			mAssembly = System.Reflection.Assembly.GetExecutingAssembly();
			listMobPoints.ListViewItemSorter = mListViewColumnSorter;

			Instances.Add( this );
		}


		public void InitializeMap( string Mapname ) {
			mMapname = Mapname;

			InitializePoints();
			InitializeMobImage();
		}

		public void DeinitializeMap() {
			if( MapControl.CanEdit == true && mFactory != null )
				mFactory.SavePoints( MapControl.CanEdit );
			ClearMobList();
			mFactory = null;
		}


		public static void SavePointsAll() {
			MapControl.Instances.ForEach(
				new Action<MapControl>(
					delegate( MapControl Map ) {
						if( Map.Factory != null )
							Map.Factory.SavePoints( MapControl.CanEdit );
					}
				)
			);
		}

		public static void LoadMobListAll() {
			MapControl.Instances.ForEach(
				new Action<MapControl>(
					delegate( MapControl Map ) {
						Map.LoadMobList();
					}
				)
			);
		}

		public static void InitializeMobImageAll() {
			MapControl.Instances.ForEach(
				new Action<MapControl>(
					delegate( MapControl Map ) {
						Map.InitializeMobImage();
					}
				)
			);
		}

		public static void InvalidateAll() {
			MapControl.Instances.ForEach(
				new Action<MapControl>(
					delegate( MapControl Map ) {
						Map.MonsterMap.Invalidate();
					}
				)
			);
		}

		public static void CreateBackupAll() {
			MapControl.Instances.ForEach(
				new Action<MapControl>(
					delegate( MapControl Map ) {
						if( Map.Factory != null )
							Map.Factory.CreateBackup();
					}
				)
			);
		}

		public static void DeinitializeAll() {
			MapControl.Instances.ForEach(
				new Action<MapControl>(
					delegate( MapControl Map ) {
						Map.DeinitializeMap();
					}
				)
			);
		}

		public static void RefreshAll() {
			SavePointsAll();
			LoadMobListAll();
			InitializeMobImageAll();
		}


		#region Initialize
		public void InitializeFactories() {
			mFactory = new FactoryMobPoint( listMobPoints, MonsterMap );

			MonsterMap.EditPoint = new ShaiyaMonsterMap.Components.EditPointEventHandler( MonsterMap_EditPoint );
			MonsterMap.RemovePoint = new ShaiyaMonsterMap.Components.RemovePointEventHandler( MonsterMap_RemovePoint );
		}
		public void InitializePoints() {
			LoadMobList();
		}
		public void InitializeMobImage() {
			if( SMobPoints.MobImages == null ) {
				SMobPoints.MobImages = new Image[ 4 ] {
					Properties.Resources.Mob1, 
					Properties.Resources.Mob2,
					Properties.Resources.Mob3,
					Properties.Resources.Mob4
				};
			}

			imgMob1.Image = SMobPoints.MobImages[ 0 ];
			imgMob2.Image = SMobPoints.MobImages[ 1 ];
			imgMob3.Image = SMobPoints.MobImages[ 2 ];
			imgMob4.Image = SMobPoints.MobImages[ 3 ];
			imgMobBoss.Image = Properties.Resources.MobBoss;

			MonsterMap.Factory = mFactory;
			MonsterMap.Image = Bitmap.FromStream( mAssembly.GetManifestResourceStream( string.Format( FactoryMobPoint.MapRessource, mFactory.Map.ToString() ) ) );

			lblMobLevel1.Text = "Mob " + mFactory.ActiveMapRule.MobLevel1;
			lblMobLevel2.Text = "Mob " + mFactory.ActiveMapRule.MobLevel2;
			lblMobLevel3.Text = "Mob " + mFactory.ActiveMapRule.MobLevel3;
			lblMobLevel4.Text = "Mob " + mFactory.ActiveMapRule.MobLevel4;

			MonsterMap.Invalidate();
		}
		#endregion


		#region MapControl Events
		private void MapControl_KeyUp( object sender, KeyEventArgs e ) {
			if( ( e.Modifiers & Keys.Control ) != Keys.Control )
				return;

			switch( e.KeyCode ) {
				case Keys.Up:
				case Keys.Down:
				case Keys.Left:
				case Keys.Right:
					e.Handled = MoveMobPoints( e.KeyCode );
					break;
			}
		}
		#endregion

		#region MonsterMap Events
		private void MonsterMap_RemovePoint( int Index ) {
			RemoveMobInList( Index );
		}

		private void MonsterMap_EditPoint( int Index, int X, int Y ) {
			EditMobPoint( Index, X, Y );
		}

		private void MonsterMap_Paint( object sender, PaintEventArgs e ) {
			if( mFactory != null )
				mFactory.DrawPoints( e.Graphics, mMarkedMobs, Properties.Settings.Default.ShowName );
		}
		#endregion

		#region listMobPoints Events
		private void listMobPoints_ColumnClick( object sender, ColumnClickEventArgs e ) {
			if( e.Column == mListViewColumnSorter.SortColumn ) {
				if( mListViewColumnSorter.Order == SortOrder.Ascending )
					mListViewColumnSorter.Order = SortOrder.Descending;
				else
					mListViewColumnSorter.Order = SortOrder.Ascending;
			} else {
				mListViewColumnSorter.SortColumn = e.Column;
				mListViewColumnSorter.Order = SortOrder.Ascending;
			}

			listMobPoints.Sort();
		}

		private void listMobPoints_SelectedIndexChanged( object sender, EventArgs e ) {
			mMarkedMobs.Clear();
			for( int i = 0; i < listMobPoints.SelectedItems.Count; i++ )
				mMarkedMobs.Add( int.Parse( listMobPoints.SelectedItems[ i ].Tag.ToString() ) );

			MonsterMap.Invalidate();
		}

		private void listMobPoints_DoubleClick( object sender, EventArgs e ) {
			if( mMarkedMobs.Count == 0 || MapControl.CanEdit == false )
				return;

			EditMobPoint( mMarkedMobs[ 0 ], mFactory[ mMarkedMobs[ 0 ] ].X, mFactory[ mMarkedMobs[ 0 ] ].Y );
		}
		#endregion



		#region Helper [Mob]
		private void LoadMobList() {
			if( mFactory == null ) 
				InitializeFactories();
			mFactory.LoadList( mMapname );
		}

		public void ClearMobList() {
			if( mFactory != null )
				mFactory.ClearList();
		}

		public void RemoveMobInList( int i ) {
			mFactory.DeletePoint( i );

			if( mMarkedMobs.Contains( i ) == true )
				mMarkedMobs.Remove( i );
		}

		public void EditMobPoint( int i, int x, int y ) {
			frmMobPoint frm = new frmMobPoint( "bearbeiten..." );

			SMobPoint p = mFactory[ i ] as SMobPoint;
			frm.txtName.Text = p.Name;
			frm.txtLevel.Text = p.Level;
			frm.cbCount.Text = p.Anzahl;
			frm.cbElement.SelectedIndex = (int)p.Element;
			frm.chkBoss.Checked = p.IsBoss;
			frm.txtInfo.Text = p.InfoDesc;
			if( frm.ShowDialog() != DialogResult.OK )
				return;

			p.Changed = true;
			p.Name = frm.txtName.Text;
			p.Level = frm.txtLevel.Text;
			p.Anzahl = frm.cbCount.Text;
			p.Element = (EMobElement)frm.cbElement.SelectedIndex;
			p.IsBoss = frm.chkBoss.Checked;
			p.InfoDesc = frm.txtInfo.Text;

			for( int j = 0; j < listMobPoints.Items.Count; j++ )
				if( int.Parse( listMobPoints.Items[ j ].Tag.ToString() ) == i ) {
					listMobPoints.Items[ j ] = FactoryMobPoint.BuildListItem( mFactory, i, p );
					break;
				}

			MonsterMap.Invalidate();
		}

		public bool MoveMobPoints( Keys key ) {
			if( mMarkedMobs.Count == 0 )
				return false;
			if( MapControl.CanEdit == false )
				return false;

			mMarkedMobs.ForEach(
				delegate( int i ) {
					switch( key ) {
						case Keys.Up:
							if( mFactory[ i ].Y == 0 )
								break;
							mFactory[ i ].Y--;
							mFactory[ i ].Changed = true;
							break;
						case Keys.Down:
							if( mFactory[ i ].Y == MonsterMap.Height )
								break;
							mFactory[ i ].Y++;
							mFactory[ i ].Changed = true;
							break;
						case Keys.Left:
							if( mFactory[ i ].X == 0 )
								break;
							mFactory[ i ].X--;
							mFactory[ i ].Changed = true;
							break;
						case Keys.Right:
							if( mFactory[ i ].X == MonsterMap.Width )
								break;
							mFactory[ i ].X++;
							mFactory[ i ].Changed = true;
							break;
					}
				}
			);

			MonsterMap.Invalidate();
			return true;
		}

		public bool SelectPoint( SMobPoint p, bool Clear ) {
			if( Clear == true ) {
				listMobPoints.SelectedIndices.Clear();
				mMarkedMobs.Clear();
				MonsterMap.Invalidate();
			}

			for( int i = 0; i < mFactory.Points.Count; i++ ) {
				if( mFactory[ i ].Equals( p ) == true ) {
					mMarkedMobs.Add( i );

					for( int j = 0; j < listMobPoints.Items.Count; j++ )
						if( int.Parse( listMobPoints.Items[ j ].Tag.ToString() ) == i ) {
							listMobPoints.SelectedIndices.Add( j );
							break;
						}
					return true;
				}
			}
			return false;
		}
		#endregion


	}

}
