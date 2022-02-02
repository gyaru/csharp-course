using System;
using vending_machine;
using Xunit;

namespace vending_machine_test
{
    public class VendingMachineTests
    {
        [Fact]
        public void GetCorrectAmountProducts()
        {
            VendingMachine vm = new();
            int amount = vm.GetProducts().Count;
            Assert.Equal(3, amount);
        }
        
        [Theory]
        [InlineData(1, 10, 10)]
        [InlineData(1000, 5, 5000)]
        [InlineData(20, 20, 400)]
        public void GetCorrectValue(int denomination, int amount, int expected)
        {
            // populate
            VendingMachine vm = new();
            Currency cd = new();
            // insert money
            vm.Insert(denomination, amount);
            // value that it should be
            int actual = 0;
            // ending transaction, is it still a multidimensional array?
            int[,] change = vm.EndTransaction();
            for (int index = 0; index < cd.Denominations.Length; index++)
            {
                actual += change[index, 0] * change[index, 1];
            }
            Assert.Equal(expected, actual);
        }
    }
}