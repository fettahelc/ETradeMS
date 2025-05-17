using APP.Products.Domain;
using CORE.APP.Features;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace APP.Products.Features.Products
{
    public class ProductDeleteHandler : ProductsDbHandler, IRequestHandler<ProductDeleteRequest, CommandResponse>
    {
        public ProductDeleteHandler(ProductsDb db) : base(db)
        {
        }

        public async Task<CommandResponse> Handle(ProductDeleteRequest request, CancellationToken cancellationToken)
        {
            var product = await Db.Products
                .Include(p => p.ProductStores)
                .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

            if (product == null)
            {
                return Error("Product not found!");
            }

            Db.ProductStores.RemoveRange(product.ProductStores);
            Db.Products.Remove(product);
            await Db.SaveChangesAsync(cancellationToken);

            return Success("Product deleted successfully.");
        }
    }
} 