using Data;
using System.ComponentModel;

namespace Logic
{
    internal class BallsManager : LogicAbstactAPI
    {

        private int width;
        private int height; 
        private int radius;
        public int MaxBallSpeed = 5;
        private BoardAPI boardAPI;

        private List<BallLogicAPI> list = new();

        private int weight = 100;
        private Dictionary<BallDataAPI, BallDataAPI> ballsLastCollision = new();
        
        private readonly object syncObject = new();

        public BallsManager(BoardAPI BoardAPI)
        {
            boardAPI = BoardAPI;
            width = BoardAPI.Width;
            height = BoardAPI.Height;
            radius = 15;

        }

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
            BallLogicAPI ball = BallLogicAPI.CreateBall(ballData.XValue, ballData.YValue, ballData.Radius);
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

        public void CheckIfCollisioned(Object s, PropertyChangedEventArgs e)
        {
            BallDataAPI ball = (BallDataAPI)s;
            BallReflection(ball, ball.XValue, ball.YValue);
            WallReflection(ball, ball.XValue, ball.YValue);
        }

        private void WallReflection(BallDataAPI ball, int x, int y)
        {
           
            if (x + ball.XDirection >= width - radius ||
               x + ball.XDirection <= radius)
            {
                ballsLastCollision.Remove(ball);
                ball.XDirection *= -1;
            }

            if (y + ball.YDirection >= height - radius ||
                y + ball.YDirection <= radius)
            {
                ballsLastCollision.Remove(ball);            
                ball.YDirection *= -1;
            }
        }
        private void BallReflection(BallDataAPI ball1, int x, int y)
        {
            lock (syncObject)
            {
                foreach (BallDataAPI ball2 in boardAPI.getBalls().ToArray())
                {

                    if (ball2 == null)
                    {
                        continue;
                    }
                    BallDataAPI lastBall1, lastBall2;
                    if ((ballsLastCollision.TryGetValue(ball1, out lastBall1!) &&
                        ballsLastCollision.TryGetValue(ball2, out lastBall2!) &&
                        lastBall1 == ball2 && lastBall2 == ball1) || ball1.Equals(ball2))
                    {
                        continue;
                    }
                    int ball1XValue = x;
                    int ball1YValue = y;
                    int ball2XValue;
                    int ball2YValue;

                    lock (ball2)
                    {
                        ball2XValue = ball2.XValue;
                        ball2YValue = ball2.YValue;
                    }

                    if (
                        (Math.Abs(Math.Sqrt(
                             (ball1XValue - ball2XValue) * (ball1XValue - ball2XValue) +
                             (ball1YValue - ball2YValue) * (ball1YValue - ball2YValue)
                         )) <= radius * 2.0 ||
                         Math.Sqrt(
                             (ball1XValue + ball1.XDirection - ball2XValue + ball2.XDirection) *
                             (ball1XValue + ball1.XDirection - ball2XValue + ball2.XDirection) +
                             (ball1YValue + ball1.YDirection - ball2YValue + ball2.YDirection) *
                             (ball1YValue + ball1.YDirection - ball2YValue + ball2.YDirection)
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

        private static void ChangeXdirToOpposite(int Initial_X_Speed, BallDataAPI ball1, BallDataAPI ball2)
        {
            switch (Initial_X_Speed)
            {
                case > 0 when ball1.XValue > ball2.XValue:
                case < 0 when ball1.XValue < ball2.XValue:
                    ball2.XDirection *= -1;
                    break;
                case < 0 when ball1.XValue < ball2.XValue:
                case > 0 when ball1.XValue > ball2.XValue:
                    ball1.XDirection *= -1;
                    break;
            }
        }

        private static void ChangeYdirToOpposite(int Initial_Y_Speed, BallDataAPI ball1, BallDataAPI ball2)
        {
            switch (Initial_Y_Speed)
            {
                case > 0 when ball1.YValue > ball2.YValue:
                case < 0 when ball1.YValue < ball2.YValue:
                    ball2.YDirection *= -1;
                    break;
                case < 0 when ball1.YValue < ball2.YValue:
                case > 0 when ball1.YValue > ball2.YValue:
                    ball1.YDirection *= -1;
                    break;
            }
        }

        

    }
}