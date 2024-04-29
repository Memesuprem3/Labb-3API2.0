using System.ComponentModel.DataAnnotations;

namespace Labb_3API2._0.Models
{
    public class Link
    {
        [Key]
        public int Id { get; set; }
        public string Url { get; set; }

        public int PersonInterestId { get; set; }

        public PersonInterest PersonInterest { get; set; }
    }
}
