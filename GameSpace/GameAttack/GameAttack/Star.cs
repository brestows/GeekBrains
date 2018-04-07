using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GameAttack
{
    /// <summary>
    /// Класс звезды для главной формы
    /// методы описаны в классе наследнике GameObject
    /// </summary>
    class Star : GameObject
    {
        public Star(Point pos, Size sz) : base(pos, sz) { }
        public override void Draw()
        {
            Game._buffer.Graphics.DrawLine(Pens.White, _position.X, _position.Y, _size.Width + _position.X, _size.Height + _position.Y);
            Game._buffer.Graphics.DrawLine(Pens.White, _position.X + _size.Width, _position.Y, _position.X, _size.Height + _position.Y);
        }
        public override void Update()
        {
            _position.X -= 3;
            if (_position.X < -60) _position.X = 799;
        }
    }
}

