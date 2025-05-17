using APP.Products.Domain;
using CORE.APP.Features;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace APP.Products.Features.Products
{
    public class ProductUpdateHandler : ProductsDbHandler, IRequestHandler<ProductUpdateRequest, CommandResponse>
    {
        public ProductUpdateHandler(ProductsDb db) : base(db)
        {
        }

        public async Task<CommandResponse> Handle(ProductUpdateRequest request, CancellationToken cancellationToken)
        {
            if (await Db.Products.AnyAsync(p => p.Name == request.Name && p.Id != request.Id, cancellationToken))
            {
                return Error("Product with the same name exists!");
            }

            var product = await Db.Products
                .Include(p => p.ProductStores)
                .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

            if (product == null)
            {
                return Error("Product not found!");
            }

            product.Name = request.Name;
            product.UnitPrice = request.UnitPrice;
            product.ExpirationDate = request.ExpirationDate;
            product.IsDiscontinued = request.IsDiscontinued;
            product.CategoryId = request.CategoryId;

            Db.ProductStores.RemoveRange(product.ProductStores);

            if (request.StoreIds != null && request.StoreIds.Any())
            {
                var productStores = request.StoreIds.Select(storeId => new ProductStore
                {
                    ProductId = product.Id,
                    StoreId = storeId
                });

                Db.ProductStores.AddRange(productStores);
            }

            await Db.SaveChangesAsync(cancellationToken);

            return Success("Product updated successfully.");
        }
    }
} 