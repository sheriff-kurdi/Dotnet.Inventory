using System.Collections.Generic;
using System.Linq;
using Kurdi.Inventory.Core.Contracts.Repositories;
using Kurdi.Inventory.Core.Entities.ProductAggregate;
using Kurdi.Inventory.Core.Entities.SalesOrderAggregate;
using Kurdi.Inventory.Core.Enums;
using Kurdi.Inventory.Core.SalesOrders;

namespace Kurdi.Inventory.Services
{
    public class SalesOrdersService(
        ISalesOrdersRepo salesOrdersRepo,
        IProductsRepo productsRepo,
        ISalesOrderProductsRepo salesOrderProductsRepo)
    {
        public IProductsRepo ProductsRepo { get; } = productsRepo;

        public SalesOrder CreateOrder(SalesOrderDto salesOrderDto)
        {
            List<Product> products = ProductsRepo.FindAll().ToList();
            SalesOrder salesOrder = new SalesOrder()
            {
                Discount = salesOrderDto.SalesOrderItems
                .Sum(item =>
                 item.Quantity * products.FirstOrDefault(product => product.Sku == item.Sku).ProductPrices.Discount),
                StatusId = (int)SalesOrderStatusesEnum.ISSUED,
                TotalPrice = salesOrderDto.SalesOrderItems
                .Sum(item =>
                 item.Quantity * products.Where(product => product.Sku == item.Sku).FirstOrDefault().ProductPrices.SellingPrice),
            };
            salesOrdersRepo.CreateAsync(salesOrder);
            salesOrdersRepo.SaveChangesAsync();

            foreach (SalesOrderItemDto salesOrderItem in salesOrderDto.SalesOrderItems)
            {
                Product product = products.FirstOrDefault(p => p.Sku == salesOrderItem.Sku);
                if (product != null)
                {
                    SalesOrderProduct salesOrderProduct = new SalesOrderProduct()
                    {
                        SellingPricePerItem = product.ProductPrices.SellingPrice - product.ProductPrices.Discount,
                        CostPricePerItem = product.ProductPrices.CostPrice,
                        DiscountPerItem = product.ProductPrices.Discount,
                        SellingPricePerItemBeforeDiscount = product.ProductPrices.SellingPrice,
                        Sku = product.Sku,
                        Quantity = salesOrderItem.Quantity,
                        SalesOrder = salesOrder,
                        SalesOrderId = salesOrder.Id
                    };
                    salesOrder.SalesOrderProducts.Add(salesOrderProduct);
                }
            }
            salesOrderProductsRepo.BulkCreateAsync(salesOrder.SalesOrderProducts);
            salesOrdersRepo.SaveChangesAsync();
            return salesOrder;
        }
    }
}