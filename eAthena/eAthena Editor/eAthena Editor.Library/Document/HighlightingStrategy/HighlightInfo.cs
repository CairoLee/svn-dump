using System;

namespace GodLesZ.eAthenaEditor.Library.Document
{
	public class HighlightInfo
	{
		public bool BlockSpanOn = false;
		public bool Span				= false;
		public Span CurSpan		 = null;
		
		public HighlightInfo(Span curSpan, bool span, bool blockSpanOn)
		{
			this.CurSpan		 = curSpan;
			this.Span				= span;
			this.BlockSpanOn = blockSpanOn;
		}
	}
}
