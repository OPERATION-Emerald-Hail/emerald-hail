using Microsoft.AspNetCore.Mvc;
using Emerald.Hail.Domain.Catalog;
using Emerald.Hail.Data;

namespace Emerald.Hail.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly StoreContext _context;

        public CatalogController(StoreContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult GetItems()
        {
            return Ok(_context.Items);

        }   


        [HttpGet("{id:int}")]
        public IActionResult GetItem(int id)
        {
            var item = _context.Items.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult CreateItem(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
            return Created($"api/catalog/{item.Id}", item);
        }

        [HttpPost("{id:int}/ratings")]
        public IActionResult AddRating(int id, Rating rating)
        {
            var item = _context.Items.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            item.AddRating(rating);
            _context.SaveChanges();

            return Ok(item);
        }

        
    }


}