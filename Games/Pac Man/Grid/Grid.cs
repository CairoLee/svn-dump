using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework;

namespace PacMan {

	/// <summary>
	/// Represents the maze in terms of tiles. Initializes itself from txt file.
	/// </summary>
	public static class Grid {
		private static GridTile[,] mGrid = new GridTile[28, 31];

		public static GridTile[,] TileGrid {
			get { return mGrid; }
		}

		public static int Width {
			get { return 28; }
		}

		public static int Height {
			get { return 31; }
		}

		public static int NumCrumps {
			get;
			set;
		}


		/// <summary>
		/// Creates a new Grid object
		/// </summary>
		static Grid() {
			InitializeFromFile();
		}


		/// <summary>
		/// Reads Grid.txt to get an object grid from the numbers.
		/// </summary>
		private static void InitializeFromFile() {
			TextReader tr = new StreamReader("Content/Grid.txt");
			string line = tr.ReadLine();
			int lineIndex = 0;
			int charIndex = 0;

			while (line != null) {
				foreach (char c in line) {
					if (c == '1') {
						TileGrid[charIndex, lineIndex] = new GridTile(ETileTypes.Open, true, false, new Point(charIndex, lineIndex));
					} else if (c == '0') {
						TileGrid[charIndex, lineIndex] = new GridTile(ETileTypes.Closed, false, false, new Point(charIndex, lineIndex));
					} else if (c == '2') {
						TileGrid[charIndex, lineIndex] = new GridTile(ETileTypes.Home, false, false, new Point(charIndex, lineIndex));
					} else if (c == '3') {
						TileGrid[charIndex, lineIndex] = new GridTile(ETileTypes.Open, true, true, new Point(charIndex, lineIndex));
					}
					if (c != ' ') {
						charIndex++;
					}
				}
				charIndex = 0;
				lineIndex++;
				line = tr.ReadLine();
			}

			tr.Close();

			// Now, actually a few open tiles do not contain a crump; such as 
			// the tunnels and around the ghosts' home. 
			for (int i = 0; i < 28; i++) {
				if (i != 6 && i != 21) {
					TileGrid[i, 14].HasCrump = false;
				}
			}

			for (int j = 11; j < 20; j++) {
				TileGrid[9, j].HasCrump = false;
				TileGrid[18, j].HasCrump = false;
			}

			for (int i = 10; i < 18; i++) {
				TileGrid[i, 11].HasCrump = false;
				TileGrid[i, 17].HasCrump = false;
			}

			TileGrid[12, 9].HasCrump = false;
			TileGrid[15, 9].HasCrump = false;
			TileGrid[12, 10].HasCrump = false;
			TileGrid[15, 10].HasCrump = false;
			TileGrid[13, 23].HasCrump = false;
			TileGrid[14, 23].HasCrump = false;
		}

		/// <summary>
		/// Resets the grid and initialize a new one from file
		/// </summary>
		public static void Reset() {
			NumCrumps = 0;
			InitializeFromFile();
		}

	}


}
