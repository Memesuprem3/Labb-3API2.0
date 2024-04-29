using Labb_3API2._0.Data;
using Labb_3API2._0.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb_3API2._0.Services
{
    public class PersonRepository : IPerson
    {
        private AppDbContext _appDbContext;

        public PersonRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Link> AddLink(int personId, int interestId, string url)
        {

            
            var result = await _appDbContext.PersonInterests
                .FirstOrDefaultAsync(pi => pi.PersonId == personId && pi.InterestId == interestId);

            
            if (result == null)
            {
                return null;
            }

            
            var newLink = new Link
            {
                Url = url,
                PersonInterestId = result.Id
            };
            _appDbContext.Links.Add(newLink);
            await _appDbContext.SaveChangesAsync();

            return newLink;
        }

        public async Task<PersonInterest> AddNewPersonInterest(int personId, int interestId)
        {
            
            var existingUser = await _appDbContext.PersonInterests.FirstOrDefaultAsync(
                pi => pi.PersonId == personId && pi.InterestId == interestId);


            if (existingUser != null)
            {
                return null;
            }

            
            var newInterest = new PersonInterest
            {
                PersonId = personId,
                InterestId = interestId
            };

            
            _appDbContext.PersonInterests.Add(newInterest);
            await _appDbContext.SaveChangesAsync();
            return newInterest;
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            return await _appDbContext.Persons.ToListAsync();
        }

        public async Task<IEnumerable<Interest>> GetInterestById(int personId)
        {
            return await _appDbContext.PersonInterests
                .Where(pi => pi.PersonId == personId)  
                .Select(pi => pi.Interest)      
                .ToListAsync();
        }

        public async Task<IEnumerable<Link>> GetLinksById(int id)
        {
            return await _appDbContext.PersonInterests
                .Where(pi => pi.PersonId == id) 
                .Include(pi => pi.Links) 
                .SelectMany(pi => pi.Links) 
                .ToListAsync();
        }
    }
}
