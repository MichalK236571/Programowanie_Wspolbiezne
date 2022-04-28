using Logic;
using System.Collections.Generic;

namespace Presentation.Model
{
    public abstract class MapApi
    {
        public static MapApi createMap(int w, int h)
        {
            return new Map(w, h);
        }

        public abstract void Move();
        public abstract List<BallApi> GetBalls();
        public abstract void CreateBalls(int amount);
        public abstract void ClearMap();

        private class Map : MapApi
        {
            private int width;
            private int height;
            private LogicAbstactAPI screen;

            public Map(int w, int h)
            {
                width = w;
                height = h;
                screen = LogicAbstactAPI.CreateApi(width, height);
            }

            public override void Move()
            {
                screen.BounceAndMove();
            }

            public override List<BallApi> GetBalls()
            {
                return screen.GetAllBalls();
            }

            public override void ClearMap()
            {
                screen.RemoveAllBalls();
            }

            public override void CreateBalls(int amount)
            {
                screen.makeBalls(amount);
            }

        }

    }
}