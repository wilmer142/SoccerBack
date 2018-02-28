using Domain.Entidades;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoccerBackend.Models
{
    [NotMapped]
    public class TournamentTeamView : TournamentTeam
    {
        [Display(Name = "League")]
        public int LeagueId { get; set; }
    }
}