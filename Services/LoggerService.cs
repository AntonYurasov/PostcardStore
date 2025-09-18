using System.IO;

public class LoggerService : ILoggerSerivce
{
    public async void LogData(string someData)
    {
        await File.WriteAllTextAsync("log.txt", someData);
    }
}