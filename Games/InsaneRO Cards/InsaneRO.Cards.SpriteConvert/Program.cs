using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using InsaneRO.Cards.Library.Formats;

namespace InsaneRO.Cards.SpriteConvert {

	public class Program {
		private static string mFilepathNew = "D:/Desktop/C# Projects/Games/Ragnarok Cards/InsaneRO.Cards.Client/Content/Mobs/";
		private static string mFilepathOld = "D:/Xampp/htdocs/wbb31/wcf/images/ragnarokCP/mobs/";

		public static void Main( string[] args ) {
			//TextWriter writer = File.CreateText( AppDomain.CurrentDomain.BaseDirectory + @"\Console.log" );
			//Console.SetOut( writer );

			string[] files = Directory.GetFiles( mFilepathOld, "*.spr" );
			for( int i = 0; i < files.Length; i++ ) {
				string fileName = Path.GetFileNameWithoutExtension( files[ i ] );
				string spriteName = files[ i ];
				string actionName = Path.GetDirectoryName( spriteName ) + "\\" + fileName + ".act";

				Console.Write( "parse " + fileName + ".." );

				RoSprite spr = new RoSprite();
				RoAction act = new RoAction();
				bool result = false;
				try {
					result = spr.Read( spriteName );
				} catch {
					result = false;
				}
				if( result == false ) {
					Console.WriteLine( " -- sprite FAILED" );
					continue;
				}


				try {
					result = act.Read( actionName );
				} catch {
					result = false;
				}
				if( result == false ) {
					Console.WriteLine( " -- action FAILED" );
					continue;
				}

				if( spr.Compressed == false )
					Console.WriteLine( " [uncompressed]" );

				RagnarokAnimation ani = CreateAnimation( spr, act );
				ani.Write( mFilepathNew + fileName + ".ani", true );

				Console.WriteLine();
			}

			Console.WriteLine( "\n\ndone " + files.Length + " files" );
			//writer.Dispose();
			Console.Read();

		}


		private static RagnarokAnimation CreateAnimation( RoSprite spr, RoAction act ) {
			RagnarokAnimation ani = new RagnarokAnimation();
			ani.Images = new List<RagnarokAnimationImage>();
			for( int i = 0; i < spr.Images.Count; i++ ) {
				RagnarokAnimationImage img = new RagnarokAnimationImage();
				byte[] data = spr.Images[ i ].Data;
				if( spr.Compressed == false )
					data = InsaneRO.Cards.Library.Cryptic.RLE.Encode( data );

				img.Width = spr.Images[ i ].Width;
				img.Height = spr.Images[ i ].Height;
				img.Size = data.Length;
				img.Data = data;

				ani.Images.Add( img );
			}

			ani.Palette = new RagnarokAnimationPalette( spr.Palette.Count );
			for( int i = 0; i < spr.Palette.Count; i++ )
				ani.Palette.Add( new Microsoft.Xna.Framework.Graphics.Color( spr.Palette[ i ].R, spr.Palette[ i ].G, spr.Palette[ i ].B ) );

			ani.Actions = new RagnarokAnimationActionList();
			for( int i = 0; i < act.Actions.Count; i++ ) {
				RagnarokAnimationAction action = new RagnarokAnimationAction();
				action.Frames = new RagnarokAnimationActionFrameList();
				for( int f = 0; f < act.Actions[ i ].Frames.Count; f++ ) {
					RagnarokAnimationActionFrame frame = new RagnarokAnimationActionFrame();
					frame.Images = new RagnarokAnimationActionFrameImageList();
					frame.Palette1 = act.Actions[ i ].Frames[ f ].Palette1;
					frame.Palette2 = act.Actions[ i ].Frames[ f ].Palette2;
					frame.Audio = act.Actions[ i ].Frames[ f ].Audio;
					frame.Numxxx = act.Actions[ i ].Frames[ f ].Numxxx;
					if( frame.Numxxx == 1 ) {
						frame.Ext1 = act.Actions[ i ].Frames[ f ].Ext1;
						frame.ExtX = act.Actions[ i ].Frames[ f ].ExtX;
						frame.ExtY = act.Actions[ i ].Frames[ f ].ExtY;
						frame.Terminate = act.Actions[ i ].Frames[ f ].Terminate;
					}

					for( int s = 0; s < act.Actions[ i ].Frames[ f ].Sprites.Count; s++ ) {
						RagnarokAnimationActionFrameImage img = new RagnarokAnimationActionFrameImage() {
							X = (short)act.Actions[ i ].Frames[ f ].Sprites[ s ].X,
							Y = (short)act.Actions[ i ].Frames[ f ].Sprites[ s ].Y,
							Number = (ushort)act.Actions[ i ].Frames[ f ].Sprites[ s ].Number,
							Mirror = ( act.Actions[ i ].Frames[ f ].Sprites[ s ].Mirror > 0 ),
							Color = new Microsoft.Xna.Framework.Graphics.Color( act.Actions[ i ].Frames[ f ].Sprites[ s ].ColorR, act.Actions[ i ].Frames[ f ].Sprites[ s ].ColorG, act.Actions[ i ].Frames[ f ].Sprites[ s ].ColorB, 255 - act.Actions[ i ].Frames[ f ].Sprites[ s ].ColorA ),
							ScaleX = act.Actions[ i ].Frames[ f ].Sprites[ s ].ScaleX,
							ScaleY = act.Actions[ i ].Frames[ f ].Sprites[ s ].ScaleY,
							Rotation = (short)act.Actions[ i ].Frames[ f ].Sprites[ s ].Rotation,
							Type = (short)act.Actions[ i ].Frames[ f ].Sprites[ s ].Type,
							Width = (ushort)act.Actions[ i ].Frames[ f ].Sprites[ s ].Width,
							Height = (ushort)act.Actions[ i ].Frames[ f ].Sprites[ s ].Height,
						};

						// fixxes
						if( act.Actions[ i ].Frames[ f ].Sprites[ s ].ScaleXY != 0 ) {
							img.ScaleX = act.Actions[ i ].Frames[ f ].Sprites[ s ].ScaleXY;
							img.ScaleY = act.Actions[ i ].Frames[ f ].Sprites[ s ].ScaleXY;
						}
						if( img.Width == 0 || img.Height == 0 ) {
							int num = (int)act.Actions[ i ].Frames[ f ].Sprites[ s ].Number;
							img.Width = ani.Images[ num ].Width;
							img.Height = ani.Images[ num ].Height;
						}

						frame.Images.Add( img );
					}
					action.Frames.Add( frame );
				}
				ani.Actions.Add( action );
			}

			// sounds
			ani.ActionSounds = new List<string>();
			for( int i = 0; i < act.Sounds.Count; i++ )
				ani.ActionSounds.Add( act.Sounds[ i ].Trim() );

			return ani;
		}

	}

}
