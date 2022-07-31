﻿using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using MiltiTenancy.Tests.Core;
using MultiTenency.Entities;
using MultiTenency.Tests;
using Xunit;

namespace MiltiTenancy.Tests
{
    public class Tests : IClassFixture<MultiTenancyFixture>
    {
        private MultiTenancyFixture _fixture;
        public Tests(MultiTenancyFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void UsersCountShouldBeFour_WhenQueryFiltersAreIgnored()
        {
            var context1 = _fixture.Context1;

            var users = context1.Users.IgnoreQueryFilters().ToList();

            users.Should().HaveCount(5);
        }

        [Fact]
        public void UsersCountShouldBeOne_WhenTenantOneAndAdditionalQueryFiltersThatFilterByIdAreApplied()
        {
            var context1 = _fixture.Context1;

            var users = context1.Users.ToList();

            users.Should().HaveCount(1);
        }

        [Fact]
        public void ProductShouldNotBeNull_WhenTenantOne()
        {
            var context1 = _fixture.Context1;

            var product1_c1 = context1.Products.FirstOrDefault(x => x.Name == "Product 1");
            
            product1_c1.Should().NotBeNull();
        }

        [Fact]
        public void ProductShouldBeNull_WhenTenantTwo()
        {
            var context2 = _fixture.Context2;

            var product1_c2 = context2.Products.FirstOrDefault(x => x.Name == "Product 1");

            product1_c2.Should().BeNull();
        }

        [Fact]
        public void TenantIdShouldBeOne_WhenTenantOneAndIsNotTenantOwnedEntity()
        {
            var context1 = _fixture.Context1;

            var subProduct1 = context1.SubProducts.FirstOrDefault(x => x.Name == "SubProduct 1");

            subProduct1.Should().NotBeNull();

            subProduct1?.Product.Category.TenantId.Should().Be(1);
        }

        [Fact]
        public void UserShouldOnlySeeHisOwnAddresses_WhenNotSuperUser()
        {
            var context1 = _fixture.Context1;

            var addresses1 = context1.Addresses.ToList();

            addresses1.Should().HaveCount(1);
        }

        [Fact]
        public void UserShouldSeeAllAddressesWithinSameTenant_WhenSuperUser()
        {
            var context3 = _fixture.Context3;

            var addresses3 = context3.Addresses.ToList();

            addresses3.Should().HaveCount(3);
        }

        //[Fact]
        //public void CacheTest()
        //{
        //    var builder = new DbContextOptionsBuilder();
        //    builder.UseSqlite(@"Data Source=Shareable;Mode=Memory;Cache=Shared").UseLazyLoadingProxies();

        //    var user = new ApplicationUser
        //    {
        //        UserId = 1,
        //        TenantId = 1
        //    };

        //    var contextList = new List<ExampleContext>();

        //    for(int i = 0; i < 20; i++)
        //    {
        //        var context = new ExampleContext(builder.Options, user, Guid.NewGuid().ToString());
        //        context.Database.OpenConnection();
        //        context.Database.EnsureCreated();

        //        contextList.Add(context);
        //    }

        //    contextList.Should().HaveCount(20);
        //}
    }
}