using Microsoft.AspNetCore.Mvc;

namespace Phetolo.Math28.HealthChecks.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        if(_logger.IsEnabled(LogLevel.Debug))
          _logger.LogDebug("Redirect to health check page");

        return Redirect("/health-check");
    }
}
