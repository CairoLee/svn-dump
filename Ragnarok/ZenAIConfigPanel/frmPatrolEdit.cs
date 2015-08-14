using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ZenAIConfigPanel.Expression;

namespace ZenAIConfigPanel {

	public partial class frmPatrolEdit : Form {
		private List<int[]> mSteps;
		private List<int[]> mStepsDefault;
		private bool mManuEdit = false;

		public frmPatrolEdit() {
			InitializeComponent();
			InitializeControls();

			mSteps = new List<int[]>();
			mStepsDefault = new List<int[]>();
			mStepsDefault.Add(new int[] { 4, 4 });
			mStepsDefault.Add(new int[] { 7, 3 });
			mStepsDefault.Add(new int[] { 10, 4 });
			mStepsDefault.Add(new int[] { 11, 7 });
			mStepsDefault.Add(new int[] { 10, 10 });
			mStepsDefault.Add(new int[] { 7, 11 });
			mStepsDefault.Add(new int[] { 4, 10 });
			mStepsDefault.Add(new int[] { 3, 7 });
		}


		private void InitializeControls() {
			for (int x = 0; x < 15; x++) {
				for (int y = 0; y < 15; y++) {
					Panel pnl = CreatePanel(x, y);
					if (x == 7 && y == 7)
						pnl.BackColor = Color.SteelBlue; // alche
					pnl.MouseClick += new MouseEventHandler(Control_MouseClick);
					pnlStepContainer.Controls.Add(pnl);
				}
			}
		}

		#region frmPatrolEdit Events
		private void frmPatrolEdit_Shown(object sender, EventArgs e) {
			if (File.Exists("Patrol.lua") == false)
				return;

			List<string> Lines = new List<string>(File.ReadAllLines("Patrol.lua", ASCIIEncoding.Default));
			for (int i = 0; i < Lines.Count; i++) {
				string line = Lines[i].Trim();
				// kill comments
				if (line.Length < 2 || line.StartsWith("--")) {
					Lines.RemoveAt(i);
					i--;
					continue;
				}
				if (line.Contains("--")) {
					// contains comment, remove it
					Lines[i] = Lines[i].Substring(0, Lines[i].IndexOf("--")).Trim();
				}
			}

			ParsePatrol(Lines);
		}
		#endregion

