using CORE.APP.Features;
using MediatR;

namespace APP.Products.Features.Products
{
    /// <summary>
    /// Represents a request to query products.
    /// Implements IRequest to support MediatR pattern.
    /// </summary>
    public class ProductQueryRequest : Request, IRequest<IQueryable<ProductQueryResponse>>
    {
    }
} 