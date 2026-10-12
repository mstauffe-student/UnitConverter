using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnitConverter.Models;
using UnitConverter.Services;
using UnitsNet;

namespace UnitConverter.Pages;

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


    public Logs(ILogReader logReader, ILogger<Logs> logger)
    {
        _logReader = logReader;
        _logger = logger;

        Level = string.Empty;
        ConversionType  = string.Empty;
        Entries = new List<LogEntry>();
    }

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
            ViewData["IfNone"] = "None of that level found";
        }

    }
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
            ViewData["IfNone"] = "None of that conversion type found";
        }
    }

    public IActionResult OnPostResetList()
    {
        Entries.Clear();
        return Page();
    }
}
