namespace Logic
{
    public abstract class LogicAbstactAPI
    {
        public static LogicAbstactAPI CreateApi(int width, int height)
        {
            return new BallsManager(width,height);
        }

        public abstract List<Ball> GetAllBalls();
        public abstract void generateBalls();
        public abstract void RemoveAllBalls();
        public abstract void makeBalls(int amount);
        public abstract void BounceAndMove();
        public abstract void AddBallToList(int radious, int x, int y, int xDirection, int yDirection);
        public abstract Ball GetBall(int index);

    }
}