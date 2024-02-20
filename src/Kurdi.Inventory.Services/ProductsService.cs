using System.Linq;
using Kurdi.Inventory.Core.Contracts.Repositories;
using Kurdi.Inventory.Core.Entities.ProductAggregate;

namespace Kurdi.Inventory.Services
{
    public class ProductsService(IProductsRepo productsRepo)
    {
        public void Reserve(string sku, int quantity)
        {
            Product product = productsRepo.Find(s => s.Sku == sku).FirstOrDefault();
            if (product != null)
            {
                product.ProductQuantity.ReserveStock(quantity);
                productsRepo.Update(product);
            }

            productsRepo.SaveChangesAsync();
        }

        public void CancelReservation(string sku, int quantity)
        {
            Product product = productsRepo.Find(s => s.Sku == sku).FirstOrDefault();
            if (product != null)
            {
                product.ProductQuantity.CancelReservation(quantity);
                productsRepo.Update(product);
            }

            productsRepo.SaveChangesAsync();
        }

        public void AddStock(string sku, int quantity, double addedItemsCost)
        {
            Product product = productsRepo.Find(s => s.Sku == sku).FirstOrDefault();

            //update quantities
            if (product != null)
            {
                product.ProductQuantity.AddStock(quantity);

                //update stock cost
                double costOfAllProductStock = product.ProductQuantity.TotalStock * product.ProductPrices.CostPrice;
                double costOfAllProductStockAfterAdding = costOfAllProductStock + addedItemsCost;
                product.ProductPrices.CostPrice = costOfAllProductStockAfterAdding / product.ProductQuantity.TotalStock;

                productsRepo.Update(product);
            }

            productsRepo.SaveChangesAsync();
        }

        public void Update(Product product)
        {
            productsRepo.Update(product);
            productsRepo.SaveChangesAsync();
        }

        public void Create(Product product)
        {
            productsRepo.CreateAsync(product);
            productsRepo.SaveChangesAsync();
        }

        public void Delete(string sku)
        {
            Product product = productsRepo.Find(stock => stock.Sku == sku).FirstOrDefault();
            productsRepo.Delete(product);
            productsRepo.SaveChangesAsync();
        }

    }
}