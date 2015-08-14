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
    class Optimized_Heightmap
    {        
        public Matrix world = Matrix.Identity;
        private Matrix worldViewProj = Matrix.Identity;

        public HeightmapCell[,] cell;

        public Point size;
        public Vector2 cellSize;
        public Point cellDivisions;

        private BasicEffect basicEffect;

        private Effect effect;
        private EffectParams effectParams;

        Triangle testTri;

        /// <summary>
        /// Optimized Heightmap, using cells to optimize process of drawing and modifying.
        /// The heightmap is divided into cells which are each surrounded by a bounding box and
        /// hidden if they are outside of the field of view or too far away. The bounding boxes 
        /// are also used to speed up the ray detection test when making modifications to the terrain.
        /// </summary>
        /// <param name="divisions">Size of the map, ex: 256x256</param>
        /// <param name="cellsize">The size of a single quad, ex: 50x50</param>
        /// <param name="cellDivisions">Number of quads in each heightmap cell, ex: 16x16</param>
        public Optimized_Heightmap(GraphicsDevice graphicsDevice, Point divisions, Vector2 cellsize, Point cellDivisions)
        {
            this.size = divisions;
            this.cellSize = cellsize;
            this.cellDivisions = cellDivisions;

            //basicEffect = new BasicEffect(graphicsDevice, null);
            //basicEffect.VertexColorEnabled = true;
            effect = Editor.content.Load<Effect>(@"content\shaders\opt_heightmap");
            effectParams = new EffectParams(ref effect, "TransformWireframe");

            int w = (int)((float)divisions.X / (float)cellDivisions.X);
            int h = (int)((float)divisions.Y / (float)cellDivisions.Y);

            cell = new HeightmapCell[w, h];

            //Build the cells
            for (int y = 0; y < w; y++)
            {
                for (int x = 0; x < h; x++)
                {
                    //get the adjacent cells (max 3) : [0,0],[0,1],[1,0]
                    HeightmapCell[,] adjacent_cell = new HeightmapCell[2, 2];
                    if (x > 0) adjacent_cell[0, 1] = cell[x - 1, y];
                    if (y > 0) adjacent_cell[1, 0] = cell[x, y - 1];
                    if (x > 0 && y > 0) adjacent_cell[0, 0] = cell[x - 1, y - 1];

                    cell[x, y] = new HeightmapCell(graphicsDevice, new Point(x, y), cellDivisions, cellsize, adjacent_cell);
                }
            }

            HeightmapCell.Tri collisionTri = cell[0,0].triangle[0];
            testTri = new Triangle(collisionTri.p1, collisionTri.p2, collisionTri.p3, Color.White);
        }

        /// <summary>
        /// Update Terrain
        /// </summary>
        public void Update()
        {
            for (int y = 0; y < cell.GetLength(1); y++)
            {
                for (int x = 0; x < cell.GetLength(0); x++)
                {
                    cell[x, y].Update();
                }
            }

            if (testTri != null)
                testTri.Update();
        }

        public void Redraw()
        {
            for (int y = 0; y < cell.GetLength(1); y++)
                for (int x = 0; x < cell.GetLength(0); x++)
                    cell[x, y].Redraw();
        }

        /// <summary>
        /// Draw the Terrain
        /// </summary>
        public void Draw(GraphicsDevice graphicsDevice, Matrix view, Matrix projection)
        {
            Editor.graphics.GraphicsDevice.RenderState.CullMode = CullMode.CullClockwiseFace;

            if (basicEffect != null)
                BasicEffectDraw(graphicsDevice, view, projection);
            else if (effect != null)
                EffectDraw(graphicsDevice, view, projection);

            if (testTri != null)
                testTri.Draw(view, projection);
        }

        /// <summary>
        /// Draw the Terrain using a Basic Effect. Method called from Draw();
        /// </summary>
        private void BasicEffectDraw(GraphicsDevice graphicsDevice, Matrix view, Matrix projection)
        {
            Ray pickRay = Editor.camera.GetPickRay();
            float? rayLength;
            
            basicEffect.Begin();

            for (int y = 0; y < cell.GetLength(1); y++)
            {
                for (int x = 0; x < cell.GetLength(0); x++)
                {
                    float distance = Vector3.Distance(Editor.camera.position, cell[x, y].center);
                    if (distance < Editor.camera.viewDistance)
                    {
                        if (Editor.camera.boundingFrustrum.Contains(cell[x, y].boundingBox) != ContainmentType.Disjoint)
                        {
                            basicEffect.World = cell[x, y].world;
                            basicEffect.View = view;
                            basicEffect.Projection = projection;

                            basicEffect.CommitChanges();

                            //------- PickRay Test -------
                            cell[x, y].boundingBox.Intersects(ref pickRay, out rayLength);

                            if (rayLength.HasValue)
                                basicEffect.DiffuseColor = Color.Red.ToVector3();
                            else
                                basicEffect.DiffuseColor = Vector3.One;
                            //------- PickRay Test -------

                            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
                            {
                                pass.Begin();
                                cell[x, y].Draw(graphicsDevice, view, projection);
                                pass.End();
                            }
                        }
                    }
                }
            }

            basicEffect.End();
        }

        /// <summary>
        /// Draw the Terrain using a Shader file. Method called from Draw();
        /// </summary>
        private void EffectDraw(GraphicsDevice graphicsDevice, Matrix view, Matrix projection)
        {
            //Ray pickRay = Editor.camera.GetPickRay();
            //float? rayLength;

            effect.Begin();

            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Begin();
                for (int y = 0; y < cell.GetLength(1); y++)
                {
                    for (int x = 0; x < cell.GetLength(0); x++)
                    {
                        float distance = Vector3.Distance(Editor.camera.position, cell[x, y].center);
                        if (distance < Editor.camera.viewDistance)
                        {
                            if (Editor.camera.boundingFrustrum.Contains(cell[x, y].boundingBox) != ContainmentType.Disjoint)
                            {
                                effectParams.Update(cell[x, y].world, view, projection);

                                //------- PickRay Test -------
                                //cell[x, y].boundingBox.Intersects(ref pickRay, out rayLength);

                                //if (rayLength.HasValue)
                                //    effectParams.Update(Color.LightBlue.ToVector4());
                                //else
                                //    effectParams.Update(Vector4.One);
                                //------- PickRay Test -------

                                effect.CommitChanges();

                                cell[x, y].Draw(graphicsDevice, view, projection);
                                //cell[x,y].boundingBoxWire.Draw(graphicsDevice, Matrix.Identity, view, projection);
                            }
                        }
                    }
                }
                pass.End();
            }
            effect.End();
        }
    }
}
