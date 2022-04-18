namespace ClassLibrary1
{
    public class Circle
    {
        public int Radious { get; set; }
        public int XValue { get; set; }
        public int YValue { get; set; }
        public int XDirection { get; set; }
        public int YDirection { get; set; }

        public Circle(int r, int x, int y, int xDirection, int yDirection)
        {
            Radious = r;
            XValue = x;
            YValue = y;
            XDirection = xDirection;
            YDirection = yDirection;

        }



    }
}