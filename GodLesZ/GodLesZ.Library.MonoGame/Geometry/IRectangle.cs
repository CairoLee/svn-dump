namespace GodLesZ.Library.MonoGame.Geometry {
	
	public interface IRectangle {

		IPoint Start { get; set; }
		IPoint End { get; set; }

		int X { get; set; }
		int Y { get; set; }

		int Width { get; set; }
		int Height { get; set; }

		void Set(int x, int y, int width, int height);
		bool Contains(IPoint p);
		 
	}

}