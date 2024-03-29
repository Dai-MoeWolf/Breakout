﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout
{
    abstract class GameObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }  //根据自身image来设置宽高
        public int Height { get; set; }
        protected abstract Image GetImage();
        public void DrawSelf()
        {
            Graphics g = GameFramework.g;
            g.DrawImage(GetImage(), X, Y);
        }
        public virtual void Update()
        {
            DrawSelf();
        }
        public Rectangle GetRectangle()//用于碰撞检测，获取自身的信息
        {
            Rectangle rectangle = new Rectangle(X, Y, Width, Height);
            return rectangle;
        }
    }
}
