﻿using System;
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


        public delegate void CollisionEvent();
        public static event CollisionEvent ColEvent;

        private Bitmap img;
        public Bullet(Point pos, Size sz) : base(pos, sz) { }
        

        public override void Draw()
        {
            img = new Bitmap(Properties.Resources.bullet);
            Color transparent = img.GetPixel(0, 0);
            img.MakeTransparent(transparent);
            img.RotateFlip(RotateFlipType.Rotate180FlipY);
            Game._buffer.Graphics.DrawImage(img, _position.X , _position.Y, _size.Width, _size.Height);
        }
        /// <summary>
        /// Реализация методов интерфейса ICollision
        /// </summary>
        public Rectangle Rect { get => rect; set => rect = value; }
        public bool Collision(ICollision _object)
        {
            return rect.IntersectsWith(_object.Rect);
        }
        /// <summary>
        /// Обновляем координаты обеъкта пули 
        /// а так же проверяем на столкновение с 
        /// метеоритом
        /// </summary>
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
                        ColEvent();
                        ObjectPosition = new Point(40, ObjectPosition.Y);                        
                        obj.ObjectPosition = new Point(800, obj.ObjectPosition.Y);
                    }
                }
            }
        }
     }
}
