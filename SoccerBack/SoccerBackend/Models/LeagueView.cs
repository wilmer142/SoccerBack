using Domain.Entidades;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace SoccerBackend.Models
{
    [NotMapped]
    public class LeagueView : League
    {
        [Display(Name = "Logo")]
        public HttpPostedFileBase LogoFile { get; set; }
    }
}