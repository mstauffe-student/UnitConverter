namespace UnitConverter.Services;

using UnitConverter.Models;

/**
 * interface for the JsonLogReader class. Sets up for dependency injection.
 */
public interface ILogReader
{
    IEnumerable<LogEntry> Read();
}
