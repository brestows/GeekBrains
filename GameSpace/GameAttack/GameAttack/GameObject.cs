using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GameAttack
{
    class GameObject
    {
        protected Point _position;
        protected Point _dir;
        protected Size _size;
        private Bitmap img;
        public GameObject(Point pos, Point dir, Size sz)
        {
            _position = pos;
            _dir = dir;
            _size = sz;
        }

        public virtual void Draw()
        {           
            img = new Bitmap(Properties.Resources.star);
            Color transparent = img.GetPixel(1, 1);
            img.MakeTransparent(transparent);
            Game._buffer.Graphics.DrawImage(img, _position.X, _position.Y);
        }

        public virtual void Update()
        {
            _position.X -= 3;
            if (_position.X < -60) _position.X = 799;
        }

    }
}
