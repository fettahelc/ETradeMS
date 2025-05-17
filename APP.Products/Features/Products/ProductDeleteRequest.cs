using CORE.APP.Features;
using MediatR;

namespace APP.Products.Features.Products
{
    public class ProductDeleteRequest : Request, IRequest<CommandResponse>
    {
    }
} 