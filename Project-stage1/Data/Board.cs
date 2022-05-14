using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public abstract class BoardAPI
    {

        public abstract int Height { get; }
        public abstract int Width { get; }
        public abstract List<DataBallAPI> getBalls();
        public abstract void removeBalls();

        public static BoardAPI createAPI(int width, int height)
        {
            return new Board(width, height);
        }
        public abstract DataBallAPI createDataBallAPI(int xV, int yV, int radius, int weight, int xDir, int yDir);
    }

    public  class Board : BoardAPI
    {
        public int width;
        public int height;

        public override int Width
        {
            get => width;
            
        }

        public override int Height
        {
            get => height;
            
        }
        private List<DataBallAPI> ballDataList = new();

        public override List<DataBallAPI> getBalls()
        {
            return ballDataList;
        }

        public override void removeBalls()
        {
            ballDataList.Clear();
        }

        public Board(int w,int h)
        {
            width = w;
            height = h;
        }

        public override DataBallAPI createDataBallAPI(int xV, int yV, int radius, int weight, int xDir, int yDir)
        {
            DataBallAPI dataBallAPI =  DataBallAPI.CreateDataBallAPI(xV,yV,radius,weight,xDir,yDir);
            return dataBallAPI;
        }

        
    }
}
