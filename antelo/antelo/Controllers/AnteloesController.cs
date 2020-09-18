using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using antelo.Models;

namespace antelo.Controllers
{
    public class AnteloesController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Anteloes
        [Authorize]
        public IQueryable<Antelo> GetAnteloes()
        {
            return db.Anteloes;
        }

        // GET: api/Anteloes/5
        [Authorize]
        [ResponseType(typeof(Antelo))]
        public IHttpActionResult GetAntelo(int id)
        {
            Antelo antelo = db.Anteloes.Find(id);
            if (antelo == null)
            {
                return NotFound();
            }

            return Ok(antelo);
        }

        // PUT: api/Anteloes/5
        [Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAntelo(int id, Antelo antelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != antelo.anteloID)
            {
                return BadRequest();
            }

            db.Entry(antelo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnteloExists(id))
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

        // POST: api/Anteloes
        [Authorize]
        [ResponseType(typeof(Antelo))]
        public IHttpActionResult PostAntelo(Antelo antelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Anteloes.Add(antelo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = antelo.anteloID }, antelo);
        }

        // DELETE: api/Anteloes/5
        [Authorize]
        [ResponseType(typeof(Antelo))]
        public IHttpActionResult DeleteAntelo(int id)
        {
            Antelo antelo = db.Anteloes.Find(id);
            if (antelo == null)
            {
                return NotFound();
            }

            db.Anteloes.Remove(antelo);
            db.SaveChanges();

            return Ok(antelo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AnteloExists(int id)
        {
            return db.Anteloes.Count(e => e.anteloID == id) > 0;
        }
    }
}