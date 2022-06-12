using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace Data
{
    public abstract class BallDataAPI
    {
       
        public static BallDataAPI CreateBallDataAPI(int xV, int yV, int radius,int weight, int xDir, int yDir)
        {
            return new BallData(xV, yV, radius,weight, xDir, yDir);
        }
        public abstract event PropertyChangedEventHandler? PropertyChanged;
        internal abstract event PropertyChangedEventHandler? LoggerPropertyChanged;
        public abstract int XValue { get; internal set; }
        public abstract int YValue { get; internal set; }
        public abstract int XDirection { get; set; }
        public abstract int YDirection { get; set; }
        public abstract int Radius { get; }
        

        internal abstract void StartBall();
        internal abstract void Stop();
    }
}