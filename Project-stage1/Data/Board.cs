using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public abstract class BoardAPI
    {
        public static BoardAPI createAPI(int width, int height)
        {
            return new Board(width, height);
        }
        public abstract int Height { get; }
        public abstract int Width { get; }
        public abstract List<BallDataAPI> getBalls();
        public abstract void removeBalls();
        public abstract BallDataAPI createDataBallAPI(int xV, int yV, int radius, int weight, int xDir =0, int yDir=0);
    }

    public  class Board : BoardAPI
    {
        //public int width;
        //public int height;
        private List<BallDataAPI> ballDataList = new();
        public override int Width
        {
            get;// => width;
            
        }

        public override int Height
        {
            get; //=> height;
            
        }


        public override List<BallDataAPI> getBalls()
        {
            return ballDataList;
        }

        public override void removeBalls()
        {
            ballDataList.Clear();
        }

        public Board(int w,int h)
        {
            Width = w;
            Height = h;
        }

        public override BallDataAPI createDataBallAPI(int xV, int yV, int radius, int weight, int xDir=0, int yDir=0)
        {
            BallDataAPI ballDataAPI =  BallDataAPI.CreateBallDataAPI(xV,yV,radius,weight,xDir,yDir);
            ballDataList.Add(ballDataAPI);
            return ballDataAPI;
        }

        
    }
}
