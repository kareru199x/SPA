using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using SPA.Helpers;
using SPA.Models;

/**
 API Class for the CRUD end points
*/
namespace SPA.Controllers
{
    public class CustomerAPIController : ApiController
    {
        private SimpleDatabaseEntities db = new SimpleDatabaseEntities();

        // GET: api/CustomerAPI
        public IQueryable<Customer> GetCustomers()
        {
            return db.Customers.OrderBy(x => x.LastName);
        }

        // GET: api/CustomerAPI/5
        [ResponseType(typeof(Customer))]
        public IHttpActionResult GetCustomer(int id)
        {
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // PUT: api/CustomerAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customer.Id)
            {
                return BadRequest();
            }

            db.Entry(customer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
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

        // POST: api/CustomerAPI
        [ResponseType(typeof(Customer))]
        public IHttpActionResult PostCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(CustomerExists(customer))
            {
                return BadRequest("Customer already exists!");
            }

            customer.CustomerCode = CustomerHelper.GenerateCustomerCode(customer);

            db.Customers.Add(customer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = customer.Id }, customer);
        }

        // DELETE: api/CustomerAPI/5
        [ResponseType(typeof(Customer))]
        public IHttpActionResult DeleteCustomer(int id)
        {
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }

            db.Customers.Remove(customer);
            db.SaveChanges();

            return Ok(customer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerExists(int id)
        {
            return db.Customers.Count(e => e.Id == id) > 0;
        }

        private bool CustomerExists(Customer customer)
        {
            //Set time of birthdate to 12 am for comparison -- better to user moment.js in the front end
            var birthdate = customer.BirthDate.AddHours(8);

            var ifExists = db.Customers.Any(x => x.FirstName.ToLower().Equals(customer.FirstName.ToLower())
                && x.LastName.ToLower().Equals(customer.LastName.ToLower())
                && DbFunctions.TruncateTime(x.BirthDate) == birthdate);

            return ifExists;
        }
    }
}