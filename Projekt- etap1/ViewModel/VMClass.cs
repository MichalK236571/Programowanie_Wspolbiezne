
using Model;
using Logic;
using System.Windows;



namespace ViewModel;


public class VMClass : BaseViewModel
{

    public MapInterface _map { get; }
    public int _width { get; set; }
    public int _height { get; set; }
    public RelayCommand _start { get; set; }
    public RelayCommand _pause { get; set; }

    public bool pause = false;
    public bool start = false;

    public string _numberOfBalls = "10";
    

    public VMClass()
    {
        _map = MapInterface.CreateMap(650,434);
        _width = 650;
        _height = 434;
        _start = new RelayCommand(Start, CanStart);
        _pause = new RelayCommand(Pause, CanPause);
    }

    private bool CanStart()
    {
        return StartButton;
    }

    private bool CanPause()
    {
        return PauseButton;
    }

    public BallInterface[]? GetBalls {
        get => _map.GetAllBallsInList().ToArray(); 
        
    }

    public async void Move()
    {
        await Task.Delay(10);
        _map.Move();
    }

    public void Start()
    {
        int numberOfBalls = int.Parse(_numberOfBalls);
        _map.CreateBallsOnMap(numberOfBalls);

        PauseButton = false;
        StartButton = true;
        while (!pause)
        {
            Move();
        }
        
    }

    public void Pause()
    {
        StartButton = false;
        PauseButton = true;
    }

    public bool StartButton
    {
        get => start;

        set
        {
            start = value;
            
        }
    }

    public bool PauseButton
    {
        get => pause;

        set
        {
            pause = value;

        }
    }


    // public BallApi[]? GetBalls { get => _mainMap.GetBalls().ToArray(); }
    /* private bool Running = false;
     private string count = "ABCD";
     public string countBalls
     {
         get => count;
         set { count = value; }
     }
    // public BindableCollection<Circle>;

     public int width { get; }
     public int height { get; }
     Map map;

     public VMClass()
     {
         width = 650;
         height = 434;
         map = new Map(width, height);
     }

     public async void Start(int amount)
     {
         Running = true;
         map.CreateCircles(amount);

   *//*      while (Running)
         {
             await Task.Delay(10);
             map.Move();

         }*//*


     }

     public void Stop()
     {
         Running = false;
     }

     public Object[]? GetCircles
     {
         get => map.GetAllCircles().ToArray();

     }

     public List<String> Items
     {
         get { return new List<String> { "One", "Two", "Three" }; }
     }*/
}
