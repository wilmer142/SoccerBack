﻿using SoccerBackend.Models;
using System.Linq;
using System.Web.Mvc;

namespace SoccerBackend.Controllers
{
    public class GenericController : Controller
    {
        private DataContextLocal db = new DataContextLocal();

        public JsonResult GetTeams(int leagueId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var teams = db.Teams.Where(team => team.LeagueId == leagueId).OrderBy(team => team.Name);
            return Json(teams);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}