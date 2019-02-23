using DanceHub.Models;
using DanceHub.Models.DTOs;
using System;
using System.Collections.Generic;
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
    public class DancersController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Dancers
        [HttpGet]
        [ResponseType(typeof(DancerDTO))]
        public async Task<IHttpActionResult> GetAll()
        {
            var dancerList = AutoMapper.Mapper.Map<IList<DancerDTO>>(await db.Dancers.ToListAsync());
            if (dancerList == null)
            {
                return NotFound();
            }


            return Ok(dancerList);

        }

        [HttpGet]
        [ResponseType(typeof(DancerDTO))]
        public async Task<IHttpActionResult> GetDancer(int id)
        {
            try
            {

                var result = db.Dancers.Where(d => d.DancerId == id).Include("DanceTeams").Include("Achievements").Select(d => new DancerDTO()
                {
                    DancerId = d.DancerId,
                    Name = d.Name,
                    DanceExperience = d.DanceExperience,
                    DanceTeams = d.DanceTeams.Select(dt => new DanceTeamDTO()
                    {
                        TeamId = dt.TeamId,
                        TeamName = dt.TeamName,
                        DirectorName = dt.DirectorName,
                        YearCreated = dt.YearCreated
                    }).ToList(),
                    Achievements = d.Achievements.Select(a => new AchievementDTO()
                    {
                        AchievementId = a.AchievementId,
                        AchievementName = a.AchievementName,
                        YearsWon = a.YearsWon
                    }).ToList()
                });

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(await result.ToListAsync());
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));
            }
        }

        [HttpPut]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDancer(int id, DancerDTO dancer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dancer.DancerId)
            {
                return BadRequest();
            }

            db.Entry(dancer).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DancerExists(id))
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

        [HttpPost]
        [ResponseType(typeof(DancerDTO))]
        public async Task<IHttpActionResult> PostDancer(DancerDTO dancer)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState));
                }
                var user = db.Users.First(x => x.Id == dancer.UserId);
                var hope = new DancerDTO
                {
                    Name = dancer.Name,
                    DanceExperience = dancer.DanceExperience,
                    User = user,
                };
                var result = AutoMapper.Mapper.Map<Dancer>(hope);


                db.Dancers.Add(result);

                await db.SaveChangesAsync();

                return CreatedAtRoute("DefaultApi", new { id = dancer.DancerId }, dancer);
            }
            catch (Exception ex)
            {

                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));
            }
        }

        [ResponseType(typeof(Dancer))]
        public async Task<IHttpActionResult> DeleteDancer(int id)
        {
            try
            {
                Dancer dancer = await db.Dancers.FindAsync(id);
                if (dancer == null)
                {
                    return NotFound();
                }

                db.Dancers.Remove(dancer);
                await db.SaveChangesAsync();

                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, id));
            }
            catch (Exception ex)
            {

                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DancerExists(int id)
        {
            return db.Dancers.Count(e => e.DancerId == id) > 0;
        }
    }
}