using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PathDefence.Screens;
using ProjectMercury;
using ProjectMercury.Emitters;
using ProjectMercury.Renderers;

namespace PathDefence
{
    public class EmitterDrawer : DrawableGameComponent
    {
        private readonly PathDefenceGame CurrGame;
        private readonly GamePlayScreen GamePlayScreen;
        private SpriteBatchRenderer Renderer;
        private RectEmitter TowerSelector;

        public EmitterDrawer(Game game, GamePlayScreen screen) : base(game)
        {
            CurrGame = (PathDefenceGame) game;
            GamePlayScreen = screen;
        }

        public override void Initialize()
        {
            Renderer = new SpriteBatchRenderer {BlendMode = SpriteBlendMode.Additive, Batch = CurrGame.SpriteBatch};

            //TowerSelector = CurrGame.Content.Load<RectEmitter>("GUI/TowerSelector");
            TowerSelector = new RectEmitter
                            {
                                ReleaseColour = Color.Lime.ToVector3(),
                                ReleaseOpacity = 1,
                                ReleaseQuantity = 100,
                                ReleaseScale = new VariableFloat {Anchor = 15, Variation = 1},
                                ReleaseSpeed = new VariableFloat {Anchor = 10, Variation = 5},
                                Frame = true,
                                Height = 50,
                                Width = 50,
                                Budget = 10000,
                                Term = 0.5f
                            };

            TowerSelector.Initialize();
            TowerSelector.LoadContent(CurrGame.Content);
            base.Initialize();
        }

        public override void Draw(GameTime gameTime)
        {
            Renderer.RenderEmitter(TowerSelector);
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            TowerSelector.Update((float) gameTime.TotalGameTime.TotalSeconds,
                                 (float) gameTime.ElapsedGameTime.TotalSeconds);
            base.Update(gameTime);
        }

        public void Emit(Vector2 pos)
        {
            TowerSelector.Trigger(pos);
        }
    }
}