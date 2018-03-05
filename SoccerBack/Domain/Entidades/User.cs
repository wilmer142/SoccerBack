﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(50, ErrorMessage = "The maximun length for field {0} is {1} characters")]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(50, ErrorMessage = "The maximun length for field {0} is {1} characters")]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Display(Name = "User type")]
        public int UserTypeId { get; set; }

        [DataType(DataType.ImageUrl)]
        public string Picture { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(100, ErrorMessage = "The maximun length for field {0} is {1} characters")]
        [DataType(DataType.EmailAddress)]
        [Index("User_Email_Index", IsUnique = true)]
        public string Email { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(20, ErrorMessage = "The maximun length for field {0} is {1} characters")]
        [Index("User_NickName_Index", IsUnique = true)]
        [Display(Name = "Nick name")]
        public string NickName { get; set; }

        [Display(Name = "Favorite team")]
        public int FavoriteTeamId { get; set; }

        public int Points { get; set; }

        public virtual Team FavoriteTeam { get; set; }

        public virtual UserType UserType { get; set; }

        //public virtual ICollection<Group> UserGroups { get; set; }

        //public virtual ICollection<GroupUser> GroupUsers { get; set; }

        //public virtual ICollection<Prediction> Predictions { get; set; }
    }

}
