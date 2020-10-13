using ShoppingApi.Models.Curbside;
using System.Threading.Tasks;

namespace ShoppingApi.Services
{
    public interface IDoCurbsideQueries
    {
        Task<GetCurbsideOrdersResponse> GetAll();
    }
}