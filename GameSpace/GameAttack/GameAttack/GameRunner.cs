using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace GameAttack
{
    class GameRunner
    {
        static void Main()
        {
            Form frm = new Form();
            frm.Width = 300;
            frm.Height = 500;
            SplashScreen.Init(frm);
            SplashScreen.Destroy();
            frm.Show();
            Application.Run(frm);
        }
    }
}

