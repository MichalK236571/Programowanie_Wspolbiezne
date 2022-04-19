using Data;
namespace Logic
{
    public class Screen
    {
        private int width { get; set; }
        private int height { get; set; }
        private int minRadious { get; }
        private int maxRadious { get; }

        private CirclesList<Circle> circles { get; set; }

        public Screen(int w, int h)
        {
            width = w;  
            height = h;
            minRadious = Math.Min(w, h)/50;
            maxRadious = Math.Max(w, h)/25;
        }

        public void generateCircle()
        {
            Random random = new Random();
            int randomX = 0;
            int randomY = 0;
            while (randomX == 0 && randomY == 0)
            {
                randomX = random.Next(-1,1);
                randomY = random.Next(-1,1);
            }
            addCircleToScreen(random.Next(minRadious, maxRadious), random.Next(maxRadious, width - maxRadious), random.Next(maxRadious, height - maxRadious), randomX, randomY);
        }

        public void addCircleToScreen(int radious, int x, int y, int xDirection, int yDirection)
        {
            if (x < radious || x > width-radious ||
                y < radious || y > height-radious)
            {
                Console.WriteLine("Blad");
            }
            else
            {
                Circle circle = new Circle(radious,x,y,xDirection,yDirection);
                circles.AddCircle(circle);
            }
        }

        

        public void bounceAndMove()
        {
            foreach(Circle circle in circles.GetAllCircles())
            {
                if(circle.XValue + circle.XDirection + circle.Radious > width || circle.XValue + circle.XDirection - circle.Radious < 0)
                {
                    circle.XDirection = circle.XDirection * (-1);
                }

                if (circle.YValue + circle.YDirection + circle.Radious > height || circle.YValue + circle.YDirection - circle.Radious < 0)
                {
                    circle.YDirection = circle.YDirection * (-1);
                }
                circle.XValue += circle.XDirection;
                circle.YValue += circle.YDirection;
            }
        }

        public void makeCircles(int amount)
        {
            for(int i = 0; i < amount; i++)
            {
                
            }
        }


    }
}