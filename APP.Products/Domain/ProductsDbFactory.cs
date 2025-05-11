using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace APP.Products.Domain
{
    public class ProductsDbFactory : IDesignTimeDbContextFactory<ProductsDb>
    {
        public ProductsDb CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProductsDb>();
            optionsBuilder.UseSqlite("data source=ProductsDB");
            return new ProductsDb(optionsBuilder.Options);
        }

        public void Seed()
        {
            var db = CreateDbContext(null);

            #region Deleting Current Data
            var productStores = db.ProductStores.ToList();
            db.ProductStores.RemoveRange(productStores);

            var stores = db.Stores.ToList();
            db.Stores.RemoveRange(stores);

            var products = db.Products.ToList();
            db.Products.RemoveRange(products);

            var categories = db.Categories.ToList();
            db.Categories.RemoveRange(categories);
            #endregion

            #region Inserting Initial Data
            db.Stores.Add(new Store()
            {
                Name = "Hepsiburada"
            });
            db.Stores.Add(new Store()
            {
                Name = "Vatan"
            });
            db.SaveChanges();

            db.Categories.Add(new Category()
            {
                Name = "Computer",
                Products = new List<Product>()
                {
                    new Product()
                    {
                        Name = "Laptop",
                        UnitPrice = 3000.5m,
                        ProductStores = new List<ProductStore>()
                        {
                            new ProductStore()
                            {
                                StoreId = db.Stores.SingleOrDefault(s => s.Name == "Hepsiburada").Id
                            }
                        }
                    },
                    new Product()
                    {
                        Name = "Mouse",
                        IsDiscontinued = true,
                        UnitPrice = 20.5m,
                        ProductStores = new List<ProductStore>()
                        {
                            new ProductStore()
                            {
                                StoreId = db.Stores.SingleOrDefault(s => s.Name == "Hepsiburada").Id
                            },
                            new ProductStore()
                            {
                                StoreId = db.Stores.SingleOrDefault(s => s.Name == "Vatan").Id
                            }
                        }
                    },
                    new Product()
                    {
                        Name = "Keyboard",
                        UnitPrice = 40,
                        IsDiscontinued = true,
                        ProductStores = new List<ProductStore>()
                        {
                            new ProductStore()
                            {
                                StoreId = db.Stores.SingleOrDefault(s => s.Name == "Hepsiburada").Id
                            },
                            new ProductStore()
                            {
                                StoreId = db.Stores.SingleOrDefault(s => s.Name == "Vatan").Id
                            }
                        }
                    },
                    new Product()
                    {
                        Name = "Monitor",
                        UnitPrice = 2500,
                        ProductStores = new List<ProductStore>()
                        {
                            new ProductStore()
                            {
                                StoreId = db.Stores.SingleOrDefault(s => s.Name == "Vatan").Id
                            }
                        }
                    }
                }
            });
            db.Categories.Add(new Category()
            {
                Name = "Home Theater System",
                Products = new List<Product>()
                {
                    new Product()
                    {
                        Name = "Speaker",
                        UnitPrice = 2500
                    },
                    new Product()
                    {
                        Name = "Receiver",
                        UnitPrice = 5000,
                        ProductStores = new List<ProductStore>()
                        {
                            new ProductStore()
                            {
                                StoreId = db.Stores.SingleOrDefault(s => s.Name == "Vatan").Id
                            }
                        }
                    },
                    new Product()
                    {
                        Name = "Equalizer",
                        UnitPrice = 1000,
                        ProductStores = new List<ProductStore>()
                        {
                            new ProductStore()
                            {
                                StoreId = db.Stores.SingleOrDefault(s => s.Name == "Hepsiburada").Id
                            },
                            new ProductStore()
                            {
                                StoreId = db.Stores.SingleOrDefault(s => s.Name == "Vatan").Id
                            }
                        }
                    }
                }
            });
            db.Categories.Add(new Category()
            {
                Name = "Medicine",
                Products = new List<Product>()
                {
                    new Product()
                    {
                        Name = "Majezik",
                        ExpirationDate = DateTime.Parse("12/23/2026", new CultureInfo("en-US")),
                        UnitPrice = 5
                    }
                }
            });
            #endregion

            db.SaveChanges();
        }
    }
}
