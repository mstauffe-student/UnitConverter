using System.Text.Json;
using UnitConverter.Models;

namespace UnitConverter.Services;

public class JsonLogReader : ILogReader
{
    private readonly string _logDirectory;
    private readonly ILogger<JsonLogReader> _logger;

    public JsonLogReader(IWebHostEnvironment environment, ILogger<JsonLogReader> logger)
    {
        _logDirectory = Path.Combine(environment.ContentRootPath, "Logs");
        _logger = logger;
    }

    public IEnumerable<LogEntry> Read()
    {
        string[] logFiles = null;

        List<LogEntry> logs = new List<LogEntry>();

        try
        {
            logFiles = Directory.GetFiles(_logDirectory, "*.json");
        }
        catch (IOException e)
        {
            _logger.LogError(e.Message + "Couldn't read log files from {LogDirectory}", _logDirectory);
        }

        foreach (string logFile in logFiles)
        {
            FileStream? stream = null;
            try
            {
                stream = GetFileStream(logFile);
                if (stream == null)
                {
                    continue;
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message + "Couldn't read log file {LogFile}", logFile);
                continue;
            }

            using StreamReader reader = new(stream);

            try
            {
                LoadLogs(reader, logFile, logs);
            }
            catch (IOException e)
            {
                _logger.LogError(e.Message + "Couldn't read log entry in file {LogFile}", logFile);
            }
        }
        return logs;
    }

    private FileStream GetFileStream(string logFile)
    {
        FileStream stream;
        try
        {
            stream = new FileStream(logFile, FileMode.Open, FileAccess.Read,
                FileShare.ReadWrite | FileShare.Delete);
        }
        catch (IOException e)
        {
            _logger.LogError(e.Message + "Couldn't read file {logFile}", logFile);
            throw;
        }

        return stream;
    }

    private void LoadLogs(StreamReader reader, string logFile, List<LogEntry> logs)
    {
        while (reader.ReadLine() is { } line)
        {
            try
            {
                LogEntry? entry = JsonSerializer.Deserialize<LogEntry>(line);
                if (entry != null)
                {
                    logs.Add(entry);
                }
            }
            catch (Exception e) when (e is JsonException or JsonException or NotSupportedException)
            {
                _logger.LogWarning(e, "Couldn't {line} line entry in {LogFile}", line, logFile);
            }
        }
    }


}
