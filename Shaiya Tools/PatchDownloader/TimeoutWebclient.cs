using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace PatchDownloader {

	public class TimeoutWebclient : WebClient {
		private int mTimeout = 10000;

		public int TimeOut {
			get { return mTimeout; }
			set { mTimeout = value; }
		}


		protected override WebRequest GetWebRequest( Uri address ) {
			WebRequest webRequest = base.GetWebRequest( address );
			webRequest.Timeout = mTimeout;
			return webRequest;
		}

	}

}
