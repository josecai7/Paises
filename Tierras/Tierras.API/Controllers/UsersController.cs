using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Tierras.API.Helpers;
using Tierras.API.Models;
using Tierras.Domain;

namespace Tierras.API.Controllers
{
    [RoutePrefix("api/Users")]
    public class UsersController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Users
        public IQueryable<User> GetUsers()
        {
            return db.Users;
        }
        
        [HttpPost]
        [Route("GetUserByEmail")]
        public async Task<IHttpActionResult> GetUserByEmail(JObject pEmail)
        {
            var email = string.Empty;
            dynamic jsonObject = pEmail;
                try
                {
                    email = jsonObject.Email.Value;
                }
                catch
                {
                    return BadRequest( "Llamado incorrecto" );
                }


            User user = await db.Users.Where( item => item.Email.ToLower() == email.ToLower() ).FirstOrDefaultAsync();
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUser(int id, UserRequest user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.UserId)
            {
                return BadRequest();
            }

            db.Entry(user).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> PostUser(UserRequest userView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }            

            if ( userView.ImageArray != null && userView.ImageArray.Length > 0 )
            {
                var stream = new MemoryStream( userView.ImageArray );
                var guid = Guid.NewGuid().ToString();
                var file = string.Format("{0}.jpg",guid);
                var folder = "~/Content/Images";
                var fullPath = String.Format( "{0}/{1}", folder, file );
                var response = FilesHelper.UploadPhoto( stream, folder, file );
                if ( response )
                {
                    userView.ImagePath = fullPath;
                }
            }

            var user = userView.ToUser();
            db.Users.Add( user );
            await db.SaveChangesAsync();

            UsersHelper.CreateUserASP( userView.Email, "User", userView.Password );

            return CreatedAtRoute("DefaultApi", new { id = user.UserId }, user);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> DeleteUser(int id)
        {
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            db.Users.Remove(user);
            await db.SaveChangesAsync();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.UserId == id) > 0;
        }
    }
}