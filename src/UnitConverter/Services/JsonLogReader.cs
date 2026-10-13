using System.Text.Json;
using UnitConverter.Models;

namespace UnitConverter.Services;

/**
 * Class to read json logs.
 */
public class JsonLogReader : ILogReader
{
    private readonly string _logDirectory;
    private readonly ILogger<JsonLogReader> _logger;

    /**
     * Constructor to set up injection for IWebHostEnvironment and ILogger.
     *
     * @param environment- dependency injection for IWebHostEnvironment.
     * @param logger- dependency injection for ILogger.
     */
    public JsonLogReader(IWebHostEnvironment environment, ILogger<JsonLogReader> logger)
    {
        _logDirectory = Path.Combine(environment.ContentRootPath, "Logs");
        _logger = logger;
    }

    /**
     * Reads the logs. Tries to get files that are .json. Throws and logs if an exception occurs.
     * Uses GetFileStream() and LoadLogs() to help read and put the logs in a list to be used elsewhere, like
     * in the Logs Razor Page.
     *
     * @return a list of LogEntry logs
     */
    public IEnumerable<LogEntry> Read()
    {
        string[] logFiles;

        List<LogEntry> logs = new List<LogEntry>();

        try
        {
            logFiles = Directory.GetFiles(_logDirectory, "*.json");
        }
        catch (IOException e)
        {
            _logger.LogError(e.Message + "Couldn't read log files from {logDirectory}", _logDirectory);
            throw;
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
                _logger.LogError(e.Message + "Couldn't read log entry in file {logFile}", logFile);
            }
        }
        return logs;
    }

    /**
     * Tries using a stream to take a string of logFile. Throws an IOException and logs if an exception
     * happens.
     *
     * @param logFiles a file for logging. Meant to be streamed in this case.
     */
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

    /**
     * Tries to read each line from a log file to be added to a LogEntry list. Logs a warning if
     * there is an ArgumentNullException, JsonException, or NotSupportedException.
     */
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
            catch (Exception e) when (e is ArgumentNullException or JsonException or NotSupportedException)
            {
                _logger.LogWarning(e, "Could not read {line} line entry in {LogFile}", line, logFile);
            }
        }
    }
}
