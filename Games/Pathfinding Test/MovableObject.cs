using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Pathfinding {

	public class MovableObject {
		private Vector2 mPositionOld;
		private Vector2 mPositionCurrent;
		private Vector2 mPositionStart;
		private Vector2 mPositionDestination;

		private enum MovingType {
			None,
			Linear,
			PathSmooth
		};

		private MovingType mMovingStatus = MovingType.None;

		private static float mMoveSpeed = 320.0f;

		private float mTime = 0.0f;
		private float mTotalTime = 0.0f;

		private float mMoveDistance;

		//Position on map regarding to path
		private Point mCurrentPosOnPath;
		private Point mPrevPosOnPath;
		private Point mStartPosOnPath;
		private Point mEndPosOnPath;

		//index in path nodes list
		private int mNodePos;

		//Moving Direction
		private float mDirection = 0.0f;

		//Directions number
		private int mDirFrom = 0;
		private int mDirTo = 0;

		//Curves for smooth path movement
		public Curve mCurveX;
		public Curve mCurveY;

		//Width of one path tile
		private static int mGridWidth;
		//GridWidth/2
		private static int mGridWidthDiv2;

		//Array containing directions lookups
		private static int[] mDirections;
		//Array for relative position(regarding to directions) lookup
		private static Point[] mLinearMoves;

		public MovableObject(Vector2 StartPos) {
			mPositionCurrent = mPositionOld = StartPos;

			mCurveX = new Curve();
			mCurveY = new Curve();
		}

		public Vector2 PositionCurrent {
			get { return mPositionCurrent; }
			set { mPositionCurrent = value; }
		}
		public bool PositionChanged {
			get { return mPositionCurrent != mPositionOld; }
		}
		public float MoveSpeed {
			get { return mMoveSpeed; }
			set { mMoveSpeed = value; }
		}
		public float Direction {
			get { return mDirection; }
			set { mDirection = value; }
		}


		/// <summary>
		/// Init MovableObject class
		/// </summary>
		/// <param name="GridSize">Dimensions of provided grid</param>
		/// <param name="MoveWidth">Size of one grid tile</param>
		public static void Initalize(int GridSize, int MoveWidth) {
			mGridWidth = MoveWidth;
			mGridWidthDiv2 = MoveWidth / 2;

			//Lookups for direction and node insertion 
			mDirections = new int[8];
			mDirections[0] = -GridSize;
			mDirections[1] = -GridSize + 1;
			mDirections[2] = 1;
			mDirections[3] = GridSize + 1;
			mDirections[4] = GridSize;
			mDirections[5] = GridSize - 1;
			mDirections[6] = -1;
			mDirections[7] = -GridSize - 1;

			mLinearMoves = new Point[8];
			mLinearMoves[0] = new Point(mGridWidthDiv2, mGridWidth);
			mLinearMoves[1] = new Point(0, mGridWidth);
			mLinearMoves[2] = new Point(0, mGridWidthDiv2);
			mLinearMoves[3] = new Point(0, 0);
			mLinearMoves[4] = new Point(mGridWidthDiv2, 0);
			mLinearMoves[5] = new Point(mGridWidth, 0);
			mLinearMoves[6] = new Point(mGridWidth, mGridWidthDiv2);
			mLinearMoves[7] = new Point(mGridWidth, mGridWidth);

		}

		/// <summary>
		/// Stop moving and reset times
		/// </summary>
		public void StopMoving() {
			mMovingStatus = MovingType.None;
			mTime = 0.0f;
			mTotalTime = 0.0f;
		}

		/// <summary>
		/// Perform a linear move
		/// </summary>
		/// <param name="startPos">Start position</param>
		/// <param name="endPos">End Position</param>
		public void LinearMove(Vector2 startPos, Vector2 endPos) {
			mMovingStatus = MovingType.Linear;
			mTime = 0.0f;
			mPositionStart = startPos;
			mPositionDestination = endPos;
			Vector2.Distance(ref mPositionStart, ref mPositionDestination, out mMoveDistance);
			mDirection = (float)Math.Atan2(endPos.Y - startPos.Y, endPos.X - startPos.X);
		}

		/// <summary>
		/// Perform move on found path
		/// </summary>
		/// <param name="Nodes">List of found path nodes</param>
		/// <param name="StartPosition">Point from where to start moving</param>
		/// <param name="EndPosition">Moving end point</param>
		public void PathMove(ref List<PathReturnNode> Nodes, Vector2 StartPosition, Vector2 EndPosition) {
			mMovingStatus = MovingType.PathSmooth;

			mCurveX.Keys.Clear();
			mCurveY.Keys.Clear();

			mNodePos = Nodes.Count - 1;

			//This needed to get directions
			mStartPosOnPath = new Point(Nodes[mNodePos].PosX, Nodes[mNodePos].PosY);
			mPrevPosOnPath = mStartPosOnPath;
			mCurrentPosOnPath = mStartPosOnPath;
			mEndPosOnPath = new Point(Nodes[0].PosX, Nodes[0].PosY);

			mDirFrom = GetDirection(mNodePos, ref Nodes);

			CurveKey key;

			//Loop throught all nodes
			for (int n = mNodePos - 1; n >= 0; n -= 1) {
				//Prew direction
				mDirTo = mDirFrom;
				//Get new direction
				mDirFrom = GetDirection(n, ref Nodes);

				//Add nodes in curves, LinearMoves array and DirTo are used to get the rigt spot
				key = new CurveKey((mNodePos - n) * mGridWidth, mCurrentPosOnPath.X * mGridWidth + mLinearMoves[mDirTo].X);

				mCurveX.Keys.Add(key);

				key = new CurveKey((mNodePos - n) * mGridWidth, mCurrentPosOnPath.Y * mGridWidth + mLinearMoves[mDirTo].Y);

				mCurveY.Keys.Add(key);

				mPrevPosOnPath = mCurrentPosOnPath;
				mCurrentPosOnPath = new Point(Nodes[n].PosX, Nodes[n].PosY);
			}


			//First and last nodes are inserted and are not path node based
			//We should get distance form first to second node to insert in in right time
			float firstDist = mGridWidth - Vector2.Distance(StartPosition, new Vector2(mCurveX.Keys[0].Value, mCurveY.Keys[0].Value));

			key = new CurveKey(firstDist, StartPosition.X);
			mCurveX.Keys.Add(key);
			key = new CurveKey(firstDist, StartPosition.Y);
			mCurveY.Keys.Add(key);

			float secondDist = Vector2.Distance(EndPosition, new Vector2(mCurveX.Keys[mCurveX.Keys.Count - 1].Value, mCurveY.Keys[mCurveY.Keys.Count - 1].Value)) - mGridWidth;

			key = new CurveKey(Nodes.Count * mGridWidth + secondDist, EndPosition.X);
			mCurveX.Keys.Add(key);
			key = new CurveKey(Nodes.Count * mGridWidth + secondDist, EndPosition.Y);
			mCurveY.Keys.Add(key);

			if (mNodePos > 2) {
				mCurveX.Keys.RemoveAt(1);
				mCurveX.Keys.RemoveAt(mCurveX.Keys.Count - 2);
				mCurveY.Keys.RemoveAt(1);
				mCurveY.Keys.RemoveAt(mCurveY.Keys.Count - 2);
			}

			//Compute tangents for both curves
			mCurveX.ComputeTangents(CurveTangent.Smooth);
			mCurveY.ComputeTangents(CurveTangent.Smooth);

			//Set start and end positions on curve, used in Update
			mTime = firstDist;
			mTotalTime = Nodes.Count * mGridWidth + secondDist;
		}

		/// <summary>
		/// Performs moving logic
		/// </summary>
		/// <param name="ElapsedTime">Time elapsed form last frame</param>
		public void Update(float ElapsedTime) {
			mPositionOld = mPositionCurrent;
			switch (mMovingStatus) {
				case MovingType.Linear: {
						mPositionCurrent = Linear(mPositionStart, mPositionDestination, mTime);
						mTime += (mMoveSpeed * ElapsedTime) / mMoveDistance;
						if (mTime >= 1.0f) {
							StopMoving();
							mPositionCurrent = mPositionDestination;
						}
					}
					break;
				case MovingType.PathSmooth: {
						mTime += (mMoveSpeed * ElapsedTime);
						if (mTime < mTotalTime) {
							float newX = mCurveX.Evaluate(mTime);
							float newY = mCurveY.Evaluate(mTime);

							mDirection = (float)Math.Atan2(newY - mPositionCurrent.Y, newX - mPositionCurrent.X);

							mPositionCurrent.X = newX;
							mPositionCurrent.Y = newY;
						} else {
							StopMoving();
						}
					}
					break;
			}
		}

		//Get direction, where to add next path point
		private int GetDirection(int nodePosition, ref List<PathReturnNode> Nodes) {
			if (nodePosition > 0) {
				int difference = (int)Nodes[nodePosition].Pos - (int)Nodes[nodePosition - 1].Pos;
				int direction = 0;

				for (int i = 0; i < 8; i += 1) {
					if (mDirections[i] == difference) {
						direction = i;
						break;
					}
				}

				return direction;
			} else {
				return mDirFrom;
			}
		}

		//Return 2D Postion on line form start and end point at given time
		private static Vector2 Linear(Vector2 startPos, Vector2 endPos, float time) {
			return startPos = startPos + (endPos - startPos) * time;
		}

	}

}
