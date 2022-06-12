using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Text;

namespace Data;

internal class Logger
{

    private string Begining = "{\n" +
                                     "\t\"logs\": [";

    private string Ending = "\t]\n" +
                                   "}";

    private const string filePath = "../../../../logs_{0}.json";

    private readonly string fileName;
    private object fileLock = new();

    private static Logger instancja;

    public Logger()
    {
        fileName = string.Format(filePath, DateTime.Now.ToFileTime());

        using StreamWriter writer = File.AppendText(fileName);
        writer.WriteLineAsync(Begining);
        writer.Close();
    }

    public static Logger Instance()
    {
        if(instancja == null)
        {
            instancja = new Logger();
        }
        return instancja;

    }

    public void EndLogging()
    {
        using StreamWriter writer = File.AppendText(fileName);
        writer.WriteLineAsync(Ending);
        writer.Close();
    }

    public void writeLog(LoggerArgs o)
    {
        lock (fileLock)
        {
            using StreamWriter writer = File.AppendText(fileName);
            writer.WriteLineAsync(o.informacje());
            writer.Close();
        }
        

    }


}