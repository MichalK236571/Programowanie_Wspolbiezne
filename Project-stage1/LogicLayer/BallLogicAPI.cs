using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Logic
{
    public abstract class BallLogicAPI
    {
        public static BallLogicAPI CreateBall(int xV, int yV, int radius/*, int weight, int xDir=0, int yDir=0*/)
        {
            return new Ball(xV, yV, radius/*, weight, xDir, yDir*/);
        }
        public abstract event PropertyChangedEventHandler? PropertyChanged;
        public abstract int XValue { get; set; }
        public abstract int YValue { get; set; }
        //public abstract int XDirection { get; set; }
        //public abstract int YDirection { get; set; }
        public abstract int Radius { get; set; }
       // public abstract int Weight { get; set; }
        public abstract void Update(Object obj, PropertyChangedEventArgs e);
    }
}
