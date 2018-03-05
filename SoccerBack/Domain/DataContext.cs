using Domain.Entidades;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Domain
{
    public class DataContext : DbContext
    {
        public DataContext()
            :base("DefaultConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //MAPEANDO RELACIONES ESPECIALES
            modelBuilder.Configurations.Add(new UsersMap());
            modelBuilder.Configurations.Add(new MatchesMap());

        }

        public DbSet<League> Leagues { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Tournament> Tournaments { get; set; }

        public DbSet<TournamentGroup> TournamentGroups { get; set; }

        public DbSet<Date> Dates { get; set; }

        public DbSet<TournamentTeam> TournamentTeams { get; set; }

        public DbSet<UserType> UserTypes { get; set; }
    }
}
