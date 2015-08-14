using System;
using System.Collections.Generic;
using System.Text;

namespace Shaiya.Extended.Library.Utility {

	public class TileDisplay : GraphicsDeviceControl {
		[System.ComponentModel.Browsable( true )]
		public event EventHandler OnInitialize;
		[System.ComponentModel.Browsable( true )]
		public event EventHandler OnDraw;

		protected override void Initialize() {
			if( OnInitialize != null )
				OnInitialize( this, null );
		}

		protected override void Draw() {
			if( OnDraw != null )
				OnDraw( this, null );
		}

	}

}
