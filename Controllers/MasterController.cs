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
        private readonly IRepository<TeamBaseModel> _teamRepository;
        public MasterController(IRepository<PlayerBaseModel> playerRepository, IRepository<BattleBaseModel> battleRepository, IRepository<TeamBaseModel> teamRepository)
        {
            _playerRepository = playerRepository;
            _battleRepository = battleRepository;
            _teamRepository = teamRepository;
        }

        #region Player

        [HttpGet("players/GetPlayers")]
        public IEnumerable<PlayerBaseModel> GetPlayers()
        {
            return _playerRepository.GetAll();
        }
        [HttpGet("players/OrderBy/{descendingOrder}")]
        public IEnumerable<PlayerBaseModel> GetPlayers(bool descendingOrder)
        {
            if (descendingOrder) 
            {
                return _playerRepository.GetAll().OrderBy(o => o.Handicap);
            }
            else 
            { 
                return _playerRepository.GetAll().OrderByDescending(o => o.Handicap);
            }
        }

        [HttpGet("players/{id}")]
        public IActionResult GetPlayer(Guid id)
        {
            var player = _playerRepository.GetById(id);
            if (player == null)
                return NotFound();

            return Ok(player);
        }

        [HttpDelete("players/Delete/{id}")]
        public IActionResult DeletePlayer(Guid id)
        {
            var player = _playerRepository.GetById(id);
            if (player == null)
                return NotFound();
            _playerRepository.Delete(id);
            return Ok(player);
        }

        [HttpPost("players/CreatePlayer")]
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

        [HttpGet("players/Search/{searchTerm}")]
        public IActionResult GetPlayer(string searchTerm)
        {
            var player = _playerRepository.GetBySearchTerm(searchTerm);
            if (player == null)
                return NotFound();

            return Ok(player);
        }

        #endregion


        #region Teams
        [HttpGet("teams/GetTeams")]
        public IEnumerable<TeamBaseModel> GetTeams()
        {
            return _teamRepository.GetAll();
        }

        [HttpPost("teams/CreateTeam")]
        public IActionResult CreateTeam([FromBody] TeamBaseModel team)
        {
          
            if(team.PlayerOne != team.PlayerTwo) { 
                // Check if TeamTwoGuid exists in either TeamOneGuid or TeamTwoGuid
                if (_teamRepository.GetAll().Any(existingTeam =>
                    existingTeam.PlayerOne == team.PlayerTwo || existingTeam.PlayerTwo == team.PlayerTwo))
                {
                    return BadRequest("A team with TeamTwoGuid already exists.");
                }

                // Check if TeamOneGuid exists in either TeamOneGuid or TeamTwoGuid
                if (_teamRepository.GetAll().Any(existingTeam =>
                    existingTeam.PlayerOne == team.PlayerOne || existingTeam.PlayerTwo == team.PlayerOne))
                {
                    return BadRequest("A team with TeamOneGuid already exists.");
                }
                //Ensure it does not use swagger default
                team.UniqueTeamGuid = Guid.NewGuid();
            
                _teamRepository.Add(team);
                return CreatedAtAction(nameof(GetTeams), team);
            }
            return BadRequest();
        }
        #endregion


        #region Battles

        [HttpGet("battles/Get")]
        public IEnumerable<BattleBaseModel> GetBattles()
        {
            return _battleRepository.GetAll();
        }

        [HttpGet("battles/GetById/{id}")]
        public IActionResult GetBattle(Guid id)
        {
            var battle = _battleRepository.GetById(id);
            if (battle == null)
                return NotFound();

            return Ok(battle);
        }

        [HttpPost("battles/CreateBattle")]
        public IActionResult CreateBattle([FromBody] BattleBaseModel battle)
        {
            if ((battle.TeamTwoGuid != battle.TeamOneGuid) &&
             (battle.TeamTwoGuid == battle.WinnerGuid || battle.TeamOneGuid == battle.WinnerGuid))
            { 
                //Ensure it does not use swagger default
                battle.UniqueBattleGuid = Guid.NewGuid();

                _battleRepository.Add(battle);
                List<TeamBaseModel> teams = new List<TeamBaseModel>
                {
                    _teamRepository.GetById(battle.TeamOneGuid),
                    _teamRepository.GetById(battle.TeamTwoGuid)
                };

                List<PlayerBaseModel> players = new List<PlayerBaseModel>();

                foreach (var team in teams)
                {
                    var playerOne = _playerRepository.GetById(team.PlayerOne);
                    var playerTwo = _playerRepository.GetById(team.PlayerTwo);

                    if (team.UniqueTeamGuid == battle.WinnerGuid)
                    {
                        playerOne.Handicap++;
                        playerTwo.Handicap++;
                    }
                    else
                    {
                        playerOne.Handicap--;
                        playerTwo.Handicap--;
                    }

                    players.Add(playerOne);
                    players.Add(playerTwo);
                }
                _playerRepository.UpdateMultiple(players);

                return CreatedAtAction(nameof(GetBattle), battle);
            }
            else { return BadRequest(); }
        }

        #endregion


    }
}
