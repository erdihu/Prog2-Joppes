using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog2_Joppes
{
    /*
     * Owner can only have one ball at a time. When the quality of the ball is below 2, the ball will recovered to its original state; simulating a new ball.
     * This class is basically a singleton object, because it does not allow any other instances to be created. 
     * We could have allowed to create a new ball everytime the quality goes below 2 but that would be unnecessary in this context. 
     * Keeping track of balls would be a bit hard. However, if a new instance of this class would be highly costly to instantiate
     * it would not be efficient to create a new one each time we need it. 
     */
    internal class Ball
    {
        private int _quality;

        public int Quality
        {
            get { return _quality; }
            set { _quality = value; }
        }

        public string Color { get; set; }
        private static Ball _instance;

        public static Ball GetBall
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Ball {Color = "Red", _quality = 10};
                }

                if (_instance._quality < 2)
                {
                    Console.WriteLine("Your ball is very old. But we replaced it with a new one!");
                    _instance._quality = 10;
                }

                return _instance;
            }
        }

        private Ball() { }

        public override string ToString()
        {
            return $"{Color} ball has {_quality} left.";
        }
    }
}
