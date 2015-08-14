using System.Collections.Generic;
using FinalSoftware.Games.Defender.Library.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections;

namespace FinalSoftware.Games.Defender.Library.Units {

	public class Unit : IDefenderDraw {
		protected Crossroad mDestination;
		protected Vector2 mPosition;
		protected Vector2 mOffset;
		protected Vector2 mMovement;
		protected float mToMove;
		protected float mSpeed;
		protected float mDSpeed;
		protected int mTier;

		protected Texture2D texLiving;
		protected Texture2D texDead;
		protected Texture2D currentTex;
		protected Color mTint;

		protected int mMaxHealth;
		protected int mHealth;
		protected int mMoney;
		protected int mArmor;
		protected float mScale;

		protected Dictionary<string, UnitEffect> mUnitEffects = new Dictionary<string, UnitEffect>();


		public float Scale {
			get { return mScale; }
			set { mScale = value; }
		}

		public Vector2 Center {
			get { return new Vector2( mPosition.X + Rectangle.Width / 2, mPosition.Y + Rectangle.Height / 2 ); }
		}

		public bool Lost {
			get { return ( mDestination == null ); }
		}

		public bool Dead {
			get { return ( mHealth == -1 ); }
		}

		public int Money {
			get { return mMoney; }
		}

		public int Health {
			get { return mHealth; }
		}

		public float HealthPercent {
			get { return ( (float)mHealth / (float)mMaxHealth ); }
		}

		public int Tier {
			get { return mTier; }
		}

		public Vector2 Position {
			get { return mPosition; }
			set { mPosition = value; }
		}

		public Rectangle Rectangle {
			get { return new Rectangle( (int)mPosition.X, (int)mPosition.Y, (int)( currentTex.Width * mScale ), (int)( currentTex.Height * mScale ) ); }
		}

		public Vector2 Movement {
			get { return mMovement; }
		}

		public Crossroad Destination {
			get { return mDestination; }
		}

		public Vector2 Offset {
			get { return mOffset; }
		}

		public Texture2D Texture {
			get { return currentTex; }
		}

		public float Speed {
			get { return mSpeed; }
			set { mSpeed = value; }
		}

		public float DSpeed {
			get { return mDSpeed; }
			set { mDSpeed = value; }
		}

		public Color Color {
			get { return mTint; }
			set { mTint = value; }
		}

		public int Armor {
			get { return mArmor; }
			set { mArmor = value; }
		}


		public Unit( Crossroad spawn, Vector2 offset, Vector2 movement, float speed, int tier, Texture2D textureLiving, Texture2D textureDead, int value, int maxHP, int armor ) {
			mDestination = spawn;
			mPosition = spawn.Position + offset;

			mOffset = offset;
			mMovement = movement;
			mSpeed = speed;
			mDSpeed = speed;
			mTier = tier;
			texLiving = textureLiving;
			texDead = textureDead;
			mMoney = value;
			currentTex = textureLiving;

			mTint = Color.White;
			mScale = 0.4f;

			mHealth = maxHP;
			mMaxHealth = maxHP;
			mArmor = armor;
		}

		public Unit( Crossroad spawn, Vector2 offset, Vector2 movement, float speed, int tier, Texture2D textureLiving, Texture2D textureDead, int value, int maxHP )
			: this( spawn, offset, movement, speed, tier, textureLiving, textureDead, value, maxHP, 0 ) {
		}


		public virtual void Initialize() {
		}

		public virtual void LoadContent() {
		}

		public virtual void Update( GameTime time ) {
			ArrayList keysToRemove = UpdateEffects( time );
			RemoveEffects( keysToRemove );

			Move();
			if( Lost ) {
				DefenderWorld.Instance.CreateAnimation( "explosion", mPosition, 1.0f, 0, 16.0f );
				DefenderWorld.Instance.Status.Survived += 1;
				Die();
			}
		}

