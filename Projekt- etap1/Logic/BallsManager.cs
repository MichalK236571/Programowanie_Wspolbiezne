using Data;
namespace Logic
{
    internal class BallsManager : LogicAbstactAPI
    {

        private DataAbstactAPI dataApi;
        private int width { get; set; }
        private int height { get; set; }
        private int minRadious { get; }
        private int maxRadious { get; }

        private List<BallInterface> list = new();

        public BallsManager(int w, int h)
        {
            width = w;
            height = h;
            minRadious = Math.Min(w, h) / 50;
            maxRadious = Math.Max(w, h) / 25;
            dataApi = DataAbstactAPI.CreateApi();
        }


        public override BallInterface GetBall(int index)
        {
            return list[index];
        }
        public void AddBall(Ball obj)
        {
            list.Add(obj);
        }

        public override List<BallInterface> GetAllBalls()
        {
            return list;
        }

        public void RemoveBall(Ball obj)
        {
            list.Remove(obj);
        }

        public override void RemoveAllBalls()
        {
            list.Clear();
        }

        public int Count()
        {
            int count = 0;
            foreach (Ball obj in list)
                count++;
            return count;
        }


        public override void generateBalls()
        {
            Random random = new Random();
            int randomX = 0;
            int randomY = 0;
            while (randomX == 0 && randomY == 0)
            {
                randomX = random.Next(-1, 1);
                randomY = random.Next(-1, 1);
            }
            AddBallToList(random.Next(minRadious, maxRadious), random.Next(maxRadious, width - maxRadious), random.Next(maxRadious, height - maxRadious), randomX, randomY);
        }

        public override void AddBallToList(int radious, int x, int y, int xDirection, int yDirection)
        {
            if (x < radious || x > width - radious ||
                y < radious || y > height - radious)
            {
                Console.WriteLine("Blad");
            }
            else
            {
                Ball ball = new Ball(radious, x, y, xDirection, yDirection);
                list.Add(ball);
            }
        }



        public override void BounceAndMove()
        {
            foreach (Ball ball in list)
            {
                if (ball.XValue + ball.XDirection + ball.Radious > width || ball.XValue + ball.XDirection - ball.Radious < 0)
                {
                    ball.XDirection = ball.XDirection * (-1);
                }

                if (ball.YValue + ball.YDirection + ball.Radious > height || ball.YValue + ball.YDirection - ball.Radious < 0)
                {
                    ball.YDirection = ball.YDirection * (-1);
                }
                ball.XValue += ball.XDirection;
                ball.YValue += ball.YDirection;
            }
        }

        public override void makeBalls(int amount)
        {
            //generateCircle();
            //while (circles.Count() < amount-1)
            //{
            //    generateCircle();
            //}

            for (int i = 0; i < amount; i++)
            {
                generateBalls();
            }
        }

    }
}