using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Tetris.Helpers;
using Tetris.Game;
using Microsoft.Xna.Framework.Content;

namespace Tetris.Graphics {

	public class TextureFont {
		/// <summary>
		/// Game font filename for our bitmap.
		/// </summary>
		const string GameFontFilename = "GameFont";

		/// <summary>
		/// Font height
		/// </summary>
		const int FontHeight = 36;//first try texture: 25;

		/// <summary>
		/// Substract this value from the y postion when rendering.
		/// Most letters start below the CharRects, this fixes that issue.
		/// </summary>
		const int SubRenderHeight = 5;//7;//6;

		/// <summary>
		/// Char rectangles, goes from space (32) to ~ (126).
		/// Height is not used (always the same), instead we save the actual
		/// used width for rendering in the height value!
		/// This are the characters:
		///  !"#$%&'()*+,-./0123456789:;<=>?@
		/// ABCDEFGHIJKLMNOPQRSTUVWXYZ[\]^_`
		/// abcdefghijklmnopqrstuvwxyz{|}~
		/// Then we also got 4 extra rects for the XBox Buttons: A, B, X, Y
		/// </summary>
		static Rectangle[] CharRects = new Rectangle[126 - 32 + 1]
		{
			new Rectangle(0, 0, 1, 8), // space
			new Rectangle(1, 0, 11, 10),
			new Rectangle(12, 0, 14, 13),
			new Rectangle(26, 0, 20, 18),
			new Rectangle(46, 0, 20, 18),
			new Rectangle(66, 0, 24, 22),
			new Rectangle(90, 0, 25, 23),
			new Rectangle(115, 0, 8, 7),
			new Rectangle(124, 0, 10, 9),
			new Rectangle(136, 0, 10, 9),
			new Rectangle(146, 0, 20, 18),
			new Rectangle(166, 0, 20, 18),
			new Rectangle(186, 0, 10, 8),
			new Rectangle(196, 0, 10, 9),
			new Rectangle(207, 0, 10, 8),
			new Rectangle(217, 0, 18, 16),
			new Rectangle(235, 0, 20, 19),

			new Rectangle(0, 36, 20, 18), // 1
			new Rectangle(20, 36, 20, 18),
			new Rectangle(40, 36, 20, 18),
			new Rectangle(60, 36, 21, 19),
			new Rectangle(81, 36, 20, 18),
			new Rectangle(101, 36, 20, 18),
			new Rectangle(121, 36, 20, 18),
			new Rectangle(141, 36, 20, 18),
			new Rectangle(161, 36, 20, 18), // 9
			new Rectangle(181, 36, 10, 8),
			new Rectangle(191, 36, 10, 8),
			new Rectangle(201, 36, 20, 18),
			new Rectangle(221, 36, 20, 18),

			new Rectangle(0, 72, 20, 18), // >
			new Rectangle(20, 72, 19, 17),
			new Rectangle(39, 72, 26, 24),
			new Rectangle(65, 72, 22, 20),
			new Rectangle(87, 72, 22, 20),
			new Rectangle(109, 72, 22, 20),
			new Rectangle(131, 72, 23, 21),
			new Rectangle(154, 72, 20, 18),
			new Rectangle(174, 72, 19, 17),
			new Rectangle(193, 72, 23, 21),
			new Rectangle(216, 72, 23, 21),
			new Rectangle(239, 72, 11, 10),

			new Rectangle(0, 108, 15, 13), // J
			new Rectangle(15, 108, 22, 20),
			new Rectangle(37, 108, 19, 17),
			new Rectangle(56, 108, 29, 26),
			new Rectangle(85, 108, 23, 21),
			new Rectangle(108, 108, 24, 22), // O
			new Rectangle(132, 108, 22, 20),
			new Rectangle(154, 108, 24, 22),
			new Rectangle(178, 108, 24, 22),
			new Rectangle(202, 108, 21, 19),
			new Rectangle(223, 108, 16, 15),

			new Rectangle(0, 144, 22, 20), // U
			new Rectangle(22, 144, 22, 20),
			new Rectangle(44, 144, 30, 28),
			new Rectangle(74, 144, 22, 20),
			new Rectangle(96, 144, 20, 18),
			new Rectangle(116, 144, 20, 18),
			new Rectangle(136, 144, 10, 9),
			new Rectangle(146, 144, 18, 16),
			new Rectangle(167, 144, 10, 9),
			new Rectangle(177, 144, 17, 16),
			new Rectangle(194, 144, 17, 16),
			new Rectangle(211, 144, 17, 16),
			new Rectangle(228, 144, 20, 18),

			new Rectangle(0, 180, 20, 18), // b
			new Rectangle(20, 180, 18, 16),
			new Rectangle(38, 180, 20, 18),
			new Rectangle(58, 180, 20, 18), // e
			new Rectangle(79, 180, 14, 12), // f
			new Rectangle(94, 180, 19, 18), // g
			new Rectangle(114, 180, 19, 18), // h
			new Rectangle(133, 180, 11, 9),
			new Rectangle(145, 180, 11, 9), // j
			new Rectangle(156, 180, 20, 18),
			new Rectangle(176, 180, 11, 9),
			new Rectangle(187, 180, 29, 27),
			new Rectangle(216, 180, 20, 18),
			new Rectangle(236, 180, 20, 19),

			new Rectangle(0, 216, 20, 18), // p
			new Rectangle(20, 216, 20, 18),
			new Rectangle(40, 216, 13, 12), // r
			new Rectangle(53, 216, 18, 16),
			new Rectangle(71, 216, 13, 11), // t
			new Rectangle(84, 216, 19, 18),
			new Rectangle(104, 216, 17, 16),
			new Rectangle(122, 216, 25, 23),
			new Rectangle(148, 216, 19, 17),
			new Rectangle(168, 216, 18, 16),
			new Rectangle(186, 216, 16, 15),
			new Rectangle(203, 216, 10, 9),
			new Rectangle(214, 216, 12, 11), // |
			new Rectangle(227, 216, 10, 9),
			new Rectangle(237, 216, 18, 17),
		};