		public virtual void Draw( GameTime gameTime, SpriteBatch spriteBatch, SpriteBatch additiveBatch ) {
			Color unitColor = new Color( 255, (byte)( HealthPercent * 255 ), (byte)( HealthPercent * 255 ), 150 );

			spriteBatch.Draw( Texture, Position, null, Color, 0, Vector2.Zero, Scale, SpriteEffects.None, 0 );
			//spriteBatch.Draw( Texture, Position, null, unitColor, 0, Vector2.Zero, Scale, SpriteEffects.None, 0 );

			if( Dead )
				return;

			// Health as number
			/*
			string healthPerc = mHealth.ToString();
			Vector2 hpSize = DefenderWorld.Instance.Interface.Font.MeasureString( healthPerc ) * 0.2f;
			hpSize = new Vector2( (int)( Position.X + ( Rectangle.Width / 2 ) - hpSize.X / 2 ), (int)( Position.Y + Rectangle.Height - 13 ) );
			spriteBatch.DrawString( DefenderWorld.Instance.Interface.Font, healthPerc, hpSize, Color.Black, 0, Vector2.Zero, 0.2f, SpriteEffects.None, 0 );
			*/

			// Health as line
			Rectangle size = new Rectangle( (int)Position.X, (int)Position.Y + Rectangle.Height, Rectangle.Width, 2 );
			int healthAmount = (int)( HealthPercent * 100 );
			if( healthAmount < 100 ) {
				// red background
				int temp = (int)( (float)Rectangle.Width / 100 * healthAmount );
				size.X += temp;
				size.Width -= temp;
				spriteBatch.Draw( DefenderWorld.Instance.Interface.texBlank, size, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 0 );
			}
			// green line
			size.X = (int)Position.X;
			size.Width = Rectangle.Width - (int)( (float)Rectangle.Width / 100 * ( 100 - healthAmount ) );
			spriteBatch.Draw( DefenderWorld.Instance.Interface.texBlank, size, null, Color.LightGreen, 0, Vector2.Zero, SpriteEffects.None, 0 );
		}


		public virtual void Damage( int dmg, EUnitDamageType dType ) {
			mHealth -= RealDamage( dmg, dType );
			if( mHealth <= 0 )
				Die();
		}

		public void Die() {
			mHealth = -1;
			currentTex = texDead;
			mMovement = Vector2.Zero;
			DefenderWorld.Instance.CreateAnimation( "explosion1", mPosition, 0.4f, 0, 20.0f );
			DefenderWorld.Instance.PlaySound( "explosion", mPosition );
		}

		#region Effect Handling
		public void AddEffect( string name, UnitEffect effect ) {
			if( !mUnitEffects.ContainsKey( name ) )
				mUnitEffects.Add( name, effect );
		}

		protected ArrayList UpdateEffects( GameTime time ) {
			ArrayList keysToRemove = new ArrayList();

			foreach( KeyValuePair<string, UnitEffect> kvp in mUnitEffects ) {
				if( kvp.Value != null ) {
					if( kvp.Value.IsValid( time ) ) {
						if( time.TotalGameTime.Milliseconds <= 16 ) {
							kvp.Value.ApplyEffects( this );

						}
					} else {
						keysToRemove.Add( kvp.Key );
						kvp.Value.UndoEffect( this );

					}
				}
			}
			return keysToRemove;
		}

		protected void RemoveEffects( ArrayList keys ) {
			for( int i = 0; i < keys.Count; i++ )
				mUnitEffects.Remove( (string)keys[ i ] );
		}
		#endregion

		protected virtual int RealDamage( int dmg, EUnitDamageType dType ) {
			switch( dType ) {
				case EUnitDamageType.Pierce:
					dmg = (int)( 1.5 * dmg );
					break;
				case EUnitDamageType.Energy:
					dmg = (int)( 0.5 * dmg );
					break;
				default:
					break;
			}
			return dmg;
		}

		protected virtual void Move() {
			if( mPosition == mDestination.Position + mOffset || Overshot() ) {
				ChangeMovement();
				return;
			}

			mPosition += mMovement * mSpeed;
		}

		protected virtual bool Overshot() {
			if( ( mToMove -= mSpeed ) < 0 )
				return true;
			return false;
		}

		protected virtual void ChangeMovement() {
			mDestination = mDestination.RandomConnection;
			if( mDestination == null ) {
				mMovement = Vector2.Zero;
				return;
			}

			mMovement = mDestination.Position + mOffset - mPosition;
			mToMove = mMovement.Length();
			mMovement.Normalize();

			mTier = mDestination.Tier;
		}


		public virtual float GetDistance( Vector2 TargetCenter ) {
			return ( Center - TargetCenter ).Length();
		}

	}

}
