using Domain.Entidades;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace SoccerBackend.Models
{
    [NotMapped]
    public class TournamentView : Tournament
    {
        [Display(Name = "Logo")]
        public HttpPostedFileBase LogoFile { get; set; }
    }
}