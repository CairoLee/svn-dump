using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Sbt.Structs {

	[Serializable]
	public class SBoss {
		private string mName = string.Empty;
		private int mRespawnMinutes = 0;
		private int mRespawnHours = 0;
		private int mRespawnDays = 0;
		private TimeSpan mRespawnTimeSpan = TimeSpan.Zero;


		[XmlAttribute( AttributeName = "Name" )]
		public string Name {
			get { return mName; }
			set { mName = value; }
		}

		[XmlAttribute( AttributeName = "Min" )]
		public int RespawnMinutes {
			get { return mRespawnMinutes; }
			set { mRespawnMinutes = value; }
		}

		[XmlAttribute( AttributeName = "Hour" )]
		public int RespawnHours {
			get { return mRespawnHours; }
			set { mRespawnHours = value; }
		}

		[XmlAttribute( AttributeName = "Day" )]
		public int RespawnDays {
			get { return mRespawnDays; }
			set { mRespawnDays = value; }
		}

		[XmlIgnore]
		public TimeSpan RespawnTimeSpan {
			get {
				if( mRespawnTimeSpan == TimeSpan.Zero && ( mRespawnMinutes > 0 || mRespawnHours > 0 || mRespawnDays > 0 ) )
					mRespawnTimeSpan = new TimeSpan( mRespawnDays, mRespawnHours, mRespawnMinutes, 0 );
				return mRespawnTimeSpan;
			}
		}



		public SBoss() {
		}

		public SBoss( string name, int d, int h, int m ) {
			mName = name;
			mRespawnDays = d;
			mRespawnHours = h;
			mRespawnMinutes = m;
		}

	}

}
