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
using APICandyCrush.Models;
using System.Web.Http.Cors;

namespace APICandyCrush.Controllers
{
    public class PartidasController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Partidas
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IQueryable<Partida> GetGames()
        {
            return db.Games;
        }

        // GET: api/Partidas/5
        [ResponseType(typeof(Partida))]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult GetPartida(int id)
        {

            Partida partida = db.Games.Find(id);
            if (partida == null)
            {
                return NotFound();
            }

            return Ok(partida);
        }

        // PUT: api/Partidas/5
        [ResponseType(typeof(void))]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult PutPartida(int id, Partida partida)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != partida.id)
            {
                return BadRequest();
            }

            db.Entry(partida).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartidaExists(id))
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

        // POST: api/Partidas
        [ResponseType(typeof(Partida))]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult PostPartida(Partida partida)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Games.Add(partida);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = partida.id }, partida);
        }

        // DELETE: api/Partidas/5
        [ResponseType(typeof(Partida))]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult DeletePartida(int id)
        {
            Partida partida = db.Games.Find(id);
            if (partida == null)
            {
                return NotFound();
            }

            db.Games.Remove(partida);
            db.SaveChanges();

            return Ok(partida);
        }
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        private bool PartidaExists(int id)
        {
            return db.Games.Count(e => e.id == id) > 0;
        }
    }
}