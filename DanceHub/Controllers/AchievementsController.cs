using DanceHub.Models;
using DanceHub.Models.DTOs;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace DanceHub.Controllers
{
    public class AchievementsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Achievements
        public IQueryable<Achievement> GetAchievements()
        {
            return db.Achievements;
        }

        // GET: api/Achievements/5
        [ResponseType(typeof(Achievement))]
        public async Task<IHttpActionResult> GetAchievement(int id)
        {
            Achievement achievement = await db.Achievements.FindAsync(id);
            if (achievement == null)
            {
                return NotFound();
            }

            return Ok(achievement);
        }

        // PUT: api/Achievements/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAchievement(int id, Achievement achievement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != achievement.AchievementId)
            {
                return BadRequest();
            }

            db.Entry(achievement).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AchievementExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Achievements
        [ResponseType(typeof(AchievementDTO))]
        public async Task<IHttpActionResult> PostAchievement(AchievementDTO achievement)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = AutoMapper.Mapper.Map<Achievement>(achievement);
                db.Achievements.Add(result);
                await db.SaveChangesAsync();

                int id = achievement.AchievementId;

                return CreatedAtRoute("DefaultApi", new { id = achievement.AchievementId }, id);
            }
            catch (Exception ex)
            {

                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, ex));
            }
        }

        // DELETE: api/Achievements/5
        [ResponseType(typeof(AchievementDTO))]
        public async Task<IHttpActionResult> DeleteAchievement(int id)
        {
            Achievement achievement = await db.Achievements.FindAsync(id);
            if (achievement == null)
            {
                return NotFound();
            }

            db.Achievements.Remove(achievement);
            await db.SaveChangesAsync();

            return Ok(achievement);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AchievementExists(int id)
        {
            return db.Achievements.Count(e => e.AchievementId == id) > 0;
        }
    }
}