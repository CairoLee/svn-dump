using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Content;

namespace GLibary {
	public partial class Utility {
		public struct VertexPosition {
			public Vector3 Position;


			public VertexPosition( Vector3 Position ) {
				this.Position = Position;
			}

			public static readonly VertexElement[] VertexElements = Utility.CreateVertexElems( new VertexMeta( VertexElementFormat.Vector3, VertexElementUsage.Position ) );

			public static int SizeInBytes {
				get {
					return VertexDeclaration.GetVertexStrideSize( VertexElements, 0 );
				}
			}

			public static VertexDeclaration GetVertexDeclaration() {
				return new VertexDeclaration( Utility.GraphicsDevice, VertexElements );
			}

		}


		public struct VertexPositionNormal {
			public Vector3 Position;
			public Vector3 Normal;

			public VertexPositionNormal( Vector3 Position, Vector3 Normal ) {
				this.Position = Position;
				this.Normal = Normal;
			}

			public static readonly VertexElement[] VertexElements =
				Utility.CreateVertexElems(
					new VertexMeta( VertexElementFormat.Vector3, VertexElementUsage.Position ),
					new VertexMeta( VertexElementFormat.Vector3, VertexElementUsage.Normal ) );

			public static int SizeInBytes {
				get {
					return VertexDeclaration.GetVertexStrideSize( VertexElements, 0 );
				}
			}

			public static VertexDeclaration GetVertexDeclaration() {
				return new VertexDeclaration( Utility.GraphicsDevice, VertexElements );
			}
		}
	}
}
