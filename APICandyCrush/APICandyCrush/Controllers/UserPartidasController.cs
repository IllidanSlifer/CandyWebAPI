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

namespace APICandyCrush.Controllers
{
    public class UserPartidasController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/UserPartidas
        public IQueryable<UserPartida> GetUserPartidas()
        {
            return db.UserPartidas;
        }

        // GET: api/UserPartidas/5
        [ResponseType(typeof(UserPartida))]
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
        public IHttpActionResult PostUserPartida(UserPartida userPartida)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserPartidas.Add(userPartida);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = userPartida.ID }, userPartida);
        }

        // DELETE: api/UserPartidas/5
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserPartidaExists(int id)
        {
            return db.UserPartidas.Count(e => e.ID == id) > 0;
        }
    }
}