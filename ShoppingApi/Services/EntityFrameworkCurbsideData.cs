using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ShoppingApi.Domain;
using ShoppingApi.Models.Curbside;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingApi.Services
{
    public class EntityFrameworkCurbsideData : IDoCurbsideQueries
    {
        private readonly ShoppingDataContext _context;

        public EntityFrameworkCurbsideData(ShoppingDataContext context)
        {
            _context = context;
        }

        public async Task<GetCurbsideOrdersResponse> GetAll()
        {
            var response = new GetCurbsideOrdersResponse();
            var data = await _context.CurbsideOrders.ToListAsync();
            response.Data = data;
            response.NumberOfApprovedOrders = response.Data.Count(o => o.Status == CurbsideOrderStatus.Approved);
            response.NumberOfDeniedOrders = response.Data.Count(o => o.Status == CurbsideOrderStatus.Denied);
            response.NumberOfFulfilledOrders = response.Data.Count(o => o.Status == CurbsideOrderStatus.Fulfilled);
            response.NumberOfPendingOrders = response.Data.Count(o => o.Status == CurbsideOrderStatus.Pending);
            return response;
        }
    }
}
