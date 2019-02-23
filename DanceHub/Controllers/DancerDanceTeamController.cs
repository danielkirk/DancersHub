using DanceHub.DataObjects.DTOs;
using DanceHub.Models;
using DanceHub.Models.DTOs;
using System;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace DanceHub.Controllers
{
    [RoutePrefix("dancerdanceteam")]
    public class DancerDanceTeamController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Route("{id}")]
        public async Task<IHttpActionResult> GetDanceTeamById(int id)
        {
            try
            {
                var danceTeam = await db.DanceTeams.FindAsync(id);
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

        [HttpPost]
        [Route("join", Name = "CreateDanceTeamJoin")]
        [ResponseType(typeof(DancerDanceTeamDTO))]
        public async Task<IHttpActionResult> CreateDanceTeamJoin(DancerDanceTeamDTO dancerDanceTeam)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState));
                }
                var danceTeamJoin = await db.Database.ExecuteSqlCommandAsync(
                       "Insert Into dbo.DancerDanceTeam " +
                       "( TeamId, DancerId )" +
                       "Values (@TeamId, @DancerId)", new SqlParameter("@TeamId", dancerDanceTeam.DanceTeamId), new SqlParameter("@DancerId", dancerDanceTeam.DancerId));

                return CreatedAtRoute("CreateDanceTeamJoin", new { dancerDanceTeam.DancerId, dancerDanceTeam.DanceTeamId }, dancerDanceTeam);
            }
            catch (Exception ex)
            {

                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));
            }

        }
    }
}
