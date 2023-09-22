using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TableBallAPI.Models
{
    public class PlayerBaseModel
    {
        //A unique GUID to be used as a foreign key
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UniquePlayerGuid { get; set; }
        //Player's real life name
        public string PlayerName { get; set; }
        //Players gamer name
        public string PlayerInitials { get; set; }
        //The players score
        public int Handicap { get; set; } = 10;
    }
}
