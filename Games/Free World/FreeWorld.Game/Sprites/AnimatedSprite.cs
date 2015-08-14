#if false
using System;
using System.Collections.Generic;
using System.Text;
using FreeWorld.Engine.Compontents.Input;
using FreeWorld.Engine.TileEngine;
using GodLesZ.Library.Xna.Geometry;
using GodLesZ.Library.Xna.Geometry;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using FreeWorld.Engine;
using FreeWorld.Engine.Compontents;
using FreeWorld.Game.Objects;
using DrawHelper = FreeWorld.Engine.Tools.DrawHelper;

namespace FreeWorld.Game {

	public class AnimatedSprite {

		private Vector2 mPosition = Vector2.Zero;
		private Vector2 mOriginOffset = Vector2.Zero;
		private Vector2 mFinalPosition = Vector2.Zero;
		private EDirection mCurrentDirection = EDirection.Down;
		private bool mIsAnimating = true;
		private Texture2D mTexture;
		private static Texture2D mTextureShadow;
		private bool mDrawShadow = true;
		private float mRadius = 2f;
		private float mSpeed = 2f;
		private bool mPermMove = false;

		private Character mCharacter;

		private Texture2D healthBarHP = null;
		private Texture2D healthBarSP = null;
		private Texture2D healthBarBorder = null;


		public Dictionary<EDirection, FrameAnimation> Animations {
			get;
			set;
		}

		public Vector2 Position {
			get { return mPosition; }
			set { mPosition = value; }
		}

		public Vector2 OriginOffset {
			get { return mOriginOffset; }
			set { mOriginOffset = value; }
		}

		public Vector2 FinalPosition {
			get { return mFinalPosition; }
			set {
				mFinalPosition = value;
				GetCurrentDirection();
			}
		}

		public Vector2 Origin {
			get { return Position + OriginOffset; }
		}

		public Vector2 Center {
			get { return Position + new Vector2( CurrentAnimation.CurrentRect.Width / 2, CurrentAnimation.CurrentRect.Height / 2 ); }
		}

		public Rectangle Bounds {
			get { return new Rectangle( (int)Position.X, (int)Position.Y, CurrentAnimation.CurrentRect.Width, CurrentAnimation.CurrentRect.Height ); }
		}

		public float Speed {
			get { return mSpeed; }
			set { mSpeed = (float)Math.Max( value, 0.1f ); }
		}

		public float CollisionRadius {
			get { return mRadius; }
			set { mRadius = (float)Math.Max( value, 1f ); }
		}

		public bool IsAnimating {
			get { return mIsAnimating; }
			set { mIsAnimating = value; }
		}

		public FrameAnimation CurrentAnimation {
			get { return Animations[ mCurrentDirection ]; }
		}

		public EDirection CurrentDirection {
			get { return mCurrentDirection; }
			set {
				if( Animations.ContainsKey( value ) )
					mCurrentDirection = value;
			}
		}

		public Texture2D Texture {
			get { return mTexture; }
			set { mTexture = value; }
		}

		public static Texture2D TextureShadow {
			get { return mTextureShadow; }
			set { mTextureShadow = value; }
		}

		public bool DrawShadow {
			get { return mDrawShadow; }
			set { mDrawShadow = value; }
		}

		public bool PermMove {
			get { return mPermMove; }
			set { mPermMove = value; }
		}

		public Character Character {
			get { return mCharacter; }
			set { mCharacter = value; }
		}


		public AnimatedSprite()
			: this( null, null ) {
		}

		public AnimatedSprite( Texture2D Texture )
			: this( null, Texture ) {
		}

		public AnimatedSprite( Character Char )
			: this( Char, null ) {
		}

		public AnimatedSprite( Character Char, Texture2D Texture ) {
			mCharacter = Char;
			if( Texture == null && Char != null )
				mTexture = EngineCore.ContentLoader.GetCharacter( mCharacter.GetTextureName() );
			else
				mTexture = Texture;
			Animations = new Dictionary<EDirection, FrameAnimation>();
			mPosition = Vector2.Zero;
			mOriginOffset = Vector2.Zero;
			mFinalPosition = Vector2.Zero;

			// Basic Animations
			Animations.Add( EDirection.Down, new FrameAnimation( 4, Constants.CharTileWidth, Constants.CharTileHeight, 0, 0, 7 ) );
			Animations.Add( EDirection.Left, new FrameAnimation( 4, Constants.CharTileWidth, Constants.CharTileHeight, 0, Constants.CharTileHeight, 7 ) );
			Animations.Add( EDirection.Right, new FrameAnimation( 4, Constants.CharTileWidth, Constants.CharTileHeight, 0, Constants.CharTileHeight * 2, 7 ) );
			Animations.Add( EDirection.Up, new FrameAnimation( 4, Constants.CharTileWidth, Constants.CharTileHeight, 0, Constants.CharTileHeight * 3, 7 ) );

			if( mTextureShadow == null )
				mTextureShadow = EngineCore.ContentLoader.Load<Texture2D>( "shadow" );
		}



