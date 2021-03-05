using Products.Models;

namespace Products.Data
{
    public class SeedData
    {
        public static void Seed(DataContext context)
        {
            context.Categories
                .AddRange(new Category[] { new Category() { Id = 1, Title = "Roupas" }, new Category() { Id = 2, Title = "Brinquedos" } });            

            context.Products.AddRange(new Product[]
            {
                  new Product()
                    {
                        Id = 1,
                        Name = "Camisa Polo",
                        Description = "Camisa polo branca com bolinhas petras",
                        Price = 10.40M,
                        CategoryId = 1
                    },
                    new Product()
                    {
                        Id = 2,
                        Name = "Camisa Preta",
                        Description = "Camisa preta",
                        Price = 45.10M,
                        CategoryId = 1
                    },
                    new Product()
                    {
                        Id = 3,
                        Name = "Carrinho",
                        Description = "Carrinho",
                        Price = 110M,
                        CategoryId = 2
                    },
                    new Product()
                    {
                        Id = 4,
                        Name = "Boneco",
                        Description = "Boneco star wars",
                        Price = 50.99M,
                        CategoryId = 2
                    }
                });


            context.Users.Add(new User() { Id = 1, Username = "admin", Password = "admin", Role = ERole.Admin });

            context.SaveChanges();
        }   
    }
}