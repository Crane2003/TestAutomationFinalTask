namespace TestAutomationFinalTask.Utils;

public static class Logger
{
    private static readonly string logFilePath = Path
        .Combine(AppDomain.CurrentDomain.BaseDirectory, "test_logs.txt");

    private static readonly object _lock = new();
    static Logger()
    {
        if (File.Exists(logFilePath))
        {
            File.Delete(logFilePath);
        }
        File.Create(logFilePath).Dispose();
    }
    public static void Log(string message)
    {
        string logMessage = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}";

        Console.WriteLine(logMessage);

        lock (_lock)
        {

            File.AppendAllText(logFilePath, logMessage + Environment.NewLine);
        }
    }

    public static void LogTestCompleted()
    {
        Logger.Log("Test passed.");
        Logger.Log("Test completed.");
    }

    public static void LogBrowserClosed()
    {
        Logger.Log("Browser closed.\n");
    }

    public static void LogNavigation()
    {
        Logger.Log("Navigated to the Login page.");
    }

    public static void LogParameters(string username, string password)
    {
        Logger.Log($"Testing login with Username: {username}, Password: {password}");
    }

    public static void LogExpectedMessage(string message)
    {
        Logger.Log($"Error message: {message}.");
    }

    public static void LogSuccessfulLogin(string message)
    {
        Logger.Log($"Dashboard title: {message}.");
    }
}
