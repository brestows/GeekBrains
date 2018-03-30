using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
namespace GameAttack
{
    class Bullet : GameObject, ICollision
    {
        public Bullet(Point pos, Size sz) : base(pos, sz) {
            rect.Size = new Size(5, 10);
        }
        private Bitmap img;

        public override void Draw()
        {
            img = new Bitmap(Properties.Resources.bullet);
            Color transparent = img.GetPixel(0, 0);
            img.MakeTransparent(transparent);
            img.RotateFlip(RotateFlipType.Rotate180FlipY);
            Game._buffer.Graphics.DrawImage(img, _position.X , _position.Y);
        }
        public Rectangle Rect { get => rect; set => rect = value; }
        public bool Collision(ICollision _object)
        {
        //    Debug.WriteLine(" rect: " + rect + " Object: " + _object.Rect);

            return rect.IntersectsWith(_object.Rect);
        }
        public override void Update()
        {
            _position.X += 3;
            if (_position.X > 799) _position.X = 60;
            rect.Location = _position;
            foreach (GameObject obj in Game._objects)
            {
                if (obj is ICollision)
                {
                    if (Collision(obj as ICollision))
                    {
                        Debug.WriteLine(" COLLISON");
                        ObjectPosition = new Point(40, ObjectPosition.Y);
                        obj.ObjectPosition = new Point(800, obj.ObjectPosition.Y);

                    }
                }
            }
        }
     }
}
