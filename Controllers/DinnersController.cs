using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using halvatta.API.Models;

namespace halvatta.API.Controllers
{
    public class DinnersController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Dinners
        public IQueryable<Dinner> GetDinners()
        {
            return db.Dinners;
        }

        // GET: api/Dinners/5
        [ResponseType(typeof(Dinner))]
        public async Task<IHttpActionResult> GetDinner(int id)
        {
            Dinner dinner = await db.Dinners.FindAsync(id);
            if (dinner == null)
            {
                return NotFound();
            }

            return Ok(dinner);
        }

        // PUT: api/Dinners/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDinner(int id, Dinner dinner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dinner.Id)
            {
                return BadRequest();
            }

            db.Entry(dinner).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DinnerExists(id))
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

        // POST: api/Dinners
        [ResponseType(typeof(Dinner))]
        public async Task<IHttpActionResult> PostDinner(Dinner dinner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Dinners.Add(dinner);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = dinner.Id }, dinner);
        }

        // DELETE: api/Dinners/5
        [ResponseType(typeof(Dinner))]
        public async Task<IHttpActionResult> DeleteDinner(int id)
        {
            Dinner dinner = await db.Dinners.FindAsync(id);
            if (dinner == null)
            {
                return NotFound();
            }

            db.Dinners.Remove(dinner);
            await db.SaveChangesAsync();

            return Ok(dinner);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DinnerExists(int id)
        {
            return db.Dinners.Count(e => e.Id == id) > 0;
        }
    }
}