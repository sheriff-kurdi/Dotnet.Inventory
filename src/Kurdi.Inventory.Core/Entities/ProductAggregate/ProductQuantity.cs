using System.ComponentModel.DataAnnotations.Schema;
using Kurdi.Inventory.Core.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Kurdi.Inventory.Core.Entities.ProductAggregate
{
    [Owned]
    public class ProductQuantity
    {
        [Column(name:"total_stock")]
        public int TotalStock { get; private set; }

        [Column(name:"available_stock")]
        public int AvailableStock { get; private set; }

        [Column(name:"reserved_stock")]
        public int ReservedStock { get; private set; }

        public void AddStock(int quantity)
        {
            this.TotalStock += quantity;
            this.AvailableStock += quantity;
        }    

        public void ReserveStock(int quantity)
        {
            if(this.AvailableStock - quantity < 0)
            {
                throw new NegativeStockTransactionException();
            }
            this.ReservedStock += quantity;
            this.AvailableStock -= quantity;
        }

        public void CancelReservation(int quantity)
        {
            if (this.ReservedStock - quantity < 0)
            {
                throw new NegativeStockTransactionException();
            }
            this.ReservedStock -= quantity;
            this.AvailableStock += quantity;
        }
    }
}
