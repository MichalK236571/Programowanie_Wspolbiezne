using Logic;
using Data;

namespace Model
{
    public class Map
    {
        private int _width;
        private int _height;
        private LogicAbstactAPI _screen;

        public Map(int w, int h)
        {
            _width = w;
            _height = h;
            _screen = LogicAbstactAPI.CreateApi(_width, _height);
        }

/*        public void Move()
        {
            _screen.bounceAndMove();   
        }*/

        public List<Ball> GetAllBallsInList()
        {
            return _screen.GetAllBalls();
        }

        public void ClearMap()
        {
            _screen.RemoveAllBalls();  
        }

        public void CreateBallsOnMap(int amount)
        {
            _screen.makeBalls(amount);
        }


    }

    
}