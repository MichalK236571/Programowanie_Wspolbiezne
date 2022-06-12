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
        public override event PropertyChangedEventHandler? PropertyChanged;
            public Ball(int x, int y, int r)
            {
                Radius = r;
                XValue = x;
                YValue = y;
            }
        private void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public override void Update(Object obj, PropertyChangedEventArgs e)
        {
            BallDataAPI ball = (BallDataAPI)obj;
            XValue = ball.XValue;
            YValue = ball.YValue;
            OnPropertyChanged();
        }
    }
}