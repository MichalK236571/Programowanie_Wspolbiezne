using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Diagnostics;

namespace Data
{
    internal class BallData : BallDataAPI, INotifyPropertyChanged
    {

        private int xValue;
        private int yValue;
        private int xDirection;
        private int yDirection;
        private int weight;
        private int radius;
        private bool moving = true;
        private Thread mov;
        public override event PropertyChangedEventHandler? PropertyChanged;
        internal override event PropertyChangedEventHandler? LoggerPropertyChanged;
        private const int FluentMoveTime = 8;
        public BallData(int x, int y, int r, int w, int xDir, int yDir)
        {
            radius = r;
            xValue = x;
            yValue = y;
            xDirection = xDir;
            yDirection = yDir;
            weight = w;
            mov = new(Movement) { IsBackground = true };


  /*          Thread thread = new Thread(Movement);
            thread.IsBackground = true;
            thread.Start();*/
        }

        public override int Radius
        {
            get => radius;
            //set { radius = value; }
        }

        public override int XValue
        {
            get => xValue;
           internal set { //OnLoggerPropertyChanged(xValue, value);
                          xValue = value; }
        }

        public override int YValue
        {
            get => yValue;
            internal set {/* OnLoggerPropertyChanged(yValue, value);*/ yValue = value; }
        }

        public override int XDirection
        {
            get => xDirection;
            set {xDirection = value;
               // OnLoggerPropertyChanged(xDirection, value); 
            }
        }

        public override int YDirection
        {
            get => yDirection;
            set {
                yDirection = value;
                //OnLoggerPropertyChanged(yDirection, value);
            }
        }

        public  int Weight
        {
            get => weight;
            //set { weight = value; }
        }
        internal override void StartBall()
        {
            mov.Start();
        }
        internal override void Stop()
        {
            moving = false;
        }
        public  void Movement()
        {
            Stopwatch stopwatch = new();
            while (moving)
            {
                stopwatch.Start();

                lock (this)
                {
                    XValue += XDirection;
                    YValue += YDirection;
                }
                OnPropertyChanged();

                stopwatch.Stop();

                if ((int)stopwatch.ElapsedMilliseconds < FluentMoveTime)
                {
                    Thread.Sleep(FluentMoveTime - (int)stopwatch.ElapsedMilliseconds);
                }

                stopwatch.Reset();
                //Move();
                //Thread.Sleep(6);
            }
        }
        public void Move()
        {
            XValue += XDirection;
            YValue += YDirection;
        }

        private void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new BallDataArgs(name, XValue, YValue));
        }

        public void Update(Object s, PropertyChangedEventArgs e)
        {
            Logger.Instancce().zapiszLoga(new LoggerArgs(XValue,YValue,xDirection,yDirection,this.GetHashCode()));

        }


        /*private void OnLoggerPropertyChanged(
            double oldValue, double newValue,
            [CallerMemberName] string? propertyName = null
        )
        {
            *//*Thread thread = new(
                () => LoggerPropertyChanged?.Invoke(this,new LoggerArgs(propertyName, oldValue, newValue)));
            thread.Start();*//*
        }*/


    }
}