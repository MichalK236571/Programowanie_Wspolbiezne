using System.ComponentModel;
using System.Runtime.CompilerServices;
using Data;

namespace Logic
{
    public  class Ball : BallLogicAPI, INotifyPropertyChanged
    {

        private int radius;
        private int xValue;
        private int yValue;
        private int xDirection;
        private int yDirection;
        private int weight;
        public override event PropertyChangedEventHandler? PropertyChanged;

        public override int Radius
        {
            get => radius;
            set { radius = value; }
        }

        public override int XValue
        {
            get => xValue;
            set { xValue = value; OnPropertyChanged(); }
        }

        public override int YValue
        {
            get => yValue;
            set { yValue = value; OnPropertyChanged(); }
        }

        public override int XDirection
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
        }

        
            public Ball(int x, int y, int r,int weight, int xDirection=0, int yDirection=0)
            {
                Radius = r;
                XValue = x;
                YValue = y;
                Weight = weight;
                XDirection = xDirection;
                YDirection = yDirection;
            }

       

        private void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public override void Update(Object obj, PropertyChangedEventArgs e)
        {
            BallDataAPI ball = (BallDataAPI) obj;
            GetType().GetProperty(e.PropertyName!)!.SetValue(
                this, ball.GetType().GetProperty(e.PropertyName!)!.GetValue(ball));

            //GetType().GetProperty(e.PropertyName!)!.SetValue(this, obj); //??? - Nie wiem czy tak może być
        }
    }
}