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
    public class DanceTeamsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/DanceTeams
        [HttpGet]
        [ResponseType(typeof(DanceTeamDTO))]
        public async Task<IHttpActionResult> GetDanceTeams()
        {
            try
            {
                var result = AutoMapper.Mapper.Map<IList<DanceTeamDTO>>(await db.DanceTeams.ToListAsync());
                return Ok(result);
            }
            catch (Exception ex)
            {

                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));
            }
        }

        // GET: api/DanceTeams/5
        [HttpGet]
        [ResponseType(typeof(DanceTeam))]
        public async Task<IHttpActionResult> GetDanceTeam(int id)
        {
            try
            {
                DanceTeam danceTeam = await db.DanceTeams.FindAsync(id);
                var result = AutoMapper.Mapper.Map<DanceTeamDTO>(danceTeam);
                if (danceTeam == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {

                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));
            }
        }

        // PUT: api/DanceTeams/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDanceTeam(int id, DanceTeam danceTeam)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != danceTeam.TeamId)
            {
                return BadRequest();
            }

            db.Entry(danceTeam).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DanceTeamExists(id))
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

        // POST: api/DanceTeams
        [HttpPost]
        [ResponseType(typeof(DanceTeamDTO))]
        public async Task<IHttpActionResult> PostDanceTeam(DanceTeamDTO danceTeam)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = AutoMapper.Mapper.Map<DanceTeam>(danceTeam);

            db.DanceTeams.Add(result);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = danceTeam.TeamId }, danceTeam);
        }

        // DELETE: api/DanceTeams/5
        [HttpDelete]
        [ResponseType(typeof(DanceTeam))]
        public async Task<IHttpActionResult> DeleteDanceTeam(int id)
        {
            DanceTeam danceTeam = await db.DanceTeams.FindAsync(id);
            if (danceTeam == null)
            {
                return NotFound();
            }

            db.DanceTeams.Remove(danceTeam);
            await db.SaveChangesAsync();

            return Ok(danceTeam);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DanceTeamExists(int id)
        {
            return db.DanceTeams.Count(e => e.TeamId == id) > 0;
        }
    }
}