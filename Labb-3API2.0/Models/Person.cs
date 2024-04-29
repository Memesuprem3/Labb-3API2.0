using System.ComponentModel.DataAnnotations;

namespace Labb_3API2._0.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<PersonInterest> PersonInterests { get; set; }
    }
}
