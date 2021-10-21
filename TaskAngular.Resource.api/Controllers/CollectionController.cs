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
    public class CollectionController : ControllerBase
    {
        private readonly BookStore _store;
        private readonly ApplicationDbContext _applicationDbContext;
        private Guid UserId => Guid.Parse(User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value);
        public CollectionController(BookStore store, ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            this._store = store;
        }
        [HttpGet]
        [Route("")]
        public IActionResult GetAllCollection()
        {
            return Ok(_applicationDbContext.Collections.ToArray());
        }

        [HttpGet]
        [Authorize]
        [Route("GetUserCollections")]
        public IActionResult GetUserCollections()
        {
            return Ok(_applicationDbContext.Collections.Where(s=>s.UserName==UserId.ToString()).ToArray());
        }

        [HttpPost]
        [Authorize]
        [Route("AddCollections")]
        public IActionResult AddNewCollection([FromBody]AddCollectionModel response)
        {
            try
            {
                _applicationDbContext.Collections.Add(new Collection
                {
                    UserName = UserId.ToString(),
                    CollectionName = response.CollectionName,
                    Topic = response.Topic,
                    Description = response.Description
                });
                _applicationDbContext.SaveChanges();
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
