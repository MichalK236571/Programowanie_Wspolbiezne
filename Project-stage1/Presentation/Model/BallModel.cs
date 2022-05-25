using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Logic;

namespace Presentation.Model
{
    internal class BallModel : BallModelAPI, INotifyPropertyChanged
    {
        private int x;
        private int y;
        private int radius;

        public override int X
        {
            get => x;
            set
            {
                x = value;
                RaisePropertyChanged();
            }
        }

        public override int Y
        {
            get => y;
            set
            {
                y = value;
                RaisePropertyChanged();
            }
        }

        public override int Radius
        {
            get => radius;
            set => radius = value;
        }

        public override event PropertyChangedEventHandler? PropertyChanged;

        public BallModel(int x, int y, int radius)
        {
            X = x;
            Y = y;
            Radius = radius;
        }

        public override void UpdateModelBalls(Object s, PropertyChangedEventArgs e)
        {
            BallLogicAPI ball = (BallLogicAPI)s;
            if (e.PropertyName == "XValue")
            {
                X = ball.XValue;
            }
            else if (e.PropertyName == "YValue")
            {
                Y = ball.YValue;
            }
        }

        private void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}