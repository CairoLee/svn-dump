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
    
    public partial class frmInput : Form
    {        
        string returnValue;
        string dialogText;
        string dialogDefaultValue;
        string dialogTitel;

        public frmInput()
        {
            InitializeComponent();
            returnValue = "";
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        public string Konfigurationsname
        {
            get { return returnValue; }
            set { returnValue = value; }
        }

        public string DialogText
        {
            get { return dialogText; }
            set { dialogText = value; }
        }

        public string DialogDefaultValue
        {
            get { return dialogDefaultValue; }
            set { dialogDefaultValue = value; }
        }

        public string DialogTitel
        {
            get { return dialogTitel; }
            set { dialogTitel = value; }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            returnValue = this.txtReturnValue.Text;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DialogForm_Load(object sender, EventArgs e)
        {
            this.lblDialogText.Text = dialogText;
            this.txtReturnValue.Text = DialogDefaultValue;            
            this.Text = dialogTitel;
        }
    }
}
