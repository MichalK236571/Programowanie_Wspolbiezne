using Caliburn.Micro;
using Model;
using Logic;
namespace ViewModel;


public class VMClass
{

    public MapInterface _map { get; }
    public int _width { get; set; }
    public int _height { get; set; }

    public VMClass()
    {
        _map = MapInterface.CreateMap(650,434);
        _width = 650;
        _height = 434;

    }

    public BallInterface[]? GetBalls {
        get => _map.GetAllBallsInList().ToArray(); 
        
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
