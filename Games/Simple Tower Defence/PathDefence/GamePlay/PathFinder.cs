using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework;

namespace PathDefence.GamePlay
{
    //Nicht meine Klasse, ich habe von A* ehrlich gesagt KEINE Ahnung ^^
    public static class HighResolutionTime
    {
        #region Win32APIs

        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceCounter(out long perfcount);

        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceFrequency(out long freq);

        #endregion

        #region Variables Declaration

        private static readonly long mFrequency;
        private static long mStartCounter;

        #endregion

        #region Constuctors

        static HighResolutionTime()
        {
            QueryPerformanceFrequency(out mFrequency);
        }

        #endregion

        #region Methods

        public static void Start()
        {
            QueryPerformanceCounter(out mStartCounter);
        }

        public static double GetTime()
        {
            long endCounter;
            QueryPerformanceCounter(out endCounter);
            long elapsed = endCounter - mStartCounter;
            return (double) elapsed/mFrequency;
        }

        #endregion
    }

    public interface IPriorityQueue<T>
    {
        #region Methods

        int Push(T item);
        T Pop();
        T Peek();
        void Update(int i);

        #endregion
    }

    public class PriorityQueueB<T> : IPriorityQueue<T>
    {
        #region Variables Declaration

        protected List<T> InnerList = new List<T>();
        protected IComparer<T> mComparer;

        #endregion

        #region Contructors

        public PriorityQueueB()
        {
            mComparer = Comparer<T>.Default;
        }

        public PriorityQueueB(IComparer<T> comparer)
        {
            mComparer = comparer;
        }

        public PriorityQueueB(IComparer<T> comparer, int capacity)
        {
            mComparer = comparer;
            InnerList.Capacity = capacity;
        }

        #endregion

        #region Methods

        public int Count
        {
            get { return InnerList.Count; }
        }

        public T this[int index]
        {
            get { return InnerList[index]; }
            set
            {
                InnerList[index] = value;
                Update(index);
            }
        }

        public int Push(T item)
        {
            int p = InnerList.Count, p2;
            InnerList.Add(item); // E[p] = O
            do
            {
                if (p == 0)
                {
                    break;
                }
                p2 = (p - 1)/2;
                if (OnCompare(p, p2) < 0)
                {
                    SwitchElements(p, p2);
                    p = p2;
                }
                else
                {
                    break;
                }
            } while (true);
            return p;
        }

        /// <summary>
        /// Get the smallest object and remove it.
        /// </summary>
        /// <returns>The smallest object</returns>
        public T Pop()
        {
            T result = InnerList[0];
            int p = 0, p1, p2, pn;
            InnerList[0] = InnerList[InnerList.Count - 1];
            InnerList.RemoveAt(InnerList.Count - 1);
            do
            {
                pn = p;
                p1 = 2*p + 1;
                p2 = 2*p + 2;
                if (InnerList.Count > p1 && OnCompare(p, p1) > 0) // links kleiner
                {
                    p = p1;
                }
                if (InnerList.Count > p2 && OnCompare(p, p2) > 0) // rechts noch kleiner
                {
                    p = p2;
                }

                if (p == pn)
                {
                    break;
                }
                SwitchElements(p, pn);
            } while (true);

            return result;
        }

        /// <summary>
        /// Notify the PQ that the object at position i has changed
        /// and the PQ needs to restore order.
        /// Since you dont have access to any indexes (except by using the
        /// explicit IList.this) you should not call this function without knowing exactly
        /// what you do.
        /// </summary>
        /// <param name="i">The index of the changed object.</param>
        public void Update(int i)
        {
            int p = i, pn;
            int p1, p2;
            do // aufsteigen
            {
                if (p == 0)
                {
                    break;
                }
                p2 = (p - 1)/2;
                if (OnCompare(p, p2) < 0)
                {
                    SwitchElements(p, p2);
                    p = p2;
                }
                else
                {
                    break;
                }
            } while (true);
            if (p < i)
            {
                return;
            }
            do // absteigen
            {
                pn = p;
                p1 = 2*p + 1;
                p2 = 2*p + 2;
                if (InnerList.Count > p1 && OnCompare(p, p1) > 0) // links kleiner
                {
                    p = p1;
                }
                if (InnerList.Count > p2 && OnCompare(p, p2) > 0) // rechts noch kleiner
                {
                    p = p2;
                }

                if (p == pn)
                {
                    break;
                }
                SwitchElements(p, pn);
            } while (true);
        }

