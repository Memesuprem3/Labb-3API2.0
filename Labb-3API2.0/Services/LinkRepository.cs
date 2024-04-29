using Labb_3API2._0.Data;
using Labb_3API2._0.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb_3API2._0.Services
{
    public class LinkRepository : ILink
    {
        private AppDbContext _appDbContext;

        public LinkRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Link>> GetAll()
        {
            return await _appDbContext.Links.ToListAsync();
        }
    }
}
