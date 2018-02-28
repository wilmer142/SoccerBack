using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entidades
{
    public class League
    {
        [Key]
        public int LeagueId { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        [MaxLength(50, ErrorMessage = "The maximum length for field {0} is {1} characters")]
        [Index("League_Name_Index", IsUnique = true)]
        [Display(Name = "League")]
        public string Name { get; set; }

        [DataType(DataType.ImageUrl)]
        public string Logo { get; set; }

        //Relacion con entidad Team
        public virtual ICollection<Team> Teams { get; set; }
    }
}
