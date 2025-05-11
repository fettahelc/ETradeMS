using CORE.APP.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APP.Products.Domain
{
    public class Product : Entity
    {
        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        public decimal UnitPrice { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public bool IsDiscontinued { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public List<ProductStore> ProductStores { get; set; }

        [NotMapped]
        public List<int> StoreIds 
        {
            get => ProductStores?.Select(ps => ps.StoreId).ToList();
            set => ProductStores = value?.Select(v => new ProductStore() { StoreId = v }).ToList();
        }
    }
}
