using NativeMessaging;
using System.Reflection;
using System.Text.Json.Nodes;

public class MyHost : Host
{
    private const bool SendConfirmationReceipt = true;

    public override string Hostname
    {
        get { return "com.anewtonlevey.myhost"; }
    }

    public MyHost() : base(SendConfirmationReceipt)
    {

    }

    protected override void ProcessReceivedMessage(JsonObject data)
    {
        Console.WriteLine(data);
        //SendMessage(data);
    }
}

class Program
{
    static public string AssemblyLoadDirectory
    {
        get
        {
            string codeBase = Assembly.GetEntryAssembly().Location;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
        }
    }

    static public string AssemblyExecuteablePath
    {
        get
        {
            string codeBase = Assembly.GetEntryAssembly().Location;
            UriBuilder uri = new UriBuilder(codeBase);
            return Uri.UnescapeDataString(uri.Path);
        }
    }

    static Host Host;

    static string[] AllowedOrigins = new string[] { "chrome-extension://hdhjadldckbhijphjpakflgmdiljfdaa/" };
    static string Description = "Description Goes Here";

    static void Main(string[] args)
    {
        Host = new MyHost();
        Host.SupportedBrowsers.Add(ChromiumBrowser.GoogleChrome);
        Host.SupportedBrowsers.Add(ChromiumBrowser.MicrosoftEdge);

        if (args.Contains("--register"))
        {
            Host.GenerateManifest(Description, AllowedOrigins);
            Host.Register();
        }
        else if (args.Contains("--unregister"))
        {
            Host.Unregister();
        }
        else
        {
            try
            {
                Host.Listen();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.InnerException);
            }
        }
    }
}