using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GodLesZ.Games.Match3 {

	public class Gem : DrawableGameComponent {

		public const float Speed = 200f;
		public const int TileHeight = 48;
		public const int TileWidth = 48;

		private bool mContentLoaded;
		private float mAmount;
		private Vector2 mPointA;
		private Vector2 mPointB;
		private Vector2 mPosition;
		private SpriteBatch mSpriteBatch;

		public Texture2D Texture;
		public float Scale = 1f;
		public EGemType Type;
		public bool ZoomIn;
		public bool ZoomOut;


		public Gem(Game game, EGemType type, Vector2 position)
			: base(game) {
			Type = type;
			mPosition = position;
			
			var vector = new Vector2(position.X, position.Y);
			mPointA = vector;
			vector = new Vector2(position.X, position.Y);
			mPointB = vector;
			mAmount = 0f;
			ZoomOut = false;
			ZoomIn = false;
		}


		protected override void LoadContent() {
			if (mContentLoaded) {
				return;
			}

			Texture = Game.Content.Load<Texture2D>(@"Texture\gem");
			mSpriteBatch = Game.Services.GetService<SpriteBatch>();
			mContentLoaded = true;
		}

		public override void Update(GameTime gameTime) {
			if (mAmount < 1f) {
				mAmount += ((float)gameTime.ElapsedGameTime.TotalMilliseconds) / Speed;
				if (mAmount >= 1f) {
					mAmount = 1f;
				}
				mPosition = Vector2.SmoothStep(mPointA, mPointB, mAmount);
			}
			if (ZoomOut) {
				if (Scale > 0f) {
					Scale -= ((float)gameTime.ElapsedGameTime.TotalMilliseconds) / Speed;
				} else {
					ZoomOut = false;
				}
			}
			if (ZoomIn) {
				if (Scale > 1f) {
					Scale = 1f;
				} else if (Scale < 1f) {
					Scale += ((float)gameTime.ElapsedGameTime.TotalMilliseconds) / Speed;
				} else {
					ZoomIn = false;
				}
			}

		}

		public override void Draw(GameTime gameTime) {
			if (mContentLoaded == false) {
				LoadContent();
			}

			var srcRectangle = new Rectangle((int)Type * 64, 0, 64, 64);
			var destinationRectangle = new Rectangle {
				X = ((int)mPosition.X) + ((int)(((1f - Scale) * TileHeight) / 2f)),
				Y = ((int)mPosition.Y) + ((int)(((1f - Scale) * TileWidth) / 2f)),
				Width = (int)(TileHeight * Scale),
				Height = (int)(TileWidth * Scale)
			};

			mSpriteBatch.Draw(Texture, destinationRectangle, srcRectangle, Color.White);
		}


		public bool IsMoving() {
			return !(mAmount == 1f);
		}

		public void SetMove(Vector2 desPosition) {
			mPointA = mPosition;
			mPointB = desPosition;
			mAmount = 0f;
		}

	}

}