﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TableBallAPI.Models
{
    public class BattleBaseModel
    {
        //Unique ID to avoid duplicates overwriting each other
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UniqueBattleGuid { get; set; }
        //Player One in the team battle, uses the unique guid key in PlayerBaseModel
        public Guid TeamOneGuid{ get; set; }
        //Player Two in the team battle, uses the unique guid key in PlayerBaseModel
        public Guid TeamTwoGuid{ get; set; }
        //Winner of the battle
        public Guid WinnerGuid { get; set; }
        //When the battle occured
        public DateTime BattleDate { get; set; } = DateTime.Now;
        //For future use, incase battles can be set in the future
        public bool isDone { get; set; }
    }
}
