﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GameAttack
{
    /// <summary>
    /// Класс НЛО для SplashScreen
    /// </summary>
    class Ufo : GameObject
    {
        public Ufo(Point pos,  Size sz) : base(pos,  sz) { }
        private Bitmap img;
        public override void Draw()
        {
            img = new Bitmap(Properties.Resources.ufo);
            Color transparent = img.GetPixel(1, 1);
            img.MakeTransparent(transparent);
            SplashScreen._bfr.Graphics.DrawImage(img, _position.X, _position.Y);
        }
        public override void Update()
        {
            _position.X -= 3;
            if (_position.X < -60) _position.X = 799;
        }
    }
}

