using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MultiTenancy.Domain;

namespace MultiTenancy.DataAccess.Extensions
{
    public static class ShopModelBuilderExtensions
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Tenant>().HasData(InitialData.Tenants);
            modelBuilder.Entity<Country>().HasData(InitialData.Countries);
            modelBuilder.Entity<Specification>().HasData(InitialData.Specifications);
            modelBuilder.Entity<Category>().HasData(InitialData.Categories);
            modelBuilder.Entity<CategorySpecification>().HasData(InitialData.CategorySpecifications);
            modelBuilder.Entity<Image>().HasData(InitialData.Images);
            modelBuilder.Entity<Product>().HasData(InitialData.Products);
            modelBuilder.Entity<ProductSpecification>().HasData(InitialData.ProductSpecifications);
            modelBuilder.Entity<User>().HasData(InitialData.Users);
            modelBuilder.Entity<Address>().HasData(InitialData.Addresses);
            modelBuilder.Entity<Order>().HasData(InitialData.Orders);
            modelBuilder.Entity<OrderItem>().HasData(InitialData.OrderItems);


        }
    }
}
