using System;
using System.Drawing;
using System.Windows.Forms;

namespace eAthenaTool.Library.Tools
{
    class YesNoQuestion : Form
    {
        #region DECLARE & INITIALIZE VARS

        private Label Label_Question = new Label();
        private Button Button_Yes = new Button();
        private Button Button_No = new Button();

        #endregion

        #region CONSTRUCTOR

        public YesNoQuestion(string Titel, string Question, string YesButtonText, string NoButtonText)
        {
            InitializeComponents(Titel, Question, YesButtonText, NoButtonText);
        }

        #endregion

        #region INITIALIZE COMPONENTS

        private void InitializeComponents(string Titel, string Question, string YesButtonText, string NoButtonText)
        {
            #region ADD EVENTHANDLER

            Button_Yes.Click += new EventHandler(Button_Yes_Click);
            Button_No.Click += new EventHandler(Button_No_Click);

            #endregion

            #region SETTINGS

            #region FORM

            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.ClientSize = new Size(484, 134);
            this.Name = "YesNoWindow";
            this.Text = Titel;
            this.ControlBox = false;

            #endregion

            #region ELEMENTS

            Label_Question.Location = new Point(12, 9);
            Label_Question.Size = new Size(460, 87);
            Label_Question.Name = "Label_Question";
            Label_Question.Text = Question;
            Label_Question.TabIndex = 0;

            Button_Yes.Location = new Point(316, 99);
            Button_Yes.Size = new Size(75, 23);
            Button_Yes.Name = "Button_Yes";
            Button_Yes.Text = YesButtonText;
            Button_Yes.TabIndex = 1;

            Button_No.Location = new Point(397, 99);
            Button_No.Size = new Size(75, 23);
            Button_No.Name = "Button_No";
            Button_No.Text = NoButtonText;
            Button_No.TabIndex = 2;

            #endregion

            #endregion

            #region ADD ELEMENTS TO FORM

            this.Controls.AddRange(new Control[]
            {
                Label_Question,
                Button_Yes,
                Button_No
            });

            #endregion
        }

        #endregion

        #region BUTTON METHOS

        private void Button_Yes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void Button_No_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        #endregion
    }
}