		#region btnDefault Events
		private void btnDefault_Click(object sender, EventArgs e) {
			mManuEdit = true;
			for (int i = 0; i < mSteps.Count; )
				Control_MouseClick(pnlStepContainer.Controls["pnlStep" + mSteps[i][0] + "_" + mSteps[i][1]], new MouseEventArgs(MouseButtons.Right, 1, 0, 0, 0));
			for (int i = 0; i < mStepsDefault.Count; i++)
				Control_MouseClick(pnlStepContainer.Controls["pnlStep" + mStepsDefault[i][0] + "_" + mStepsDefault[i][1]], new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
			mManuEdit = false;
			RefreshStepLabel();
		}
		#endregion

		#region btnSave Events
		private void btnSave_Click(object sender, EventArgs e) {
			if (mSteps.Count > 0)
				SavePatrol();
			Close();
		}
		#endregion

		#region pnlStep Events
		private void Control_MouseClick(object sender, MouseEventArgs e) {
			Panel pnl = sender as Panel;
			if (pnl == null)
				return;
			int[] coord = (int[])pnl.Tag;
			if (coord[0] == 7 && coord[1] == 7)
				return; // dont edit center?

			if (e.Button == MouseButtons.Left) {
				if (mSteps.Contains(coord) == false) {
					pnl.BackColor = Color.LightSkyBlue;
					mSteps.Add(coord);
				}
			} else {
				if (mSteps.Contains(coord) == true) {
					pnl.BackColor = Color.FromKnownColor(KnownColor.ActiveBorder);
					pnl.Controls[0].Text = "";
					mSteps.Remove(coord);
				}
			}
			if (mManuEdit == false)
				RefreshStepLabel();
		}
		#endregion


		private void ParsePatrol(List<string> Lines) {
			int AAI_CIRC_RADIUS = 0;
			Evaluator eval = new Evaluator();
			Dictionary<string, int> steps = new Dictionary<string, int>();
			List<string> stepsX = new List<string>();
			List<string> stepsY = new List<string>();
			for (int i = 0; i < Lines.Count; i++) {
				string line = Lines[i].Trim();
				Match m = Regex.Match(line, @"^([^=]+)=([^;]+)");
				if (m.Success == true) {
					string key = m.Groups[1].Value.Trim();
					string value = m.Groups[2].Value.Trim();
					if (key == "AAI_CIRC_MAXSTEP")
						continue; // no need

					if (key == "AAI_CIRC_RADIUS") {
						AAI_CIRC_RADIUS = int.Parse(value);
						continue;
					}
					if (key == "AAI_CIRC_X") {
						value = value.Substring(1, value.Length - 2); // remove { }
						stepsX.AddRange(value.Split(new char[] { ',' }));
						continue;
					}
					if (key == "AAI_CIRC_Y") {
						value = value.Substring(1, value.Length - 2); // remove { }
						stepsY.AddRange(value.Split(new char[] { ',' }));
						continue;
					}
					object mathObj = eval.Eval(value.Replace("AAI_CIRC_RADIUS", AAI_CIRC_RADIUS.ToString()));
					steps.Add(key, (int)mathObj);
					continue;
				}
			}

			ValidatePatrol(steps, stepsX, stepsY);
		}

		private void ValidatePatrol(Dictionary<string, int> StepNames, List<string> stepsX, List<string> stepsY) {
			for (int i = 0; i < stepsX.Count; i++) {
				string value = stepsX[i].Trim();
				int x;
				if (int.TryParse(value, out x) == false) {
					if (StepNames.ContainsKey(value) == false)
						continue; // badly..
					x = StepNames[value];
				}

				value = stepsY[i].Trim();
				int y;
				if (int.TryParse(value, out y) == false) {
					if (StepNames.ContainsKey(value) == false)
						continue; // badly..
					y = StepNames[value];
				}

				int[] stepPair = new int[2] { 7 + x, 7 + y };
				Control_MouseClick(pnlStepContainer.Controls["pnlStep" + stepPair[0] + "_" + stepPair[1]], new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
			}
		}

		private void SavePatrol() {
			if (File.Exists("Patrol.lua") == true)
				try { File.Delete("Patrol.lua"); } catch { }

			using (StreamWriter file = new StreamWriter(File.OpenWrite("Patrol.lua"), ASCIIEncoding.Default)) {
				string nl = Environment.NewLine;
				file.WriteLine("--------------------------------------------------");
				file.WriteLine("-- ZenAI 1.1a Patrol/Evade Movements");
				file.WriteLine("-- [created with GodLesZ " + frmMain.APP_VERSION + "]");
				file.WriteLine("--------------------------------------------------");

				string lineX = "AAI_CIRC_X = { ";
				string lineY = "AAI_CIRC_Y = { ";
				for (int i = 0; i < mSteps.Count; i++) {
					lineX += (mSteps[i][0] - 7);
					lineY += (mSteps[i][1] - 7);
					if (i < mSteps.Count - 1) {
						lineX += ", ";
						lineY += ", ";
					}
				}
				lineX += " };";
				lineY += " };";

				file.WriteLine(lineX);
				file.WriteLine(lineY);
				file.WriteLine("AAI_CIRC_MAXSTEP = " + mSteps.Count + ";");
			}
		}

		private Panel CreatePanel(int x, int y) {
			Panel pnl = new Panel();
			pnl.BackColor = SystemColors.ActiveBorder;
			pnl.BorderStyle = BorderStyle.FixedSingle;
			pnl.Location = new Point((19 * x) - 1, (19 * y) - 1);
			pnl.Name = "pnlStep" + x + "_" + y;
			pnl.Tag = new int[2] { x, y };
			pnl.Size = new System.Drawing.Size(20, 20);

			Label lbl = new Label();
			lbl.AutoSize = false;
			lbl.Dock = DockStyle.Fill;
			lbl.Location = new Point(0, 0);
			lbl.Font = new Font("Tahoma", 7);
			lbl.Name = "lblStep" + x + "_" + y;
			lbl.Text = "";
			lbl.TextAlign = ContentAlignment.MiddleCenter;
			lbl.MouseClick += delegate(object sender, MouseEventArgs e) {
				Control_MouseClick((sender as Control).Parent, e);
			};

			pnl.Controls.Add(lbl);

			return pnl;
		}

		private void RefreshStepLabel() {
			for (int i = 0; i < mSteps.Count; i++) {
				Panel pnl = pnlStepContainer.Controls["pnlStep" + mSteps[i][0] + "_" + mSteps[i][1]] as Panel;
				pnl.Controls[0].Text = (i + 1).ToString();
			}
		}

	}

}
