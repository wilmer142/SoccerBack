using Domain.Entidades;
using SoccerBackend.Helpers;
using SoccerBackend.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SoccerBackend.Controllers
{
    [Authorize]
    public class TournamentsController : Controller
    {
        private DataContextLocal db = new DataContextLocal();

        #region Tournament

        // GET: Tournaments
        public async Task<ActionResult> Index()
        {
            return View(await db.Tournaments.ToListAsync());
        }

        // GET: Tournaments/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tournament tournament = await db.Tournaments.FindAsync(id);
            if (tournament == null)
            {
                return HttpNotFound();
            }
            return View(tournament);
        }

        // GET: Tournaments/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TournamentView view)
        {
            if (ModelState.IsValid)
            {
                var pic = string.Empty;
                var folder = "~/Content/Logos";

                if (view.LogoFile != null)
                {
                    pic = FilesHelper.UploadPhoto(view.LogoFile, folder);
                    pic = string.Format("{0}/{1}", folder, pic);
                }

                var tournament = ToTournament(view);
                tournament.Logo = pic;
                db.Tournaments.Add(tournament);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(view);
        }

        private Tournament ToTournament(TournamentView view)
        {
            return new Tournament
            {
                Groups = view.Groups,
                Logo = view.Logo,
                Name = view.Name,
                IsActive = view.IsActive,
                Order = view.Order,
                TournamentId = view.TournamentId
            };
        }

        // GET: Tournaments/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var tournament = await db.Tournaments.FindAsync(id);
            if (tournament == null)
            {
                return HttpNotFound();
            }
            var view = ToView(tournament);
            return View(view);
        }

        private TournamentView ToView(Tournament tournament)
        {
            return new TournamentView
            {
                Groups = tournament.Groups,
                Logo = tournament.Logo,
                Name = tournament.Name,
                IsActive = tournament.IsActive,
                Order = tournament.Order,
                TournamentId = tournament.TournamentId
            };
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(TournamentView view)
        {
            if (ModelState.IsValid)
            {
                var pic = view.Logo;
                var folder = "~/Content/Logos";

                if (view.LogoFile != null)
                {
                    pic = FilesHelper.UploadPhoto(view.LogoFile, folder);
                    pic = string.Format("{0}/{1}", folder, pic);
                }

                var tournament = ToTournament(view);
                tournament.Logo = pic;

                db.Entry(tournament).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(view);
        }

        // GET: Tournaments/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tournament tournament = await db.Tournaments.FindAsync(id);
            if (tournament == null)
            {
                return HttpNotFound();
            }
            return View(tournament);
        }

        // POST: Tournaments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Tournament tournament = await db.Tournaments.FindAsync(id);
            db.Tournaments.Remove(tournament);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        #endregion

        #region TournamentGroup

        #region Group

        public async Task<ActionResult> DetailsGroup(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var tournamentGroup = await db.TournamentGroups.FindAsync(id);

            if (tournamentGroup == null)
            {
                return HttpNotFound();
            }

            return View(tournamentGroup);
        }

        public async Task<ActionResult> CreateGroup(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var tournament = await db.TournamentGroups.FindAsync(id);

            if (tournament == null)
            {
                return HttpNotFound();
            }

            var view = new TournamentGroup { TournamentId = tournament.TournamentId };
            return View(view);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateGroup(TournamentGroup tournamentGroup)
        {
            if (ModelState.IsValid)
            {
                db.TournamentGroups.Add(tournamentGroup);
                await db.SaveChangesAsync();
                //return RedirectToAction(string.Format("Details/#{0}", tournamentGroup.TournamentId));
                return RedirectToAction("Details", new { id = tournamentGroup.TournamentId });
            }

            return View(tournamentGroup);
        }

        public async Task<ActionResult> EditGroup(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TournamentGroup tournamentGroup = await db.TournamentGroups.FindAsync(id);
            if (tournamentGroup == null)
            {
                return HttpNotFound();
            }
            return View(tournamentGroup);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditGroup(TournamentGroup tournamentGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tournamentGroup).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Details", new { id = tournamentGroup.TournamentId });
            }
            return View(tournamentGroup);
        }

        // GET: TournamentGroups/Edit/5
        public async Task<ActionResult> DeleteGroup(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var tournamentGroup = await db.TournamentGroups.FindAsync(id);

            if (tournamentGroup == null)
            {
                return HttpNotFound();
            }

            db.TournamentGroups.Remove(tournamentGroup);
            await db.SaveChangesAsync();
            return RedirectToAction("Details", new { id = tournamentGroup.TournamentId });
        }

        #endregion

        #region TournamentTeam

        // GET: TournamentTeams/Create
        public async Task<ActionResult> CreateTeam(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var tournamentGroup = await db.TournamentGroups.FindAsync(id);
            if (tournamentGroup == null)
            {
                return HttpNotFound();
            }

            ViewBag.LeagueId = new SelectList(db.Leagues.OrderBy(league => league.Name), "LeagueId", "Name");
            ViewBag.TeamId = new SelectList(db.Teams.Where(team => team.LeagueId == db.Leagues.FirstOrDefault().LeagueId).OrderBy(team => team.Name) , "TeamId", "Name");
            var view = new TournamentTeamView { TournamentGroupId = tournamentGroup.TournamentGroupId };
            return View(view);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateTeam(TournamentTeamView view)
        {
            if (ModelState.IsValid)
            {
                var tournamentTeam = ToTournamentTeam(view);
                db.TournamentTeams.Add(tournamentTeam);
                await db.SaveChangesAsync();
                return RedirectToAction("DetailsGroup", new { id = tournamentTeam.TournamentGroupId });
            }
            ViewBag.LeagueId = new SelectList(db.Leagues.OrderBy(league => league.Name), "LeagueId", "Name", view.LeagueId);
            ViewBag.TeamId = new SelectList(db.Teams.Where(league => league.LeagueId == view.LeagueId).OrderBy(team => team.Name) , "TeamId", "Name", view.TeamId);
            return View(view);
        }

        // GET: TournamentTeams/Edit/5
        public async Task<ActionResult> EditTeam(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TournamentTeam tournamentTeam = await db.TournamentTeams.FindAsync(id);
            if (tournamentTeam == null)
            {
                return HttpNotFound();
            }

            ViewBag.LeagueId = new SelectList(db.Leagues.OrderBy(league => league.Name), "LeagueId", "Name", tournamentTeam.Team.LeagueId);
            ViewBag.TeamId = new SelectList(db.Teams.Where(team => team.LeagueId == tournamentTeam.Team.LeagueId).OrderBy(team => team.Name), "TeamId", "Name", tournamentTeam.Team.TeamId);
            var view = ToTournamentTeamView(tournamentTeam);
            return View(view);
        }

        private TournamentTeamView ToTournamentTeamView(TournamentTeam tournamentTeam)
        {
            return new TournamentTeamView
            {
                AgainstGoals = tournamentTeam.AgainstGoals,
                FavorGoals = tournamentTeam.FavorGoals,
                LeagueId = tournamentTeam.Team.LeagueId,
                MatchesLost = tournamentTeam.MatchesLost,
                MatchesPlayed = tournamentTeam.MatchesPlayed,
                MatchesTied = tournamentTeam.MatchesTied,
                MatchesWon = tournamentTeam.MatchesWon,
                Points = tournamentTeam.Points,
                Position = tournamentTeam.Position,
                Team = tournamentTeam.Team,
                TeamId = tournamentTeam.TeamId,
                TournamentGroup = tournamentTeam.TournamentGroup,
                TournamentGroupId = tournamentTeam.TournamentGroupId,
                TournamentTeamId = tournamentTeam.TournamentTeamId
            };
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditTeam(TournamentTeamView view)
        {
            if (ModelState.IsValid)
            {
                var tournamentTeam = ToTournamentTeam(view);
                db.Entry(tournamentTeam).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("DetailsGroup", new { id = view.TournamentGroupId });
            }

            ViewBag.LeagueId = new SelectList(db.Leagues.OrderBy(league => league.Name), "LeagueId", "Name", view.LeagueId);
            ViewBag.TeamId = new SelectList(db.Teams.Where(team => team.LeagueId == view.LeagueId).OrderBy(team => team.Name), "TeamId", "Name", view.TeamId);
            return View(view);
        }

        private TournamentTeam ToTournamentTeam(TournamentTeamView view)
        {
            return new TournamentTeam
            {
                AgainstGoals = view.AgainstGoals,
                FavorGoals = view.FavorGoals,
                MatchesLost = view.MatchesLost,
                MatchesPlayed = view.MatchesPlayed,
                MatchesTied = view.MatchesTied,
                MatchesWon = view.MatchesWon,
                Points = view.Points,
                Position = view.Position,
                Team = view.Team,
                TeamId = view.TeamId,
                TournamentGroup = view.TournamentGroup,
                TournamentGroupId = view.TournamentGroupId,
                TournamentTeamId = view.TournamentTeamId
            };
        }

        public async Task<ActionResult> DeleteTeam(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TournamentTeam tournamentTeam = await db.TournamentTeams.FindAsync(id);
            if (tournamentTeam == null)
            {
                return HttpNotFound();
            }
            db.TournamentTeams.Remove(tournamentTeam);
            await db.SaveChangesAsync();
            return RedirectToAction("DetailsGroup", new { id = tournamentTeam.TournamentGroupId });
        }

        #endregion

        #endregion

        #region Date

        public async Task<ActionResult> CreateDate(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var tournament = await db.Tournaments.FindAsync(id);
            if (tournament == null)
            {
                return HttpNotFound();
            }

            var date = new Date { TournamentId = tournament.TournamentId };
            return View(date);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateDate(Date date)
        {
            if (ModelState.IsValid)
            {
                db.Dates.Add(date);
                await db.SaveChangesAsync();
                return RedirectToAction("Details", new { id = date.TournamentId});
            }

            return View(date);
        }

        // GET: Dates/Edit/5
        public async Task<ActionResult> EditDate(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var date = await db.Dates.FindAsync(id);
            if (date == null)
            {
                return HttpNotFound();
            }

            return View(date);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditDate(Date date)
        {
            if (ModelState.IsValid)
            {
                db.Entry(date).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Details", new { id = date.TournamentId });
            }
            return View(date);
        }

        public async Task<ActionResult> DeleteDate(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var date = await db.Dates.FindAsync(id);
            if (date == null)
            {
                return HttpNotFound();
            }

            db.Dates.Remove(date);
            await db.SaveChangesAsync();
            return RedirectToAction("Details", new { id = date.TournamentId });
        }

        #endregion

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
