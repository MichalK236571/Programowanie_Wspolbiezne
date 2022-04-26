using Logic;
using Data;

namespace Model
{
    internal class Map : MapInterface
    {
        private int _width;
        private int _height;
        private LogicAbstactAPI _screen;

        public  Map(int w, int h)
        {
            _width = w;
            _height = h;
            _screen = LogicAbstactAPI.CreateApi(_width, _height);
        }

        public override void Move()
        {
            _screen.BounceAndMove();
        }

        public override List<BallInterface> GetAllBallsInList()
        {
            return _screen.GetAllBalls();
        }

        public override void ClearMap()
        {
            _screen.RemoveAllBalls();  
        }

        public override void CreateBallsOnMap(int amount)
        {
            _screen.makeBalls(amount);
        }


    }

    
}