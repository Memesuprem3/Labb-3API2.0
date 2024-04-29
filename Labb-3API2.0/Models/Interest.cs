using System.ComponentModel.DataAnnotations;

namespace Labb_3API2._0.Models
{
    public class Interest
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public ICollection<PersonInterest> PersonInterests { get; set; }
    }
}
