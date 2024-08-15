namespace TestAutomationFinalTask.Utils;

public static class Logger
{
    private static readonly string logFilePath = Path
        .Combine(AppDomain.CurrentDomain.BaseDirectory, "test_logs.txt");
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

        File.AppendAllText(logFilePath, logMessage + Environment.NewLine);
    }
}
