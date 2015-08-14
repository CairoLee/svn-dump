using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shaiya.Extended.Server.Geometry {

	public delegate void EventTileOnEnter( SerialObject Unit );
	public delegate void EventTileOnLeave( SerialObject Unit );

	public class EventTile {
		public EventTileOnEnter OnEnterHandler;
		public EventTileOnLeave OnLeaveHandler;


		public EventTile() {
		}


		public void OnEnter( SerialObject Unit ) {
			if( OnEnterHandler != null )
				OnEnterHandler( Unit );
		}

		public void OnLeave( SerialObject Unit ) {
			if( OnLeaveHandler != null )
				OnLeaveHandler( Unit );
		}


		public bool HasEvent() {
			return ( OnEnterHandler != null || OnLeaveHandler != null );
		}

	}

}
