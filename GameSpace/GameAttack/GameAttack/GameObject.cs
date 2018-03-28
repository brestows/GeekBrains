using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GameAttack
{
    /// <summary>
    /// Базовый класс для игровык копонентов. Метеорита, пули, звезд и т.п.
    /// </summary>
    abstract class GameObject
    {
        protected Point _position;
        protected Size _size;
        /// <summary>
        /// базовый конструктор для наследников
        /// </summary>
        /// <param name="pos">позиция</param>
        /// <param name="sz">размер</param>
        public GameObject(Point pos, Size sz)
        {
            _position = pos;
            _size = sz;
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
