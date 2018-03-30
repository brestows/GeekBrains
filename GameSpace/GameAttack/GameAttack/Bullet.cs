using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAttack
{
    class Bullet : GameObject
    {
        public Bullet(Point pos, Size sz) : base(pos, sz) {
       
        }
        private Bitmap img;

        public override void Draw()
        {
            img = new Bitmap(Properties.Resources.bullet);
            Color transparent = img.GetPixel(0, 0);
            img.MakeTransparent(transparent);
            img.RotateFlip(RotateFlipType.Rotate180FlipY);
            Game._buffer.Graphics.DrawImage(img, (_position.X-800)*-1, (_position.Y-600)*-1);
        }

        public override void Update()
        {
            _position.X -= 3;
            if (_position.X < -60) _position.X = 799;
            rect.Location = _position;
        }
     }
}
