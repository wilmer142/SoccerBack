﻿using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SoccerBackend.Models
{
    [NotMapped]
    public class MatchView : Match
    {
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public string DateString { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "Time")]
        public string TimeString { get; set; }

        [Display(Name = "Local League")]
        public int LocalLeagueId { get; set; }

        [Display(Name = "Visitor League")]
        public int VisitorLeagueId { get; set; }
    }
}