using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GodLesZ.EdenEternal.DataViewer.Library.Formats.Scene;

namespace GodLesZ.EdenEternal.DataViewer.Controls {

	public partial class MapViewControl : UserControl {
		protected SceneFile mSceneData;

		public SceneFile SceneFile {
			get { return mSceneData; }
			set {
				mSceneData = value;
				UpdateSceneData();
			}
		}


		public MapViewControl() {
			InitializeComponent();
		}


		protected void UpdateSceneData() {
			if (SceneFile == null) {
				imageMap.Refresh();
				return;
			}

			var baseImage = SceneFile.GetMapImage() as Bitmap;
			DrawMapInfo(baseImage);
			imageMap.Image = baseImage;
		}

		private void DrawMapInfo(Image baseImage) {
			if (SceneFile == null) {
				return;
			}

			using (var g = Graphics.FromImage(baseImage)) {
				var dotSize = new SizeF(10, 10);
				var dotSizeHalf = new SizeF(dotSize.Width / 2, dotSize.Height / 2);
				var dotOffset = new Point(0, 0);

				foreach (var mob in SceneFile.MobSpawns) {
					//var p = new PointF((mob.X * dotScale.Width) + dotOffsetHalf.Width, (mob.Y * dotScale.Height) + dotOffsetHalf.Height);
					var spawnPoint = new PointF(mob.X - dotSizeHalf.Width + dotOffset.X, baseImage.Height - mob.Y - dotSizeHalf.Height + dotOffset.Y);
					var dotRect = new RectangleF(spawnPoint, dotSize);
					try {
						g.FillRectangle(Brushes.BlueViolet, dotRect);
					} catch (Exception ex) {
						MessageBox.Show("Failed to draw dot: " + dotRect, "Draw error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}

					// Draw route
					if (mob.PatrolID.HasValue) {
						var routeID = mob.PatrolID.Value;
						if (SceneFile.MobRoutes.ContainsKey(routeID)) {
							// @TODO: Maybe create Point instance already in a route instance?

							var route = SceneFile.MobRoutes[routeID];
							// Create space
							var drawPath = new List<PointF>(route.Count);
							// First walking-spot is the spawn position
							drawPath.Add(spawnPoint);
							// Create points for each spot
							drawPath.AddRange(route.Select(spot => new PointF(spot.X + dotOffset.X, spot.Y + dotOffset.Y)));

							g.DrawCurve(Pens.CornflowerBlue, drawPath.ToArray());
						}
					}
				}


			}

		}

		private void imageMap_SizeChanged(object sender, EventArgs e) {
			//UpdateSceneData();
		}

	}

}
