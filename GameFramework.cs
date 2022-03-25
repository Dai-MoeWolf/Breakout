using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Breakout
{
    internal class GameFramework
    {
        public static Graphics g;
        public static void Start()
        {
            GameObjectManager.CreateMap();  //游戏开始初始化一次地图
        }
        public static void Update()
        {
            //GameObjectManager.DrawMap();
            GameObjectManager.Update();
        }
    }
}
