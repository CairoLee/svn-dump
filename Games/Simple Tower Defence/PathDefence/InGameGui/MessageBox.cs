using System;
using Microsoft.Xna.Framework.Graphics;
using TomShane.Neoforce.Controls;
using EventArgs=TomShane.Neoforce.Controls.EventArgs;

namespace PathDefence.InGameGui
{
    public class RappingLabel : Label
    {
        private string desiredText;
        private string displayText;
        private bool ww;

        public RappingLabel(Manager manager) : base(manager)
        {
            ww = true;
        }

        public bool WordWrap
        {
            get { return ww; }
            set { ww = value; }
        }

        public override string Text
        {
            get { return displayText; }
            set
            {
                desiredText = value;
                displayText = value;
                base.Text = value;
            }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            WrapText();
        }

        public virtual void WrapText()
        {
            if (desiredText != null)
            {
                if (WordWrap)
                {
                    SpriteFont cFont = Skin.Layers[0].Text.Font.Resource;
                    String line = String.Empty;
                    String returnString = String.Empty;
                    String[] wordArray = desiredText.Split(' ');

                    foreach (String word in wordArray)
                    {
                        if (Math.Ceiling(cFont.MeasureString(line + word).Length()) > Width)
                        {
                            returnString = returnString + line + '\n';
                            line = String.Empty;
                        }

                        line = line + word + ' ';
                    }

                    displayText = returnString + line;
                }
            }
        }
    }

    public class MessageBox : Window
    {
        public const int Hoffset = 14;
        public const int LargeSep = 15;
        public const int SmallSep = 10;
        public const int V2offset = 12;
        public const int Voffset = 14;
        private readonly Manager Man;
        private readonly string Message;
        private readonly string Title;
        public RappingLabel MessageLabel;
        public Button OKbutton;

        public MessageBox(Manager manager) : this(manager, "Message", "This is a empty message.")
        {
        }

        public MessageBox(Manager manager, string title, string message) : base(manager)
        {
            Title = title;
            Message = message;
            Man = manager;
        }

        public override void Init()
        {
            base.Init();
            //this.Width = this.Man.Window.Width / 4;
            //this.Height = manager.Window.Height / 3;
            Center();
            Resizable = true;
            Text = Title;

            OKbutton = new Button(Man);
            OKbutton.Init();
            OKbutton.Text = "OK";
            OKbutton.Width = (int) Math.Ceiling(Width/1.5);
            OKbutton.Height = 20;
            OKbutton.Left = ((Width/2) - (Hoffset/2)) - (OKbutton.Width/2);
            OKbutton.Top = Height - OKbutton.Height - LargeSep - Voffset -
                           V2offset;
            OKbutton.Click += OKclicked;
            Add(OKbutton);

            MessageLabel = new RappingLabel(Man);
            MessageLabel.WordWrap = true;
            MessageLabel.Top = (Voffset/2) + V2offset;
            MessageLabel.Left = (Hoffset/2);
            MessageLabel.Width = Width - Hoffset - LargeSep;
            MessageLabel.Height = Height - Voffset - V2offset -
                                  OKbutton.Height - LargeSep;
            MessageLabel.Alignment = Alignment.TopCenter;
            MessageLabel.Text = Message;
            Add(MessageLabel);

            Focused = true;
            BringToFront();
        }

        protected virtual void OKclicked(object sender, EventArgs args)
        {
            Close(ModalResult.Ok);
        }

        protected override void OnResizeEnd(EventArgs e)
        {
            base.OnResizeEnd(e);
            OKbutton.Width = (int) Math.Ceiling(Width/1.5);
            OKbutton.Height = 20;
            OKbutton.Left = ((Width/2) - (Hoffset/2)) - (OKbutton.Width/2);
            OKbutton.Top = Height - OKbutton.Height - LargeSep - Voffset -
                           V2offset;
            MessageLabel.Top = (Voffset/2) + V2offset;
            MessageLabel.Left = (Hoffset/2);
            MessageLabel.Width = Width - Hoffset - LargeSep;
            MessageLabel.Height = Height - Voffset - V2offset -
                                  OKbutton.Height - LargeSep;
        }
    }
}