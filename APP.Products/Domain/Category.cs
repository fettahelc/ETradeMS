using CORE.APP.Domain;
using System.ComponentModel.DataAnnotations;

namespace APP.Products.Domain
{
    public class Category : Entity
    {
        [Required]
        [StringLength(75)]
        public string Name { get; set; }

        public List<Product> Products { get; set; }
    }
}
