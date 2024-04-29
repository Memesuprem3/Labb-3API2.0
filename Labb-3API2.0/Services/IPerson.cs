using Labb_3API2._0.Models;

namespace Labb_3API2._0.Services
{
    public interface IPerson
    {
        Task<IEnumerable<Person>> GetAll();
        Task<IEnumerable<Link>> GetLinksById(int id);
        Task<IEnumerable<Interest>> GetInterestById(int id);

        Task<PersonInterest> AddNewPersonInterest(int personId, int interestId);
        Task<Link> AddLink(int personId, int interestId, string url);
    }

}
