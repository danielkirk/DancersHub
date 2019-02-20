﻿using DanceHub.Models;
using DanceHub.Models.DTOs;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
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

        // GET: api/Dancers/5
        [ResponseType(typeof(DancerDTO))]
        public async Task<IHttpActionResult> GetDancer(int id)
        {
            Dancer dancer = await db.Dancers.FindAsync(id);
            if (dancer == null)
            {
                return NotFound();
            }

            return Ok(dancer);
        }

        // PUT: api/Dancers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDancer(int id, Dancer dancer)
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

        // POST: api/Dancers
        [HttpPost]
        [ResponseType(typeof(DancerDTO))]
        public async Task<IHttpActionResult> PostDancer([FromBody] DancerDTO dancer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = AutoMapper.Mapper.Map<Dancer>(dancer);
            db.Dancers.Add(result);

            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = dancer.DancerId }, dancer);
        }

        // DELETE: api/Dancers/5
        [ResponseType(typeof(Dancer))]
        public async Task<IHttpActionResult> DeleteDancer(int id)
        {
            Dancer dancer = await db.Dancers.FindAsync(id);
            if (dancer == null)
            {
                return NotFound();
            }

            db.Dancers.Remove(dancer);
            await db.SaveChangesAsync();

            return Ok(dancer);
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