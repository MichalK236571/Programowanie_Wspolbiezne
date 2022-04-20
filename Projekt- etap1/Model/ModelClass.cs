using Logic;
using Data;

namespace Model
{
    public class Map
    {
        private int _width;
        private int _height;
        private Screen _screen;

        public Map()
        {
            _width = 650;
            _height = 434;
            _screen = new Screen(_width, _height);
        }

        public void Move(bool Running)
        {
            while (Running)
            {
                _screen.bounceAndMove();
            }
            
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