		/// <summary>
		/// Font texture
		/// </summary>
		Texture2D fontTexture;
		/// <summary>
		/// Font sprite
		/// </summary>
		SpriteBatch fontSprite;

		/// <summary>
		/// Height
		/// </summary>
		/// <returns>Int</returns>
		public int Height {
			get {
				return FontHeight - SubRenderHeight;
			} // get
		} // Height

		/// <summary>
		/// Create texture font
		/// </summary>
		public TextureFont(GraphicsDevice device, ContentManager content) {
			fontTexture = content.Load<Texture2D>(GameFontFilename);
			fontSprite = new SpriteBatch(device);
		} // TextureFont()


		/// <summary>
		/// Get the text width of a given text.
		/// </summary>
		/// <param name="text">Text</param>
		/// <returns>Width (in pixels) of the text</returns>
		public int GetTextWidth(string text) {
			int width = 0;
			//foreach (char c in text)
			char[] chars = text.ToCharArray();
			for (int num = 0; num < chars.Length; num++) {
				int charNum = (int)chars[num];
				if (charNum >= 32 &&
					charNum - 32 < CharRects.Length)
					width += CharRects[charNum - 32].Height;
			} // foreach
			return width;
		} // GetTextWidth(text)

		/// <summary>
		/// Font to render
		/// </summary>
		internal class FontToRender {
			/// <summary>
			/// X and y position
			/// </summary>
			public int x, y;
			/// <summary>
			/// Text
			/// </summary>
			public string text;
			/// <summary>
			/// Color
			/// </summary>
			public Color color;

			/// <summary>
			/// Create font to render
			/// </summary>
			/// <param name="setX">Set x</param>
			/// <param name="setY">Set y</param>
			/// <param name="setText">Set text</param>
			/// <param name="setColor">Set color</param>
			public FontToRender(int setX, int setY, string setText, Color setColor) {
				x = setX;
				y = setY;
				text = setText;
				color = setColor;
			} // FontToRender(setX, setY, setText)
		} // class FontToRender

		/// <summary>
		/// Remember font texts to render to render them all at once
		/// in our Render method (beween rest of the ui and the mouse cursor).
		/// </summary>
		static List<FontToRender> remTexts = new List<FontToRender>();

		/// <summary>
		/// Write the given text at the specified position.
		/// </summary>
		/// <param name="x">X</param>
		/// <param name="y">Y</param>
		/// <param name="text">Text</param>
		/// <param name="color">Color</param>
		public static void WriteText(int x, int y, string text, Color color) {
			//return font.Write(x, y, text, color);
			remTexts.Add(new FontToRender(x, y, text, color));
		} // WriteText(x, y, text)

		/// <summary>
		/// Write
		/// </summary>
		/// <param name="x">X</param>
		/// <param name="y">Y</param>
		/// <param name="text">Text</param>
		public static void WriteText(int x, int y, string text) {
			//return font.Write(x, y, text);
			remTexts.Add(new FontToRender(x, y, text, Color.White));
		} // WriteText(x, y, text)

		/// <summary>
		/// Write all
		/// </summary>
		/// <param name="texts">Texts</param>
		public void WriteAll() {
			if (remTexts.Count == 0)
				return;

			fontSprite.Begin(SpriteSortMode.Texture, BlendState.AlphaBlend);

			for (int textNum = 0; textNum < remTexts.Count; textNum++) {
				FontToRender fontText = remTexts[textNum];

				int x = fontText.x;
				int y = fontText.y;
				Color color = fontText.color;
				//foreach (char c in fontText.text)
				char[] chars = fontText.text.ToCharArray();
				for (int num = 0; num < chars.Length; num++) {
					int charNum = (int)chars[num];
					if (charNum >= 32 && charNum - 32 < CharRects.Length) {
						// Draw this char
						Rectangle rect = CharRects[charNum - 32];
						// Reduce height to prevent overlapping pixels
						rect.Y += 1;
						rect.Height = FontHeight;// Height;// - 1;
						// Add 2 pixel for g, j, y
						//if (c == 'g' || c == 'j' || c == 'y')
						//	rect.Height+=2;
						Rectangle destRect = new Rectangle(x, y - SubRenderHeight, rect.Width, rect.Height);
						fontSprite.Draw(fontTexture, new Rectangle(destRect.X * BaseGame.Width / 1024, destRect.Y * BaseGame.Height / 768, destRect.Width * BaseGame.Width / 1024, destRect.Height * BaseGame.Height / 768), rect, color);

						int charWidth = CharRects[charNum - 32].Height;
						x += charWidth;
					} // if (charNum)
				} // foreach
			} // foreach (fontText)

			// End rendering
			fontSprite.End();

			remTexts.Clear();
		} // WriteAll(texts)    
	} // class TextureFont
} // namespace Tetris.Graphics
