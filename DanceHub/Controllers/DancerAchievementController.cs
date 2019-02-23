using DanceHub.DataObjects.DTOs;
using DanceHub.Models;
using System;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace DanceHub.Controllers
{
    [RoutePrefix("dancerachievements")]
    public class DancerAchievementController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpPost]
        [Route("join", Name = "CreateDancerAchievementsJoin")]
        [ResponseType(typeof(DancerAchievementsDTO))]
        public async Task<IHttpActionResult> CreateDanceTeamJoin(DancerAchievementsDTO dancerAchievements)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState));
                }
                var danceTeamJoin = await db.Database.ExecuteSqlCommandAsync(
                       "Insert Into dbo.DancerAchievements" +
                       "( AchievementId, DancerId )" +
                       "Values (@AchievementId, @DancerId)", new SqlParameter("@AchievementId", dancerAchievements.AchievementId), new SqlParameter("@DancerId", dancerAchievements.DancerId));

                return CreatedAtRoute("CreateDancerAchievementsJoin", new { dancerAchievements.AchievementId, dancerAchievements.DancerId }, dancerAchievements);
            }
            catch (Exception ex)
            {

                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));
            }

        }
    }
}
