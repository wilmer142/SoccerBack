﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entidades
{
    public class Match
    {
        [Key]
        public int MatchId { get; set; }

        [Display(Name = "Date")]
        public int DateId { get; set; }

        [Display(Name = "Date time")]
        [DataType(DataType.DateTime)]
        public DateTime DateTime { get; set; }

        [Display(Name = "Local")]
        public int LocalId { get; set; }

        [Display(Name = "Visitor")]
        public int VisitorId { get; set; }

        [Display(Name = "Local goals")]
        public int? LocalGoals { get; set; }

        [Display(Name = "Visitor goals")]
        public int? VisitorGoals { get; set; }

        [Display(Name = "Status")]
        public int StatusId { get; set; }

        [Display(Name = "Group")]
        public int TournamentGroupId { get; set; }

        public virtual Date Date { get; set; }

        public virtual Team Local { get; set; }

        public virtual Team Visitor { get; set; }

        public virtual Status Status { get; set; }

        public virtual TournamentGroup TournamentGroup { get; set; }

        //public virtual ICollection<Prediction> Predictions { get; set; }
    }

}
