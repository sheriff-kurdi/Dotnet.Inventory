using Microsoft.EntityFrameworkCore;

namespace Kurdi.Inventory.Core.Entities.ProductAggregate
{
    [Owned]
    public class ProductPrices
    {
        private double _sellingPrice;
        public double SellingPrice
        {
            get
            {
                if (IsDiscounted) { return _sellingPrice - Discount; }
                else { return _sellingPrice; }
            }
            set => _sellingPrice = value;
        }

        public double CostPrice { get; set; }

        public double Discount { get; set; }

        public bool IsDiscounted { get; set; }
    }
}