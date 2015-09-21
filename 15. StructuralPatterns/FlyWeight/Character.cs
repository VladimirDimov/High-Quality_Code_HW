using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyWeight
{
    /// <summary>
    /// The 'Flyweight' abstract class
    /// </summary>
    abstract class Character
    {
        protected char symbol;
        protected int ascent;
        protected int descent;
        protected int height;
        protected int pointSize;
        protected int width;

        public abstract void Display(int pointSize);
    }
}
