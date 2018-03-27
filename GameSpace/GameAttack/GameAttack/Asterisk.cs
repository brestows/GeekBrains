using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GameAttack
{
    class Asterisk : GameObject
    {
        public Asterisk(Point pos, Point dir, Size sz) : base(pos, dir, sz) { }

        public override void Draw()
        {
            System.Drawing.Font fnt = new System.Drawing.Font("Arial", 16);
            System.Drawing.StringFormat frmt = new System.Drawing.StringFormat();
            System.Drawing.SolidBrush brsh = new System.Drawing.SolidBrush(System.Drawing.Color.White);
            Game._buffer.Graphics.DrawString("*", fnt, brsh, _position.X, _position.Y, frmt);
        }
    }
}
