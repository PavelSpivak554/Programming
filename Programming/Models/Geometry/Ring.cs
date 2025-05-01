using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming.Models
{
    /// <summary>
    /// Представляет кольцо с заданным центром, внешним и внутренним радиусами
    /// </summary>
    internal class Ring
    {
        /// <summary>
        /// Центр кольца
        /// </summary>
        private Point2D center;

        /// <summary>
        /// Внешний радиус кольца
        /// </summary>
        private double outerRadius;

        /// <summary>
        /// Внутренний радиус кольца
        /// </summary>
        private double innerRadius;

        /// <summary>
        /// Возвращает или задает центр кольца
        /// </summary>
        public Point2D Center { get; set; }

        /// <summary>
        /// Создает экземпляр класса <see cref="Ring"/> с заданными параметрами
        /// </summary>
        /// <param name="center">Центр кольца</param>
        /// <param name="outerRadius">Внешний радиус кольца</param>
        /// <param name="innerRadius">Внутренний радиус кольца</param>
        public Ring(Point2D center, double outerRadius, double innerRadius)
        {
            this.center = center;
            this.outerRadius = outerRadius;
            this.innerRadius = innerRadius;
        }

        /// <summary>
        /// Возвращает или задает внешний радиус кольца
        /// </summary>
        /// <remarks>
        /// Значение должно быть положительным и больше внутреннего радиуса
        /// </remarks>
        public double OuterRadius
        {
            get
            {
                return outerRadius;
            }
            set
            {
                if (Validator.AssertOnPositiveValue(value, nameof(OuterRadius)) &&
                    Validator.AssertValueMore(value, innerRadius, nameof(OuterRadius)))
                {
                    outerRadius = value;
                }
            }
        }

        /// <summary>
        /// Возвращает или задает внутренний радиус кольца
        /// </summary>
        /// <remarks>
        /// Значение должно быть положительным и меньше внешнего радиуса
        /// </remarks>
        public double InnerRadius
        {
            get { return innerRadius; }
            set
            {
                if (Validator.AssertOnPositiveValue(value, nameof(InnerRadius)) &&
                   Validator.AssertValueLow(value, OuterRadius, nameof(InnerRadius)))
                {
                    innerRadius = value;
                }
            }
        }

        /// <summary>
        /// Возвращает площадь кольца
        /// </summary>
        public double Area => Math.PI * (OuterRadius * OuterRadius - InnerRadius * InnerRadius);
    }
}