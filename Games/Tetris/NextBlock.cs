using Microsoft.Xna.Framework;
using Tetris.Graphics;
using Tetris.Helpers;

namespace Tetris {

	public partial class NextBlock : Microsoft.Xna.Framework.DrawableGameComponent {
		const int PreviewGridWidth = 5, PreviewGridHeight = 5;

		TetrisGame game = null;
		EBlockTypes nextBlockType = EBlockTypes.Empty;
		Rectangle nextBlockRect;


		public NextBlock(TetrisGame setGame, Rectangle setNextBlockRect)
			: base(setGame) {
			game = setGame;
			nextBlockRect = setNextBlockRect;
		}


		public override void Draw(GameTime gameTime) {
			TextureFont.WriteText(nextBlockRect.X + 5, nextBlockRect.Y + 10, "Next:");

			Rectangle gridRect = new Rectangle(nextBlockRect.X + 5, nextBlockRect.Y + 43, nextBlockRect.Width - 15, nextBlockRect.Height - 46);
			int blockWidth = gridRect.Width / PreviewGridWidth;
			int blockHeight = gridRect.Height / PreviewGridHeight;

			for (int x = 0; x < PreviewGridWidth; x++)
				for (int y = 0; y < PreviewGridHeight; y++) {
					int[,] blockData = TetrisGrid.BlockTypeShapesNormal[(int)nextBlockType];
					bool isFilled = x > 0 && y > 0 && x - 1 < blockData.GetLength(0) && y - 1 < blockData.GetLength(1) && blockData[x - 1, y - 1] != 0;
					game.BlockSprite.Render(new Rectangle(gridRect.X + x * blockWidth, gridRect.Y + y * blockHeight, blockWidth - 1, blockHeight - 1), TetrisGrid.BlockColor[isFilled ? (int)nextBlockType : 0]);
				}
		}

		public EBlockTypes SetNewRandomBlock() {
			if (nextBlockType == EBlockTypes.Empty)
				nextBlockType = (EBlockTypes)(1 + RandomHelper.GetRandomInt(TetrisGrid.NumOfBlockTypes - 1));

			EBlockTypes currentBlockType = nextBlockType;
			nextBlockType = (EBlockTypes)(1 + RandomHelper.GetRandomInt(TetrisGrid.NumOfBlockTypes - 1));

			return currentBlockType;
		}

	}

}


