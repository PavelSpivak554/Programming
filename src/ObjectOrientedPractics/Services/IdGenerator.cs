using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedPractics.Services
{
    internal class IdGenerator
    {
        private static int _currentId = 1;
        public static int GetNextId()
        {
            return _currentId++;
        }
    }
}
