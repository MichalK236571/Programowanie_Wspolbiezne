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
        //public abstract void generateBalls();
        public abstract void RemoveAllBalls();
        //public abstract void makeBalls(int amount);
        //public abstract void AddBallToList(int radius, int x, int y,int weight, int xDirection, int yDirection);
        public abstract BallLogicAPI GetBall(int index);
        public abstract BallLogicAPI MakeBall(int x, int y, int xDirection, int yDirection);
        public abstract BallLogicAPI CreateBallInRandomPlace();
        public abstract void CheckIfCollisioned(Object s, PropertyChangedEventArgs e);

    }
}