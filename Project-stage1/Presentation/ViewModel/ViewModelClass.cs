using Presentation.ViewModel.MVVMBase;
using Presentation.Model;
using System;
using System.Threading.Tasks;
using Logic;
using System.Collections.ObjectModel;

namespace Presentation.ViewModel
{
    public class ViewModelClass : BaseViewModel
    {
        private string numberOfBalls;
        public RelayCommand create { get; }
        public RelayCommand clear { get; }
        public RelayCommand pause { get; }
        public RelayCommand resume { get; }

        public bool createFlag = true;
        public bool clearFlag = false;
        public bool resumeFlag = false;
        public bool pauseFlag = false;

        public MapApi mainMap { get; }

        public int width { get; }
        public int height { get; }

        public ViewModelClass() : this(MapApi.createMap())
        {
        }

        public ViewModelClass(MapApi model)
        {
            width = 1020;
            height = 684;
            numberOfBalls = "";
            create = new RelayCommand(Create, GetCreateFlag);
            clear = new RelayCommand(Clear, GetClearFlag);
            resume = new RelayCommand(Start, GetStartFlag);
            pause = new RelayCommand(Stop, GetStopFlag);
            mainMap = model;
            CreateFlag = true;
            ClearFlag = false;
            StartFlag = false;
            StopFlag = false;
        }

        public string NumberOfBalls
        {
            get => numberOfBalls;
            set
            {
                numberOfBalls = value;
                OnPropertyChanged();
            }
        }

        public bool CreateFlag
        {
            get => createFlag;

            set
            {
                createFlag = value;
                create.OnCanExecuteChanged();
            }
        }

        public bool ClearFlag
        {
            get => clearFlag;

            set
            {
                clearFlag = value;
                clear.OnCanExecuteChanged();
            }
        }

        public bool StartFlag
        {
            get => resumeFlag;

            set
            {
                resumeFlag = value;
                resume.OnCanExecuteChanged();
            }
        }

        public bool StopFlag
        {
            get => pauseFlag;

            set
            {
                pauseFlag = value;
                pause.OnCanExecuteChanged();
            }
        }

        public ObservableCollection<BallModelAPI> Circles => mainMap.GetBalls();
        //public BallLogicAPI[]? GetBalls { get => mainMap.GetBalls().ToArray(); }

        public void Create()
        {
            try
            {
                

                int numberOfBalls = int.Parse(this.numberOfBalls);

                if (numberOfBalls < 1)
                {
                    throw new ArgumentException("Number of balls is less than 1");
                }

                mainMap.CreateBalls(numberOfBalls);
                OnPropertyChanged(nameof(Circles));
                CreateFlag = false;
                ClearFlag = true;
                StartFlag = true;
            }
            catch (Exception)
            {
                NumberOfBalls = "";
            }
        }

        public void Clear()
        {
            NumberOfBalls = "";
            mainMap.ClearMap();
            OnPropertyChanged(nameof(Circles));
            CreateFlag = true;
            ClearFlag = false;
            StartFlag = false;
            StopFlag = false;
            Environment.Exit(0);
        }

/*        public async void Move()
        {
            while (StopFlag)
            {
                await Task.Delay(10);
                mainMap.Move();
                OnPropertyChanged("GetBalls");
            }
        }*/

        public void Start()
        {
            StopFlag = true;
            StartFlag = false;
            //Move();
        }

        public void Stop()
        {
            StartFlag = true;
            StopFlag = false;
        }

        private bool GetCreateFlag()
        {
            return CreateFlag;
        }

        private bool GetClearFlag()
        {
            return ClearFlag;
        }

        private bool GetStartFlag()
        {
            return StartFlag;
        }

        private bool GetStopFlag()
        {
            return StopFlag;
        }
    }
}