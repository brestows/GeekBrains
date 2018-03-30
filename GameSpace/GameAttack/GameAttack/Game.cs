using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;

namespace GameAttack
{   
    /// <summary>
    /// Главная форма, отображающая все события "игры"
    /// Методы повторяются из класса SplashScreen
    /// </summary>
    static class Game
    {
        private static BufferedGraphicsContext _context;
        private static Timer time;
        public static BufferedGraphics _buffer;
        private static GameObject[] _objects;
        private static Bullet[] _objsBullet;
        public static int Width  { get; set; }
        public static int Height { get; set; }
        
        static Game() { }
     
        public static void Init(Form frm)
        {
            Graphics vgc;
            time = new Timer { Interval = 1000 };
            time.Start();
            time.Tick += new EventHandler(Timer_tick);
            _context = BufferedGraphicsManager.Current;
            vgc = frm.CreateGraphics();
            Width = frm.Width;
            Height = frm.Height;
            _buffer = _context.Allocate(vgc, new Rectangle(0, 0, Width, Height));
            Button btn = new Button
            {
                BackColor = Color.Black,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.Location = new Point(720,540);
            btn.Text = "MENU";
            btn.Click += new EventHandler(Menu_btn);
            frm.Controls.Add(btn);
            Load();
        }

        public static void Draw()
        {
            _buffer.Graphics.Clear(Color.Black);
            foreach (GameObject obj in _objects)
                obj.Draw();

            foreach (Bullet blt in _objsBullet)
                blt.Draw();
            
            _buffer.Render();
        }

        public static void Load ()
        {
            _objects = new GameObject[75];
            _objsBullet = new Bullet[25];
            Random rnd = new Random();
            for (int i = 0; i < _objects.Length; i++)
            {
                
                if (i%2 == 0)
                {
                    int sz = rnd.Next(2, 5);
                    _objects[i] = new Star(new Point(rnd.Next(0, 800), rnd.Next(0, 600)), new Size(sz, sz));
                }
                else if (i%3 == 0)
                {                    
                    _objects[i] = new Asterisk(new Point(rnd.Next(0, 800), rnd.Next(0, 600)), new Size(3, 3));
                } 
                else
                {
                    _objects[i] = new Meteor(new Point(rnd.Next(0, 800), rnd.Next(0, 600)), new Size(3, 3));
                }
            }
            for (int i = 0; i < _objsBullet.Length; i++)
            {
                _objsBullet[i] = new Bullet(new Point(rnd.Next(0, 800), rnd.Next(0, 600)), new Size(6, 6));

            }

        }

        public static void Update()
        {
            
            foreach (Bullet blt in _objsBullet)
                blt.Update();

            foreach (GameObject obj in _objects)
                    obj.Update();
            
        }
        private static void Menu_btn(object sender, EventArgs arg)
        {
            if (sender is Button)
            {
                Button btn = sender as Button;
                time.Dispose();
                Form frm = btn.FindForm();
                frm.Dispose();
            }
        }
        private static void Timer_tick(object sender, EventArgs arg)
        {
            foreach (Bullet blt in _objsBullet)
            {
                foreach (GameObject obj in _objects)
                {
                    if (obj is Meteor)
                    {
                        if (blt.Collision(obj))
                        {
                            //Debug.WriteLine("COLLISION: Bullet" + blt.ObjectPosition + " METEOR " + obj.ObjectPosition);

                            blt.ObjectPosition = new Point(659, blt.ObjectPosition.Y);
                            obj.ObjectPosition = new Point(650, obj.ObjectPosition.Y);
                        }
                    }
                }
            }
            Update();
            Draw();
        }
    }
}
