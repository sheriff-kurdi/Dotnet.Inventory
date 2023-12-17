using Kurdi.Inventory.Core.Entities.ProductAggregate;
using Kurdi.Inventory.Core.Exceptions;
using Xunit;

namespace Kurdi.Inventory.UnitTest.Products
{
    public class StockQuantitiesTest
    {

        [Theory]
        [InlineData(5, 15)]
        [InlineData(5, 1)]
        [InlineData(5, 2)]
        [InlineData(10, 2)]
        public void ReserveTest(int totalStockQuantity, int reservationQuantity)
        {
            //preparation
            var stockItemQuantity = new ProductQuantity();
            stockItemQuantity.AddStock(totalStockQuantity);



            if (totalStockQuantity < reservationQuantity)
            {
                //Action & Assertion
                Assert.Throws<NegativeStockTransactionException>(() => stockItemQuantity.ReserveStock(reservationQuantity));

            }
            else
            {
                //Action
                stockItemQuantity.ReserveStock(reservationQuantity);

                //Assert
                Assert.Equal(stockItemQuantity.ReservedStock, reservationQuantity);
                Assert.Equal(stockItemQuantity.AvailableStock, totalStockQuantity - reservationQuantity);
                //check negative stock
                Assert.True(stockItemQuantity.AvailableStock > -1, "Expected actualCount not to be negative value.");
                Assert.True(stockItemQuantity.TotalStock > -1);
            }


        }

        [Theory]
        [InlineData(5, 1, 1)]
        [InlineData(5, 2, 1)]
        [InlineData(10, 2, 0)]
        [InlineData(10, 2, 20)]
        public void CancelReservationTest(int totalStockQuantity, int reservationQuantity, int cancelReservationQuantity)
        {
            //preparation
            var stockItemQuantity = new ProductQuantity();
            stockItemQuantity.AddStock(totalStockQuantity);
            stockItemQuantity.ReserveStock(reservationQuantity);

            if (stockItemQuantity.ReservedStock < cancelReservationQuantity)
            {
                //Action & Assertion
                Assert.Throws<NegativeStockTransactionException>(() => stockItemQuantity.CancelReservation(cancelReservationQuantity));

            }
            else
            {
                //Action
                stockItemQuantity.CancelReservation(cancelReservationQuantity);

                //Assert
                Assert.Equal(stockItemQuantity.ReservedStock, reservationQuantity - cancelReservationQuantity);
                Assert.Equal(stockItemQuantity.AvailableStock, totalStockQuantity - reservationQuantity + cancelReservationQuantity);

                //check negative stock
                Assert.True(stockItemQuantity.AvailableStock > -1, "Expected actualCount not to be negative value.");
                Assert.True(stockItemQuantity.TotalStock > -1);
            }


        }

        [Theory]
        [InlineData(0)]
        [InlineData(5)]
        [InlineData(10)]
        public void AddStockTest(int totalStockQuantity)
        {
            //TODO: test cost of items edit.
            //preparation
            var stockItemQuantity = new ProductQuantity();

            //Action
            stockItemQuantity.AddStock(totalStockQuantity);

            //Assert
            Assert.Equal(stockItemQuantity.TotalStock, totalStockQuantity);
            Assert.Equal(stockItemQuantity.AvailableStock, totalStockQuantity - stockItemQuantity.ReservedStock);

            //check negative stock
            Assert.True(stockItemQuantity.AvailableStock > -1, "Expected actualCount not to be negative value.");
            Assert.True(stockItemQuantity.TotalStock > -1);
        }


    }
}
