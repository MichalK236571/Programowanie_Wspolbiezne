namespace Data
{
    public abstract class DataAbstactAPI
    {
        public static DataAbstactAPI CreateApi()
        {
            return new BallData();
        }
        public abstract void Connect();

    }
}