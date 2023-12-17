using System.ComponentModel.DataAnnotations.Schema;
using Kurdi.Inventory.Core.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Kurdi.Inventory.Core.Entities.ProductAggregate
{
    [Owned]
    public class ProductQuantity
    {
        public int TotalStock { get; private set; }

        public int AvailableStock { get; private set; }

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
