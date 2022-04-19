using Data;
namespace Logic
{
    public class Ekran
    {
        private int width { get; set; }
        private int height { get; set; }
        private int minRadious { get; }
        private int maxRadious { get; }

        public Ekran(int w, int h)
        {
            width = w;  
            height = h;
            minRadious = Math.Min(w, h)/50;
            maxRadious = Math.Max(w, h)/25;
        }

        public void addCircle(int radious, int x, int y, int xDirection, int yDirection)
        {
            if (x < radious || x > width-radious ||
                y < radious || y > height-radious)
            {
                Console.WriteLine("Blad");
            }
            else
            {
                Random random = new Random();
                Circle circle = new Circle(random.Next(minRadious,maxRadious),x,y,xDirection,yDirection);
            }
        }

        public void bounce()
        {

        }

        


    }
}