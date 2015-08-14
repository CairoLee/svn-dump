using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using ShaiyaMonsterMap.Structs;
using ShaiyaMonsterMap.Forms;

namespace ShaiyaMonsterMap.Components {

	public delegate void RemovePointEventHandler( int Index );
	public delegate void EditPointEventHandler( int Index, int X, int Y );

	public class MapImage : PictureBox, System.ComponentModel.ISupportInitialize {
		internal ColorToolTip mToolTip = null;

		public RemovePointEventHandler RemovePoint;
		public EditPointEventHandler EditPoint;

		private FactoryMain mFactory = null;
		private Timer mInvalidateTimer = new Timer();

		public FactoryMain Factory {
			set { mFactory = value; }
			get { return mFactory; }
		}

		public ColorToolTip ToolTip {
			get { return mToolTip; }
			set { mToolTip = value; }
		}


		public MapImage(){
			this.MouseMove += new MouseEventHandler( MapImage_MouseMove );
			this.MouseClick += new MouseEventHandler( MapImage_MouseClick );

			InitToolTip();
		}


		#region ISupportInitialize Member
		void System.ComponentModel.ISupportInitialize.BeginInit() {
		}

		void System.ComponentModel.ISupportInitialize.EndInit() {
			if( IsDesignMode() == true )
				return;

			this.BackColor = System.Drawing.SystemColors.ControlDark;
			mInvalidateTimer.Interval = 100;
			mInvalidateTimer.Tick += delegate( object sender, EventArgs e ) {
				this.Invalidate();
			};
			mInvalidateTimer.Start();
		}

		#endregion

		public virtual int InRange( int x, int y ) {
			if( Factory == null )
				return -1;

			IPoint p;
			for( int i = 0; i < Factory.Points.Count; i++ ) {
				p = Factory[ i ];
				if( x >= p.RectX && x <= p.RectWidth && y >= p.RectY && y <= p.RectHeight )
					return i;
			}

			return -1;
		}

		public virtual void InitToolTip() {
			if( mToolTip == null )
				return;
			mToolTip.Active = false;
			mToolTip.AutoPopDelay = 10000;
			mToolTip.InitialDelay = 0;
			mToolTip.ReshowDelay = 0;
		}

		public virtual void MapImage_MouseClick( object sender, MouseEventArgs e ) {
		}

		public virtual void MapImage_MouseMove( object sender, MouseEventArgs e ) {
			int i = InRange( e.X, e.Y );
			if( i == -1 ) {
				mToolTip.InfoPoint = null;
				mToolTip.Active = false;
				return;
			}

			// ToolTip already showed
			if( mToolTip.Active == true && mToolTip.InfoPoint.Equals( Factory[ i ] ) == true )
				return;

			// hide it if present
			mToolTip.Active = false;

			// set new Parameter
			mToolTip.InfoPoint = Factory[ i ];
			mToolTip.Active = true;
		}




		#region IsDesignMode custom implementation
		public bool IsDesignMode() {
			return MapImage.IsDesignMode( this );
		}

		public static bool IsDesignMode( Control control ) {

			while( control != null ) {
				System.Reflection.PropertyInfo siteProperty = control.GetType().GetProperty( "Site" );

				if( siteProperty != null ) {
					System.ComponentModel.ISite site = siteProperty.GetGetMethod().Invoke( control, new object[ 0 ] ) as System.ComponentModel.ISite;
					if( site != null && site.DesignMode )
						return true;
				}

				control = control.Parent;
			}

			return false;
		} 
		#endregion

	}

}
