using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GameAttack
{
    class Ship : GameObject
    {
        private Bitmap img;
        private int _energy = 100;
        public int Energy => _energy;

        public Ship(Point pos, Size sz) : base(pos, sz) { }

        public void EnergyLow(int n)
        {
            _energy -= n;
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

        public void Up()
        {
            Console.WriteLine(_position.Y);
            if (_position.Y < Game.Height )
            {
                _position.Y -= 3; 
            }
        }
        public void Down()
        {
            if (_position.Y < Game.Height)
            {
                _position.Y += 3;
            }
        }

        public override void Draw()
        {
            img = new Bitmap(Properties.Resources.ship);
            Color transparent = img.GetPixel(0, 0);
            img.MakeTransparent(transparent);
            Game._buffer.Graphics.DrawImage(img, _position.X, _position.Y, _size.Width, _size.Height);
        }

        public void Die() { }

        public override void Update()
        {
            
        }
    }
}