        /// <summary>
        /// Get the smallest object without removing it.
        /// </summary>
        /// <returns>The smallest object</returns>
        public T Peek()
        {
            if (InnerList.Count > 0)
            {
                return InnerList[0];
            }
            return default(T);
        }

        protected void SwitchElements(int i, int j)
        {
            T h = InnerList[i];
            InnerList[i] = InnerList[j];
            InnerList[j] = h;
        }

        protected virtual int OnCompare(int i, int j)
        {
            return mComparer.Compare(InnerList[i], InnerList[j]);
        }

        public void Clear()
        {
            InnerList.Clear();
        }

        public void RemoveLocation(T item)
        {
            int index = -1;
            for (int i = 0; i < InnerList.Count; i++)
            {
                if (mComparer.Compare(InnerList[i], item) == 0)
                {
                    index = i;
                }
            }

            if (index != -1)
            {
                InnerList.RemoveAt(index);
            }
        }

        #endregion
    }

    public struct PathFinderNode
    {
        #region Variables Declaration

        public int F;
        public int G;
        public int H; // f = gone + heuristic
        public int PX; // Parent
        public int PY;
        public int X;
        public int Y;

        #endregion
    }

    public enum PathFinderNodeType
    {
        Start = 1,
        End = 2,
        Open = 4,
        Close = 8,
        Current = 16,
        Path = 32
    }

    public enum HeuristicFormula
    {
        Manhattan = 1,
        MaxDXDY = 2,
        DiagonalShortCut = 3,
        Euclidean = 4,
        EuclideanNoSQR = 5,
        Custom1 = 6
    }

    public class PathFinder
    {
        #region Structs

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct PathFinderNodeFast
        {
            #region Variables Declaration

            public int F; // f = gone + heuristic
            public int G;
            public ushort PX; // Parent
            public ushort PY;
            public byte Status;

            #endregion
        }

        #endregion

        #region Variables Declaration

        // Heap variables are initializated to default, but I like to do it anyway
        private readonly PathFinderNodeFast[] mCalcGrid;
        private readonly List<PathFinderNode> mClose = new List<PathFinderNode>();
        private readonly byte[,] mGrid;
        private readonly ushort mGridX;
        private readonly ushort mGridXMinus1;
        private readonly ushort mGridY;
        private readonly ushort mGridYLog2;
        private readonly PriorityQueueB<int> mOpen;
        private int mCloseNodeCounter;
        private byte mCloseNodeValue = 2;
        private double mCompletedTime;
        private bool mDiagonals = true;

        private sbyte[,] mDirection = new sbyte[8,2]
                                          {{0, -1}, {1, 0}, {0, 1}, {-1, 0}, {1, -1}, {1, 1}, {-1, 1}, {-1, -1}};

        private int mEndLocation;
        private HeuristicFormula mFormula = HeuristicFormula.Manhattan;
        private bool mFound;

        //Promoted local variables to member variables to avoid recreation between calls
        private int mH;
        private bool mHeavyDiagonals;
        private int mHEstimate = 2;
        private int mHoriz;
        private int mLocation;
        private ushort mLocationX;
        private ushort mLocationY;
        private int mNewG;
        private int mNewLocation;
        private ushort mNewLocationX;
        private ushort mNewLocationY;
        private byte mOpenNodeValue = 1;
        private bool mPunishChangeDirection;
        private int mSearchLimit = 2000;
        private bool mStop;
        private bool mStopped = true;
        private bool mTieBreaker;

        #endregion

        #region Constructors

