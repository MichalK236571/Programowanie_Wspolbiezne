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

    }
}