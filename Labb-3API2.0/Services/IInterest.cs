using Labb_3API2._0.Models;

namespace Labb_3API2._0.Services
{
    public interface IInterest
    {
        Task<IEnumerable<Interest>> GetAll();
    }
}
