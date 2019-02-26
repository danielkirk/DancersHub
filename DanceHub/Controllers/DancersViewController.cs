using DanceHub.Models;
using DanceHub.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DanceHub.Controllers
{
    public class DancersViewController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DancersView
        public async Task<ActionResult> Dancer()
        {
            var dancer = AutoMapper.Mapper.Map<IList<DancerDTO>>(await db.Dancers.ToListAsync());

            return View(dancer);
        }

        public ActionResult Index(int? PageIndex, string SortBy)
        {
            if (!PageIndex.HasValue)
            {
                PageIndex = 1;
            }
            if (String.IsNullOrWhiteSpace(SortBy))
                SortBy = "Name";

            return Content(String.Format("Page Index = {0}, Sort By = {1}", PageIndex, SortBy));
        }

        [Route("DancersView/DanceExperience/{danceExperience}")]
        public ActionResult ByDanceExperience(int danceExperience)
        {
            return Content(danceExperience.ToString());
        }
    }
}