using System;
using System.Collections.Generic;
using System.Linq;
using Kurdi.Inventory.Core.Contracts.Repositories;
using Kurdi.Inventory.Core.DTOs.SalesOrders;
using Kurdi.Inventory.Core.Entities.ProductAggregate;
using Kurdi.Inventory.Core.Entities.SalesOrderAggregate;
using Kurdi.Inventory.Core.Enums;

namespace Kurdi.Inventory.Services
{
    public class SalesOrdersService
    {
        private readonly ISalesOrdersRepo salesOrdersRepo;
        public IProductsRepo ProductsRepo { get; }
        private readonly ISalesOrderProductsRepo salesOrderProductsRepo;
        public SalesOrdersService(ISalesOrdersRepo salesOrdersRepo, IProductsRepo productsRepo, ISalesOrderProductsRepo salesOrderProductsRepo)
        {
            this.salesOrderProductsRepo = salesOrderProductsRepo;
            this.ProductsRepo = productsRepo;
            this.salesOrdersRepo = salesOrdersRepo;

        }
        public SalesOrder CreateOrder(SalesOrderDTO salesOrderDTO)
        {
            List<Product> products = ProductsRepo.FindAll().ToList();
            SalesOrder salesOrder = new SalesOrder()
            {
                Discount = salesOrderDTO.SalesOrderItems
                .Sum(item =>
                 item.Quantity * products.Where(product => product.SKU == item.SKU).FirstOrDefault().ProductPrices.Discount),
                StatusId = (int)SalesOrderStatusesEnum.ISSUED,
                totalPrice = salesOrderDTO.SalesOrderItems
                .Sum(item =>
                 item.Quantity * products.Where(product => product.SKU == item.SKU).FirstOrDefault().ProductPrices.SellingPrice),
            };
            salesOrdersRepo.CreateAsync(salesOrder);
            salesOrdersRepo.SaveChangesAsync();

            foreach (SalesOrderItemDTO salesOrderItem in salesOrderDTO.SalesOrderItems)
            {
                Product product = products.Where(p => p.SKU == salesOrderItem.SKU).FirstOrDefault();
                SalesOrderProduct salesOrderProduct = new SalesOrderProduct()
                {
                    SellingPricePerItem = product.ProductPrices.SellingPrice - product.ProductPrices.Discount,
                    CostPricePerItem = product.ProductPrices.CostPrice,
                    DiscountPerItem = product.ProductPrices.Discount,
                    SellingPricePerItemBeforeDiscount = product.ProductPrices.SellingPrice,
                    SKU = product.SKU,
                    Quantity = salesOrderItem.Quantity,
                    SalesOrder = salesOrder,
                    SalesOrderId = salesOrder.Id
                };
                salesOrder.SalesOrderProducts.Add(salesOrderProduct);
            }
            salesOrderProductsRepo.BulkCreateAsync(salesOrder.SalesOrderProducts);
            salesOrdersRepo.SaveChangesAsync();
            return salesOrder;
        }
    }
}