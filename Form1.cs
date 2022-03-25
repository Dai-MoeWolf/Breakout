using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Breakout
{
    public partial class Form1 : Form
    {
        private Thread t;
        private static Graphics windowG;
        private static Bitmap tempBmp;
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            //拿到当前画布
            windowG = this.CreateGraphics();
            //屏幕闪烁问题
            tempBmp = new Bitmap(850, 600); //临时画布，将所有游戏元素绘制在上面之后，再将画布绘制到主画布上
            Graphics bmpG = Graphics.FromImage(tempBmp);
            GameFramework.g = bmpG;
            //GameFramework.g = windowG;
            //子线程用于游戏循环
            t = new Thread(new ThreadStart(GameMainThread));
            t.Start();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            t.Abort();
        }
        private static void GameMainThread()
        {
            GameFramework.Start();
            int sleepTime = 1000 / 120;  //休眠时间
            while (true)
            {
                GameFramework.g.Clear(Color.White);
                GameFramework.Update();     //120 FPS
                windowG.DrawImage(tempBmp, 0, 0);   //将临时画布绘制到窗体画布上
                Thread.Sleep(sleepTime);
            }
        }

        //事件消息  先将处理放入GameObjectManager
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            GameObjectManager.KeyDown(e);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            GameObjectManager.KeyUp(e);
        }
    }
}
