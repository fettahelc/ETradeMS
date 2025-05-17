using APP.Products.Domain;
using CORE.APP.Features;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace APP.Products.Features.Products
{
    public class ProductCreateHandler : ProductsDbHandler, IRequestHandler<ProductCreateRequest, CommandResponse>
    {
        public ProductCreateHandler(ProductsDb db) : base(db)
        {
        }

        public async Task<CommandResponse> Handle(ProductCreateRequest request, CancellationToken cancellationToken)
        {
            if (await Db.Products.AnyAsync(p => p.Name == request.Name, cancellationToken))
            {
                return Error("Product with the same name exists!");
            }

            var product = new Product
            {
                Name = request.Name,
                UnitPrice = request.UnitPrice,
                ExpirationDate = request.ExpirationDate,
                IsDiscontinued = request.IsDiscontinued,
                CategoryId = request.CategoryId
            };

            Db.Products.Add(product);
            await Db.SaveChangesAsync(cancellationToken);

            if (request.StoreIds != null && request.StoreIds.Any())
            {
                var productStores = request.StoreIds.Select(storeId => new ProductStore
                {
                    ProductId = product.Id,
                    StoreId = storeId
                });

                Db.ProductStores.AddRange(productStores);
                await Db.SaveChangesAsync(cancellationToken);
            }

            return Success("Product created successfully.", product.Id);
        }
    }
} 