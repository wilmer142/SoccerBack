﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entidades
{
    public class Date
    {
        [Key]
        public int DateId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(50, ErrorMessage = "The maximun length for field {0} is {1} characters")]
        [Index("Date_Name_TournamentId_Index", IsUnique = true, Order = 1)]
        [Display(Name = "Date")]
        public string Name { get; set; }

        [Display(Name = "Tournament")]
        [Index("Date_Name_TournamentId_Index", IsUnique = true, Order = 2)]
        public int TournamentId { get; set; }

        public virtual Tournament Tournament { get; set; }

    }
}
