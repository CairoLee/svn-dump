using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace Engine3DFromRiemersTutorial {
	public class DemoBase : Game {
		protected GraphicsDeviceManager graphics;
		public DemoBase() {
			graphics = new GraphicsDeviceManager( this );
			Content.RootDirectory = "Content";
		}

		protected override void Initialize() {
			graphics.PreferredBackBufferWidth = 800;
			graphics.PreferredBackBufferHeight = 600;
			graphics.IsFullScreen = false;

			graphics.ApplyChanges();

			base.Initialize();
		}

		protected override void Update( GameTime gameTime ) {
			KeyboardState state = Keyboard.GetState();
			Keys[] keys = state.GetPressedKeys();

			if( keys.Contains( Keys.F12 ) )
				Screenshot();

			if( state.IsKeyDown( Keys.Space ) )
				this.GraphicsDevice.RenderState.FillMode = ( this.GraphicsDevice.RenderState.FillMode == FillMode.WireFrame ? FillMode.Solid : FillMode.WireFrame );

			if( state.IsKeyDown( Keys.Escape ) )
				this.Exit();

			base.Update( gameTime );
		}

		private void Screenshot() {
			using( ResolveTexture2D screenshot = new ResolveTexture2D( graphics.GraphicsDevice, graphics.GraphicsDevice.PresentationParameters.BackBufferWidth, graphics.GraphicsDevice.PresentationParameters.BackBufferHeight, 1, SurfaceFormat.Color ) ) {
				GraphicsDevice.ResolveBackBuffer( screenshot );

				screenshot.Save( "screenshot.jpg", ImageFileFormat.Jpg );
			}
		}
	}


	public class Engine3DTest : DemoBase {

		public Engine3DTest() {
			Components.Add( new Fps( this ) );
		}

		protected override void Initialize() {

			Window.Title = "3D Engine Test";
			var waterLevel = 5.9f;
			var cam = new RiemersFirstPersonCamera( this );
			var pm = new HeightMapPerlin( this, 64, 64, 4.9f, 28.5f, 10, 0.7f, 4 );
			var hmm = new HeightMapMirror( pm );
			var hm = new HeightMapIslandTrim( hmm, 25.0f, waterLevel - 1.0f, 0.5f, IslandShape.Circle, IslandTrimMethod.Ditch );
			hm.Landformations.Add( new LandformVolcano( new Point( 34, 64 ), 29, 35 ) );
			hm.Landformations.Add( new LandformCrater( new Point( 45, 35 ), 12 ) );
			var terrain = new Terrain( this, hm, cam );
			var noise = new EffectPerlinNoise( this );
			var sky = new EffectSkyDome( this, cam, noise );
			//var trees = new TextureTrees( this, cam, terrain );
			var bg = new ClearComponent( this );
			var refractionMap = new RefractionMap( this, cam, waterLevel );
			refractionMap.RenderedComponents.Add( terrain );

			var reflectionMap = new ReflectionMap( this, cam, waterLevel );
			reflectionMap.RenderedComponents.Add( bg );
			reflectionMap.RenderedComponents.Add( sky );
			reflectionMap.RenderedComponents.Add( terrain );
			//reflectionMap.RenderedComponents.Add( trees );

			var water = new EffectWater( this, cam, terrain, reflectionMap, refractionMap );

			Components.Add( noise );
			Components.Add( cam );
			Components.Add( refractionMap );
			Components.Add( reflectionMap );
			Components.Add( bg );
			Components.Add( sky );
			Components.Add( terrain );
			Components.Add( new Environment( this ) );
			Components.Add( water );
			//Components.Add( trees );

			base.Initialize();
		}

	}




}
