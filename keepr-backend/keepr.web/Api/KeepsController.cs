using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Keepr.Data.Models;
using Keepr.Data.Services;

namespace keepr.web.Api
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class KeepsController : ApiController
    {
        private readonly KeeprDbContext db;

        public KeepsController(KeeprDbContext db)
        {
            this.db = db;
        }

        // GET: api/Keeps
        public IQueryable<Keep> GetKeeps()
        {
            return db.Keeps;
        }

        // GET: api/Keeps/5
        [ResponseType(typeof(Keep))]
        public async Task<IHttpActionResult> GetKeep(int id)
        {
            Keep keep = await db.Keeps.FindAsync(id);
            if (keep == null)
            {
                return NotFound();
            }

            return Ok(keep);
        }

        // PUT: api/Keeps/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutKeep(int id, Keep keep)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != keep.Id)
            {
                return BadRequest();
            }

            db.Entry(keep).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KeepExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            Keep new_keep = db.Keeps.Find(id);

            //return StatusCode(HttpStatusCode.NoContent);
            return Ok(new_keep);
        }

        // POST: api/Keeps
        [ResponseType(typeof(Keep))]
        public async Task<IHttpActionResult> PostKeep(Keep keep)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Keeps.Add(keep);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = keep.Id }, keep);
        }

        // DELETE: api/Keeps/5
        [ResponseType(typeof(Keep))]
        public async Task<IHttpActionResult> DeleteKeep(int id)
        {
            Keep keep = await db.Keeps.FindAsync(id);
            if (keep == null)
            {
                return NotFound();
            }

            db.Keeps.Remove(keep);
            await db.SaveChangesAsync();

            return Ok(keep);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KeepExists(int id)
        {
            return db.Keeps.Count(e => e.Id == id) > 0;
        }
    }
}