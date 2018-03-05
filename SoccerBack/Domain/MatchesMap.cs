using Domain.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace Domain
{
    internal class MatchesMap : EntityTypeConfiguration<Match>
    {
        public MatchesMap()
        {
            HasRequired(match => match.Local)
                .WithMany(team => team.Locals)
                .HasForeignKey(match => match.LocalId);

            HasRequired(match => match.Visitor)
                .WithMany(team => team.Visitors)
                .HasForeignKey(match => match.VisitorId);
        }
    }
}