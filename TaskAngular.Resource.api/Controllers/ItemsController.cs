using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TaskAngular.Resource.api.DbContextApp;
using TaskAngular.Resource.api.Models;
using TaskAngular.Resource.api.ViewModel;

namespace TaskAngular.Resource.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {

        private readonly ApplicationDbContext _applicationDbContext;
        private Guid UserId => Guid.Parse(User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value);
        public ItemsController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
           
        }

        [HttpGet]
        [Authorize]
        [Route("GetItems")]
        public IActionResult GetAtemsFromCollection(int idCollection)
        {
            try
            {
                var collection = _applicationDbContext.Collections.First(s => s.UserName == UserId.ToString()&&s.ID==idCollection);
                return Ok(_applicationDbContext.Items.Where(s => s.IdCollection == collection.ID).ToArray());
            }
            catch
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }
        }

        [HttpPost]
        [Authorize]
        [Route("AddItem")]
        public IActionResult AddItem([FromBody] AddItemViewModel response)
        {
            try
            {
                var collection = _applicationDbContext.Collections.First(s => s.UserName == UserId.ToString()&&s.ID==response.IdCollection);
                var item = _applicationDbContext.Items.Add(new Item { NameItem = response.NameItem, IdCollection = collection.ID });
                _applicationDbContext.SaveChanges();
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }
        }
    }
}
