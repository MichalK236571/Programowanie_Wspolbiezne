using System.ComponentModel;
using System.Runtime.CompilerServices;
using Data;

namespace Logic
{
    public  class Ball : BallLogicAPI, INotifyPropertyChanged
    {

        public override int XValue { get; set; }

        public override int YValue { get; set; }

        public override int Radius { get; set; }
        /*        private int xDirection;
                private int yDirection;
                private int weight;*/
        public override event PropertyChangedEventHandler? PropertyChanged;
   



       /* public override int XDirection
        {
            get => xDirection;
            set
            {
                xDirection = value;
            }
        }

        public override int YDirection
        {
            get => yDirection;
            set
            {
                yDirection = value;
            }
        }

        public override int Weight
        {
            get => weight;
            set { weight = value; }
        }*/

        
            public Ball(int x, int y, int r/*,int weight, int xDirection=0, int yDirection=0*/)
            {
                Radius = r;
                XValue = x;
                YValue = y;
/*                Weight = weight;
                XDirection = xDirection;
                YDirection = yDirection;*/
            }

       

        private void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            PropertyChanged?.Invoke(this, new BallArgs(name, XValue, YValue));

        }

        public override void Update(Object obj, PropertyChangedEventArgs e)
        {
            BallDataArgsAPI args = (BallDataArgsAPI)e;
            XValue = args.X;
            YValue = args.Y;
            OnPropertyChanged();
           /* BallDataAPI ball = (BallDataAPI) obj;
            GetType().GetProperty(e.PropertyName!)!.SetValue(
                this, ball.GetType().GetProperty(e.PropertyName!)!.GetValue(ball));
*/
        }
    }
}