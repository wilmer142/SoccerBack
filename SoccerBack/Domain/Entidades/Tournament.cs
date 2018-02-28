using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entidades
{
    public class Tournament
    {
        [Key]
        public int TournamentId { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        [MaxLength(50, ErrorMessage = "The maximum length for field {0} is {1} characters")]
        [Index("Tournament_Name_Index", IsUnique = true)]
        [Display(Name = "Tournament")]
        public string Name { get; set; }

        [DataType(DataType.ImageUrl)]
        public string Logo { get; set; }

        [Display(Name = "Is Active?")]
        public bool IsActive { get; set; }

        [Display(Name = "Order")]
        public int Order { get; set; }

        //Relacion con entidad TournamentGroup
        public virtual ICollection<TournamentGroup> Groups { get; set; }

        //Relacion con entidad Dates
        public virtual ICollection<Date> Dates { get; set; }
    }
}
