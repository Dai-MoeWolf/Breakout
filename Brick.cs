using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout
{
    internal class Brick : GameObject
    {
        public Image Img { get; set; }
        protected override Image GetImage()
        {
            return Img;
        }
        public Brick(int x,int y,Image image)
        {
            this.X = x;
            this.Y = y;
            this.Img = image;
            this.Width = image.Width;
            this.Height = image.Height;
        }
    }
}
