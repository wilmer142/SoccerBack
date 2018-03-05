using Domain.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace Domain
{
    internal class UsersMap : EntityTypeConfiguration<User>
    {
        public UsersMap()
        {
            HasRequired(user => user.FavoriteTeam)
                .WithMany(team => team.Fans)
                .HasForeignKey(user => user.FavoriteTeamId);

        }
    }
}