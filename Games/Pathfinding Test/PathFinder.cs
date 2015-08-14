using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Pathfinding {

	public struct PathReturnNode {
		public uint Pos;
		public int PosX;
		public int PosY;
		public uint Parrent;
	}

	public struct PathGridNode {
		public uint Parrent;
		public uint Pos;
		public int PosX;
		public int PosY;
		public int F;
		public int Gone;
		public byte OpenOrClosed;
	}


	public class PathFinder {

		private PriorityQueue<uint, int> OpenList;
		private List<PathReturnNode> SolovedList = new List<PathReturnNode>();
		private PathGridNode[] PathInfoGrid;

		private bool isStop;
		private bool isStopped;

		private int HeuristicEstimateVal = 8;

		private byte NodeOpenVal = 1;
		private byte NodeCloseVal = 2;

		private int Heuristic = 0;
		private uint Position = 0;
		private uint newPosition = 0;
		private ushort PosX = 0;
		private ushort PosY = 0;
		private ushort newPosX = 0;
		private ushort newPosY = 0;
		private ushort GridX = 24;
		private ushort GridY = 24;
		private bool nodeFound = false;
		private uint endPosition = 0;
		private uint startPosition = 0;
		private int newGone = 0;

		private sbyte[,] Directions = new sbyte[8, 2] {
			{  0, -1 }, 
			{  1,  0 }, 
			{  0,  1 }, 
			{ -1,  0 }, 
            {  1, -1 }, 
			{  1,  1 }, 
			{ -1,  1 }, 
			{ -1, -1 }
		};
		private sbyte[,] SmoothDir = new sbyte[4, 2] {
			{ -1, 1  }, 
			{ -1, -1 }, 
			{  1, -1 }, 
			{  1, 1  } 
		};

		public byte[,] PathGrid;
		public byte[,] WalkedNodes;

		public bool Stopped {
			get { return isStopped; }
		}

		public int HeuristicEstimate {
			get { return HeuristicEstimateVal; }
			set { HeuristicEstimateVal = value; }
		}


		public PathFinder(byte[,] pathGrid) {
			PathGrid = pathGrid;
			GridX = (ushort)(PathGrid.GetUpperBound(0) + 1);
			GridY = (ushort)(PathGrid.GetUpperBound(1) + 1);
			HeuristicEstimateVal = 0;

			OpenList = new PriorityQueue<uint, int>();
			PathInfoGrid = new PathGridNode[GridX * GridY];

			WalkedNodes = new byte[GridX, GridY];

			for (int i = 0; i < PathInfoGrid.Length; i++) {
				PathInfoGrid[i].Pos = (uint)i;
				PathInfoGrid[i].PosX = i % GridX;
				PathInfoGrid[i].PosY = i / GridX;
			}

		}


		public List<PathReturnNode> FindPath(Point start, Point end) {
			nodeFound = false;
			isStop = false;
			isStopped = false;

			NodeOpenVal += 2;
			NodeCloseVal += 2;

			OpenList.Clear();

			Position = (uint)(start.X + start.Y * GridX);
			startPosition = (uint)(start.X + start.Y * GridX);
			endPosition = (uint)(end.X + end.Y * GridX);

			//Set first node in info grid:
			PathInfoGrid[Position].Gone = 0;
			PathInfoGrid[Position].F = HeuristicEstimateVal;
			PathInfoGrid[Position].Parrent = Position;
			PathInfoGrid[Position].OpenOrClosed = NodeOpenVal;

			//Enqueue first node
			OpenList.Enqueue(Position, 1);

			while (OpenList.Count > 0 && !isStop) {
				//Dequeue node with lowest cost
				PriorityQueueItem<uint, int> item = OpenList.Dequeue();
				Position = item.Value;

				//Node Closed?
				if (PathInfoGrid[Position].OpenOrClosed == NodeCloseVal)
					continue;

				PathInfoGrid[Position].OpenOrClosed = NodeCloseVal;

				PosX = (ushort)PathInfoGrid[Position].PosX;
				PosY = (ushort)PathInfoGrid[Position].PosY;

				//Found end node - vaild path is found
				if (Position == endPosition) {
					PathInfoGrid[Position].OpenOrClosed = NodeCloseVal;
					nodeFound = true;
					break;
				}
				//Foreach direction          
				for (int i = 0; i < 8; i += 1) {

					newPosX = (ushort)(PosX + Directions[i, 0]);
					newPosY = (ushort)(PosY + Directions[i, 1]);

					newPosition = (uint)(newPosY * GridX + newPosX);

					//Outside of grid
					if (newPosX >= GridX || newPosY >= GridY) {
						continue;
					}

					if (PathInfoGrid[newPosition].OpenOrClosed == NodeCloseVal) {
						continue;
					}

					//Solid block
					if (PathGrid[newPosX, newPosY] == 0) {
						continue;
					}

					if (i > 3) {
						//Smooth path and do-not allow passing throw nodes with connected corners
						int iminus4 = i - 4;
						if (PathGrid[newPosX + SmoothDir[iminus4, 0], newPosY] == 0 || PathGrid[newPosX, newPosY + SmoothDir[iminus4, 1]] == 0) {
							continue;
						}
						//Passing thro diognal cost more:
						newGone = PathInfoGrid[Position].Gone + (int)(PathGrid[newPosX, newPosY] * 2.41);
					} else {
						newGone = PathInfoGrid[Position].Gone + PathGrid[newPosX, newPosY];
					}

					if (PathInfoGrid[newPosition].OpenOrClosed == NodeOpenVal) {
						if (PathInfoGrid[newPosition].Gone < newGone) {
							continue;
						}
					}

					PathInfoGrid[newPosition].Parrent = Position;
					PathInfoGrid[newPosition].Gone = newGone;

					//Calculate Euclidean heuristic
					//Heuristic = (int)(HeuristicEstimateVal * (Math.Sqrt(Math.Pow((newPosX - end.X), 2) + Math.Pow((newPosY - end.Y), 2))));
					//Manhattan
					Heuristic = HeuristicEstimateVal * (Math.Abs(end.X - newPosX) + Math.Abs(end.Y - newPosY));
					//Diognal distance
					//Heuristic = HeuristicEstimateVal * Math.Max(Math.Abs(newPosX - end.X), Math.Abs(newPosX - end.Y));

					PathInfoGrid[newPosition].F = newGone + Heuristic;

					OpenList.Enqueue(newPosition, PathInfoGrid[newPosition].F);

					PathInfoGrid[newPosition].OpenOrClosed = NodeOpenVal;
				}
			}

			//Vaild path is found
			if (nodeFound) {
				SolovedList.Clear();

				//Add end node to found list
				PathGridNode foundNodeEnd = PathInfoGrid[endPosition];
				PathReturnNode foundNode;

				foundNode.Parrent = foundNodeEnd.Parrent;
				foundNode.Pos = foundNodeEnd.Pos;
				foundNode.PosX = foundNodeEnd.PosX;
				foundNode.PosY = foundNodeEnd.PosY;

				SolovedList.Add(foundNode);

				//Add rest of the nodes by parrents
				while (foundNode.Pos != startPosition) {
					foundNodeEnd = PathInfoGrid[foundNode.Parrent];
					foundNode.Parrent = foundNodeEnd.Parrent;
					foundNode.Pos = foundNodeEnd.Pos;
					foundNode.PosX = foundNodeEnd.PosX;
					foundNode.PosY = foundNodeEnd.PosY;
					SolovedList.Add(foundNode);
				}

				isStopped = true;

				return SolovedList;
			}
			isStopped = true;
			//If no path found -> return null
			return null;
		}

	}
}
