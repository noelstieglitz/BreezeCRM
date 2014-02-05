using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Breeze.ContextProvider.EF6;
using Breeze.WebApi2;
using BreezeCRM.Models;

namespace BreezeCRM.Controllers
{
    [BreezeController]
    public class OrderController : ApiController
    {
        readonly EFContextProvider<NorthwindContext> _contextProvider = new EFContextProvider<NorthwindContext>();

        [HttpGet]
        public string Metadata()
        {
            return _contextProvider.Metadata();
        }

        [HttpGet]
        [Queryable(MaxAnyAllExpressionDepth = 3)]
        public IQueryable<Order> Orders()
        {
            return _contextProvider.Context.Orders;
        }

        [ResponseType(typeof(Order))]
        [HttpGet]
        public async Task<IHttpActionResult> Orders(int id)
        {
            Order Order = await _contextProvider.Context.Orders.FindAsync(id);
            if (Order == null)
            {
                return NotFound();
            }

            return Ok(Order);
        }

        [HttpPut]
        public async Task<IHttpActionResult> PutOrder(int id, Order Order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id == 0 || id != Order.OrderID)
            {
                return BadRequest();
            }

            _contextProvider.Context.Entry(Order).State = EntityState.Modified;

            try
            {
                await _contextProvider.Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
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
        [ResponseType(typeof(Order))]
        public async Task<IHttpActionResult> PostOrder(Order Order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _contextProvider.Context.Orders.Add(Order);
            await _contextProvider.Context.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = Order.OrderID }, Order);
        }

        [HttpDelete]
        [ResponseType(typeof(Order))]
        public async Task<IHttpActionResult> DeleteOrder(int id)
        {
            Order Order = await _contextProvider.Context.Orders.FindAsync(id);
            if (Order == null)
            {
                return NotFound();
            }

            _contextProvider.Context.Orders.Remove(Order);
            await _contextProvider.Context.SaveChangesAsync();

            return Ok(Order);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _contextProvider.Context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrderExists(int id)
        {
            return _contextProvider.Context.Orders.Count(e => e.OrderID == id) > 0;
        }
    }
}