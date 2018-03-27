using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GameAttack
{
    class Ufo : GameObject
    {
        public Ufo(Point pos, Point dir, Size sz) : base(pos, dir, sz) { }
        private Bitmap img;
        public override void Draw()
        {
            img = new Bitmap(Properties.Resources.ufo);
            Color transparent = img.GetPixel(1, 1);
            img.MakeTransparent(transparent);
            SplashScreen._bfr.Graphics.DrawImage(img, _position.X, _position.Y);
        }
    }
}
