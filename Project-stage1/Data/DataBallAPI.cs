namespace Data
{
    public abstract class DataBallAPI
    {
       
        public static DataBallAPI CreateDataBallAPI(int xV, int yV, int radius,int weight, int xDir, int yDir)
        {
            return new BallData(xV, yV, radius,weight, xDir, yDir);
        }

        public abstract int XValue { get; set; }
        public abstract int YValue { get; set; }
        public abstract int XDirection { get; set; }
        public abstract int YDirection { get; set; }
        public abstract int Radius { get; set; }
        public abstract int Weight { get; set; }

        public abstract void Move();
        public abstract void Movement();


    }
}