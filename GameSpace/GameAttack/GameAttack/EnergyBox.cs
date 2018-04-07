using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAttack
{
    class EnergyBox : GameObject, ICollision
    {


        private Bitmap img;

        public EnergyBox(Point pos, Size sz) : base(pos, sz)
        {
        }

        public Rectangle Rect { get => rect; set => rect = value; }

        public bool Collision(ICollision _object)
        {
            return rect.IntersectsWith(_object.Rect);
        }

        public override void Draw()
        {
            img = new Bitmap(Properties.Resources.box);
            Color transparent = img.GetPixel(0, 0);
            img.MakeTransparent(transparent);
            Game._buffer.Graphics.DrawImage(img, _position.X, _position.Y, _size.Width, _size.Height);
        }

        public override void Update()
        {
            _position.X -= 3;
            //придерживаем аптечку за кадром
            // что бы далеко не уплыла
            if (_position.X < -100)
            {
                _position.X = -70;
                _position.Y = -70;
            }
            rect.Location = _position;
        }
        /// <summary>
        /// Метод вызывается случайно. тем самым
        /// добавляет на сцену аптечку.
        /// </summary>
        public void IneedHelp()
        {
            Random rnd = new Random();
            _position.X = 800;
            _position.Y = rnd.Next(0, 600);
        }
    }
}
