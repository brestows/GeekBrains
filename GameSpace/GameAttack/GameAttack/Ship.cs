using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GameAttack
{
    class Ship : GameObject, ICollision
    {
        public delegate void GameOver();
        public static event GameOver ShipDie;

        public delegate void MedBoxCollision();
        public static event MedBoxCollision EnergyUPevent;

        private Bitmap img;
        private int _energy = 4;
        public int Energy => _energy;
        /// <summary>
        /// Реализация методов интерфейса ICollision
        /// </summary>
        public Rectangle Rect { get => rect; set => rect = value; }

        public bool Collision(ICollision _object)
        {
            return rect.IntersectsWith(_object.Rect);
        }

        public Ship(Point pos, Size sz) : base(pos, sz) { }


        #region Манипуляция с энергией коробля
        public void EnergyLow(int n)
        {
            _energy -= n;
            if(_energy < 0)
            {
                _energy = 0;
                ShipDie();
            }
        }

        public void EnergyUp(int n)
        {
            if ((_energy+n) <= 100 )
            {
                _energy += n;
            } else
            {
                _energy = 100;
            }
        }
        #endregion

        #region Перемещение коробля 
        public void Left()
        {
            if (_position.X < Game.Width)
            {
                _position.X -= 3;
                rect.Location = _position;
            }
        }
        public void Right()
        {
            if (_position.X < Game.Width)
            {
                _position.X += 3;
                rect.Location = _position;
            }
        }

        public void Up()
        {
            if (_position.Y < Game.Height )
            {
                _position.Y -= 3;
                rect.Location = _position;
            }
        }
        public void Down()
        {
            if (_position.Y < Game.Height)
            {
                _position.Y += 3;
                rect.Location = _position;
            }
        }
        #endregion

        public override void Draw()
        {
            img = new Bitmap(Properties.Resources.ship);
            Color transparent = img.GetPixel(0, 0);
            img.MakeTransparent(transparent);
            Game._buffer.Graphics.DrawImage(img, _position.X, _position.Y, _size.Width, _size.Height);
        }

        public override void Update()
        {
            if (Collision(Game.MedBox as ICollision))
            {
                EnergyUp(25);
                EnergyUPevent();
               
            }
            foreach (Meteor obj in Game._objsMeteor.ToArray())
            {
                if (Collision(obj as ICollision))
                {
                    EnergyLow(5);            
                    Random rnd = new Random();
                    obj.ObjectPosition = new Point(900, rnd.Next(0, 600));
                }
            }
        }
    }
}
