using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GameAttack
{
    class Star: GameObject
    {
        public Star(Point pos, Point dir, Size sz) : base(pos, dir, sz) { }

        public override void Draw()
        {
            Game._buffer.Graphics.DrawLine(Pens.White, _position.X, _position.Y, _size.Width + _position.X, _size.Height + _position.Y);
            Game._buffer.Graphics.DrawLine(Pens.White, _position.X + _size.Width, _position.Y, _position.X, _size.Height + _position.Y);
        }           
    }
}
