using TomShane.Neoforce.Controls;
using Microsoft.Xna.Framework.Graphics;

namespace PathDefence.InGameGui
{
    class ImageButton: Button
    {
        private ImageBox ImageBox;

        public Texture2D Image { get; set; }
        public SizeMode SizeMode { get; set; }

        public ImageButton(Manager manager) : base(manager)
        {
            ImageBox = new ImageBox(manager);
            
        }

        public override void Init()
        {
            base.Init();
            Text = "";

            ImageBox.Init();
            ImageBox.Image = Image;
            ImageBox.Parent = this;
            ImageBox.Width = ImageBox.Parent.Width - 10;
            ImageBox.Height = ImageBox.Parent.Height - 10;
            ImageBox.Top = 5;
            ImageBox.Left = 5;
            ImageBox.SizeMode = SizeMode;
            ImageBox.Passive = true;
        }
    }
}
