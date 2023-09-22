using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TableBallAPI.Models
{
    public class TeamBaseModel
    {
        //Unique ID used as a foreign key as well as to avoid dublicates overwriting each other
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UniqueTeamGuid { get; set; }
        //Name of the team. Go [Insert sports team name]!
        public string TeamName { get; set; }
        //Incase a logo is needed
        public string TeamLogo { get; set; }
        //Total team score
        public int TeamScore { get; set; }=0;
    }
}
