using System.Collections.Generic;
using System;
using System.Linq;
using System.Linq.Expressions;
using AutoLot.Dal.Models.Entities;
using AutoLot.Dal.Tests.Base;
using Xunit;

namespace AutoLot.Dal.Tests.ContextTests
{
    [Collection("Integration Tests")]
    public class CustomerTests : BaseTest, IClassFixture<EnsureAutoLotDatabaseTestFixture>
    {
        [Fact]
        public void ShouldGetAllOfTheCustomers()
        {
            var customers = Context.Customers.ToList();
            Assert.Equal(5, customers.Count);
        }

        [Fact]
        public void FirstGetFirstMatchingRecord()
        {
            //Gets the first record, database order
            var customer = Context.Customers.First();
            Assert.Equal(1,customer.Id);
        }
        [Fact]
        public void FirstShouldThrowExceptionIfNoneMatch()
        {
            //Filters based on Id. Throws due to no match
            Assert.Throws<InvalidOperationException>(()=> Context.Customers.First(x=>x.Id == 10));
        }

        [Fact]
        public void FirstOrDefaultShouldReturnDefaultIfNoneMatch()
        {
            //Expression<Func<Customer>> is a lambda expression
            Expression<Func<Customer, bool>> expression = x => x.Id == 10;
            //Returns null when nothing is found
            var customer = Context.Customers.FirstOrDefault(expression);
            Assert.Null(customer);
        }

        [Fact]
        public void GetOneMatchingRecordWithSingle()
        {
            //Gets the first record, database order
            var customer = Context.Customers.Single(x=>x.Id == 1);
            Assert.Equal(1,customer.Id);
        }
        [Fact]
        public void SingleShouldThrowExceptionIfNoneMatch()
        {
            //Filters based on Id. Throws due to no match
            Assert.Throws<InvalidOperationException>(()=> Context.Customers.Single(x=>x.Id == 10));
        }
        [Fact]
        public void SingleShouldThrowExceptionIfMoreThenOneMatch()
        {
            //Filters based on Id. Throws due to no match
            Assert.Throws<InvalidOperationException>(()=> Context.Customers.Single());
        }
        [Fact]
        public void SingleOrDefaultShouldReturnDefaultIfNoneMatch()
        {
            //Expression<Func<Customer>> is a lambda expression
            Expression<Func<Customer, bool>> expression = x=>x.Id == 10;
            //Returns null when nothing is found
            var customer = Context.Customers.SingleOrDefault(expression);
            Assert.Null(customer);
        }

        [Fact]
        public void ShouldGetCustomersWithLastNameWithW()
        {
            var customers = 
                Context.Customers.Where(x => x.PersonalInformation.LastName.StartsWith("W")).ToList();
            Assert.Equal(2, customers.Count);
        }
        [Fact]
        public void ShouldGetCustomersWithLastNameWithWAndFirstNameM()
        {
            var customers = 
                Context.Customers.Where(x => x.PersonalInformation.LastName.StartsWith("W"))
                    .Where(x=>x.PersonalInformation.FirstName.StartsWith("M")).ToList();
            Assert.Single(customers);
        }
        [Fact]
        public void ShouldGetCustomersWithLastNameWithWOrH()
        {
            var customers = 
                Context.Customers.Where(x => 
                    x.PersonalInformation.LastName.StartsWith("W") ||
                    x.PersonalInformation.LastName.StartsWith("H")).ToList();
            Assert.Equal(3, customers.Count);
        }

        [Fact]
        public void ShouldSortByFirstNameThenLastName()
        {
            var customers = Context.Customers
                .OrderBy(x => x.PersonalInformation.LastName)
                .ThenBy(x => x.PersonalInformation.FirstName).ToList();
        }
    }
}