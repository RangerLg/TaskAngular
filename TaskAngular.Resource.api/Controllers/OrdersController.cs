using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TaskAngular.Resource.api.Models;

namespace TaskAngular.Resource.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly BookStore store;
        private Guid UserId => Guid.Parse(User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value);
        public OrdersController(BookStore store)
        {
            this.store = store;
        }

        [HttpGet]
        [Authorize (Roles = "User")]
        [Route("")]
        public IActionResult GetOrders()
        {
            if (!store.Orders.ContainsKey(UserId)) return Ok(Enumerable.Empty<Book>());

            var orderedBookIds = store.Orders.Single(o => o.Key == UserId).Value;
            var orderedBooks = store.Books.Where(b =>orderedBookIds.Contains(b.id));

            return Ok(orderedBooks);
        }
    }
}
