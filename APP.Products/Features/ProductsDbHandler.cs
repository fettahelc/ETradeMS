using CORE.APP.Features;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using APP.Products.Domain;

namespace APP.Products.Features
{
    public class ProductsDbHandler : Handler
    {
        protected readonly ProductsDb Db;

        public ProductsDbHandler(ProductsDb db) : base(new CultureInfo("en-US"))
        {
            Db = db;
        }
    }
}
