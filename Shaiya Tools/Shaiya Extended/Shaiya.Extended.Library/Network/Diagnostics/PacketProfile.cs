using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Shaiya.Extended.Library.Network {

	public abstract class BasePacketProfile : BaseProfile {
		private long mTotalLength;

		public long TotalLength {
			get { return mTotalLength; }
		}

		public double AverageLength {
			get { return (double)mTotalLength / Math.Max( 1, this.Count ); }
		}


		public BasePacketProfile( string name )
			: base( name ) {
		}


		public void Finish( int length ) {
			Finish();

			mTotalLength += length;
		}

		public override void WriteTo( TextWriter op ) {
			base.WriteTo( op );

			op.Write( "\t{0,12:F2} {1,-12:N0}", AverageLength, TotalLength );
		}
	}

	public class PacketSendProfile : BasePacketProfile {
		private static Dictionary<Type, PacketSendProfile> mProfiles = new Dictionary<Type, PacketSendProfile>();
		private long mCreated;

		public static IEnumerable<PacketSendProfile> Profiles {
			get { return mProfiles.Values; }
		}

		public long Created {
			get { return mCreated; }
			set { mCreated = value; }
		}


		public PacketSendProfile( Type type )
			: base( type.FullName ) {
		}


		public static PacketSendProfile Acquire( Type type ) {
			if( !BaseProfile.Profiling )
				return null;

			PacketSendProfile prof;
			if( !mProfiles.TryGetValue( type, out prof ) )
				mProfiles.Add( type, prof = new PacketSendProfile( type ) );

			return prof;
		}

		public override void WriteTo( TextWriter op ) {
			base.WriteTo( op );

			op.Write( "\t{0,12:N0}", Created );
		}
	}

	public class PacketReceiveProfile : BasePacketProfile {
		private static Dictionary<int, PacketReceiveProfile> mProfiles = new Dictionary<int, PacketReceiveProfile>();

		public static IEnumerable<PacketReceiveProfile> Profiles {
			get { return mProfiles.Values; }
		}

		public PacketReceiveProfile( int packetId )
			: base( String.Format( "0x{0:X2}", packetId ) ) {
		}


		public static PacketReceiveProfile Acquire( int packetId ) {
			if( !BaseProfile.Profiling ) {
				return null;
			}

			PacketReceiveProfile prof;

			if( !mProfiles.TryGetValue( packetId, out prof ) ) {
				mProfiles.Add( packetId, prof = new PacketReceiveProfile( packetId ) );
			}

			return prof;
		}

	}


}
