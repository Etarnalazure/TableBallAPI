using System.ComponentModel.DataAnnotations.Schema;
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
        public Guid PlayerOneGuid{ get; set; }
        //Player Two in the team battle, uses the unique guid key in PlayerBaseModel
        public Guid PlayerTwoGuid{ get; set; }
        //Winner of the battle
        public Guid WinnerGuid { get; set; }
        //When the battle occured
        public DateTime BattleDate { get; set; } = DateTime.Now;

        public bool isDone { get; set; }
    }
}
