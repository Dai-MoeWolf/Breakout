using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Breakout
{
    enum BoardDirection{
        Left,
        Right,
    }
    internal class Board : GameObject
    {
        private Bitmap bitmap;
        public bool IsMoving { get; set; }
        public Bitmap Bitmap { get { return bitmap; } 
            set
            {
                bitmap = value;
                Width = bitmap.Width;
                Height = bitmap.Height;
            } 
        }
        public int Speed { get; set; }
        public BoardDirection boardDir { get; set; }

        protected override Image GetImage()
        {
            return Bitmap;
        }
        public Board(int x, int y, Bitmap bitmap,int speed)
        {
            IsMoving = false;
            this.X = x;
            this.Y = y;
            this.Bitmap = bitmap;
            Speed = speed;
            boardDir = BoardDirection.Left;
        }
        public override void Update()
        {
            MoveCheck();//移动检查
            Move();
            base.Update();
        }
        public void MoveCheck()
        {
            //检查有没有超出窗体边界
            if (boardDir == BoardDirection.Left) {
                if (X -Speed <= 0)
                {
                    IsMoving = false;
                }
            }
            if(boardDir == BoardDirection.Right)
            {
                if (X +Speed+ Width >= 640)
                {
                    IsMoving=false;
                }
            }
        }
        public void Move()
        {
            if (IsMoving == false) return;
            switch (boardDir) { 
                case BoardDirection.Left:
                    X -= Speed;
                    break;
                case BoardDirection.Right:
                    X += Speed;
                    break ;
            }
        }
        //仅仅是设置状态，具体的移动放入update中，以免移动不流畅
        public void KeyDown(KeyEventArgs args)
        {
            switch (args.KeyCode)
            {
                case Keys.Left:
                    IsMoving = true;
                    boardDir=BoardDirection.Left;
                    break;
                case Keys.Right:
                    IsMoving = true;
                    boardDir=BoardDirection.Right;
                    break;
                case Keys.Space:
                    if (GameObjectManager.ball.IsMoving == false) {
                        GameObjectManager.ball.IsMoving = true;
                    }
                    break;
            }
        }
        public void KeyUp(KeyEventArgs args)
        {
            switch (args.KeyCode)
            {
                case Keys.Left:
                    IsMoving = false;
                    break;
                case Keys.Right:
                    IsMoving = false;
                    break;
                //case Keys.Space:
                //    if (GameObjectManager.ball.IsMoving == false)
                //    {

                //    }
                //    break;
            }
        }
    }
}
