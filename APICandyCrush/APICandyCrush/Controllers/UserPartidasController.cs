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
    public class UserPartidasController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/UserPartidas
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IQueryable<UserPartida> GetUserPartidas()
        {
            return db.UserPartidas;
        }

        // GET: api/UserPartidas/5
        [ResponseType(typeof(UserPartida))]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult GetUserPartida(int id)
        {
            UserPartida userPartida = db.UserPartidas.Find(id);
            if (userPartida == null)
            {
                return NotFound();
            }

            return Ok(userPartida);
        }

        // PUT: api/UserPartidas/5
        [ResponseType(typeof(void))]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult PutUserPartida(int id, UserPartida userPartida)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userPartida.ID)
            {
                return BadRequest();
            }

            db.Entry(userPartida).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserPartidaExists(id))
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

        // POST: api/UserPartidas
        [ResponseType(typeof(UserPartida))]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult PostUserPartida(UserPartida userPartida)
        {
            userPartida.Partida = db.Games.Find(userPartida.PartidaID);
            userPartida.User = db.Users.Find(userPartida.UserID);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserPartidas.Add(userPartida);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = userPartida.ID }, userPartida);
        }

        // DELETE: api/UserPartidas/5
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [ResponseType(typeof(UserPartida))]
        public IHttpActionResult DeleteUserPartida(int id)
        {
            UserPartida userPartida = db.UserPartidas.Find(id);
            if (userPartida == null)
            {
                return NotFound();
            }

            db.UserPartidas.Remove(userPartida);
            db.SaveChanges();

            return Ok(userPartida);
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
        private bool UserPartidaExists(int id)
        {
            return db.UserPartidas.Count(e => e.ID == id) > 0;
        }
    }
}