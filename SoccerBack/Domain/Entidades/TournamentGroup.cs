using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entidades
{
    public class TournamentGroup
    {
        [Key]
        public int TournamentGroupId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(50, ErrorMessage = "The maximum length for field {0} is {1} characters")]
        //INDICE COMPUESTO PARA EVITAR QUE EL NOMBRE DE UN EQUIPO SEA REPETIDO EN LA MISMA LIGA
        [Index("TournamentGroup_Name_TournamentId_Index", IsUnique = true, Order = 1)]
        [Display(Name = "Group")]
        public string Name { get; set; }

        [Index("TournamentGroup_Name_TournamentId_Index", IsUnique = true, Order = 2)]
        [Display(Name = "Tournament")]
        public int TournamentId { get; set; }

        //Relacion con entidad Tournament
        public virtual Tournament Tournament { get; set; }

        public virtual ICollection<TournamentTeam> TournamentTeams { get; set; }

        public virtual ICollection<Match> Matches { get; set; }
    }
}
