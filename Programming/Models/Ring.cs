using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming.Models
{
    internal class Ring
    {
        private Point2D center;
        private double outerRadius;
        private double innerRadius;

        public Point2D Center { get; set; }

        public Ring(Point2D center, double outerRadius, double innerRadius)
        {
            this.center = center;
            this.outerRadius = outerRadius;
            this.innerRadius = innerRadius;
        }




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
        public double Area => Math.PI * (OuterRadius * OuterRadius - InnerRadius * InnerRadius);
    }
}

