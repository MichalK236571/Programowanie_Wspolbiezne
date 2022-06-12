using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Text;

namespace Data;

internal class Logger
{

    private const string StartPart = "{\n" +
                                     "\t\"logs\": [";

    private const string EndPart = "\t]\n" +
                                   "}";

    /*private const string ChangeLogPattern = "\t\t{{\n" +
                                            "\t\t\t\"time_stamp\": \"{0}\",\n" +
                                            "\t\t\t\"object_type\": \"{1}\",\n" +
                                            "\t\t\t\"object_id\": {2},\n" +
                                            "\t\t\t\"changed_property\": \"{3}\",\n" +
                                            "\t\t\t\"old_value\": {4},\n" +
                                            "\t\t\t\"new_value\": {5}\n" +
                                            "\t\t}},";

    private const string LogLinePattern = "\t\t\t\"{0}\": \"{1}\",\n";

    private const string CreateLogPattern = "\t\t{{\n" +
                                            "\t\t\t\"time_stamp\": \"{0}\",\n" +
                                            "\t\t\t\"object_type\": \"{1}\",\n" +
                                            "\t\t\t\"object_id\": {2},\n" +
                                            "{3}" +
                                            "\t\t}},";

    private const string EventLogPattern = "\t\t{{\n" +
                                           "\t\t\t\"time_stamp\": \"{0}\",\n" +
                                           "\t\t\t\"event\": \"{1}\"\n\t\t" +
                                           "}},";

    private const string CompletedLogPattern = "\t\t{{\n" +
                                               "\t\t\t\"time_stamp\": \"{0}\",\n" +
                                               "\t\t\t\"event\": \"Completed\"\n\t\t" +
                                               "}}";*/

    //private static readonly TimeSpan TimeSpan = new(0, 0, 1, 0);

    private const string FileLocationPattern = "../../../../logs_{0}.json";

    private readonly string _fileName;
    private object _fileLock = new();

    private static Logger instancja;

    public Logger()
    {
        _fileName = string.Format(FileLocationPattern, DateTime.Now.ToFileTime());

        using StreamWriter writer = File.AppendText(_fileName);
        writer.WriteLineAsync(StartPart);
        writer.Close();

        //LogEvent("Launched");
    }

    public static Logger Instancce()
    {
        if(instancja == null)
        {
            instancja = new Logger();
        }
        return instancja;

    }

    public void EndLogging()
    {
        //if (!Monitor.TryEnter(_fileLock, TimeSpan)) return;
        //Log(string.Format(CompletedLogPattern, GetTimestamp()));
        using StreamWriter writer = File.AppendText(_fileName);
        writer.WriteLineAsync(EndPart);
        writer.Close();
    }

    /*public void LogEvent(string name)
    {
        Log(string.Format(EventLogPattern, GetTimestamp(), name));
    }*/

/*    public void LogChange(object? s, PropertyChangedEventArgs propertyChangedEventArgs)
    {
        LoggerArgs? e = propertyChangedEventArgs as LoggerArgs;
        Log(
            string.Format(
                ChangeLogPattern,
                GetTimestamp(),
                s?.GetType().Name,
                s?.GetHashCode(),
                e?.PropertyName,
                e?.OldValue, e?.NewValue
            )
        );
    }*/

    /*public void LogCreate(object o)
    {
        StringBuilder sb = new();
        foreach (PropertyInfo propertyInfo in o.GetType().GetProperties())
        {
                sb.AppendFormat(LogLinePattern,
                propertyInfo.Name,
                o.GetType().GetProperty(propertyInfo.Name)!.GetValue(o));
        }

        Log(
            string.Format(
                CreateLogPattern, 
                GetTimestamp(), 
                o.GetType().Name, 
                o.GetHashCode(),
                sb.Remove(sb.Length - 2, 1)
            )
        );
    }*/

    /*private string GetTimestamp()
    {
        return DateTime.Now.ToString(CultureInfo.CurrentCulture) + ":" + DateTime.Now.Millisecond;
    }*/

    /*private void Log(string text)
    {
        lock (_fileLock)
        {
            using StreamWriter writer = File.AppendText(_fileName);
            writer.WriteLineAsync(text);
            writer.Close();
        }
    }*/

    public void zapiszLoga(LoggerArgs o)
    {
        using StreamWriter writer = File.AppendText(_fileName);
        writer.WriteLineAsync(o.informacje());
        writer.Close();

    }


}