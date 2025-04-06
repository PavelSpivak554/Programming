using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming.Models
{
    internal class Point2D
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Point2D()
        {
            X = 0;
            Y = 0;
        }
        public Point2D(int x, int y)
        {
            Validator.AssertValueInRange(x, 0, 500, nameof(X));
            Validator.AssertValueInRange(y, 0, 500, nameof(Y));

            X = x;
            Y = y;
        }       

    }
}
