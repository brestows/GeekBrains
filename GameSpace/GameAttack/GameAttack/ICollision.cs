using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace GameAttack
{
    /// <summary>
    /// Интерфейс для рассчета столкновений между объектами
    /// Объект унаследованный от данного интерфейса может
    /// сталкиваться с потомками данного интерфейса
    /// </summary>
    interface ICollision
    {
        bool Collision(ICollision _object);
        Rectangle Rect { get; }
    }
}
