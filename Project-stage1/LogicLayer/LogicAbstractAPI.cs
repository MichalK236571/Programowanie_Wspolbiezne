using Data;
using System.ComponentModel;


namespace Logic
{
    public abstract class LogicAbstactAPI
    {
        public static LogicAbstactAPI CreateApi(int width, int height, BoardAPI? boardApi = null)
        {
            return new BallsManager(boardApi ?? BoardAPI.createAPI(width, height));

        }

        public abstract List<BallLogicAPI> GetAllBalls();
        public abstract void RemoveAllBalls();
        public abstract BallLogicAPI MakeBall(int x, int y, int xDirection, int yDirection);
        public abstract BallLogicAPI CreateBallInRandomPlace();

    }
}