using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NbaLibrary.Models;
using NbaShopService.Models;

namespace NbaShopService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NbaController : ControllerBase
    {
        static nbashopContext context = new nbashopContext();

        #region Team
        [HttpGet("Team")]
        public ActionResult<IEnumerable<Team>> GetTeam()
        {
            var t = context.Team;
            if (t == null)
                return NotFound();
            return Ok(t);
        }

        [HttpGet("Team/Coast/{coast}")]
        public ActionResult<IEnumerable<Team>> GetCoast(string coast)
        {
            var t = context.Team.Where(a => a.Coast == coast);
            if (t == null)
                return NotFound();
            return Ok(t);
        }

        [HttpGet("Team/Name/{name}")]
        public ActionResult<IEnumerable<Team>> GetTeamName(string name)
        {
            var t = context.Team.Where(a => a.Name == name);
            if (t == null)
                return NotFound();
            return Ok(t);
        }
        #endregion

        #region Jersey
        [HttpPost("Jersey")]
        public ActionResult<Jersey> AddJersey([FromBody] Jersey newJersey)
        {
            context.Jersey.Add(newJersey);
            context.SaveChangesAsync();
            return Ok();
        }

        [HttpPatch("Jersey/JerseyId")]
        public ActionResult PatchJersey([FromBody] Jersey jersey, int jerseyid)
        {
            var p = context.Jersey.FirstOrDefault(a => a.JerseyID == jerseyid);

            if (p == null)
            {
                return NotFound();
            }
            else
            {
                p.JerseyID = jersey.JerseyID;
                p.Gender = jersey.Gender;
                p.Size = jersey.Size;
                p.Description = jersey.Description;
                p.Name = jersey.Name;
                p.Number = jersey.Number;
                context.SaveChangesAsync();
                return Ok(p.JerseyID);
            }
        }
        #endregion

        #region Shorts
        [HttpPost("Shorts")]
        public ActionResult<Shorts> AddShorts([FromBody] Jersey newShorts)
        {
            context.Jersey.Add(newShorts);
            context.SaveChangesAsync();
            return Ok();
        }

        [HttpPatch("Shorts/ShortsId")]
        public ActionResult PatchShorts([FromBody] Shorts shorts, int shortsid)
        {
            var p = context.Shorts.FirstOrDefault(a => a.ShortsID == shortsid);

            if (p == null)
            {
                return NotFound();
            }
            else
            {
                p.ShortsID = shorts.ShortsID;
                p.Gender = shorts.Gender;
                p.Size = shorts.Size;
                p.Description = shorts.Description;
                context.SaveChangesAsync();
                return Ok(p.ShortsID);
            }
        }
        #endregion

        #region Customer


        [HttpPost("Customer")]
        public ActionResult<IEnumerable<Customer>> AddCustomer([FromBody] Customer newCustomer)
        {
            context.Customer.Add(newCustomer);
            context.SaveChangesAsync();

            return Ok(newCustomer);
        }

        [HttpGet("Customer")]
        public ActionResult<IEnumerable<Customer>> GetCustomer()
        {
            var t = context.Customer;
            if (t == null)
                return NotFound();

            return Ok(t);
        }

        [HttpPatch("Customer/{CustomerId}")]
        public ActionResult PatchCustomer([FromBody] Customer customer, int customerid)
        {
            var p = context.Customer.FirstOrDefault(a => a.CustomerID == customerid);
            if (p == null)
            {
                return NotFound();
            }
            else
            {
                p.CustomerID = customer.CustomerID;
                p.Firstname = customer.Firstname;
                p.LastName = customer.LastName;
                p.DateOfBirth = customer.DateOfBirth;
                p.Email = customer.Email;
                p.Location = customer.Location;
                p.Postcode = customer.Postcode;
                context.SaveChangesAsync();

                return Ok();
            }
        }


        #endregion

        #region Cart

        //[HttpGet("Cart/{cartid}/Price")]
        //public ActionResult<Cart> GetCartPrice(int cartid)
        //{
        //    var t = context.Cart.Where(a => a.CartID == cartid).Select(a => a.Price);
        //    if (t == null)
        //        return NotFound();
        //    return Ok(t);
        //}

        [HttpGet("Cart/{cartid}/NumberOfProducts")]
        public ActionResult<Cart> GetCartNumberOfProducts(int cartid)
        {
            var t = context.Cart.Where(a => a.CartID == cartid).Select(a => a.NumberOfProducts);
            if (t == null)
                return NotFound();
            return Ok(t);
        }

        [HttpGet("Cart/{cartid}/Products")]
        public ActionResult<Cart> GetCartProducts(int cartid)
        {
            var t = context.Cart.Where(a => a.CartID == cartid).Select(a => a.Products);
            if (t == null)
                return NotFound();
            return Ok(t);
        }

        [HttpGet("Cart/{cartid}/Date")]
        public ActionResult<Cart> GetCartDate(int cartid)
        {
            var t = context.Cart.Where(a => a.CartID == cartid).Select(a => a.Date);
            if (t == null)
                return NotFound();
            return Ok(t);
        }

        [HttpDelete("Cart/{cartid}/Products/{product}")]
        public ActionResult DeleteCartProduct(int cartid, string product)
        {
            var p = context.Cart.Where(a => a.CartID == cartid).Where(t => t.Products == product).FirstOrDefault();
            if (p == null)
            {
                return NotFound();
            }
            else
            {
                context.Cart.Remove(p);
                context.SaveChangesAsync();

                return Ok();
            }
        }

        [HttpPatch("Cart/Cartid")]
        public ActionResult PatchCart([FromBody] Cart cart, int cartid)
        {
            var p = context.Cart.FirstOrDefault(a => a.CartID == cartid);

            if (p == null)
            {
                return NotFound();
            }
            else
            {
                p.CartID = cartid;
                p.Products = cart.Products;
                context.SaveChangesAsync();

                return Ok();
            }
        }

        #endregion
    }
}