		public static bool AreColliding( AnimatedSprite a, AnimatedSprite b ) {
			Vector2 d = b.Origin - a.Origin;

			return ( d.Length() < b.CollisionRadius + a.CollisionRadius );
		}


		public Point2D GetFootCell() {
			Point2D cell = DrawHelper.Vector2ToEngineCell( mPosition );
			cell.Y++;
			return cell;
		}

		public Vector2 GetFootPosition() {
			Point2D cell = DrawHelper.Vector2ToEngineCell( mPosition );
			cell.Y++;
			return DrawHelper.EngineCellToVector( cell );
		}


		public void ResetFrame() {
			if( CurrentAnimation == null )
				return;

			// reset Frame to always display first Image from Animation
			System.Diagnostics.Debug.WriteLine( "reset frame on " + CurrentAnimation.CurrentFrame + "/" + CurrentAnimation.FrameCount );
			CurrentAnimation.CurrentFrame = 0;
		}

		public void RefreshTexture() {
			if( mCharacter == null )
				return;
			mTexture = EngineCore.ContentLoader.GetCharacter( mCharacter.GetTextureName() );
		}

		public void ClampToArea( int width, int height ) {
			if( mPosition.X < 0 )
				mPosition.X = 0;
			if( mPosition.Y < 0 )
				mPosition.Y = 0;

			if( mPosition.X > width - CurrentAnimation.CurrentRect.Width )
				mPosition.X = width - CurrentAnimation.CurrentRect.Width;

			if( mPosition.Y > height - CurrentAnimation.CurrentRect.Height )
				mPosition.Y = height - CurrentAnimation.CurrentRect.Height;
		}


		public virtual void Update( GameTime gameTime ) {
			Update( gameTime, null, false );
		}

		public virtual void Update( GameTime gameTime, TileMap tileMap, bool HandleInput ) {
			if( Animations.Count == 0 )
				return;

			if( mFinalPosition == mPosition && HandleInput == true && tileMap != null ) {
				EDirection move = EDirection.None;
				if( EngineCore.InputHelper.IsActionPressed( EActions.MoveUp ) )
					move = EDirection.Up;
				if( EngineCore.InputHelper.IsActionPressed( EActions.MoveDown ) )
					move = EDirection.Down;
				if( EngineCore.InputHelper.IsActionPressed( EActions.MoveLeft ) )
					move = EDirection.Left;
				if( EngineCore.InputHelper.IsActionPressed( EActions.MoveRight ) )
					move = EDirection.Right;

				if( move != EDirection.None )
					TryMove( move, tileMap );
			}


			UpdatePosition();
			UpdateAnimation( gameTime );
		}


		public void Draw( SpriteBatch spriteBatch, SpriteFont spriteFont ) {
			Draw( spriteBatch, spriteFont, false );
		}

		public void Draw( SpriteBatch spriteBatch, SpriteFont spriteFont, bool DrawAttributes ) {
			FrameAnimation animation = CurrentAnimation;
			if( animation == null )
				return;

			if( mDrawShadow == true ) {
				Vector2 footPos = mPosition + new Vector2( 1f, Constants.TileHeight + 5f );
				spriteBatch.Draw( mTextureShadow, footPos, new Color(new Vector4( Color.White.ToVector3(), 0.75f) ) );
			}

			spriteBatch.Draw( mTexture, mPosition, animation.CurrentRect, Color.White );

			if( DrawAttributes == true )
				DrawTestAttributes( spriteBatch, spriteFont );
		}


