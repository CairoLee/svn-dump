using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rovolution.Server {
	
	public delegate void TimerCallback();
	public delegate void TimerStateCallback(object state);
	public delegate void TimerStateCallback<T>(T state);

}
