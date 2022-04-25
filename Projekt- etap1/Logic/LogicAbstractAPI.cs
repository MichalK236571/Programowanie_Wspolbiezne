using Logic;

namespace Data
{
    public abstract class LogicAbstactAPI
    {
        public static LogicAbstactAPI CreateApi(int width, int height)
        {
            return new BallsManager(width,height);
        }

        

    }
}