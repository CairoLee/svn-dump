using System;
namespace a
{
	public class M1 : ApplicationException
	{
		public M1() : base("Document version error")
		{
		}
	}
	public class m1 : ApplicationException
	{
		public m1() : base("Document checksum error")
		{
		}
	}
}
