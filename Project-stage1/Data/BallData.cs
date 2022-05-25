﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace Data
{
    internal class BallData : BallDataAPI, INotifyPropertyChanged
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
            set { xDirection = value;
                OnPropertyChanged();
            }
        }

        public override int YDirection
        {
            get => yDirection;
            set {
                yDirection = value;
                OnPropertyChanged();
            }
        }

        public override int Weight
        {
            get => weight;
            set { weight = value; }
        }

        public BallData(int x, int y, int r,int w, int xDir, int yDir)
        {
            radius = r;
            xValue = x;
            yValue = y;
            xDirection = xDir;
            yDirection = yDir;
            weight = w;
            Thread thread = new Thread(Movement);
            thread.IsBackground = true;
            thread.Start();
        }

        public override void Movement()
        {
            while (true)
            {
                Move();
            }
        }
        public override void Move()
        {
            XValue += XDirection;
            YValue += YDirection;
        }

        public override void ChangeXdir()
        {
            XDirection *= -1;
        }

        public override void ChangeYdir()
        {
            YDirection *= -1;
        }

        private void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }





    }
}