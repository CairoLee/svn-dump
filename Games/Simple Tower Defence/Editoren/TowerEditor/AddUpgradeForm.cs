using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TowerEditor
{
    public partial class AddUpgradeForm : Form
    {
        public List<string> Upgrades { get; private set; }

        public string UpgradeType { get { return cbxType.Text.ToLower(); } set { cbxType.Text = value.ToLower(); } }
        public string UpgradeName { get { return tbxName.Text; } set { tbxName.Text = value; } }
        public string UpgradeKey { get { return tbxKey.Text.ToLower(); } set { tbxKey.Text = value.ToLower(); } }
        public string UpgradeValue { get { return tbxValue.Text; } set { tbxValue.Text = value; } }
        public string UpgradePrice { get { return tbxPrice.Text; } set { tbxPrice.Text = value; } }
        public string UpgradeRequirements { get { return cbxRequirements.Text.ToLower(); } set { cbxRequirements.Text = value.ToLower(); } }
        public string UpgradeDescription { get { return tbxDescription.Text; } set { tbxDescription.Text = value; } }

        public AddUpgradeForm()
        {
            InitializeComponent();
            Upgrades = new List<string>();
        }

        private void cbxType_TextChanged(object sender, EventArgs e)
        {
            tbxKey.Text = cbxType.Text.ToLower();
        }

        private void AddUpgradeForm_Load(object sender, EventArgs e)
        {
            cbxRequirements.Items.AddRange(Upgrades.ToArray());
        }
    }
}
