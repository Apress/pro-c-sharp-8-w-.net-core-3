using System.Linq;
using AutoLot.Dal.Initialization;
using AutoLot.Dal.Models.Entities;
using AutoLot.Dal.Tests.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using Xunit;

namespace AutoLot.Dal.Tests
{
    [Collection("Integration Tests")]
    public class IntializerTests : BaseTest
    {

        [Fact]
        public void ShouldDropAndCreateTheDatabase()
        {
            SampleDataInitializer.DropAndCreateDatabase(Context);
            var cars = Context.Cars.IgnoreQueryFilters();
            Assert.Empty(cars);
        }

        [Fact]
        public void ShouldDropAndRecreateTheDatabaseThenLoadData()
        {
            SampleDataInitializer.InitializeData(Context);
            var cars = Context.Cars.IgnoreQueryFilters().ToList();
            Assert.Equal(9, cars.Count);
        }

        [Fact]
        public void ShouldClearAndReseedTheDatabase()
        {
            SampleDataInitializer.InitializeData(Context);
            var cars = Context.Cars.IgnoreQueryFilters().ToList();
            Assert.Equal(9, cars.Count);
        }
        [Fact]
        public void ShouldClearTheData()
        {
            SampleDataInitializer.InitializeData(Context);
            SampleDataInitializer.ClearData(Context);
            var cars = Context.Cars.IgnoreQueryFilters();
            Assert.Empty(cars);
        }
        [Fact]
        public void ShouldReseedTheTables()
        {
            SampleDataInitializer.ResetIdentity(Context);
        }

    }
}