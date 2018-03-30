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
    abstract class GameObject: ICollision
    {
        protected Point _position;
        protected Size _size;
        protected Rectangle rect;
        public Point ObjectPosition { get => _position; set => _position = value; }
        public Rectangle Rect { get => rect; set => rect = value; }

        /// <summary>
        /// базовый конструктор для наследников
        /// </summary>3
        /// <param name="pos">позиция</param>
        /// <param name="sz">размер</param>
        public GameObject(Point pos, Size sz)
        {
            _position = pos;
            _size = sz;
            rect = new Rectangle(pos,sz);
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

        public bool Collision(ICollision _object)
        {
            Debug.WriteLine( this.rect.IntersectsWith(_object.Rect));
            return this.rect.IntersectsWith(_object.Rect);
            //return this.Rect.IntersectsWith(_object.Rect);
        }
    }
}
