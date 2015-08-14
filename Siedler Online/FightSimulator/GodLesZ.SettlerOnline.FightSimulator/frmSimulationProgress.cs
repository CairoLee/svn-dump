using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GodLesZ.SettlerOnline.FightSimulator
{
    public partial class frmSimulationProgress : Form
    {
        int max;     

        public int ProzessMax
        {
            get { return max; }
            set { max = value; }
        }     

        public frmSimulationProgress(int Maximum)
        {
            InitializeComponent();
            progressBar1.Visible = true;
            progressBar1.Minimum = 1;
            progressBar1.Maximum = Maximum;
            progressBar1.Step = 1;            
        }

        public void Step()
        {
            this.progressBar1.PerformStep();
            this.label1.Text = this.progressBar1.Value.ToString() + " / " + this.progressBar1.Maximum.ToString();
            this.Refresh();
            if (this.progressBar1.Value == this.progressBar1.Maximum) this.button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
