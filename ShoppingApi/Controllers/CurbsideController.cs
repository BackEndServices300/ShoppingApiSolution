using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingApi.Domain;
using ShoppingApi.Models;
using ShoppingApi.Models.Curbside;
using ShoppingApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingApi.Controllers
{
    public class CurbsideController : ControllerBase
    {

        private readonly IDoCurbsideQueries _curbsideQueries;

        public CurbsideController(IDoCurbsideQueries curbsideQueries)
        {
            _curbsideQueries = curbsideQueries;
        }

        [HttpGet("curbsideorders")]
        public async Task<ActionResult> GetAllOrders()
        {
            GetCurbsideOrdersResponse response = await _curbsideQueries.GetAll();

            return Ok(response);
        }
        [HttpGet("curbsideorders/{orderId:int}")]
        public async Task<ActionResult> GetOrderById(int orderId)
        {
            CurbsideOrder response = await _curbsideQueries.GetById(orderId);
            if(response == null)
            {
                return NotFound();
            } else
            {
                return Ok(response);
            }
        }
    }
}
