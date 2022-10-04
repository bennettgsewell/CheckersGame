using Checkers.Model;
using Microsoft.AspNetCore.Mvc;

namespace Checkers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BoardController : ControllerBase
    {
        private static Board s_board = new Board();

        private readonly ILogger<BoardController> _logger;

        public BoardController(ILogger<BoardController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public Player[][] Get()
        {
            return s_board._map;
        }

        [HttpPost()]
        public Player[][] Post()
        {
            s_board = new Board();
            return Get();
        }
    }
}
