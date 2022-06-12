using System.ComponentModel;
using System.Globalization;
namespace Data;

internal class LoggerArgs
{
    public int XValue { get; }
    public int YValue { get; }
    public int XDir { get; }
    public int YDir { get; }
    public int HashCode { get; }

    public string pattern { get; }
    public string timeStamp { get; }


    public LoggerArgs(int XValue, int YValue, int XDir, int YDir, int HashCode)
    {
        this.XValue = XValue;
        this.YValue = YValue;
        this.XDir = XDir;
        this.YDir = YDir;
        this.HashCode = HashCode;
        this.pattern = "\t\t{{\n" +
                        "\t\t\t\"TimeStamp\": \"{0}\",\n" +
                        "\t\t\t\"HashCode\": \"{1}\",\n" +
                        "\t\t\t\"XPosition\": \"{2}\",\n" +
                        "\t\t\t\"YPosition\": \"{3}\",\n" +
                        "\t\t\t\"XSpeed\": \"{4}\",\n" +
                        "\t\t\t\"YSpeed\": \"{5}\",\n" +
                        "\t\t}},";
        this.timeStamp = DateTime.Now.ToString(CultureInfo.CurrentCulture) + ":" + DateTime.Now.Millisecond;

    }

    public string informacje()
    {
        string log = "";
        log = string.Format(this.pattern,this.timeStamp,this.HashCode
            ,this.XValue,this.YValue,this.XDir,this.YDir);

        return log;

    }
}