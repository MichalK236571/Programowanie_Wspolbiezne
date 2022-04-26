using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public abstract class BallInterface
    {
        internal static Ball CreateBall(int r, int x , int y, int xDir, int yDir)
        {
            return new Ball(r,x,y,xDir,yDir);
        }
        public int Radious { get; set; }
        public int XValue { get; set; }
        public int YValue { get; set; }
        public int XDirection { get; set; }
        public int YDirection { get; set; }

    }
}
