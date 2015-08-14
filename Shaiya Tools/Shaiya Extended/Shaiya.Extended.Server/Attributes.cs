using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Shaiya.Extended.Server {

	[AttributeUsage( AttributeTargets.Method )]
	public class CallPriorityAttribute : Attribute {
		private int mPriority;

		public int Priority {
			get { return mPriority; }
			set { mPriority = value; }
		}

		public CallPriorityAttribute( int priority ) {
			mPriority = priority;
		}

	}

	public class CallPriorityComparer : IComparer<MethodInfo> {
		public int Compare( MethodInfo x, MethodInfo y ) {
			if( x == null && y == null )
				return 0;
			if( x == null )
				return 1;
			if( y == null )
				return -1;
			return GetPriority( x ) - GetPriority( y );
		}

		private int GetPriority( MethodInfo mi ) {
			object[] objs = mi.GetCustomAttributes( typeof( CallPriorityAttribute ), true );
			if( objs == null )
				return 0;
			if( objs.Length == 0 )
				return 0;

			CallPriorityAttribute attr = objs[ 0 ] as CallPriorityAttribute;
			if( attr == null )
				return 0;

			return attr.Priority;
		}

	}

}
