using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace GameAttack
{
    /// <summary>
    /// Стартовая форма, с отображением меню
    /// </summary>
    static class SplashScreen
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics _bfr;
        public static GameObject[] _objs;

        private static bool state = false;

        public static int Width { get; set; }
        public static int Height { get; set; }

        static SplashScreen() {}

        /// <summary>
        /// Инициализация формы
        /// </summary>
        /// <param name="frm">Форма инициализации</param>
        public static void Init(Form frm)
        {
            Graphics vgc;
            _context = BufferedGraphicsManager.Current;
            vgc = frm.CreateGraphics();
            Width = frm.Width;
            Height = frm.Height;
            frm.BackColor = Color.Black;
            _bfr = _context.Allocate(vgc, new Rectangle(0, 0, Width, Height));

            frm.Controls.Add(AddMenuButton("START", new Size(120,60), new Point(Width/2, 100)));
            frm.Controls.Add(AddMenuButton("POINTS", new Size(120,60), new Point(Width/2, 170)));
            frm.Controls.Add(AddMenuButton("EXIT", new Size(120,60), new Point(Width/2,  240)));
            Label lbl = new Label();
            lbl.BackColor = Color.Black;
            lbl.ForeColor = Color.White;
            lbl.Location = new Point(0, 440);
            lbl.Text = "Чистяков Сергей";
            frm.Controls.Add(lbl);
            Timer time = new Timer { Interval = 1000 };
            time.Start();
            time.Tick += new EventHandler(Timer_tick);
            Load();
        }
        /// <summary>
        /// Заполнение массива объектов
        /// конкретными объектами определенного класса
        /// </summary>
        public static void Load()
        {
            _objs = new GameObject[15];
            Random rnd = new Random();
            for (int i = 0; i < _objs.Length; i++)
            {
                int sz = rnd.Next(2, 5);
                _objs[i] = new Ufo(new Point(rnd.Next(64, Width-64), rnd.Next(64, Height-64)),  new Size(sz, sz));
                
            }
        }
        /// <summary>
        /// Отрисовка объектов на форме
        /// </summary>
        public static void Draw()
        {
            _bfr.Graphics.Clear(Color.Black);
            foreach (GameObject obj in _objs)
                obj.Draw();
            _bfr.Render();
        }
        /// <summary>
        /// скрываем отрисованные объекты
        /// имитируя анимацию :)
        /// </summary>
        public static void Destroy()
        {
            _bfr.Graphics.Clear(Color.Black);
       
            _bfr.Render();
        }
        /// <summary>
        /// Добавление кнопки определенной стилистики на форму
        /// </summary>
        /// <param name="text">Текс на кнопке</param>
        /// <param name="sz">Размер кнопки</param>
        /// <param name="local">Координаты расположение на форме</param>
        /// <returns></returns>
        private static Button AddMenuButton(this String text, Size sz, Point local )
        {
            Button btn = new Button
            {
                BackColor = Color.Black,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btn.FlatAppearance.BorderSize = 0;
            local.X -= 60;
            btn.Size = sz;
            btn.Location = local; 
            btn.Text = text;
            btn.Click += new EventHandler(Menu_btn);
            return btn;
          
        }
        /// <summary>
        /// Метод отрабатываемый по нажатия какой-либо кнопки 
        /// 
        /// </summary>
        /// <param name="sender">Отправитель события Клик</param>
        /// <param name="arg">Аргументы события</param>
        private static void Menu_btn(object sender, EventArgs arg)
        {
            if (sender is Button)
            {
                Button btn = sender as Button;
                Form frmParent = btn.FindForm();
                switch (btn.Text)
                {
                    case "EXIT":
                        Application.Exit();
                        break;
                    case "START":
                        frmParent.Hide();
                        Form frm = new Form();
                        frm.Width = 800;
                        frm.Height = 600;
                        frm.ControlBox = false;
                        Game.Init(frm);
                        Game.Draw();
                        frm.ShowDialog();
                        frmParent.Show();
                        break;
                    case "POINTS":
                        break;
                }
            }
        }
        
        /// <summary>
        /// Метод таймера, отрабатываем по каждому тику таймера, 
        /// согласно его настроек
        /// </summary>
        /// <param name="sender">Отправитель события</param>
        /// <param name="arg">Аргументы</param>
        private static void Timer_tick(object sender, EventArgs arg)
        {
            if (state)
            {
                state = false;
                Destroy();
            }
            else 
            {
                state = true;
                Draw();
            }
            
        }
    }
}
