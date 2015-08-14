//======================================================================
// XNA Terrain Editor
// Copyright (C) 2007 Eric Grossinger
// http://psycad007.spaces.live.com/
//======================================================================
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XNATerrainEditor
{
    class HeightmapCell
    {
        public Point coordinates; //heightmap cell coordinates (ex: [0,0] [0,1] [1,0] [1,1] 4 cells)
        public Point divisions; //The number of divisions within this heightmap cell (ex: 32x32, 64x64)
        public Vector2 cellsize; //The size of a single cell (ex: 50units x 50units)

        Vector3 position = Vector3.Zero;
        public Matrix world = Matrix.Identity;

        public BoundingBox boundingBox = new BoundingBox();
        public DrawableBoundingBox boundingBoxWire;
        public Vector3 center;
        float maxHeight = float.MinValue;
        float minHeight = float.MaxValue;

        #region Indices & Vertices
        public VertexPositionNormalTexture[] vertices;
        private VertexDeclaration vertexDeclaration;
        private VertexBuffer vertexBuffer;
        public short[] indices;
        private IndexBuffer indexBuffer;
        #endregion

        #region PickRay Intersection
        public Tri[] triangle;
        public struct Tri
        {
            public Tri(int id, Vector3 p1, Vector3 p2, Vector3 p3)
            {
                this.id = id;
                this.p1 = p1;
                this.p2 = p2;
                this.p3 = p3;
                this.normal = new Plane(p1, p2, p3).Normal;
            }
            public int id;
            public Vector3 p1;
            public Vector3 p2;
            public Vector3 p3;
            public Vector3 normal;
        }
        #endregion

        private HeightmapCell[,] adjacent_cell;

        Vector3 color = Vector3.One;

        public HeightmapCell(GraphicsDevice graphicsDevice, Point coordinates, Point divisions, Vector2 cellsize, HeightmapCell[,] adjacent_cell)
        {
            this.coordinates = coordinates;
            this.divisions = divisions;
            this.cellsize = cellsize;
            this.adjacent_cell = adjacent_cell;

            position = new Vector3();
            position.X = coordinates.X * divisions.X * cellsize.X - cellsize.X * coordinates.X;
            position.Z = coordinates.Y * divisions.Y * cellsize.Y - cellsize.Y * coordinates.Y;

            center.X = position.X + (divisions.X * cellsize.X - cellsize.X) / 2;
            center.Z = position.Z + (divisions.Y * cellsize.Y - cellsize.Y) / 2;

            SetUpVertices(graphicsDevice);
            //SetupTilingRefs();
            UpdateAdjacentCells();
            SetVertexBuffer(graphicsDevice, null);

            SetUpIndices();
            SetIndexBuffer(graphicsDevice);

            Update();
        }

        private void SetUpVertices(GraphicsDevice graphicsDevice)
        {
            vertices = new VertexPositionNormalTexture[divisions.X * divisions.Y];

            Vector3 vectorPos = new Vector3();

            Random random = new Random();

            for (int y = 0; y < divisions.Y; y++)
            {
                for (int x = 0; x < divisions.X; x++)
                {
                    vectorPos.X = x * cellsize.X + coordinates.X * (divisions.X - 1) * cellsize.X;
                    vectorPos.Z = y * cellsize.Y + coordinates.Y * (divisions.Y - 1) * cellsize.Y;

                    //-----Cell tiling test-----
                    //if (x == 0 || y == 0 || x == divisions.X - 1 || y == divisions.Y - 1)
                    //    vectorPos.Y = (float)random.Next(0, 500) * 0.1f;
                    //else
                        vectorPos.Y = 0f;
                    //-----Cell tiling test-----

                    if (vectorPos.Y < minHeight)
                        minHeight = vectorPos.Y;
                    if (vectorPos.Y > maxHeight)
                        maxHeight = vectorPos.Y;

                    vertices[x + y * divisions.X].Position = vectorPos;
                    vertices[x + y * divisions.X].TextureCoordinate = new Vector2(x / (divisions.X / cellsize.X) / cellsize.X, y / (divisions.Y / cellsize.Y) / cellsize.Y);
                    vertices[x + y * divisions.X].Normal = Vector3.Up;
                }
            }

            UpdateBoundingBox(minHeight, maxHeight);
        }

        /// <summary>
        /// Update a single vertex position (ADD: update normal calculation & adjacent vertices normals)
        /// </summary>
        /// <param name="x">division x coordinate</param>
        /// <param name="y">division y coordinate</param>
        /// <param name="vector">vector to apply</param>
        /// <param name="equation">equation to apply (replace, add, substrace, multiply and divide)</param>
        public enum VertexEquation
        {
            Add,
            Substract,
            Multiply,
            Divide,
            Substitute
        }
        public void UpdateVertex(int x, int y, Vector3 vector, VertexEquation equation)
        {
            //skip references vertices
            //if ((coordinates.X > 0 || coordinates.Y > 0) && (x == divisions.X - 1 || y == divisions.Y - 1))
            //    return;

            int index = x + y * divisions.X;

            if (index < 0 || index >= vertices.Length)
                return;

            switch (equation)
            {
                case VertexEquation.Substitute:
                    vertices[index].Position = vector;
                    break;
                case VertexEquation.Add:
                    vertices[index].Position += vector;
                    break;
                case VertexEquation.Substract:
                    vertices[index].Position -= vector;
                    break;
                case VertexEquation.Multiply:
                    vertices[index].Position *= vector;
                    break;
                case VertexEquation.Divide:
                    vertices[index].Position /= vector;
                    break;
            }

            if (vertices[index].Position.Y < minHeight)
            {
                minHeight = vertices[index].Position.Y;
                UpdateBoundingBox(minHeight, maxHeight);

                
                //----------------Update adjacent boundingboxes-------------------
                if(coordinates.X == 0 || coordinates.Y == 0)                    

                if (x == 0 || y == 0)
                {
                    if (x == 0 && y == 0 && adjacent_cell[0, 0] != null)
                        adjacent_cell[0,0].UpdateBoundingBox();
                    if (y == 0 && adjacent_cell[1, 0] != null)
                        adjacent_cell[1,0].UpdateBoundingBox();
                    if (x == 0 && adjacent_cell[0, 1] != null)
                        adjacent_cell[0, 1].UpdateBoundingBox();
                }
            }
            else if (vertices[index].Position.Y > maxHeight)
            {
                maxHeight = vertices[index].Position.Y;
                UpdateBoundingBox(minHeight, maxHeight);

                //Update adjacent boundingboxes
                if (x == 0 || y == 0)
                {
                    if (x == 0 && y == 0 && adjacent_cell[0, 0] != null)
                        adjacent_cell[0, 0].UpdateBoundingBox();
                    if (y == 0 && adjacent_cell[1, 0] != null)
                        adjacent_cell[1, 0].UpdateBoundingBox();
                    if (x == 0 && adjacent_cell[0, 1] != null)
                        adjacent_cell[0, 1].UpdateBoundingBox();
                }
            }


            Redraw();

            //SetVertexBuffer(null, null);

            //if (x == divisions.X - 1 || y == divisions.Y - 1)
            //    UpdateAdjacentCells();
            
        }

        private void SetVertexBuffer(GraphicsDevice graphicsDevice, int? index)
        {
            if (graphicsDevice != null)
            {
                if (vertexDeclaration == null)
                    vertexDeclaration = new VertexDeclaration(graphicsDevice, VertexPositionNormalTexture.VertexElements);
                if (vertexBuffer == null)
                    vertexBuffer = new VertexBuffer(graphicsDevice, typeof(VertexPositionNormalTexture), divisions.X * divisions.Y, BufferUsage.None);
            }

            //if(index.HasValue)
            //    vertexBuffer.SetData<VertexPositionNormalTexture>(vertices, index.Value, 1);
            //else
            //{
            try
            {
                vertexBuffer.SetData<VertexPositionNormalTexture>(vertices);
            }
            catch { }
            //}

        }

        public void Redraw()
        {
            try
            {
                vertexBuffer.SetData<VertexPositionNormalTexture>(vertices);
            }
            catch { }
            UpdateAdjacentCells();
        }

        private void SetUpIndices()
        {
            indices = new short[divisions.X * divisions.Y * 6];
            int indiceID = 0;
            
            triangle = new Tri[divisions.X * divisions.Y * 2];
            int triID = 0;

            int[] index = new int[6];

            for (int y = 0; y < divisions.Y - 1; y++)
            {
                for (int x = 0; x < divisions.X - 1; x++)
                {
                    index[0] = x + y * divisions.X;
                    index[1] = x + (y + 1) * divisions.X;
                    index[2] = (x + 1) + y * divisions.X;
                    index[3] = (x + 1) + (y + 1) * divisions.X;

                    indices[indiceID] = (short)(index[0]);
                    indices[indiceID + 1] = (short)(index[1]);
                    indices[indiceID + 2] = (short)(index[2]);
                    
                    indices[indiceID + 3] = (short)(index[2]);
                    indices[indiceID + 4] = (short)(index[1]);
                    indices[indiceID + 5] = (short)(index[3]);

                    //Create ray collision triangles
                    triangle[triID] = new Tri(triID, vertices[index[0]].Position, vertices[index[1]].Position, vertices[index[2]].Position);
                    triangle[triID + 1] = new Tri(triID, vertices[index[2]].Position, vertices[index[1]].Position, vertices[index[3]].Position);

                    //Update vertices normals
                    vertices[index[0]].Normal = triangle[triID].normal;
                    vertices[index[1]].Normal = (triangle[triID].normal + triangle[triID + 1].normal) / 2;
                    vertices[index[2]].Normal = (triangle[triID].normal + triangle[triID + 1].normal) / 2;
                    vertices[index[3]].Normal = triangle[triID + 1].normal;

                    indiceID += 6;
                    triID += 2;
                }
            }
        }

        private void SetIndexBuffer(GraphicsDevice graphicsDevice)
        {
            indexBuffer = new IndexBuffer(graphicsDevice, sizeof(short) * indices.Length, BufferUsage.None, IndexElementSize.SixteenBits);
            indexBuffer.SetData<short>(indices);
        }

        private void UpdateBoundingBox(float minHeight, float maxHeight)
        {
            if (minHeight < this.minHeight)
                this.minHeight = minHeight;
            if (maxHeight > this.maxHeight)
                this.maxHeight = maxHeight;

            Vector3 Min = new Vector3(position.X, this.minHeight, position.Z);
            Vector3 Max = new Vector3(position.X + divisions.X * cellsize.X - cellsize.X, this.maxHeight, position.Z + divisions.Y * cellsize.Y - cellsize.Y);
            center.Y = Min.Y + (Max.Y - Min.Y) / 2f;

            boundingBox = new BoundingBox(Min, Max);
            boundingBoxWire = new DrawableBoundingBox(Vector3.Zero, Min, Max);
        }

        /// <summary>
        /// Forced updated of the boundingbox scanning all the 
        /// vertices of the cell for their height position
        /// </summary>
        private void UpdateBoundingBox()
        {
            float minH = float.MaxValue;
            float maxH = float.MinValue;
            float height = 0f;

            for (int y = 0; y < divisions.Y; y++)
            {
                for (int x = 0; x < divisions.X; x++)
                {
                    height = vertices[x + y * divisions.X].Position.Y;

                    if(height < minH)
                        minH = height;
                    if(height > maxH)
                        maxH = height;
                }
            }

            Vector3 Min = new Vector3(position.X, minH, position.Z);
            Vector3 Max = new Vector3(position.X + divisions.X * cellsize.X - cellsize.X, maxH, position.Z + divisions.Y * cellsize.Y - cellsize.Y);
            center.Y = Min.Y + (Max.Y - Min.Y) / 2f;

            boundingBox = new BoundingBox(Min, Max);
            boundingBoxWire = new DrawableBoundingBox(Vector3.Zero, Min, Max);

            minHeight = minH;
            maxHeight = maxH;
        }

        public void Update()
        {
            //world = Matrix.CreateTranslation(position);
        }

        public void Draw(GraphicsDevice graphicsDevice, Matrix view, Matrix projection)
        {
            graphicsDevice.Indices = indexBuffer;
            graphicsDevice.VertexDeclaration = vertexDeclaration;
            graphicsDevice.Vertices[0].SetSource(vertexBuffer, 0, VertexPositionNormalTexture.SizeInBytes);
            graphicsDevice.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, vertices.Length, 0, indices.Length / 3);
        }

        public void SetupTilingRefs()
        {
            //[0,0] top left cell.
            if (adjacent_cell[0, 0] != null)
            {
                int index = (divisions.X - 1) + (divisions.Y - 1) * divisions.X;
                //adjacent_cell[0, 0].vertices[index].Position = vertices[0].Position;
                adjacent_cell[0, 0].AssignParent(index, ref vertices[0]);

                if (adjacent_cell[0, 1] != null)
                {
                    //adjacent_cell[0, 1].vertices[(divisions.X - 1)].Position = vertices[0].Position;
                    adjacent_cell[0, 1].AssignParent(divisions.X - 1, ref vertices[0]);
                }
                if (adjacent_cell[1, 0] != null)
                {
                    //adjacent_cell[1, 0].vertices[(divisions.Y - 1) * divisions.X].Position = vertices[0].Position;
                    adjacent_cell[1, 0].AssignParent((divisions.Y - 1) * divisions.X, ref vertices[0]);
                }
            }

            //[1,0] bottom cell.
            if (adjacent_cell[1, 0] != null)
            {
                for (int x = 0; x < divisions.X; x++)
                {
                    //adjacent_cell[1, 0].vertices[x + (divisions.Y - 1) * divisions.X].Position = vertices[x].Position;
                    adjacent_cell[1, 0].AssignParent(x + (divisions.Y - 1) * divisions.X, ref vertices[x]);
                }
            }

            //[0,1] left cell.
            if (adjacent_cell[0, 1] != null)
            {
                for (int y = 0; y < divisions.Y; y++)
                {
                    //adjacent_cell[0, 1].vertices[(divisions.X - 1) + y * divisions.X].Position = vertices[y * divisions.X].Position;
                    adjacent_cell[0, 1].AssignParent((divisions.X - 1) + y * divisions.X, ref vertices[y * divisions.X]);
                }
            }
        }

        public void UpdateAdjacentCells()
        {
            SetupTilingRefs();
            if (adjacent_cell[0, 0] != null)
                adjacent_cell[0, 0].SetVertexBuffer(null, null);
            if (adjacent_cell[0, 1] != null)
                adjacent_cell[0, 1].SetVertexBuffer(null, null);
            if (adjacent_cell[1, 0] != null)
                adjacent_cell[1, 0].SetVertexBuffer(null, null);
        }

        public void AssignParent(int index, ref VertexPositionNormalTexture parent)
        {
            this.vertices[index] = parent;            
        }
    }
}
