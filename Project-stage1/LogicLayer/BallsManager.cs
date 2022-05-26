using Data;
using System.ComponentModel;

namespace Logic
{
    internal class BallsManager : LogicAbstactAPI
    {

        //private Board dataApi;
        private int width; //{ get; set; }
        private int height; //{ get; set; }
        private int radius;
        public int MaxBallSpeed = 5;
        private BoardAPI boardAPI;

        private List<BallLogicAPI> list = new();
        /*        private int minRadius { get; }
                private int maxRadius { get; }*/
        private int weight = 100;
        private Dictionary<BallDataAPI, BallDataAPI> ballsLastCollision = new();
        
        private readonly object syncObject = new();

        public BallsManager(BoardAPI BoardAPI)// int w, int h)
        {
            boardAPI = BoardAPI;
            width = BoardAPI.Width;
            height = BoardAPI.Height;
            radius = 15;// Math.Min(height, width) / 50;


            /*minRadius = Math.Min(w, h) / 60;
            maxRadius = Math.Max(w, h) / 20;*/

            //dataApi = DataAbstactAPI.CreateDataBallAPI();
        }


/*        public override BallLogicAPI GetBall(int index)
        {
            return list[index];
        }*/
/*        public void AddBall(BallLogicAPI obj)
        {
            list.Add(obj);
        }*/

        public override List<BallLogicAPI> GetAllBalls()
        {
            return list;
        }

        public override void RemoveAllBalls()
        {
            list.Clear();
            boardAPI.removeBalls();
        }


        public override BallLogicAPI MakeBall(int x, int y, int xDirection, int yDirection)
        {
            if (
                x < radius || x > width - radius ||
                y < radius || y > height - radius ||
                xDirection > height - radius || xDirection < -1 * height + radius ||
                yDirection > height - radius || yDirection < -1 * height + radius
            )
            {
                throw new ArgumentException("Coordinate out of board range.");
            }

            if (list.Any(
                    ball => Math.Abs(ball.XValue - x) <= radius && Math.Abs(ball.YValue - y) <= radius)
               )
            {
                throw new ArgumentException("Another ball is already here");
            }

            BallDataAPI ballData = boardAPI.createDataBallAPI(x, y, radius, weight, xDirection, yDirection);
            BallLogicAPI ball = BallLogicAPI.CreateBall(ballData.XValue, ballData.YValue, ballData.Radius, ballData.Weight,
                ballData.XDirection, ballData.YDirection);
            ballData.PropertyChanged += ball.Update!;
            ballData.PropertyChanged += CheckIfCollisioned!;
            list.Add(ball);
            return ball;
        }

        public override BallLogicAPI CreateBallInRandomPlace()
        {
            Random r = new();
            bool catched;
            do
            {
                catched = false;
                try
                {
                    return MakeBall(
                        r.Next(radius, width - radius),
                        r.Next(radius, height - radius),
                        r.Next(-MaxBallSpeed, MaxBallSpeed),
                        r.Next(-MaxBallSpeed, MaxBallSpeed)
                    );
                }
                catch (ArgumentException e)
                {
                    if (e.Message == "Another ball is already here")
                    {
                        catched = true;
                    }
                }
            } while (catched);

            throw new Exception();
        }

        /*        public override void generateBalls()
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
                    AddBallToList(radius, random.Next(radius, width - radius), random.Next(radius, height - radius),weight, randomX, randomY);
                }

                public override void AddBallToList(int radius, int x, int y,int weight, int xDirection, int yDirection)
                {
                     if(x < radius || x > width - radius || y < radius || y > height - radius)
                    {
                        Console.WriteLine("Blad");
                        throw new Exception();
                    }

                    if(list.Any(Ball => Math.Abs(x - Ball.XValue) <= radius && Math.Abs(y - Ball.YValue) <= radius))
                    {
                        Console.WriteLine("Blad");
                        throw new Exception();
                    }
                    BallDataAPI dataBallAPI = boardAPI.createDataBallAPI(x, y, radius, weight, xDirection, yDirection);
                    BallLogicAPI ball = BallLogicAPI.CreateBall( x, y,radius,weight, xDirection, yDirection);
                    dataBallAPI.PropertyChanged += ball.Update!;
                    dataBallAPI.PropertyChanged += CheckIfCollisioned!;
                    list.Add(ball);

                }*/

        public override void CheckIfCollisioned(Object s, PropertyChangedEventArgs e)
        {
            BallDataAPI ball = (BallDataAPI)s;

            if (e.PropertyName is not ("XValue" or "YValue")) return;

            BallReflection(ball);
            WallReflection(ball);
        }

