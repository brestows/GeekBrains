using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GameAttack
{
    /// <summary>
    /// Класс Метеорита в виде спутника для главной формы
    /// методы описаны в классе наследнике GameObject
    /// </summary>
    class Meteor : GameObject, ICollision
    {
        public Meteor(Point pos, Size sz) : base(pos, sz) { }

        private Bitmap img;
        public override void Draw()
        {
            img = new Bitmap(Properties.Resources.star);
            Color transparent = img.GetPixel(1, 1);
            img.MakeTransparent(transparent);
            Game._buffer.Graphics.DrawImage(img, _position.X, _position.Y);
        }

        public override void Update()
        {
            _position.X -= 3;
            if (_position.X < -60) _position.X = 799;
            rect.Location = _position;
        }
        public Rectangle Rect { get => rect; set => rect = value; }
        public bool Collision(ICollision _object)
        {

            return this.rect.IntersectsWith(_object.Rect);
            //return this.Rect.IntersectsWith(_object.Rect);
        }
    }
}
