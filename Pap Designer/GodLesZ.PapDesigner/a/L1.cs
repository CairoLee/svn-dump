using System;
namespace a
{
	public class L1 : ApplicationException
	{
		public L1() : base("CANCEL")
		{
		}
	}
	public class l1 : ApplicationException
	{
		public l1() : base("Invalid runtime condition")
		{
		}
	}
}
