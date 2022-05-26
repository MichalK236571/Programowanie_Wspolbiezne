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

        public bool createFlag = true;
        public bool clearFlag = false;

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
            mainMap = model;
            CreateFlag = true;
            ClearFlag = false;
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

        public ObservableCollection<BallModelAPI> Circles => mainMap.GetBalls();

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
            Environment.Exit(0);
        }

        private bool GetCreateFlag()
        {
            return CreateFlag;
        }

        private bool GetClearFlag()
        {
            return ClearFlag;
        }
    }
}