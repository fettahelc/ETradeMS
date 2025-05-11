using CORE.APP.Domain;
using System.ComponentModel.DataAnnotations;

namespace APP.Products.Domain
{
    public class Store : Entity
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public List<ProductStore> ProductStores { get; set; }
    }
}