        public PathFinder(byte[,] grid)
        {
            if (grid == null)
            {
                throw new Exception("Grid cannot be null");
            }

            mGrid = grid;
            mGridX = (ushort) (mGrid.GetUpperBound(0) + 1);
            mGridY = (ushort) (mGrid.GetUpperBound(1) + 1);
            mGridXMinus1 = (ushort) (mGridX - 1);
            mGridYLog2 = (ushort) Math.Log(mGridY, 2);

            // This should be done at the constructor, for now we leave it here.
            if (Math.Log(mGridX, 2) != (int) Math.Log(mGridX, 2) || Math.Log(mGridY, 2) != (int) Math.Log(mGridY, 2))
            {
                throw new Exception("Invalid Grid, size in X and Y must be power of 2");
            }

            if (mCalcGrid == null || mCalcGrid.Length != (mGridX*mGridY))
            {
                mCalcGrid = new PathFinderNodeFast[mGridX*mGridY];
            }

            mOpen = new PriorityQueueB<int>(new ComparePFNodeMatrix(mCalcGrid));
        }

        #endregion

        #region Properties

        public bool Stopped
        {
            get { return mStopped; }
        }

        public HeuristicFormula Formula
        {
            get { return mFormula; }
            set { mFormula = value; }
        }

        public bool Diagonals
        {
            get { return mDiagonals; }
            set
            {
                mDiagonals = value;
                mDirection = mDiagonals
                                 ? new sbyte[8,2] {{0, -1}, {1, 0}, {0, 1}, {-1, 0}, {1, -1}, {1, 1}, {-1, 1}, {-1, -1}}
                                 : new sbyte[4,2] {{0, -1}, {1, 0}, {0, 1}, {-1, 0}};
            }
        }

        public bool HeavyDiagonals
        {
            get { return mHeavyDiagonals; }
            set { mHeavyDiagonals = value; }
        }

        public int HeuristicEstimate
        {
            get { return mHEstimate; }
            set { mHEstimate = value; }
        }

        public bool PunishChangeDirection
        {
            get { return mPunishChangeDirection; }
            set { mPunishChangeDirection = value; }
        }

        public bool TieBreaker
        {
            get { return mTieBreaker; }
            set { mTieBreaker = value; }
        }

        public int SearchLimit
        {
            get { return mSearchLimit; }
            set { mSearchLimit = value; }
        }

        public double CompletedTime
        {
            get { return mCompletedTime; }
            set { mCompletedTime = value; }
        }

        public bool DebugProgress { get; set; }

        public bool DebugFoundPath { get; set; }

        #endregion

        #region Methods

        public void FindPathStop()
        {
            mStop = true;
        }

