using Model;
namespace ViewModel;

public class VMClass
{
    private bool Running = false;
    private Map map = new Map();
    public VMClass()
    {

    }

    public void Start(int amount)
    {
        Running = true;
        map.CreateCircles(amount);
        map.Move(Running);

    }

    public void Stop()
    {
        Running = false;
    }
}
