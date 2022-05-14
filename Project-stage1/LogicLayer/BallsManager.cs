using Data;
namespace Logic
{
    internal class BallsManager : LogicAbstactAPI
    {

        private DataAbstactAPI dataApi;
        private int width { get; set; }
        private int height { get; set; }
        private int minRadius { get; }
        private int maxRadius { get; }
        

        private List<BallApi> list = new();

        public BallsManager(int w, int h)
        {
            width = w;
            height = h;
            /*minRadius = Math.Min(w, h) / 60;
            maxRadius = Math.Max(w, h) / 20;*/

            dataApi = DataAbstactAPI.CreateApi();
        }


        public override BallApi GetBall(int index)
        {
            return list[index];
        }
        public void AddBall(BallApi obj)
        {
            list.Add(obj);
        }

        public override List<BallApi> GetAllBalls()
        {
            return list;
        }

        public void RemoveBall(BallApi obj)
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
            foreach (BallApi obj in list)
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
                randomX = random.Next(-6, 6);
                randomY = random.Next(-6, 6);
            }
            //AddBallToList(random.Next(minRadius, maxRadius), random.Next(maxRadius, width - maxRadius), random.Next(maxRadius, height - maxRadius), randomX, randomY);
            AddBallToList(15, random.Next(maxRadius, width - maxRadius), random.Next(maxRadius, height - maxRadius), randomX, randomY);
        }

        public override void AddBallToList(int radius, int x, int y, int xDirection, int yDirection)
        {
             if(x < radius || x > width - radius || y < radius || y > height - radius)
            {
                Console.WriteLine("Blad");
                throw new Exception();
            }
            else
            {
                BallApi ball =  BallApi.CreateBall( x, y,radius, xDirection, yDirection);
                list.Add(ball);
            }
        }

        public override void BounceAndMove()
        {
            foreach (BallApi ball in list)
            {
                if (ball.XValue + ball.XDirection + ball.Radius > width || ball.XValue + ball.XDirection - ball.Radius < 0)
                {
                    ball.XDirection = ball.XDirection * (-1);
                }

                if (ball.YValue + ball.YDirection + ball.Radius > height || ball.YValue + ball.YDirection - ball.Radius < 0)
                {
                    ball.YDirection = ball.YDirection * (-1);
                }
                ball.XValue += ball.XDirection;
                ball.YValue += ball.YDirection;
            }
        }

        public override void makeBalls(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                generateBalls();
            }
        }

    }
}