using System.Linq;
using Kurdi.Inventory.Core.Contracts.Repositories;
using Kurdi.Inventory.Core.Entities.ProductAggregate;

namespace Kurdi.Inventory.Services
{
    public class ProductsService
    {
        private readonly IProductsRepo _productsRepo;
        public ProductsService(IProductsRepo productsRepo)
        {
            this._productsRepo = productsRepo;

        }

        public void Reserve(string sku, int quantity)
        {
            Product product = _productsRepo.Find(s => s.SKU == sku).FirstOrDefault();
            product.ProductQuantity.ReserveStock(quantity);
            this._productsRepo.Update(product);
            this._productsRepo.SaveChangesAsync();
        }

        public void CancelReservation(string sku, int quantity)
        {
            Product product = _productsRepo.Find(s => s.SKU == sku).FirstOrDefault();
            product.ProductQuantity.CancelReservation(quantity);
            this._productsRepo.Update(product);
            this._productsRepo.SaveChangesAsync();
        }

        public void AddStock(string sku, int quantity, double addedItemsCost)
        {
            Product product = _productsRepo.Find(s => s.SKU == sku).FirstOrDefault();

            //update quantities
            product.ProductQuantity.AddStock(quantity);

            //update stock cost
            double costOfAllProductStock = product.ProductQuantity.TotalStock * product.ProductPrices.CostPrice;
            double costOfAllProductStockAfterAdding = costOfAllProductStock + addedItemsCost;
            product.ProductPrices.CostPrice = costOfAllProductStockAfterAdding / product.ProductQuantity.TotalStock;

            this._productsRepo.Update(product);
            this._productsRepo.SaveChangesAsync();
        }

        public void Update(Product product)
        {
            this._productsRepo.Update(product);
            this._productsRepo.SaveChangesAsync();
        }

        public void Create(Product product)
        {
            this._productsRepo.CreateAsync(product);
            this._productsRepo.SaveChangesAsync();
        }

        public void Delete(string sku)
        {
            Product product = this._productsRepo.Find(stock => stock.SKU == sku).FirstOrDefault();
            _productsRepo.Delete(product);
            _productsRepo.SaveChangesAsync();
        }

    }
}