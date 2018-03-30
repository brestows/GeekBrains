using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using System.Diagnostics;

namespace GameAttack
{
    /// <summary>
    /// Базовый класс для игровык копонентов. Метеорита, пули, звезд и т.п.
    /// </summary>
    abstract class GameObject
    {
        protected Point _position;
        protected Size _size;
        protected Rectangle rect;
        public Point ObjectPosition { get => _position; set => _position = value; }
       

        /// <summary>
        /// базовый конструктор для наследников
        /// </summary>3
        /// <param name="pos">позиция</param>
        /// <param name="sz">размер</param>
        public GameObject(Point pos, Size sz)
        {
            try
            {
                if (pos.X < 0 || pos.Y < 0)
                {
                    throw new GameObjectException("Ошибка позиции.");
                } else if (_size.Height < 0 || _size.Width < 0)
                {
                    throw new GameObjectException("Ошибка размера");
                }
                else
                { 
                    _position = pos;
                    _size = sz;
                    rect = new Rectangle(pos, sz);
                }
            }
            catch (GameObjectException e)
            {
                Debug.WriteLine(e);
            }
        }



        /// <summary>
        /// Отрисовывает игровой компонент на форме
        /// </summary>
        abstract public void Draw();
        /// <summary>
        /// Реализует "анимацию" движения объектов, 
        /// путём изменения координат
        /// </summary>
        abstract public void Update();

    
    }
}
