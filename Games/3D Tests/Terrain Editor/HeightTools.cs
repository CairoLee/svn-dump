using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Ragnarok3D.Editor {
	public partial class HeightTools : Form {
		public Tool currentTool = Tool.Select;
		public enum Tool {
			Select,
			Raise,
			Lower,
			Smooth,
			Flatten
		}

		MouseState ms;
		Heightmap heightmap;

		bool bHeightSet = false;

		public HeightTools( Heightmap myHeightmap ) {
			heightmap = myHeightmap;
			InitializeComponent();
		}

		private void HeightTools_Load( object sender, EventArgs e ) {
			ResetToolSelection( Tool.Select );
			SlideCursorSize.Value = heightmap.groundCursorSize;
			SlideCursorForce.Value = heightmap.groundCursorStrength;
			Editor.heightmap.bShowCursor = true;
			timer1.Start();
		}

		private void SelectTool( Tool tool ) {
			ResetToolSelection( tool );

			switch( tool ) {
				case Tool.Select:
					currentTool = Tool.Select;
					break;
				case Tool.Raise:
					currentTool = Tool.Raise;
					break;
				case Tool.Lower:
					currentTool = Tool.Lower;
					break;
				case Tool.Smooth:
					currentTool = Tool.Smooth;
					break;
				case Tool.Flatten:
					currentTool = Tool.Flatten;
					break;
			}
		}

		private void ResetToolSelection( Tool tool ) {
			if( tool != Tool.Select )
				ChkArrow.Checked = false;
			if( tool != Tool.Raise )
				ChkRaise.Checked = false;
			if( tool != Tool.Lower )
				ChkLower.Checked = false;
			if( tool != Tool.Smooth )
				ChkSmooth.Checked = false;
			if( tool != Tool.Flatten )
				ChkFlattern.Checked = false;
		}

		private void hScrollBar1_Scroll( object sender, ScrollEventArgs e ) {
			heightmap.groundCursorSize = SlideCursorSize.Value;
		}

		private void hScrollBar2_Scroll( object sender, ScrollEventArgs e ) {
			heightmap.groundCursorStrength = SlideCursorForce.Value;
		}

		//int[] vertID;
		bool bEditing = false;
		private void timer1_Tick( object sender, EventArgs e ) {
			ms = Mouse.GetState();
			//List<int> TriangleList = new List<int>();

			int o = 0;

			Ray pickRay = Editor.heightmap.GetPickRay();
			float rayLength = 0f;
			float? rayLengthParent;

			//TODO: Use a QuadTree
			if( ms.MiddleButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed ) {
				o += 1;
			}

			//if (heightmap.quadTree != null)
			heightmap.quadTree.boundingBox.Intersects( ref pickRay, out rayLengthParent );

			if( rayLengthParent == null ) {
				o += 1;
			} else
			//if (MathExtra.Intersects(pickRay, heightmap.quadTree.BoundingCoordinates.LowerRight, heightmap.quadTree.BoundingCoordinates.UpperRight, heightmap.quadTree.BoundingCoordinates.UpperLeft, Vector3.Up, true, false, out rayLengthParent) || MathExtra.Intersects(pickRay, heightmap.quadTree.BoundingCoordinates.LowerRight, heightmap.quadTree.BoundingCoordinates.UpperLeft, heightmap.quadTree.BoundingCoordinates.LowerLeft, Vector3.Up, true, false, out rayLengthParent))
            {
				Vector3 rayTargetParent = pickRay.Position + pickRay.Direction * (float)rayLengthParent;
				if( rayLengthParent >= 0f ) {
					//Parse Quadtree based on rayTarget.Position
					//                    List<int> TriangleList = heightmap.quadTree.GetTriangleIndexes(heightmap.quadTree.NodeList[0], rayTargetParent.X, rayTargetParent.Z);
					List<int> TriangleList = new List<int>();
					heightmap.quadTree.GetTriangleIndexes( heightmap.quadTree.NodeList[ 0 ], ref TriangleList, ref pickRay );

					if( Editor.camera.state == Camera.State.Fixed ) {

						//for (int i = 0; i < heightmap.triangle.Length; i++)
						foreach( int i in TriangleList ) {

							Heightmap.Tri thisTri = heightmap.triangle[ i ];
							//heightmap.testTriangle[6].SetNewCoordinates(thisTri.p1, thisTri.p2, thisTri.p3, Microsoft.Xna.Framework.Graphics.Color.Pink);
							if( MathExtra.Intersects( pickRay, thisTri.p1, thisTri.p2, thisTri.p3, thisTri.normal, false, true, out rayLength ) ) {
								//heightmap.testTriangle[6].SetNewCoordinates(thisTri.p1, thisTri.p2, thisTri.p3, Microsoft.Xna.Framework.Graphics.Color.Red);

								Vector3 rayTarget = pickRay.Position + pickRay.Direction * rayLength;
								heightmap.groundCursorPosition.X = rayTarget.X / ( heightmap.size.X * heightmap.cellSize.X );
								heightmap.groundCursorPosition.Y = rayTarget.Y;
								heightmap.groundCursorPosition.Z = rayTarget.Z / ( heightmap.size.Y * heightmap.cellSize.Y );

								if( rayLength > 0f ) {
									if( ms.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed ) {
										bEditing = true;

										switch( currentTool ) {
											case Tool.Raise:
												heightmap.RiseHeight( thisTri.id );
												break;
											case Tool.Lower:
												heightmap.LowerHeight( thisTri.id );
												break;
											case Tool.Smooth:
												heightmap.Smooth( thisTri.id );
												break;
											case Tool.Flatten:
												if( !bHeightSet ) {
													heightmap.flattenHeight = heightmap.groundCursorPosition.Y;
													bHeightSet = true;
												}
												heightmap.FlattenVertices( thisTri.id );
												break;
										}
									} else if( bHeightSet )
										bHeightSet = false;
								}
								break;
							}
						}
					}


				}
			}





			if( bEditing && ms.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Released ) {
				bEditing = false;
				Editor.heightmap.CalculateNormals();
				//Game1.heightmap.CalculateLightmapNormals();

				//Game1.heightmap.GenerateNormals();
			}
		}

		private void checkBox1_CheckedChanged( object sender, EventArgs e ) {
			if( ChkArrow.Checked == true )
				SelectTool( Tool.Select );
		}

		private void checkBox2_CheckedChanged( object sender, EventArgs e ) {
			if( ChkRaise.Checked == true )
				SelectTool( Tool.Raise );
		}

		private void checkBox3_CheckedChanged( object sender, EventArgs e ) {
			if( ChkLower.Checked == true )
				SelectTool( Tool.Lower );
		}

		private void checkBox4_CheckedChanged( object sender, EventArgs e ) {
			if( ChkSmooth.Checked == true )
				SelectTool( Tool.Smooth );
		}

		private void checkBox5_CheckedChanged( object sender, EventArgs e ) {
			if( ChkFlattern.Checked == true )
				SelectTool( Tool.Flatten );
		}

		protected override void OnClosed( EventArgs e ) {
			heightmap.bShowCursor = false;
			base.OnClosed( e );
		}
	}
}