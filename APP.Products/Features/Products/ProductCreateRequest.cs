using CORE.APP.Features;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace APP.Products.Features.Products
{
    public class ProductCreateRequest : Request, IRequest<CommandResponse>
    {
        [Required]
        [StringLength(150)]
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public bool IsDiscontinued { get; set; }
        public int CategoryId { get; set; }
        public List<int> StoreIds { get; set; }
    }
} 