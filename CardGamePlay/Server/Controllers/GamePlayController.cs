using System.Collections.Generic;
using System.Linq;
using CardGamePlay.Shared.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CardGamePlay.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GamePlayController : ControllerBase
    {
        private readonly ILogger<GamePlayController> _logger;
        private readonly IGameplay _gameplay;

        public GamePlayController(ILogger<GamePlayController> logger, IGameplay gameplay)
        {
            this._logger = logger;
            this._gameplay = gameplay;
        }

        [HttpGet("Shuffle")]
        public int[] Shuffle()
        {
            return this._gameplay.Shuffle();
        }

        [HttpGet("Draw")]
        public List<List<int>> Draw()
        {
            var cards = this._gameplay.Shuffle();
            var drawCards = this._gameplay.Draw(cards, 4);

            var result = new List<List<int>>
            {
                cards.ToList(),
                drawCards[0].ToList(),
                drawCards[1].ToList(),
                drawCards[2].ToList(),
                drawCards[3].ToList()
            };

            return result;
        }
    }
}
