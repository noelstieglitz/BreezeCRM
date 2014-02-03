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
using System.Web.Http.Description;
using Breeze.ContextProvider.EF6;
using Breeze.WebApi2;
using BreezeCRM.Models;

namespace BreezeCRM.Controllers
{
    [BreezeController]
    public class CustomerController : ApiController
    {
        readonly EFContextProvider<CrmContext> _contextProvider = new EFContextProvider<CrmContext>();

        [HttpGet]
        public string Metadata()
        {
            return _contextProvider.Metadata();
        }

        [HttpGet]
        public IQueryable<Customer> Customers()
        {
            return _contextProvider.Context.Customers.Include(x=> x.Orders);
        }

        [ResponseType(typeof(Customer))]
        [HttpGet]
        public async Task<IHttpActionResult> Customers(int id)
        {
            Customer customer = await _contextProvider.Context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPut]
        public async Task<IHttpActionResult> PutCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customer.Id)
            {
                return BadRequest();
            }

            _contextProvider.Context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _contextProvider.Context.SaveChangesAsync();
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

        [HttpPost]
        [ResponseType(typeof(Customer))]
        public async Task<IHttpActionResult> PostCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _contextProvider.Context.Customers.Add(customer);
            await _contextProvider.Context.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = customer.Id }, customer);
        }

        [HttpDelete]
        [ResponseType(typeof(Customer))]
        public async Task<IHttpActionResult> DeleteCustomer(int id)
        {
            Customer customer = await _contextProvider.Context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _contextProvider.Context.Customers.Remove(customer);
            await _contextProvider.Context.SaveChangesAsync();

            return Ok(customer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _contextProvider.Context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerExists(int id)
        {
            return _contextProvider.Context.Customers.Count(e => e.Id == id) > 0;
        }
    }
}