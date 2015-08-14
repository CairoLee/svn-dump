using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XNASimpleTemplates
{
    public abstract class GameComponentBase<T> : DrawableGameComponent where T : Game
    {
        protected float Rotation;
        private Texture2D Texture;
        protected string TextureDirectory;
        protected string TextureName;

        protected GameComponentBase(Game game)
            : base(game)
        {
            CurrGame = (T)game;
        }

        protected T CurrGame { get; private set; }
        public Vector2 Position { get; protected set; }
        private Vector2 Origin { get; set; }
        private Vector2 Scale { get; set; }
        public Vector2 Size { get; protected set; }
        protected OriginType OriginType { private get; set; }
        protected SpriteBatch SpriteBatch { private get; set; }

        //protected Vector2 TopLeft
        //{
        //    get
        //    {
        //        switch (OriginType)
        //        {
        //            case OriginType.TopLeft:
        //                return Position;
        //            case OriginType.TopRight:
        //                return new Vector2(Position.X-Size.X,Position.Y);
        //            case OriginType.BottomLeft:
        //                return new Vector2(Position.X,Position.Y - Size.Y);
        //            case OriginType.BottomRight:
        //                return new Vector2(Position.X-Size.X,Position.Y-Size.Y);
        //            case OriginType.Center:
        //                return new Vector2(Position.X - Size.X/2,Position.Y - Size.Y/2);
        //        }
        //        return Vector2.Zero;
        //    }
        //}
        //protected Vector2 TopRight
        //{
        //    get
        //    {
        //        switch (OriginType)
        //        {
        //            case OriginType.TopLeft:
        //                return new Vector2(Position.X - Size.X,Position.Y);
        //            case OriginType.TopRight:
        //                return Position;
        //            case OriginType.BottomLeft:
        //                return new Vector2(Position.X-Size.X, Position.Y - Size.Y);
        //            case OriginType.BottomRight:
        //                return new Vector2(Position.X - Size.X, Position.Y - Size.Y);
        //            case OriginType.Center:
        //                return new Vector2(Position.X - Size.X / 2, Position.Y - Size.Y / 2);
        //        }
        //        return Vector2.Zero;
        //    }
        //}
        //protected Vector2 BottomLeft { get { return new Vector2(); } }
        //protected Vector2 BottomRight { get { return new Vector2(); } }
        //protected Vector2 Center { get { return new Vector2(); } }

        public override void Initialize()
        {
            Texture = CurrGame.Content.Load<Texture2D>(TextureDirectory + TextureName);
            switch (OriginType)
            {
                case OriginType.TopLeft:
                    Origin = Vector2.Zero;
                    break;
                case OriginType.TopRight:
                    Origin = new Vector2(Texture.Width, 0);
                    break;
                case OriginType.BottomLeft:
                    Origin = new Vector2(0, Texture.Height);
                    break;
                case OriginType.BottomRight:
                    Origin = new Vector2(Texture.Width, Texture.Height);
                    break;
                case OriginType.Center:
                    Origin = new Vector2(Texture.Width / 2f, Texture.Height / 2f);
                    break;
            }
            Scale = new Vector2(Size.X / Texture.Width, Size.Y / Texture.Height);
            base.Initialize();
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch.Begin();
            {
                SpriteBatch.Draw(Texture, Position, null, Color.White, Rotation, Origin, Scale, SpriteEffects.None, 0);
            }
            SpriteBatch.End();
            base.Draw(gameTime);
        }
    }

    public enum OriginType
    {
        TopLeft,
        TopRight,
        BottomLeft,
        BottomRight,
        Center
    }
}