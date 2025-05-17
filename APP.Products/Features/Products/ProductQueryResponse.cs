using CORE.APP.Features;
using APP.Products.Features.Categories;
using APP.Products.Features.Stores;

namespace APP.Products.Features.Products
{
    /// <summary>
    /// Represents the response for a product query.
    /// </summary>
    public class ProductQueryResponse : QueryResponse
    {
        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the unit price of the product.
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets the expiration date of the product as a nullable DateTime.
        /// </summary>
        public DateTime? ExpirationDate { get; set; }

        /// <summary>
        /// Gets or sets whether the product is discontinued.
        /// </summary>
        public bool IsDiscontinued { get; set; }

        /// <summary>
        /// Gets or sets the category ID of the product.
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the list of store IDs associated with the product.
        /// </summary>
        public List<int> StoreIds { get; set; }

        /// <summary>
        /// Gets the formatted unit price of the product as a currency string.
        /// </summary>
        public string UnitPriceF => UnitPrice.ToString("C2");

        /// <summary>
        /// Gets the formatted expiration date of the product as a string.
        /// </summary>
        public string ExpirationDateF => ExpirationDate?.ToString("MM/dd/yyyy");

        /// <summary>
        /// Gets the formatted discontinued status of the product as a string.
        /// </summary>
        public string IsDiscontinuedF => IsDiscontinued ? "Yes" : "No";

        /// <summary>
        /// Gets or sets the name of the category.
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// Gets or sets the category information.
        /// </summary>
        public CategoryQueryResponse Category { get; set; }

        /// <summary>
        /// Gets or sets the comma-separated list of store names.
        /// </summary>
        public string StoreNames { get; set; }

        /// <summary>
        /// Gets or sets the list of stores associated with the product.
        /// </summary>
        public List<StoreQueryResponse> Stores { get; set; }
    }
} 