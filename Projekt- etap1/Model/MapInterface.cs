using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;

namespace Model
{
    public abstract class MapInterface
    {
        internal static Map CreateMap(int w, int h)
        {
            return new Map(w,h);
        }

        public abstract void Move();
        public abstract List<BallInterface> GetAllBallsInList();

        public abstract void ClearMap();

        public abstract void CreateBallsOnMap(int amount);
    }
}
