using APP.Products.Domain;
using APP.Products.Features.Categories;
using APP.Products.Features.Stores;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace APP.Products.Features.Products
{
    /// <summary>
    /// Handles queries related to products by fetching data from the database.
    /// Implements IRequestHandler to process ProductQueryRequest and return a list of ProductQueryResponse.
    /// </summary>
    public class ProductQueryHandler : ProductsDbHandler, IRequestHandler<ProductQueryRequest, IQueryable<ProductQueryResponse>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductQueryHandler"/> class.
        /// </summary>
        /// <param name="db">The products database instance.</param>
        public ProductQueryHandler(ProductsDb db) : base(db)
        {
        }
        
        public Task<IQueryable<ProductQueryResponse>> Handle(ProductQueryRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(Db.Products
                .Include(p => p.Category)
                .Include(p => p.ProductStores).ThenInclude(ps => ps.Store)
                .OrderByDescending(p => p.IsDiscontinued)
                .ThenBy(p => p.Name)
                .Select(p => new ProductQueryResponse
                {
                    // Map properties from the Product entity to the response DTO.
                    // Optionally AutoMapper third party library (https://automapper.org/) can be used for mapping operations.
                    Id = p.Id,
                    Name = p.Name,
                    UnitPrice = p.UnitPrice,
                    ExpirationDate = p.ExpirationDate,
                    IsDiscontinued = p.IsDiscontinued,
                    CategoryId = p.CategoryId,
                    StoreIds = p.ProductStores.Select(ps => ps.StoreId).ToList(),
                    CategoryName = p.Category.Name,
                    Category = new CategoryQueryResponse
                    {
                        Id = p.Category.Id,
                        Name = p.Category.Name
                    },
                    StoreNames = string.Join(", ", p.ProductStores.Select(ps => ps.Store.Name)),
                    Stores = p.ProductStores.Select(ps => new StoreQueryResponse
                    {
                        Id = ps.Store.Id,
                        Name = ps.Store.Name
                    }).ToList()
                }));
        }
    }
} 