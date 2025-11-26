using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Phetolo.Math28.API.Models;

namespace Phetolo.Math28.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PuzzleController : ControllerBase
    {
        [HttpGet]
        public PuzzleDetailsDTO TodaysPuzzle()
        {
            return new PuzzleDetailsDTO
            {
                PuzzleNumbers = new PuzzleDTO
                {
                    Id = Guid.NewGuid(),
                    Position = 1,
                    Value = "1",
                    IsNumber = true,
                }
            };
        }
    }
}