        public List<PathFinderNode> FindPath(Vector2 start, Vector2 end)
        {
            lock (this)
            {
                HighResolutionTime.Start();

                // Is faster if we don't clear the matrix, just assign different values for open and close and ignore the rest
                // I could have user Array.Clear() but using unsafe code is faster, no much but it is.
                //fixed (PathFinderNodeFast* pGrid = tmpGrid) 
                //    ZeroMemory((byte*) pGrid, sizeof(PathFinderNodeFast) * 1000000);

                mFound = false;
                mStop = false;
                mStopped = false;
                mCloseNodeCounter = 0;
                mOpenNodeValue += 2;
                mCloseNodeValue += 2;
                mOpen.Clear();
                mClose.Clear();

                mLocation = (((int) start.Y) << mGridYLog2) + (int) start.X;
                mEndLocation = (((int) end.Y << mGridYLog2)) + (int) end.X;
                mCalcGrid[mLocation].G = 0;
                mCalcGrid[mLocation].F = mHEstimate;
                mCalcGrid[mLocation].PX = (ushort) start.X;
                mCalcGrid[mLocation].PY = (ushort) start.Y;
                mCalcGrid[mLocation].Status = mOpenNodeValue;

                mOpen.Push(mLocation);
                while (mOpen.Count > 0 && !mStop)
                {
                    mLocation = mOpen.Pop();

                    //Is it in closed list? means this node was already processed
                    if (mCalcGrid[mLocation].Status == mCloseNodeValue)
                    {
                        continue;
                    }

                    mLocationX = (ushort) (mLocation & mGridXMinus1);
                    mLocationY = (ushort) (mLocation >> mGridYLog2);

                    if (mLocation == mEndLocation)
                    {
                        mCalcGrid[mLocation].Status = mCloseNodeValue;
                        mFound = true;
                        break;
                    }

                    if (mCloseNodeCounter > mSearchLimit)
                    {
                        mStopped = true;
                        mCompletedTime = HighResolutionTime.GetTime();
                        return null;
                    }

                    if (mPunishChangeDirection)
                    {
                        mHoriz = (mLocationX - mCalcGrid[mLocation].PX);
                    }

                    //Lets calculate each successors
                    for (int i = 0; i < (mDiagonals ? 8 : 4); i++)
                    {
                        mNewLocationX = (ushort) (mLocationX + mDirection[i, 0]);
                        mNewLocationY = (ushort) (mLocationY + mDirection[i, 1]);
                        mNewLocation = (mNewLocationY << mGridYLog2) + mNewLocationX;

                        if (mNewLocationX >= mGridX || mNewLocationY >= mGridY)
                        {
                            continue;
                        }

                        // Unbreakeable?
                        if (mGrid[mNewLocationX, mNewLocationY] == 0)
                        {
                            continue;
                        }

                        if (mHeavyDiagonals && i > 3)
                        {
                            mNewG = mCalcGrid[mLocation].G + (int) (mGrid[mNewLocationX, mNewLocationY]*2.41);
                        }
                        else
                        {
                            mNewG = mCalcGrid[mLocation].G + mGrid[mNewLocationX, mNewLocationY];
                        }

                        if (mPunishChangeDirection)
                        {
                            if ((mNewLocationX - mLocationX) != 0)
                            {
                                if (mHoriz == 0)
                                {
                                    mNewG += Math.Abs(mNewLocationX - (int) end.X) +
                                             Math.Abs(mNewLocationY - (int) end.Y);
                                }
                            }
                            if ((mNewLocationY - mLocationY) != 0)
                            {
                                if (mHoriz != 0)
                                {
                                    mNewG += Math.Abs(mNewLocationX - (int) end.X) +
                                             Math.Abs(mNewLocationY - (int) end.Y);
                                }
                            }
                        }

                        //Is it open or closed?
                        if (mCalcGrid[mNewLocation].Status == mOpenNodeValue ||
                            mCalcGrid[mNewLocation].Status == mCloseNodeValue)
                        {
                            // The current node has less code than the previous? then skip this node
                            if (mCalcGrid[mNewLocation].G <= mNewG)
                            {
                                continue;
                            }
                        }

                        mCalcGrid[mNewLocation].PX = mLocationX;
                        mCalcGrid[mNewLocation].PY = mLocationY;
                        mCalcGrid[mNewLocation].G = mNewG;

                        switch (mFormula)
                        {
                            default:
                                mH = mHEstimate*
                                     (Math.Abs(mNewLocationX - (int) end.X) + Math.Abs(mNewLocationY - (int) end.Y));
                                break;
                            case HeuristicFormula.MaxDXDY:
                                mH = mHEstimate*
                                     (Math.Max(Math.Abs(mNewLocationX - (int) end.X),
                                               Math.Abs(mNewLocationY - (int) end.Y)));
                                break;
                            case HeuristicFormula.DiagonalShortCut:
                                int h_diagonal = Math.Min(Math.Abs(mNewLocationX - (int) end.X),
                                                          Math.Abs(mNewLocationY - (int) end.Y));
                                int h_straight = (Math.Abs(mNewLocationX - (int) end.X) +
                                                  Math.Abs(mNewLocationY - (int) end.Y));
                                mH = (mHEstimate*2)*h_diagonal + mHEstimate*(h_straight - 2*h_diagonal);
                                break;
                            case HeuristicFormula.Euclidean:
                                mH =
                                    (int)
                                    (mHEstimate*
                                     Math.Sqrt(Math.Pow((mNewLocationY - end.X), 2) +
                                               Math.Pow((mNewLocationY - end.Y), 2)));
                                break;
                            case HeuristicFormula.EuclideanNoSQR:
                                mH =
                                    (int)
                                    (mHEstimate*
                                     (Math.Pow((mNewLocationX - end.X), 2) + Math.Pow((mNewLocationY - end.Y), 2)));
                                break;
                            case HeuristicFormula.Custom1:
                                var dxy = new Point(Math.Abs((int) end.X - mNewLocationX),
                                                    Math.Abs((int) end.Y - mNewLocationY));
                                int Orthogonal = Math.Abs(dxy.X - dxy.Y);
                                int Diagonal = Math.Abs(((dxy.X + dxy.Y) - Orthogonal)/2);
                                mH = mHEstimate*(Diagonal + Orthogonal + dxy.X + dxy.Y);
                                break;
                        }
                        if (mTieBreaker)
                        {
                            int dx1 = mLocationX - (int) end.X;
                            int dy1 = mLocationY - (int) end.Y;
                            var dx2 = (int) (start.X - end.X);
                            var dy2 = (int) (start.Y - end.Y);
                            int cross = Math.Abs(dx1*dy2 - dx2*dy1);
                            mH = (int) (mH + cross*0.001);
                        }
                        mCalcGrid[mNewLocation].F = mNewG + mH;

                        //It is faster if we leave the open node in the priority queue
                        //When it is removed, it will be already closed, it will be ignored automatically
                        //if (tmpGrid[newLocation].Status == 1)
                        //{
                        //    //int removeX   = newLocation & gridXMinus1;
                        //    //int removeY   = newLocation >> gridYLog2;
                        //    mOpen.RemoveLocation(newLocation);
                        //}

                        //if (tmpGrid[newLocation].Status != 1)
                        //{
                        mOpen.Push(mNewLocation);
                        //}
                        mCalcGrid[mNewLocation].Status = mOpenNodeValue;
                    }

                    mCloseNodeCounter++;
                    mCalcGrid[mLocation].Status = mCloseNodeValue;
                }

                mCompletedTime = HighResolutionTime.GetTime();
                if (mFound)
                {
                    mClose.Clear();

                    PathFinderNodeFast fNodeTmp = mCalcGrid[((int) end.Y << mGridYLog2) + (int) end.X];
                    PathFinderNode fNode;
                    fNode.F = fNodeTmp.F;
                    fNode.G = fNodeTmp.G;
                    fNode.H = 0;
                    fNode.PX = fNodeTmp.PX;
                    fNode.PY = fNodeTmp.PY;
                    fNode.X = (int) end.X;
                    fNode.Y = (int) end.Y;

                    while (fNode.X != fNode.PX || fNode.Y != fNode.PY)
                    {
                        mClose.Add(fNode);

                        int posX = fNode.PX;
                        int posY = fNode.PY;
                        fNodeTmp = mCalcGrid[(posY << mGridYLog2) + posX];
                        fNode.F = fNodeTmp.F;
                        fNode.G = fNodeTmp.G;
                        fNode.H = 0;
                        fNode.PX = fNodeTmp.PX;
                        fNode.PY = fNodeTmp.PY;
                        fNode.X = posX;
                        fNode.Y = posY;
                    }

                    mClose.Add(fNode);

                    mStopped = true;
                    return mClose;
                }
                mStopped = true;
                return null;
            }
        }

        #endregion

        #region Inner Classes

        internal class ComparePFNodeMatrix : IComparer<int>
        {
            #region Variables Declaration

            private readonly PathFinderNodeFast[] mMatrix;

            #endregion

            #region Constructors

            public ComparePFNodeMatrix(PathFinderNodeFast[] matrix)
            {
                mMatrix = matrix;
            }

            #endregion

            #region IComparer<int> Members

            public int Compare(int a, int b)
            {
                if (mMatrix[a].F > mMatrix[b].F)
                {
                    return 1;
                }
                if (mMatrix[a].F < mMatrix[b].F)
                {
                    return -1;
                }
                return 0;
            }

            #endregion
        }

        #endregion
    }
}