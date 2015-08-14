using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LevelEditor
{
    public class WallEditor : DrawableGameComponent
    {
        private const int GridCount = 32;
        private readonly Leveleditor CurrGame;
        public readonly bool[,] Grid = new bool[GridCount,GridCount];
        private Texture2D FieldTex;
        private Vector2 GridSize;
        private Texture2D LineTex;
        private KeyboardState OldKeyboardState;
        private MouseState OldMouseState;
        public bool Show = true;
        private SpriteBatch spriteBatch;
        private Vector2 LastField;

        public WallEditor(Game game) : base(game)
        {
            CurrGame = (Leveleditor) game;
        }

        public override void Initialize()
        {
            GridSize = new Vector2((CurrGame.Width-600)/(float) GridCount, CurrGame.Height/(float) GridCount);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = CurrGame.SpriteBatch;
            LineTex = CurrGame.Content.Load<Texture2D>("point");
            FieldTex = CurrGame.Content.Load<Texture2D>("field");
            base.LoadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            if (Show)
            {
                DrawGrid();
            }
            base.Draw(gameTime);
        }

        private void DrawGrid()
        {
            spriteBatch.Begin();
            {
                for (int i = 0; i < GridCount; i++)
                {
                    for (int j = 0; j < GridCount; j++)
                    {
                        spriteBatch.Draw(FieldTex, new Vector2(i * GridSize.X, j * GridSize.Y), null,
                                         Grid[i, j] ? Color.Lime : Color.Green, 0, Vector2.Zero,
                                         new Vector2(GridSize.X / FieldTex.Width, GridSize.Y / FieldTex.Height),
                                         SpriteEffects.None, 0);
                    }
                }

                for (int i = 1; i < GridCount; i++)
                {
                    spriteBatch.Draw(LineTex, new Vector2(i * GridSize.X, 0), null, Color.Black, 0, Vector2.Zero,
                                     new Vector2(1, CurrGame.Height), SpriteEffects.None, 0);
                }
                for (int i = 1; i < GridCount; i++)
                {
                    spriteBatch.Draw(LineTex, new Vector2(0, i * GridSize.Y), null, Color.Black, 0, Vector2.Zero,
                                     new Vector2(CurrGame.Width - 600, 1), SpriteEffects.None, 0);
                }
            }
            spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            if (Show)
            {
                KeyboardState Keystate = Keyboard.GetState();

                OldKeyboardState = Keystate;

                MouseState Mousestate = Mouse.GetState();
                if ((Mousestate.LeftButton == ButtonState.Pressed))// && (OldMouseState.LeftButton == ButtonState.Released))
                {
                    HandleMouseClick(new Vector2(Mousestate.X, Mousestate.Y));
                }
                else
                {
                    LastField = new Vector2(-1);
                }
                OldMouseState = Mousestate;
            }

            base.Update(gameTime);
        }

        private void HandleMouseClick(Vector2 position)
        {
            var x = (int) (position.X/GridSize.X);
            var y = (int) (position.Y/GridSize.Y);
            if (new Vector2(x, y) != LastField)
            {
                if ((x < GridCount - 1) && (x >= 1) && (y < GridCount) && (y >= 0))
                {
                    Grid[x, y] = !Grid[x, y];
                    LastField = new Vector2(x, y);
                }
            }
        }
    }
}