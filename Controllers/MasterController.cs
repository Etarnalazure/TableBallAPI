using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using TableBallAPI.Interface;
using TableBallAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TableBallAPI.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class MasterController : ControllerBase
    {
        private readonly IRepository<PlayerBaseModel> _playerRepository;
        private readonly IRepository<BattleBaseModel> _battleRepository;
        public MasterController(IRepository<PlayerBaseModel> playerRepository, IRepository<BattleBaseModel> battleRepository)
        {
            _playerRepository = playerRepository;
            _battleRepository = battleRepository;
        }

        #region Player

        [HttpGet("players")]
        public IEnumerable<PlayerBaseModel> GetPlayers()
        {
            return _playerRepository.GetAll();
        }

        [HttpGet("players/{id}")]
        public IActionResult GetPlayer(Guid id)
        {
            var player = _playerRepository.GetById(id);
            if (player == null)
                return NotFound();

            return Ok(player);
        }

        [HttpPost("players")]
        public IActionResult CreatePlayer([FromBody] PlayerBaseModel player)
        {
            //Ensure it does not use swagger default
            player.UniquePlayerGuid = Guid.NewGuid();
            //Ensure swagger does not ignore default value
            player.Handicap = 10;
            _playerRepository.Add(player);
            return CreatedAtAction(nameof(GetPlayer), player);
        }

        [HttpPost("players/edit/{id}")]
        public IActionResult EditPlayer(Guid id, [FromBody] PlayerBaseModel updatedPlayer)
        {
            // Fetch the player by ID
            var existingPlayer = _playerRepository.GetById(id);

            if (existingPlayer == null)
            {
                return NotFound();
            }

            // Update the player's name/intials
            existingPlayer.PlayerName = updatedPlayer.PlayerName;
            existingPlayer.PlayerInitials = updatedPlayer.PlayerInitials;

            //No cheating allowed
            existingPlayer.Handicap = existingPlayer.Handicap;

            // Update the player in the database
            _playerRepository.Update(existingPlayer);

            // Return the updated player
            return CreatedAtAction(nameof(GetPlayer), existingPlayer);
        }
        [HttpGet("players/search/{searchTerm}")]
        public IActionResult GetPlayer(string searchTerm)
        {
            var player = _playerRepository.GetBySearchTerm(searchTerm);
            if (player == null)
                return NotFound();

            return Ok(player);
        }

        #endregion

        #region Battles

        [HttpGet("battles/get")]
        public IEnumerable<BattleBaseModel> GetBattles()
        {
            return _battleRepository.GetAll();
        }

        [HttpGet("battles/get/{id}")]
        public IActionResult GetBattle(Guid id)
        {
            var battle = _battleRepository.GetById(id);
            if (battle == null)
                return NotFound();

            return Ok(battle);
        }

        [HttpPost("battles/create")]
        public IActionResult CreateBattle([FromBody] BattleBaseModel battle)
        {
            if ((battle.PlayerTwoGuid != battle.PlayerOneGuid) &&
             (battle.PlayerTwoGuid == battle.WinnerGuid || battle.PlayerOneGuid == battle.WinnerGuid))
            { 
                //Ensure it does not use swagger default
                battle.UniqueBattleGuid = Guid.NewGuid();
                _battleRepository.Add(battle);
                List<PlayerBaseModel> players = new List<PlayerBaseModel>();
                players.Add(_playerRepository.GetById(battle.PlayerOneGuid));
                players.Add(_playerRepository.GetById(battle.PlayerTwoGuid));
            
                foreach (var player in players)
                { 
                    if(player.UniquePlayerGuid == battle.WinnerGuid)
                    {
                        player.Handicap++;
                    }
                    else
                    {
                        player.Handicap--;
                    }
                }
                _playerRepository.UpdateMultiple(players);

                return CreatedAtAction(nameof(GetBattle), battle);
            }
            else { return BadRequest(); }
        }

        #endregion


    }
}
