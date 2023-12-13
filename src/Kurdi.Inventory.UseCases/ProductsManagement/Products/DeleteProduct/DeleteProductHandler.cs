﻿using Kurdi.Inventory.Core.Contracts.Repositories;
using Kurdi.Inventory.Core.Entities.ProductAggregate;
using Kurdi.Inventory.UseCases.ProductsManagement.Products;
using Kurdi.SharedKernel;
using Kurdi.SharedKernel.Result;
using MediatR;

namespace Kurdi.Inventory.UseCases;

public class DeleteProductHandler : ICommandHandler<DeleteProductCommand, Result<string>>
{

    private readonly IProductsRepo _productsRepo;

    public DeleteProductHandler(IProductsRepo productsRepo)
    {
        _productsRepo = productsRepo;
    }

    public async Task<Result<string>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        Product? product = _productsRepo.Find(stock => stock.SKU == request.sku).FirstOrDefault();
        if(product is null) return Result.NotFound();
        
        _productsRepo.Delete(product);
        await _productsRepo.SaveChangesAsync();
        return Result.Success<string>(request.sku);    
    }


}