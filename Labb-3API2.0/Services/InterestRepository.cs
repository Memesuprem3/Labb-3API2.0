using Labb_3API2._0.Data;
using Labb_3API2._0.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb_3API2._0.Services
{
   
        public class InterestRepository : IInterest
        {
            private AppDbContext _appDbContext;

            public InterestRepository(AppDbContext appDbContext)
            {
                _appDbContext = appDbContext;
            }

            public async Task<IEnumerable<Interest>> GetAll()
            {
                return await _appDbContext.Interests.ToListAsync();
            }
        }
    
}