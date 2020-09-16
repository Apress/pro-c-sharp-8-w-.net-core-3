using AutoLot.DAL.DataOperations;
using Xunit;

namespace AutoLot.DAL.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void ShouldGetInventory()
        {
            var sut = new InventoryDAL();
            var cars = sut.GetAllInventory();
            Assert.Equal(7,cars.Count);
        }
        [Fact]
        public void ShouldGetOneCar()
        {
            var sut = new InventoryDAL();
            var car = sut.GetCar(3);
            Assert.Equal("Saab",car.Make);
        }
        [Fact]
        public void ShouldGetPetName()
        {
            var sut = new InventoryDAL();
            var petName = sut.LookUpPetName(3);
            Assert.Equal("Mel",petName);
        }

        [Fact]
        public void ShouldProcessCreditRisk()
        {
            var sut = new InventoryDAL();
            sut.ProcessCreditRisk(true, 1);
        }
    }
}
