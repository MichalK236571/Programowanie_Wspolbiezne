using Logic;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Presentation.Model
{
    public abstract class MapApi
    {
        public static MapApi createMap(LogicAbstactAPI? logicApi = null)
        {
            return new Map(logicApi ?? LogicAbstactAPI.CreateApi(1020,684));
        }
        public abstract ObservableCollection<BallModelAPI> GetBalls();
        public abstract void CreateBalls(int amount);
        public abstract void ClearMap();

        private class Map : MapApi
        {
            private LogicAbstactAPI screen;
            private ObservableCollection<BallModelAPI> ModelBalls = new();

            public Map(LogicAbstactAPI logicApi)
            {

                screen = logicApi;
            }


            public override ObservableCollection<BallModelAPI> GetBalls()
            {
                ModelBalls.Clear();
                foreach (BallLogicAPI ball in screen.GetAllBalls())
                {
                    BallModelAPI c = BallModelAPI.CreateModelBall(ball.XValue, ball.YValue, ball.Radius);
                    ModelBalls.Add(c);
                    ball.PropertyChanged += c.UpdateModelBalls!;
                }

                return ModelBalls;
            }

            public override void ClearMap()
            {
                screen.RemoveAllBalls();
            }

            public override void CreateBalls(int amount)
            {
                for (int i = 0; i < amount; i++)
                {
                    screen.CreateBallInRandomPlace();
                }
            }

        }

    }
}