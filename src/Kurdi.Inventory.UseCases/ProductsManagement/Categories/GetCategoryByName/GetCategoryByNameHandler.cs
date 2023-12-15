using Kurdi.Inventory.Core.Contracts.Repositories;
using Kurdi.SharedKernel;
using Kurdi.SharedKernel.Result;
using Microsoft.EntityFrameworkCore;

namespace Kurdi.Inventory.UseCases.ProductsManagement.Categories;

public class GetCategoryByNameHandler : IQueryHandler<GetCategoryByNameQuery, Result<GetCategoryByNameResponse>>
{
    private readonly ICategoriesRepo _categoriesRepo;

    public GetCategoryByNameHandler(ICategoriesRepo categoriesRepo)
    {
        _categoriesRepo = categoriesRepo;
    }

    public async Task<Result<GetCategoryByNameResponse>> Handle(GetCategoryByNameQuery request, CancellationToken cancellationToken)
    {
        GetCategoryByNameResponse? categoryResponse = await _categoriesRepo
        .Find(category => category.Name == request.name)
        .Include(category => category.CategoryDetails).Select(category => new GetCategoryByNameResponse()
        {
            Name = category.Name,
            HasParent = category.HasParent,
            ParentName = category.ParentName,
            CategoryDetails = category.CategoryDetails,
            Activation = category.Activation

        }).FirstOrDefaultAsync();


        if (categoryResponse == null) return Result.NotFound();

        return Result.Success<GetCategoryByNameResponse>(categoryResponse);
    }
}
