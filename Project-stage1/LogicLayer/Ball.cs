namespace Logic
{
    public abstract class BallApi
    {
        public static BallApi CreateBall( int xV, int yV, int radius,int weight, int xDir, int yDir)
        {
            return new Ball( xV, yV, radius,weight, xDir, yDir);
        }

        public int XValue { get; set; }
        public int YValue { get; set; }
        public int XDirection { get; set; }
        public int YDirection { get; set; }
        public int Radius { get; set; }
        public int Weight { get; set; }

        public class Ball : BallApi
        {

            public Ball(int x, int y, int r,int weight, int xDirection, int yDirection)
            {
                Radius = r;
                XValue = x;
                YValue = y;
                Weight = weight;
                XDirection = xDirection;
                YDirection = yDirection;
            }

        }
    }
}