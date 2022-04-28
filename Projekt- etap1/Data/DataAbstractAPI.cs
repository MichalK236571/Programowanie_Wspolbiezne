namespace Data
{
    public abstract class DataAbstactAPI
    {
        public static DataAbstactAPI CreateApi()
        {
            return new Data();
        }
        public abstract void Connect();

    }
}