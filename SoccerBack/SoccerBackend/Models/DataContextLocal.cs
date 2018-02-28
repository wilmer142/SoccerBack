using Domain;

namespace SoccerBackend.Models
{
    public class DataContextLocal : DataContext
    {
        public System.Data.Entity.DbSet<Domain.Entidades.Date> Dates { get; set; }

        public System.Data.Entity.DbSet<Domain.Entidades.TournamentTeam> TournamentTeams { get; set; }
    }
}