//======================================================================
// XNA Terrain Editor
// Copyright (C) 2007 Eric Grossinger
// http://psycad007.spaces.live.com/
//======================================================================
using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace XNATerrainEditor
{
    class HeightmapModifier
    {        
        private Optimized_Heightmap heightmap;
        
        Random random = new Random();

        Timer timer;
        KeyboardState ks;

        Texture2D stamp;

        public HeightmapModifier(ref Optimized_Heightmap heightmap, int timerInterval)
        {
            this.heightmap = heightmap;

            stamp = Editor.content.Load<Texture2D>(@"content\textures\icons\height_cursor_01");

            timer = new Timer(timerInterval);
            timer.Elapsed += new ElapsedEventHandler(Timer_tick);
            timer.Start();
        }

        public void Update()
        {
        }

        Vector2 cursorLocation = new Vector2(1200f, 1200f);
        float force = -3f;
        float i = 0f;
        float radius = 0f;
        private void Timer_tick(Object obj, ElapsedEventArgs e_args)
        {
            //ks = Keyboard.GetState();
            //if (ks.IsKeyDown(Keys.Space))
            //{
                //Rise(new Point(1, 1), new Point(0, 0));

                //Vector2 location = new Vector2((float)random.Next(600, 1000), (float)random.Next(600, 1000));
                //float height = (float)random.Next(0, 100) * 0.05f;
                //Rise(location, height);

                //Stamp(stamp, 2f, new Vector2(800f, 800f), 0.1f);

                cursorLocation += new Vector2((float)Math.Sin(i) * radius, (float)Math.Cos(i) * radius);
                i += 0.01f;
                radius += 0.01f;
                MoveVertices(cursorLocation, 5, 20f + radius * 2f);
            //}            
        }

        public void Stamp(Texture2D texture, float scale, Vector2 location, float force)
        {            
            Color[] pixel = new Color[texture.Width * texture.Height];
            texture.GetData<Color>(pixel);

            int width = (int)(texture.Height * scale);
            int height = (int)(texture.Width * scale);

            Vector2 loc = Vector2.Zero;
            float add_height = 0f;
            int index = 0;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    index = (int)(x / scale) + (int)(y / scale) * (int)(width / scale);

                    loc.X = location.X + x * heightmap.cellSize.X - width / 2 * heightmap.cellSize.X;
                    loc.Y = location.Y + y * heightmap.cellSize.Y - height / 2 * heightmap.cellSize.Y;

                    float percent = (pixel[index].ToVector3().X + pixel[index].ToVector3().Y + pixel[index].ToVector3().Z) / 3.0f;
                    add_height = 1.0f * percent * force;
                    Rise(loc, add_height);
                }
            }
        }

        private void MoveVertices(Vector2 location, int size, float force)
        {
            for (int v = -size; v < size; v++)
            {
                for (int w = -size; w < size; w++)
                {
                    float l = Vector2.Distance(Vector2.Zero, new Vector2(w, v));
                    if (l < size)
                    {
                        float height = 0.1f * (size - l) / 2f * force;
                        Vector2 center = Vector2.Zero;
                        center.X = (float)Math.Round(location.X + w * heightmap.cellSize.X, MidpointRounding.ToEven);
                        center.Y = (float)Math.Round(location.Y + v * heightmap.cellSize.Y, MidpointRounding.ToEven);

                        if(location.X > 0 && location.Y > 0 && 
                           location.X < heightmap.size.X * heightmap.cellSize.X && 
                           location.Y < heightmap.size.Y * heightmap.cellSize.Y)
                            Rise(center, height);
                    }
                }
            }
        }

        public void Rise(Vector2 location, float height)
        {
            Coordinates coords = GetCoordinates(location);
            Rise(coords.cellCoords, coords.cellPoint, height);
        }

        public void Rise(Point cellCoords, Point center, float height)
        {
            //Skip Out-Of-Bounds
            if (cellCoords.X >= 0 && cellCoords.Y >= 0 && cellCoords.X < heightmap.cell.GetLength(0) && cellCoords.Y < heightmap.cell.GetLength(1))
            {
                //Skip references vertices
                if (center.X == heightmap.cellDivisions.X - 1 || center.Y == heightmap.cellDivisions.Y - 1)
                {
                    //Don't skip the last cells, they got no referenced vertices.
                    //if (cellCoords.X < heightmap.cell.GetLength(0) - 1 && cellCoords.Y < heightmap.cell.GetLength(1) - 1)
                        return;
                }

                //if (cellCoords.X == 0 && center.X == 0)
                //    height /= 2f;
                //if (cellCoords.Y == 0 && center.Y == 0)
                //    height /= 2f;

                heightmap.cell[cellCoords.X, cellCoords.Y].UpdateVertex(center.X, center.Y, new Vector3(0f, -height, 0f), HeightmapCell.VertexEquation.Add);
            }
        }

        struct Coordinates
        {
            public Point cellCoords;
            public Point cellPoint;
        }
        private Coordinates GetCoordinates(Vector2 location)
        {
            Coordinates coords = new Coordinates();

            location.X = (float)Math.Round(location.X, MidpointRounding.ToEven);
            location.Y = (float)Math.Round(location.Y, MidpointRounding.ToEven);

            float cvX = location.X / (heightmap.size.X * heightmap.cellSize.X) * heightmap.cell.GetLength(0);
            float cvY = location.Y / (heightmap.size.Y * heightmap.cellSize.Y) * heightmap.cell.GetLength(1);
            coords.cellCoords.X = (int)cvX;
            coords.cellCoords.Y = (int)cvY;

            Vector2 startSize;
            startSize.X = coords.cellCoords.X * heightmap.cellDivisions.X * heightmap.cellSize.X;
            startSize.Y = coords.cellCoords.Y * heightmap.cellDivisions.Y * heightmap.cellSize.Y;

            coords.cellPoint.X = (int)((location.X - startSize.X) / heightmap.cellSize.X);
            coords.cellPoint.Y = (int)((location.Y - startSize.Y) / heightmap.cellSize.Y);

            return coords;
        }
    }
}
