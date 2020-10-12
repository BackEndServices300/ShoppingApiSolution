using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingApi.Controllers
{
    public class CatalogController : ControllerBase
    {
        private readonly ShoppingDataContext _context;

        public CatalogController(ShoppingDataContext context)
        {
            _context = context;
        }

        [HttpGet("catalog")]
        public async Task<ActionResult> GetFullCatalog()
        {
            var response = await _context.ShoppingItems.Where(item => item.InInventory)
                .ToListAsync();

            return Ok(response);
        }
    }
}
