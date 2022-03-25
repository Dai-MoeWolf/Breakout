using Breakout.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Breakout
{
    internal class GameObjectManager
    {
        public static List<Brick> brickList = new List<Brick>();
        public static Board board;
        public static Ball ball;
        public static void Update()
        {
            foreach (Brick brick in brickList)
            {
                brick.Update();
            }
            board.Update();
            ball.Update();
        }
        public static Brick BallIsCollidedWithBrick(Rectangle rectangle)
        {
            foreach(Brick bricks in brickList)
            {
                if (bricks.GetRectangle().IntersectsWith(rectangle)){
                    
                    return bricks;
                }
            }
            return null;
        }
        public static void DestroyBrick(Brick brick)
        {
            brickList.Remove(brick);
        }

        #region 检查小球与挡板的碰撞
        public static bool BallIsCollidedWithBoard()
        {
            if (ball.GetRectangle().IntersectsWith(board.GetRectangle()))
            {
                return true;
            }
            return false;
        }
        #endregion

        #region 检查小球是否掉落，掉落后重置挡板和小球
        public static bool BallIsFell()
        {
            if (ball.Y + ball.Speed >= 650)
            {
                return true;
            }
            else return false;
        }
        #endregion
        public static void CreateMap()   //地图初始化
        {
            //初始化砖块
            CreateBrick(40,20,5);//第一条
            CreateBrick(200,20,5);
            CreateBrick(360,20,5);
            CreateBrick(520,20,5);
            //初始化挡板
            CreateBoard(260,450,8);
            //初始化小球
            CreateBall(310,430,12);
        }
        public static void CreateBoard(int x,int y,int speed)
        {
            board = new Board(x,y,Resources.board,speed);
        }
        public static void CreateBall(int x, int y,int speed) 
        { 
            ball = new Ball(x,y,Resources.ball,speed);
        }
        public static void CreateBrick(int x,int y,int count) //按条创建砖块
        {
            for(int i = 1; i <= count ; i++)
            {
                Brick brick = new Brick(x,y,Resources.brick);
                brickList.Add(brick);
                y += 40;
            }
        }
        //具体操作放入Board中
        public static void KeyDown(KeyEventArgs args)
        {
            board.KeyDown(args);
        }
        public static void KeyUp(KeyEventArgs args)
        {
            board.KeyUp(args);
        }
    }
}
