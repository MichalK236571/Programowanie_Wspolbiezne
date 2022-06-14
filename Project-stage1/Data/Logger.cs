using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Text;

namespace Data;

internal class Logger
{



    private readonly string fileName;
    private object fileLock = new();

    private static Logger instancja;

    public Logger()
    {
        fileName = string.Format("../../../../logs_{0}.json", DateTime.Now.ToFileTime());

        using StreamWriter writer = File.AppendText(fileName);
        writer.WriteLineAsync("{\n\t\"logs\": [");
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
        writer.WriteLineAsync("\t]\n}");
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