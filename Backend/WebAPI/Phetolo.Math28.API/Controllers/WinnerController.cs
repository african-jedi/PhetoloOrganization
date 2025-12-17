using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Phetolo.Math28.API.Hubs;

namespace Phetolo.Math28.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WinnerController : ControllerBase
    {
        IHubContext<WinnerNotificationHub> _winnerNotificationHub;
        public WinnerController(IHubContext<WinnerNotificationHub> winnerNotificationHub)
        {
            _winnerNotificationHub = winnerNotificationHub;
        }
        [HttpPost("notify")]
        public async Task<IActionResult> NotifyWinner([FromBody] string message)
        {
            if (_winnerNotificationHub != null)
            {
                await _winnerNotificationHub.Clients.All.SendAsync("ReceiveWinnerNotification", message);
                return Ok(new { Status = "Notification sent" });
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Hub context is not available");
            }
        }
    }
}
