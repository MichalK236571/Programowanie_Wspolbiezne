using Logic;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Presentation.Model
{
    public abstract class MapApi
    {
        public static MapApi createMap(LogicAbstactAPI? logicApi = null)//int w, int h)
        {
            return new Map(logicApi ?? LogicAbstactAPI.CreateApi(1020,684));//w, h);
        }
        //public abstract void CreateNBallsInRandomPlaces(int numOfBalls);
        //public abstract void Move();
        //public abstract List<BallLogicAPI> GetBalls();
        public abstract ObservableCollection<BallModelAPI> GetBalls();
        public abstract void CreateBalls(int amount);
        public abstract void ClearMap();

        private class Map : MapApi
        {
            //private int width;
            //private int height;
            private LogicAbstactAPI screen;
            private ObservableCollection<BallModelAPI> ModelBalls = new();

            public Map(LogicAbstactAPI logicApi)//int w, int h)
            {
                //width = w;
                //height = h;
                screen = logicApi;
            }

            /*            public override void Move()
                        {
                            screen.BounceAndMove();
                        }*/


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

            /*            public override List<BallLogicAPI> GetBalls()
                        {
                            return screen.GetAllBalls();
                        }*/
/*            public override void CreateNBallsInRandomPlaces(int numOfBalls)
            {
                
            }*/
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