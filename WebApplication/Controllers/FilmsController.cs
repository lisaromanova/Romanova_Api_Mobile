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
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class FilmsController : ApiController
    {
        private FilmsEntities db = new FilmsEntities();

        [ResponseType(typeof(List<ModelFilms>))]
        // GET: api/Films
        public IHttpActionResult GetFilms()
        {
            return Ok(db.Films.ToList().ConvertAll(x=> new ModelFilms(x)));
        }

        // GET: api/Films/5
        [ResponseType(typeof(Films))]
        public IHttpActionResult GetFilms(int id)
        {
            Films films = db.Films.Find(id);
            if (films == null)
            {
                return NotFound();
            }

            return Ok(films);
        }

        // PUT: api/Films/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFilms(int id, Films films)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != films.IdFilm)
            {
                return BadRequest();
            }

            db.Entry(films).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmsExists(id))
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

        // POST: api/Films
        [ResponseType(typeof(Films))]
        public IHttpActionResult PostFilms(Films films)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Films.Add(films);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = films.IdFilm }, films);
        }

        // DELETE: api/Films/5
        [ResponseType(typeof(Films))]
        public IHttpActionResult DeleteFilms(int id)
        {
            Films films = db.Films.Find(id);
            if (films == null)
            {
                return NotFound();
            }

            db.Films.Remove(films);
            db.SaveChanges();

            return Ok(films);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FilmsExists(int id)
        {
            return db.Films.Count(e => e.IdFilm == id) > 0;
        }
    }
}