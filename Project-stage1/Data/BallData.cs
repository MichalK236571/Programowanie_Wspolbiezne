namespace Data
{
    internal class BallData : DataBallAPI
    {

        private int radius;
        private int xValue;
        private int yValue;
        private int xDirection;
        private int yDirection;
        private int weight;

        public override int Radius
        {
            get => radius;
            set { radius = value; }
        }

        public override int XValue
        {
            get => xValue;
            set { xValue = value; }
        }

        public override int YValue
        {
            get => yValue;
            set { yValue = value; }
        }

        public override int XDirection
        {
            get => xDirection;
            set { xDirection = value; }
        }

        public override int YDirection
        {
            get => yDirection;
            set { yDirection = value; }
        }

        public override int Weight
        {
            get => weight;
            set { weight = value; }
        }

        public BallData(int x, int y, int r,int w, int xDir, int yDir)
        {
            radius = r;
            xValue = x;
            yValue = y;
            xDirection = xDir;
            yDirection = yDir;
            weight = w;
            Thread thread = new Thread(Movement);
            thread.IsBackground = true;
            thread.Start();
        }

        public override void Movement()
        {
            while (true)
            {
                Move();
            }
        }
        public override void Move()
        {
            XValue += XDirection;
            YValue += YDirection;
        }





    }
}