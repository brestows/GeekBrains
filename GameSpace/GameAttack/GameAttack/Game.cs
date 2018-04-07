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
    class Game
    {
        private static BufferedGraphicsContext _context;
        private static Timer time;
        public static BufferedGraphics _buffer;
        public static GameObject[] _objects;
        public static List<Meteor> _objsMeteor = new List<Meteor>();
        public static List<Bullet> _objsBullet = new List<Bullet>();
        public static int Width { get; set; }
        public static int Height { get; set; }
        private static int UserScore = 0;
        private static Random rnd = new Random();
        private static bool ShipDie = false;
        private static Ship Souz = new Ship(new Point(25, 300), new Size(94, 64));
        public static EnergyBox MedBox = new EnergyBox(new Point(0, 0), new Size(35, 35));
        static Game() { }

        public static void Init(Form frm)
        {
            frm.KeyDown += FromKeyDown;
            Bullet.ColEvent += ObjectCollision;
            Ship.ShipDie += GameOver;
            Ship.EnergyUPevent += HideEnergyBox;
            try
            {
                if (frm.Height > 1000 || frm.Width > 1000)
                {
                    throw new ArgumentOutOfRangeException("Form size is out of reange!");
                }
            } catch
            {
                Debug.WriteLine("Введено слишком большое значение!");
            }

            Graphics vgc;
            time = new Timer { Interval = 100 };
            time.Start();
            time.Tick += new EventHandler(Timer_tick);
            _context = BufferedGraphicsManager.Current;
            vgc = frm.CreateGraphics();

            Width = frm.Width;
            Height = frm.Height;

            _buffer = _context.Allocate(vgc, new Rectangle(0, 0, Width, Height));

            #region Добавляем компоненты на форму
            Button btn = new Button
            {
                BackColor = Color.Black,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            Label lblScore = new Label
            {
                BackColor = Color.Black,
                ForeColor = Color.White,
            };
            lblScore.Location = new Point(20, 20);
            lblScore.Text = "SCORE:";
            lblScore.Size = new Size(50, 15);

            Label lblEnergy = new Label
            {
                BackColor = Color.Black,
                ForeColor = Color.White,
            };
            lblEnergy.Location = new Point(20, 40);
            lblEnergy.Text = "ENERGY:";
            lblEnergy.Size = new Size(57, 15);


            btn.FlatAppearance.BorderSize = 0;
            btn.Location = new Point(720, 540);
            btn.Text = "MENU";
            btn.Click += new EventHandler(Menu_btn);
            frm.Controls.Add(btn);
            frm.Controls.Add(lblScore);
            frm.Controls.Add(lblEnergy);
            #endregion

            Load();
        }
        /// <summary>
        /// Cкрываем аптечку, после того как пользователь ей воспользовался.
        /// </summary>
        private static void HideEnergyBox()
        {
            MedBox.ObjectPosition = new Point(-70, -70);
        }
        /// <summary>
        /// Обрабатываем событие проигрыша пользователя
        /// </summary>
        private static void GameOver()
        {
            time.Dispose();
            ShipDie = true;
        }

        // При столкновении увеличиваем очки пользователя на 1 
        // Добавляем в коллекцию еще один метеорит
        private static void ObjectCollision()
        {
            UserScore++;
            _objsMeteor.Add(new Meteor(new Point(800, rnd.Next(0, 600)), new Size(35, 15)));
        }

        /// <summary>
        /// Обработка события нажатия клавиш
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void FromKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up) Souz.Up();
            if (e.KeyCode == Keys.Down) Souz.Down();
            if (e.KeyCode == Keys.Left) Souz.Left();
            if (e.KeyCode == Keys.Right) Souz.Right();
            if (e.KeyCode == Keys.Space)
            {
                _objsBullet.Add(new Bullet(new Point(Souz.ObjectPosition.X + 80, Souz.ObjectPosition.Y + 30), new Size(15, 5)));
            }
        }

        public static void Draw()
        {
            _buffer.Graphics.Clear(Color.Black);
            //рисуем очки пользователя
            System.Drawing.Font fnt = new System.Drawing.Font("Arial", 10);
            System.Drawing.StringFormat frmt = new System.Drawing.StringFormat();
            System.Drawing.SolidBrush brsh = new System.Drawing.SolidBrush(System.Drawing.Color.White);

            foreach (GameObject obj in _objects)
            {
                obj.Draw();
            }
            Souz?.Draw();
            MedBox?.Draw();
            foreach (Bullet blt in _objsBullet)
            {
                blt.Draw();
            }
            foreach (Meteor meteor in _objsMeteor)
            {
                meteor.Draw();
            }
            //Если игрок проиграл выводим соответствующее сообщение
            if (ShipDie) {
                System.Drawing.Font tmpFont = new System.Drawing.Font("Arial", 24);
                _buffer.Graphics.DrawString("GAME OVER", tmpFont, brsh, (Width / 2) - 100, (Height / 2) - 50, frmt);
                _buffer.Graphics.DrawString("YOU SCORE IS", tmpFont, brsh, (Width / 2) - 120, Height / 2, frmt);
                _buffer.Graphics.DrawString(UserScore.ToString(), tmpFont, brsh, (Width / 2) - 20, (Height / 2) + 50, frmt);
            } else {
                _buffer.Graphics.DrawString(Souz.Energy.ToString(), fnt, brsh, 75, 38, frmt);
                _buffer.Graphics.DrawString(UserScore.ToString(), fnt, brsh, 70, 18, frmt);
            }
            _buffer.Render();
        }

        public static void Load()
        {
            _objects = new GameObject[75];

            for (int i = 0; i < _objects.Length; i++)
            {
                if (i % 2 == 0)
                {
                    int sz = rnd.Next(2, 5);
                    _objects[i] = new Star(new Point(rnd.Next(0, 800), rnd.Next(0, 600)), new Size(sz, sz));
                }
                else
                {
                    _objects[i] = new Asterisk(new Point(rnd.Next(0, 800), rnd.Next(0, 600)), new Size(3, 3));
                }
            }
            _objsMeteor.Add(new Meteor(new Point(800, rnd.Next(0, 600)), new Size(35, 15)));
        }

        public static void Update()
        {
            foreach (GameObject obj in _objects)
                obj.Update();

            foreach (Bullet blt in _objsBullet.ToArray())
            {
                blt.Update();
            }
            foreach (Meteor meteor in _objsMeteor)
            {
                meteor.Update();
            }
            Souz?.Update();
            MedBox?.Update();

            /// Случайно выбрасываем аптечку на сцену
            int bul = rnd.Next(0, 1000);
            /// Если выпало число от 42 до 47
            /// показываем аптечку
            if (bul > 41 && bul < 48)
            {
                MedBox.IneedHelp();
            }

        }
        /// <summary>
        /// Закрываем основную форму, и возвращаемся к форме запуска игры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
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
            Update();
            Draw();
        }
    }
}

