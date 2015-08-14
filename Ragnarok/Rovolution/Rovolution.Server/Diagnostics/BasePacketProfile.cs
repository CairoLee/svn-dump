using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Rovolution.Server.Diagnostics {

	public abstract class BasePacketProfile : BaseProfile {
		private long mTotalLength;

		public long TotalLength {
			get { return mTotalLength; }
		}

		public double AverageLength {
			get { return (double)mTotalLength / Math.Max(1, this.Count); }
		}


		public BasePacketProfile(string name)
			: base(name) {
		}


		public void Finish(int length) {
			Finish();

			mTotalLength += length;
		}

		public override void WriteTo(TextWriter op) {
			base.WriteTo(op);

			op.Write("\t{0,12:F2} {1,-12:N0}", AverageLength, TotalLength);
		}
	}

}
