using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnitConverter.Models;
using UnitConverter.Services;
using UnitsNet;

namespace UnitConverter.Pages;

/**
 * The Logs page model. It creates a list for the logs table. It gets the logs to show. It allows the select
 * lists to actually filter the logs.
 */
public class Logs : PageModel
{
    private readonly ILogReader _logReader;
    private readonly ILogger<Logs> _logger;

    [BindProperty(SupportsGet = true)]
    public string Search { get; set; }

    [BindProperty(SupportsGet = true)]
    public string Level { get; set; }

    [BindProperty(SupportsGet = true)]
    public string ConversionType { get; set; }

    public List<LogEntry> Entries { get; set; }

    /**
     * A default constructor. Allows ILogReader and ILogger to be injected in. Sets
     * up default values fot Level, ConversionType, and Entries.
     *
     * @param logReader- ILogReader dependency injection.
     * @param logger- ILogger dependency injection.
     */
    public Logs(ILogReader logReader, ILogger<Logs> logger)
    {
        _logReader = logReader;
        _logger = logger;

        Level = string.Empty;
        ConversionType  = string.Empty;
        Entries = new List<LogEntry>();
    }

    /**
     * Attempts to load the logs, redirects to an error page if there's an exception. It also filters
     * the logs. Returns the page.
     */
    public IActionResult OnGet()
    {
        try
        {
            LoadLogs();
        }
        catch (Exception e)
        {
            return RedirectToPage("/Error");
        }

        FilterLevelLogs();
        FilterConversionTypeLog();

        return Page();
    }

    /**
     * Attempts to us logReader to Read the logs, turn it into a list, and put the list into the Entries list.
     * Throws and logs if there's an exception.
     */
    private void LoadLogs()
    {
        try
        {
            Entries = _logReader.Read().ToList();
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message, "Unable to load logs");
            throw;
        }
    }

    /**
     * Allows filtering for the Level logs using a foreach loop. If there is nothing, uses a ViewData to
     * display a message.
     */
    private void FilterLevelLogs()
    {
        if (string.IsNullOrEmpty(Level))
        {
            return;
        }
        for (int i = Entries.Count - 1; i >= 0; i--)
        {
            if (!string.Equals(Entries[i].Level, Level, StringComparison.OrdinalIgnoreCase))
            {
                Entries.RemoveAt(i);
            }
        }
        if (Entries.Count == 0)
        {
            ViewData["IfNone"] = "Sorry, none of that level found";
        }

    }

    /**
     * Allows filtering for the conversion types using a foreach loop. If there is nothing, uses a ViewData to
     * display a message.
     */
    private void FilterConversionTypeLog()
    {
        if (string.IsNullOrEmpty(ConversionType))
        {
            return;
        }
        for (int i = Entries.Count - 1; i >= 0; i--)
        {
            if (!string.Equals(Entries[i].ConversionType, ConversionType, StringComparison.OrdinalIgnoreCase))
            {
                Entries.RemoveAt(i);
            }
        }
        if (Entries.Count == 0)
        {
            ViewData["IfNone"] = "Sorry, none of that conversion type found";
        }
    }

    /**
     * Allows the clear button to clear the table.
     */
    public IActionResult OnPostResetList()
    {
        Entries.Clear();
        return Page();
    }
}
