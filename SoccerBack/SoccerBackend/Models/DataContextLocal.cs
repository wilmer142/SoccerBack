using Domain;

namespace SoccerBackend.Models
{
    public class DataContextLocal : DataContext
    {
        public System.Data.Entity.DbSet<Domain.Entidades.User> Users { get; set; }

        public System.Data.Entity.DbSet<Domain.Entidades.Status> Status { get; set; }

        public System.Data.Entity.DbSet<Domain.Entidades.Match> Matches { get; set; }
    }
}