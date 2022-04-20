using Caliburn.Micro;
using Model;
namespace ViewModel;


public class VMClass
{
    private bool Running = false;
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

  /*      while (Running)
        {
            await Task.Delay(10);
            map.Move();
            
        }*/
        

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
    }
}
