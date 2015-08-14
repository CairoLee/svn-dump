using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerInterface
{
    public interface ITowerInterface
    {
        string ThumbnailTextureName { get; }

        float Price { get; }

        float Range { get; }
        float Damage { get; }

        Texture2D Thumbnail { get; }

        Vector2 PathPosition { get; }
        Vector2 Position { get; }

        Vector2 PathSize { get; }
        Vector2 Size { get; }

        void Update(GameTime gameTime);
        void Draw(GameTime gameTime);
        void Initialize();
    }
}