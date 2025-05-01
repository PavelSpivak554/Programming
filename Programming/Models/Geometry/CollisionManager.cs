using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming.Models
{
    /// <summary>
    /// Проверяет объекты на пересечение.
    /// </summary>
    internal static class CollisionManager
    {
        /// <summary>
        /// Проверяет прямоугольники на пересечение.
        /// </summary>
        /// <param name="rectangle1"></param>
        /// <param name="rectangle2"></param>
        /// <returns> Возвращает true, если пересекаются.</returns>
        public static bool IsCollision(Rectangle rectangle1, Rectangle rectangle2)
        {
            int diffX = Math.Abs(rectangle1.Center.X - rectangle2.Center.X);
            int diffY = Math.Abs(rectangle1.Center.Y - rectangle2.Center.Y);

            double halfWidth1 = rectangle1.Width / 2.0;
            double halfWidth2 = rectangle2.Width / 2.0;
            double halfHeight1 = rectangle1.Length / 2.0;
            double halfHeight2 = rectangle2.Length / 2.0;
            if (diffX < (halfWidth1 + halfWidth2) && diffY < (halfHeight1 + halfHeight2))
            {
                return true;
            }
            return false;
        }


        /// <summary>
        /// Проверяет кольца на пересечение
        /// </summary>
        /// <param name="ring1"></param>
        /// <param name="ring2"></param>
        /// <returns>Возвращает true, если пересекаются.</returns>
        public static bool IsCollision(Ring ring1,Ring ring2)
            {
                double sumRadius = ring1.OuterRadius + ring2.OuterRadius;
                double dx = ring1.Center.X - ring2.Center.X;
                double dy = ring1.Center.Y - ring2.Center.Y;
                double distance = Math.Sqrt(dx * dx + dy * dy);

                return distance < sumRadius;
            }

    }


}
