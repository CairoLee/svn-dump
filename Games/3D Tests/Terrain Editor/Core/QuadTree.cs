using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Ragnarok3D.Editor {

	public enum NodeType {
		Leaf = 0,
		Node = 1
	}

	public struct BoundingSquare {
		public Vector3 UpperRight;
		public Vector3 UpperLeft;
		public Vector3 LowerRight;
		public Vector3 LowerLeft;
	}


	public class QuadNode {
		public NodeType Type;
		public BoundingSquare BoundingCoordinates = new BoundingSquare();
		public int[] Branches = new int[ 4 ];
		public BoundingBox boundingBox;
		public List<int> TriangleIDs = new List<int>();
		public int ID;
		public int ParentID;


		public QuadNode() {

		}
	}

	public class QuadTree {

		public float GridWidth = 257;
		public float GridHeight = 257;
		public int TotalTreeID = 0;
		public List<QuadNode> NodeList;
		public Vector2 CellSize;
		public BoundingSquare BoundingCoordinates = new BoundingSquare();
		public BoundingBox boundingBox;



		public QuadTree( float MapWidth, float MapHeight, Vector2 CellSize, Heightmap.Tri[] Triangle ) {

			this.CellSize = CellSize;

			GridWidth = MapWidth / CellSize.X;
			GridHeight = MapHeight / CellSize.Y;

			int numberOfLeaves = ( (int)GridWidth / 4 ) * ( (int)GridHeight / 4 );

			int numberOfNodes = CalcNodeNum( numberOfLeaves, 4 );
			NodeList = new List<QuadNode>( numberOfNodes );

			for( int i = 0; i < numberOfNodes; i++ ) {
				NodeList.Add( null );
			}


			Vector3 A = Vector3.Zero;
			Vector3 B = new Vector3( MapWidth, 0, 0 );
			Vector3 C = new Vector3( 0, 0, MapHeight );
			Vector3 D = new Vector3( MapWidth, 0, MapHeight );

			BoundingCoordinates.LowerLeft = A;
			BoundingCoordinates.LowerRight = B;
			BoundingCoordinates.UpperLeft = C;
			BoundingCoordinates.UpperRight = D;

			boundingBox = new BoundingBox( new Vector3( BoundingCoordinates.LowerLeft.X, Editor.heightmap.lowestPoint, BoundingCoordinates.LowerLeft.Z ), new Vector3( BoundingCoordinates.UpperRight.X, Editor.heightmap.highestPoint, BoundingCoordinates.UpperRight.Z ) );

			CreateNode( BoundingCoordinates, 0, 0, Triangle );

		}


		public int CalcNodeNum( int numberOfLeaves, int leafWidth ) {
			int counter = 0;
			int var = 0;

			while( var == 0 ) {
				counter += numberOfLeaves;
				numberOfLeaves /= leafWidth;

				if( numberOfLeaves == 1 ) { var = 1; }
			}
			counter++;

			return counter;
		}

		public void CreateNode( BoundingSquare Bounding, int ParentID, int NodeID, Heightmap.Tri[] Triangle ) {

			NodeType nodeType;
			float Width;
			float Height;


			Width = Bounding.UpperRight.X - Bounding.UpperLeft.X; //X
			Height = Bounding.UpperLeft.Z - Bounding.LowerLeft.Z; //Z

			if( Width / 2 == ( 2 * (int)CellSize.X ) ) {
				nodeType = NodeType.Leaf;
			} else {
				nodeType = NodeType.Node;
			}

			QuadNode node = new QuadNode();


			node.ID = NodeID;
			node.ParentID = ParentID;

			node.BoundingCoordinates.UpperLeft = Bounding.UpperLeft;

			node.BoundingCoordinates.UpperRight = Bounding.UpperRight;

			node.BoundingCoordinates.LowerLeft = Bounding.LowerLeft;

			node.BoundingCoordinates.LowerRight = Bounding.LowerRight;

			node.boundingBox = new BoundingBox( new Vector3( node.BoundingCoordinates.LowerLeft.X, Editor.heightmap.lowestPoint, node.BoundingCoordinates.LowerLeft.Z ), new Vector3( node.BoundingCoordinates.UpperRight.X, Editor.heightmap.highestPoint, node.BoundingCoordinates.UpperRight.Z ) );

			node.Type = nodeType;

			if( nodeType == NodeType.Leaf ) {


				int tID;
				int o = 0;
				float lowestPoint = Editor.heightmap.maxHeight;
				float highestPoint = 0f;
				for( int y = (int)node.BoundingCoordinates.LowerLeft.Z / (int)CellSize.Y; y < ( ( node.BoundingCoordinates.UpperRight.Z / CellSize.Y ) - 0 ); y++ ) {
					for( int x = (int)node.BoundingCoordinates.LowerLeft.X / (int)CellSize.X; x < ( ( node.BoundingCoordinates.UpperRight.X / CellSize.X ) - 0 ); x++ ) {
						tID = ( x + y * ( Editor.heightmap.size.X - 1 ) ) * 2;

						if( tID >= Triangle.Length - 0 ) {
							o++;
						}
						if( tID < Triangle.Length ) {
							node.TriangleIDs.Add( tID );
							node.TriangleIDs.Add( tID + 1 );

							if( Triangle[ tID ].p1.Y > highestPoint )
								highestPoint = Triangle[ tID ].p1.Y;
							if( Triangle[ tID ].p2.Y > highestPoint )
								highestPoint = Triangle[ tID ].p2.Y;
							if( Triangle[ tID ].p3.Y > highestPoint )
								highestPoint = Triangle[ tID ].p3.Y;

							if( Triangle[ tID ].p1.Y < lowestPoint )
								lowestPoint = Triangle[ tID ].p1.Y;
							if( Triangle[ tID ].p2.Y < lowestPoint )
								lowestPoint = Triangle[ tID ].p2.Y;
							if( Triangle[ tID ].p3.Y < lowestPoint )
								lowestPoint = Triangle[ tID ].p3.Y;

							if( Triangle[ tID + 1 ].p1.Y > highestPoint )
								highestPoint = Triangle[ tID + 1 ].p1.Y;
							if( Triangle[ tID + 1 ].p2.Y > highestPoint )
								highestPoint = Triangle[ tID + 1 ].p2.Y;
							if( Triangle[ tID + 1 ].p3.Y > highestPoint )
								highestPoint = Triangle[ tID + 1 ].p3.Y;

							if( Triangle[ tID + 1 ].p1.Y < lowestPoint )
								lowestPoint = Triangle[ tID + 1 ].p1.Y;
							if( Triangle[ tID + 1 ].p2.Y < lowestPoint )
								lowestPoint = Triangle[ tID + 1 ].p2.Y;
							if( Triangle[ tID + 1 ].p3.Y < lowestPoint )
								lowestPoint = Triangle[ tID + 1 ].p3.Y;

						}


					}

					//Determine the height of the bounding box for this Leaf Node
					node.boundingBox.Min.Y = lowestPoint;
					node.boundingBox.Max.Y = highestPoint;


				}

			} else {
				BoundingSquare BoundingBox = new BoundingSquare();
				TotalTreeID++;
				node.Branches[ 0 ] = TotalTreeID;

				//LowerLeft
				BoundingBox.LowerLeft = Bounding.LowerLeft;
				//LowerRight
				BoundingBox.LowerRight = Bounding.LowerLeft + ( ( Bounding.LowerRight - Bounding.LowerLeft ) / 2 );
				//UpperLeft
				BoundingBox.UpperLeft = Bounding.LowerLeft + ( ( Bounding.UpperLeft - Bounding.LowerLeft ) / 2 );
				//UpperRight
				BoundingBox.UpperRight = Bounding.LowerLeft + ( ( Bounding.LowerRight - Bounding.LowerLeft ) / 2 ) + ( ( Bounding.UpperLeft - Bounding.LowerLeft ) / 2 );

				CreateNode( BoundingBox, NodeID, TotalTreeID, Triangle );

				//Determine the height of the bounding box for this Node
				if( NodeList[ TotalTreeID ].boundingBox.Max.Y > node.boundingBox.Max.Y )
					node.boundingBox.Max.Y = NodeList[ TotalTreeID ].boundingBox.Max.Y;

				if( NodeList[ TotalTreeID ].boundingBox.Min.Y < node.boundingBox.Min.Y )
					node.boundingBox.Min.Y = NodeList[ TotalTreeID ].boundingBox.Min.Y;

				//**************************************************************************

				TotalTreeID++;
				node.Branches[ 1 ] = TotalTreeID;

				//LowerLeft
				BoundingBox.LowerLeft = Bounding.LowerLeft + ( ( Bounding.LowerRight - Bounding.LowerLeft ) / 2 );
				//LowerRight
				BoundingBox.LowerRight = Bounding.LowerRight;
				//UpperLeft
				BoundingBox.UpperLeft = Bounding.LowerLeft + ( ( Bounding.LowerRight - Bounding.LowerLeft ) / 2 ) + ( ( Bounding.UpperLeft - Bounding.LowerLeft ) / 2 );
				//UpperRight
				BoundingBox.UpperRight = Bounding.LowerLeft + ( ( Bounding.UpperLeft - Bounding.LowerLeft ) / 2 ) + ( ( Bounding.LowerRight - Bounding.LowerLeft ) );

				CreateNode( BoundingBox, NodeID, TotalTreeID, Triangle );

				//Determine the height of the bounding box for this Node
				if( NodeList[ TotalTreeID ].boundingBox.Max.Y > node.boundingBox.Max.Y )
					node.boundingBox.Max.Y = NodeList[ TotalTreeID ].boundingBox.Max.Y;

				if( NodeList[ TotalTreeID ].boundingBox.Min.Y < node.boundingBox.Min.Y )
					node.boundingBox.Min.Y = NodeList[ TotalTreeID ].boundingBox.Min.Y;

				//**************************************************************************

				TotalTreeID++;
				node.Branches[ 2 ] = TotalTreeID;

				//LowerLeft
				BoundingBox.LowerLeft = Bounding.LowerLeft + ( ( Bounding.UpperLeft - Bounding.LowerLeft ) / 2 );
				//LowerRight
				BoundingBox.LowerRight = Bounding.LowerLeft + ( ( Bounding.UpperLeft - Bounding.LowerLeft ) / 2 )
											+ ( ( Bounding.LowerRight - Bounding.LowerLeft ) / 2 );
				//UpperLeft
				BoundingBox.UpperLeft = Bounding.UpperLeft;
				//UpperRight
				BoundingBox.UpperRight = Bounding.LowerLeft + ( ( Bounding.LowerRight - Bounding.LowerLeft ) / 2 ) + ( ( Bounding.UpperLeft - Bounding.LowerLeft ) );

				CreateNode( BoundingBox, NodeID, TotalTreeID, Triangle );

				//Determine the height of the bounding box for this Node
				if( NodeList[ TotalTreeID ].boundingBox.Max.Y > node.boundingBox.Max.Y )
					node.boundingBox.Max.Y = NodeList[ TotalTreeID ].boundingBox.Max.Y;

				if( NodeList[ TotalTreeID ].boundingBox.Min.Y < node.boundingBox.Min.Y )
					node.boundingBox.Min.Y = NodeList[ TotalTreeID ].boundingBox.Min.Y;

				//**************************************************************************

				TotalTreeID++;
				node.Branches[ 3 ] = TotalTreeID;

				//LowerLeft
				BoundingBox.LowerLeft = Bounding.LowerLeft + ( ( Bounding.LowerRight - Bounding.LowerLeft ) / 2 ) + ( ( Bounding.UpperLeft - Bounding.LowerLeft ) / 2 );
				//LowerRight
				BoundingBox.LowerRight = Bounding.LowerLeft + ( ( Bounding.UpperLeft - Bounding.LowerLeft ) / 2 ) + ( ( Bounding.LowerRight - Bounding.LowerLeft ) );
				//UpperLeft
				BoundingBox.UpperLeft = Bounding.LowerLeft + ( ( Bounding.LowerRight - Bounding.LowerLeft ) / 2 ) + ( ( Bounding.UpperLeft - Bounding.LowerLeft ) );
				//UpperRight
				BoundingBox.UpperRight = Bounding.UpperRight;

				CreateNode( BoundingBox, NodeID, TotalTreeID, Triangle );

				//Determine the height of the bounding box for this Node
				if( NodeList[ TotalTreeID ].boundingBox.Max.Y > node.boundingBox.Max.Y )
					node.boundingBox.Max.Y = NodeList[ TotalTreeID ].boundingBox.Max.Y;

				if( NodeList[ TotalTreeID ].boundingBox.Min.Y < node.boundingBox.Min.Y )
					node.boundingBox.Min.Y = NodeList[ TotalTreeID ].boundingBox.Min.Y;


			}
			NodeList[ NodeID ] = node;

			//Determine the height of the bounding box for the QuadTree
			if( node.boundingBox.Max.Y > boundingBox.Max.Y )
				boundingBox.Max.Y = node.boundingBox.Max.Y;

			if( node.boundingBox.Min.Y < boundingBox.Min.Y )
				boundingBox.Min.Y = node.boundingBox.Min.Y;


			return;
		}


		public bool InsideBoundingBox( Heightmap.Tri TestTriangle, BoundingSquare Box ) {
			bool inside = false;
			if( TestTriangle.p1.X >= Box.UpperLeft.X && TestTriangle.p1.X <= Box.UpperRight.X ) {
				if( TestTriangle.p1.Z >= Box.LowerLeft.Z && TestTriangle.p1.X <= Box.UpperLeft.Z ) {
					inside = true;
				}
			}

			if( TestTriangle.p2.X >= Box.UpperLeft.X && TestTriangle.p2.X <= Box.UpperRight.X ) {
				if( TestTriangle.p2.Z >= Box.LowerLeft.Z && TestTriangle.p2.X <= Box.UpperLeft.Z ) {
					inside = true;
				}
			}

			if( TestTriangle.p3.X >= Box.UpperLeft.X && TestTriangle.p3.X <= Box.UpperRight.X ) {
				if( TestTriangle.p3.Z >= Box.LowerLeft.Z && TestTriangle.p3.X <= Box.UpperLeft.Z ) {
					inside = true;
				}
			}
			return inside;
		}

		public void GetTriangleIndexes( QuadNode ParentNode, ref List<int> tempIndexes, ref Ray ray ) {
			//List<int> tempIndexes = new List<int>();

			for( int i = 0; i < 4; i++ ) {
				QuadNode branchNode = NodeList[ ParentNode.Branches[ i ] ];

				float? rayLength;
				branchNode.boundingBox.Intersects( ref ray, out rayLength );

				//Does the Ray intersect the Bounding Box of this Node
				if( rayLength != null ) {
					if( branchNode.Type == NodeType.Node ) {
						GetTriangleIndexes( branchNode, ref tempIndexes, ref ray );
					} else {

						tempIndexes.AddRange( branchNode.TriangleIDs );


						/*
						 * These Triangles are used to draw the bounding box of the Leaf Node 
						Vector3[] corners = branchNode.boundingBox.GetCorners();
						Editor.heightmap.testTriangle[0].SetNewCoordinates(corners[0], corners[2], corners[3], Microsoft.Xna.Framework.Graphics.Color.Blue);
						Editor.heightmap.testTriangle[1].SetNewCoordinates(corners[2], corners[0], corners[1], Microsoft.Xna.Framework.Graphics.Color.Blue);

						Editor.heightmap.testTriangle[2].SetNewCoordinates(corners[1], corners[6], corners[2], Microsoft.Xna.Framework.Graphics.Color.Blue);
						Editor.heightmap.testTriangle[3].SetNewCoordinates(corners[6], corners[1], corners[5], Microsoft.Xna.Framework.Graphics.Color.Blue);

						Editor.heightmap.testTriangle[4].SetNewCoordinates(corners[4], corners[3], corners[0], Microsoft.Xna.Framework.Graphics.Color.Blue);
						Editor.heightmap.testTriangle[5].SetNewCoordinates(corners[3], corners[0], corners[7], Microsoft.Xna.Framework.Graphics.Color.Blue);
                        
						Editor.heightmap.testTriangle[7].SetNewCoordinates(corners[5], corners[7], corners[6], Microsoft.Xna.Framework.Graphics.Color.Yellow);
						Editor.heightmap.testTriangle[8].SetNewCoordinates(corners[4], corners[7], corners[5], Microsoft.Xna.Framework.Graphics.Color.Yellow);

						Editor.heightmap.testTriangle[9].SetNewCoordinates(corners[3], corners[6], corners[2], Microsoft.Xna.Framework.Graphics.Color.Yellow);
						Editor.heightmap.testTriangle[10].SetNewCoordinates(corners[7], corners[6], corners[3], Microsoft.Xna.Framework.Graphics.Color.Yellow);

						Editor.heightmap.testTriangle[11].SetNewCoordinates(corners[4], corners[1], corners[0], Microsoft.Xna.Framework.Graphics.Color.Yellow);
						Editor.heightmap.testTriangle[12].SetNewCoordinates(corners[5], corners[1], corners[4], Microsoft.Xna.Framework.Graphics.Color.Yellow);
						*/
					}
				}
			}
			return;
		}


		public void UpdateBoundingBox( QuadNode ParentNode, int TriangleID ) {
			float lowestPoint = Editor.heightmap.maxHeight;
			float highestPoint = 0f;
			UpdateBoundingBox2( ParentNode, TriangleID, ref lowestPoint, ref highestPoint );
		}
		public void UpdateBoundingBox2( QuadNode ParentNode, int TriangleID, ref float lowestPoint, ref float highestPoint ) {
			for( int i = 0; i < 4; i++ ) {
				QuadNode branchNode = NodeList[ ParentNode.Branches[ i ] ];

				if( Editor.heightmap.triangle[ TriangleID ].p1.X > branchNode.boundingBox.Min.X && Editor.heightmap.triangle[ TriangleID ].p1.X < branchNode.boundingBox.Max.X && Editor.heightmap.triangle[ TriangleID ].p1.Z > branchNode.boundingBox.Min.Z && Editor.heightmap.triangle[ TriangleID ].p1.Z < branchNode.boundingBox.Max.Z ) {
					if( branchNode.Type == NodeType.Node ) {
						UpdateBoundingBox2( branchNode, TriangleID, ref lowestPoint, ref highestPoint );

						//Update the bounding box for the Branch Nodes
						if( highestPoint > branchNode.boundingBox.Max.Y )
							branchNode.boundingBox.Max.Y = highestPoint;

						if( lowestPoint < branchNode.boundingBox.Min.Y )
							branchNode.boundingBox.Min.Y = lowestPoint;

					} else {

						foreach( int tID in branchNode.TriangleIDs ) {
							if( Editor.heightmap.triangle[ tID ].p1.Y > highestPoint )
								highestPoint = Editor.heightmap.triangle[ tID ].p1.Y;
							if( Editor.heightmap.triangle[ tID ].p2.Y > highestPoint )
								highestPoint = Editor.heightmap.triangle[ tID ].p2.Y;
							if( Editor.heightmap.triangle[ tID ].p3.Y > highestPoint )
								highestPoint = Editor.heightmap.triangle[ tID ].p3.Y;

							if( Editor.heightmap.triangle[ tID ].p1.Y < lowestPoint )
								lowestPoint = Editor.heightmap.triangle[ tID ].p1.Y;
							if( Editor.heightmap.triangle[ tID ].p2.Y < lowestPoint )
								lowestPoint = Editor.heightmap.triangle[ tID ].p2.Y;
							if( Editor.heightmap.triangle[ tID ].p3.Y < lowestPoint )
								lowestPoint = Editor.heightmap.triangle[ tID ].p3.Y;
						}

						//Update the bounding box for the Leaf Node
						branchNode.boundingBox.Max.Y = highestPoint;
						branchNode.boundingBox.Min.Y = lowestPoint;

					}
				}
			}
			return;
		}
	}



}