        private void WallReflection(BallDataAPI ball)
        {
            

            if (ball.XValue + ball.XDirection >= width - radius ||
               ball.XValue + ball.XDirection <= radius)
            {
                ballsLastCollision.Remove(ball);
                ball.ChangeXdir();
            }

            if (ball.YValue + ball.YDirection >= height - radius ||
                ball.YValue + ball.YDirection <= radius)
            {
                ballsLastCollision.Remove(ball);
                ball.ChangeYdir();
            }
        }


/*        public override void BounceAndMove()
        {
            foreach (BallLogicAPI ball in list)
            {
                if (ball.XValue + ball.XDirection + ball.Radius > width || ball.XValue + ball.XDirection - ball.Radius < 0)
                {
                    ball.XDirection = ball.XDirection * (-1);
                    
                }

                if (ball.YValue + ball.YDirection + ball.Radius > height || ball.YValue + ball.YDirection - ball.Radius < 0)
                {
                    ball.YDirection = ball.YDirection * (-1);
                }
                *//*ball.XValue += ball.XDirection;
                ball.YValue += ball.YDirection;*//*
            }
        }*/


        private void BallReflection(BallDataAPI ball1)
        {
            lock (syncObject)
            {
                foreach (BallDataAPI ball2 in boardAPI.getBalls().ToArray())
                {
                    BallDataAPI lastBall1, lastBall2;
                    if ((ballsLastCollision.TryGetValue(ball1, out lastBall1!) &&
                        ballsLastCollision.TryGetValue(ball2, out lastBall2!) &&
                        lastBall1 == ball2 && lastBall2 == ball1) || ball1.Equals(ball2))
                    {
                        continue;
                    }

                    if ( //condition of circles external contact: (r_1 + r_2) <= |AB|
                        (Math.Abs(Math.Sqrt(
                             (ball1.XValue - ball2.XValue) * (ball1.XValue - ball2.XValue) +
                             (ball1.YValue - ball2.YValue) * (ball1.YValue - ball2.YValue)
                         )) <= radius * 2.0 ||
                         Math.Sqrt(
                             (ball1.XValue + ball1.XDirection - ball2.XValue + ball2.XDirection) *
                             (ball1.XValue + ball1.XDirection - ball2.XValue + ball2.XDirection) +
                             (ball1.YValue + ball1.YDirection - ball2.YValue + ball2.YDirection) *
                             (ball1.YValue + ball1.YDirection - ball2.YValue + ball2.YDirection)
                         ) <= radius * 2.0)
                       )
                    {
                       
                        int ball1StartXSpeed = ball1.XDirection;
                        int ball1StartYSpeed = ball1.YDirection;
                        int ball2StartXSpeed = ball2.XDirection;
                        int ball2StartYSpeed = ball2.YDirection;
                        ball1.YDirection = ball2StartYSpeed;
                        ball2.YDirection = ball1StartYSpeed;
                        ball1.XDirection = ball2StartXSpeed;
                        ball2.XDirection = ball1StartXSpeed;
                        if (ball1StartXSpeed * ball2StartXSpeed > 0)
                        {
                            ChangeXdirToOpposite(ball1StartXSpeed, ball1, ball2);
                        }

                        if (ball1StartYSpeed * ball2StartYSpeed > 0)
                        {
                            ChangeYdirToOpposite(ball1StartYSpeed, ball1, ball2);
                        }
                        ballsLastCollision.Remove(ball1);
                        ballsLastCollision.Remove(ball2);
                        ballsLastCollision.Add(ball1, ball2);
                        ballsLastCollision.Add(ball2, ball1);
                    }
                }
            }
        }

        private static void ChangeYdirToOpposite(int ball1StartYSpeed, BallDataAPI ball1, BallDataAPI ball2)
        {
            switch (ball1StartYSpeed)
            {
                case > 0 when ball1.YValue > ball2.YValue:
                case < 0 when ball1.YValue < ball2.YValue:
                    ball2.ChangeYdir();
                    break;
                case < 0 when ball1.YValue < ball2.YValue:
                case > 0 when ball1.YValue > ball2.YValue:
                    ball1.ChangeYdir();
                    break;
            }
        }

        private static void ChangeXdirToOpposite(int ball1StartXSpeed, BallDataAPI ball1, BallDataAPI ball2)
        {
            switch (ball1StartXSpeed)
            {
                case > 0 when ball1.XValue > ball2.XValue:
                case < 0 when ball1.XValue < ball2.XValue:
                    ball2.ChangeXdir();
                    break;
                case < 0 when ball1.XValue < ball2.XValue:
                case > 0 when ball1.XValue > ball2.XValue:
                    ball1.ChangeXdir();
                    break;
            }
        }



/*        public override void makeBalls(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                CreateBallInRandomPlace();
            }
        }*/

    }
}