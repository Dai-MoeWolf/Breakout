using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout
{
    enum Direction{ 
        RightUp,
        LeftUp,
        RightDown,
        LeftDown,
    }
    internal class Ball : GameObject
    {
        private Bitmap bitmap;
        public Bitmap Bitmap
        {
            get { return bitmap; }
            set
            {
                bitmap = value;
                Width = bitmap.Width;
                Height = bitmap.Height;
            }
        }
        public int Speed { get; set; }
        public bool IsMoving { get; set; }
        public Direction Direction { get; set; }

        protected override Image GetImage()
        {
            Bitmap.MakeTransparent(Color.White);    //将小球的白色背景变成透明
            return Bitmap;
        }
        public Ball(int x, int y, Bitmap bitmap,int speed)
        {
            this.X = x;
            this.Y = y;
            this.Speed = speed;
            this.Bitmap = bitmap;
            this.Direction = Direction.RightUp;
            this.IsMoving = false;
        }
        public override void Update()
        {
            MoveCheck();//移动检查
            Move();
            base.Update();
        }
        
        public void MoveCheck()
        {
            #region 检查小球与窗体的碰撞
            //检查有没有超出窗体边界
            if (Direction == Direction.RightUp)
            {
                if (X + Speed >= 640)
                {
                    Direction = Direction.LeftUp;
                }
                if (Y + Speed <= 0)
                {
                    Direction=Direction.RightDown;
                }
            }
            if (Direction == Direction.LeftUp)
            {
                if (Y + Speed <= 0)
                {
                    Direction= Direction.LeftDown;
                }
                if(X + Speed <= 0)
                {
                    Direction = Direction.RightUp;
                }
            }
            if (Direction == Direction.RightDown) {
                if(X + Speed >= 640)
                {
                    Direction = Direction.LeftDown;
                }
            }
            if (Direction == Direction.LeftDown) { 
                if(X + Speed <= 0)
                {
                    Direction = Direction.RightDown;
                }
            }
            #endregion


            #region 与砖块碰撞后的运动逻辑
            Rectangle rectangle = GetRectangle();
            Brick brick = null;
            if ((brick =GameObjectManager.BallIsCollidedWithBrick(rectangle)) != null)
            {
                //运动逻辑
                switch (Direction)
                {
                    case Direction.RightUp:
                        Direction = Direction.RightDown;
                        break;
                    case Direction.LeftUp:
                        Direction = Direction.LeftDown;
                        break;
                    case Direction.RightDown:
                        Direction = Direction.RightUp;
                        break;
                    case Direction.LeftDown:
                        Direction = Direction.LeftUp;
                        break;
                }
                GameObjectManager.DestroyBrick(brick);
            }
            #endregion

            //与挡板碰撞后的运动逻辑
            if (GameObjectManager.BallIsCollidedWithBoard())
            {
                if(Direction == Direction.RightDown)
                {
                    Direction = Direction.RightUp;
                }
                if(Direction == Direction.LeftDown)
                {
                    Direction = Direction.LeftUp;
                }
            }

            //掉落后的重置逻辑
            if (GameObjectManager.BallIsFell())
            {
                GameObjectManager.board.X = 260;
                this.X = 310;
                this.Y = 430;
                this.IsMoving = false;
                this.Direction = Direction.RightUp;
            }

        }
        public void Move()
        {
            if (IsMoving == false) {    //如果没有按下空格的话，小球和挡板一起移动
                if (GameObjectManager.board.IsMoving == true) { 
                    X = GameObjectManager.board .X + GameObjectManager.board.Width/2 - Width/2;
                }
                return;
            }
            switch (Direction)
            {
                case Direction.RightUp:
                    X += Speed;
                    Y -= Speed;
                    break;
                case Direction.LeftUp:
                    X -= Speed;
                    Y -= Speed;
                    break;
                case Direction.RightDown:
                    X += Speed;
                    Y += Speed;
                    break;
                case Direction.LeftDown:
                    X -= Speed;
                    Y += Speed;
                    break;
            }
        }
    }
}
