using Logic;
using Data;

namespace Model
{
    public class Map
    {
        private int _width;
        private int _height;
        private Screen _screen;

        public Map(int w, int h)
        {
            _width = w;
            _height = h;
            _screen = new Screen(_width, _height);
        }

        public void Move()
        {
            _screen.bounceAndMove();
        }

        public CirclesList<Circle> GetAllCircles()
        {
            return _screen.GetCircles();
        }

        public void ClearMap()
        {
            _screen.ClearScreen();  
        }

        public void CreateCircles(int amount)
        {
            _screen.makeCircles(amount);
        }


    }

    
}