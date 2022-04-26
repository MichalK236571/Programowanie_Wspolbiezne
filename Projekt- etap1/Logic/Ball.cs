namespace Logic
{
    internal class Ball : BallInterface
    {
        public Ball(int r, int x, int y, int xDirection, int yDirection)
        {
            Radious = r;
            XValue = x;
            YValue = y;
            XDirection = xDirection;
            YDirection = yDirection;

        }

    }
}