		private void DrawTestAttributes( SpriteBatch spriteBatch, SpriteFont spriteFont ) {
			if( mCharacter == null )
				return;

			if( healthBarHP == null ) {
				healthBarHP = DrawHelper.Rect2Texture( CurrentAnimation.CurrentRect.Width, 4, 2, Color.Red );
				healthBarSP = DrawHelper.Rect2Texture( CurrentAnimation.CurrentRect.Width, 4, 2, Color.Blue );
				healthBarBorder = DrawHelper.Rect2Texture( CurrentAnimation.CurrentRect.Width + 2, 6, 1, Color.Black );
			}

			Vector2 barPos = mPosition + new Vector2( 0f, CurrentAnimation.CurrentRect.Height + 1f ); // start 1px below Bottom Bound (mostly feets)
			Vector2 namePos = new Vector2( mPosition.X + ( CurrentAnimation.CurrentRect.Width / 2 ) - ( spriteFont.MeasureString( mCharacter.Name ).X / 2 ), mPosition.Y ); // BottomLeft Corner + half Width (=Bottom Center) - NameLength / 2 (=Bottom Center)
			namePos.Y -= spriteFont.MeasureString( mCharacter.Name ).Y;

			// fixxing ugly swimming Names by forcing integer
			namePos.X = Math.Max( 0, (int)namePos.X );
			namePos.Y = Math.Max( 0, (int)namePos.Y );

			spriteBatch.DrawStringShadowed( spriteFont, mCharacter.Name, namePos, Color.DarkBlue, Color.White );

			int hpPct = (int)( ( (float)mCharacter.Status.Hp / (float)mCharacter.Status.MaxHp ) * healthBarHP.Width );
			int SpPct = (int)( ( (float)mCharacter.Status.Mp / (float)mCharacter.Status.MaxMp ) * healthBarSP.Width );
			spriteBatch.Draw( healthBarBorder, new Rectangle( (int)barPos.X, (int)barPos.Y, healthBarBorder.Width, healthBarBorder.Height ), Color.White );
			spriteBatch.Draw( healthBarHP, new Rectangle( (int)barPos.X + 1, (int)barPos.Y + 1, hpPct, healthBarHP.Height ), Color.White );
			spriteBatch.Draw( healthBarBorder, new Rectangle( (int)barPos.X, (int)barPos.Y + healthBarBorder.Height + 1, healthBarBorder.Width, healthBarBorder.Height ), Color.White );
			spriteBatch.Draw( healthBarSP, new Rectangle( (int)barPos.X + 1, (int)barPos.Y + healthBarBorder.Height + 1 + 1, SpPct, healthBarSP.Height ), Color.White );

		}


		private void TryMove( EDirection MoveDir, TileMap TileMap ) {
			Point2D newCell = DrawHelper.Vector2ToEngineCell( mPosition ) + MoveDir.ToPoint2D();

			mCurrentDirection = MoveDir;
			if( EngineCore.InputHelper.IsKeyDown( Microsoft.Xna.Framework.Input.Keys.LeftShift ) == true )
				return; // no move, only Dir Change 

			if( CanMove( newCell, TileMap ) == false )
				return;

			if( Character != null )
				Character.Move( newCell );
			mFinalPosition = DrawHelper.EngineCellToVector( newCell );
		}

		#region private Helper
		private bool CanMove( Point2D cell, TileMap tileMap ) {
			if( cell.Y < 0 || cell.X < 0 || cell.X >= tileMap.Width - 1 || cell.Y >= tileMap.Height - 1 )
				return false;

			cell.Y++; // so we check the "Foot Cell"
			return ( tileMap.CollisionLayer.GetCell( cell ) & ECollisionType.Moveable ) == ECollisionType.Moveable;
		}

		private void UpdatePosition() {
			if( mPosition == mFinalPosition ) {
				if( PermMove == false && IsAnimating == true ) // first stop, reset Frames
					ResetFrame();
				IsAnimating = PermMove; // stop animation, but keep moving if PermMove
				return;
			}

			bool reached = false;
			switch( mCurrentDirection ) {
				case EDirection.Up:
					mPosition.Y -= mSpeed;
					reached = ( mPosition.Y <= mFinalPosition.Y );
					break;
				case EDirection.Down:
					mPosition.Y += mSpeed;
					reached = ( mPosition.Y >= mFinalPosition.Y );
					break;
				case EDirection.Left:
					mPosition.X -= mSpeed;
					reached = ( mPosition.X <= mFinalPosition.X );
					break;
				case EDirection.Right:
					mPosition.X += mSpeed;
					reached = ( mPosition.X >= mFinalPosition.X );
					break;
			}

			if( reached == false ) {
				IsAnimating = true;
				return;
			}

			mPosition = mFinalPosition = ClampToCell( mFinalPosition );
			IsAnimating = PermMove;

			//done in TryMove()
			//SaveManager.State.ActiveCharacter.Move( mCurrentDirection );
		}

		private void UpdateAnimation( GameTime gameTime ) {
			// nothing to animate ôo
			if( Animations == null || Animations.Count == 0 )
				return;

			// FinalPosition is reached & no PermMove
			if( IsAnimating == false )
				return;

			FrameAnimation animation = CurrentAnimation;
			if( animation == null ) {
				mCurrentDirection = EDirection.Down;
				animation = CurrentAnimation;
			}

			animation.Update( gameTime );
		}

		private Vector2 ClampToCell( Vector2 pos ) {
			Point2D cellPoint = DrawHelper.Vector2ToEngineCell( pos );

			return DrawHelper.EngineCellToVector( cellPoint );
		}

		private void GetCurrentDirection() {
			if( mFinalPosition.X > mPosition.X )
				mCurrentDirection = EDirection.Right;
			else if( mFinalPosition.X < mPosition.X )
				mCurrentDirection = EDirection.Left;
			else if( mFinalPosition.Y > mPosition.Y )
				mCurrentDirection = EDirection.Down;
			else if( mFinalPosition.Y < mPosition.Y )
				mCurrentDirection = EDirection.Up;
			else
				mCurrentDirection = EDirection.Down; // default to down? ôo
		}
		#endregion

	}

}
#endif