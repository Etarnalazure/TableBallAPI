using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TableBallAPI.Models
{
    public class TeamBaseModel
    {
        //Unique ID to avoid duplicates overwriting each other
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UniqueTeamGuid { get; set; }
        public Guid PlayerOne { get; set; }
        public Guid PlayerTwo { get; set; }
        public string TeamName { get; set; }
    }
}
