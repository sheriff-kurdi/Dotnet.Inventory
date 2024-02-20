using Kurdi.Inventory.Core.Contracts.Repositories;
using Kurdi.SharedKernel;
using Kurdi.SharedKernel.Result;
using Microsoft.EntityFrameworkCore;

namespace Kurdi.Inventory.UseCases.ProductsManagement.Categories.GetCategoryByName;

public class GetCategoryByNameHandler(ICategoriesRepo categoriesRepo)
    : IQueryHandler<GetCategoryByNameQuery, Result<GetCategoryByNameResponse>>
{
    public async Task<Result<GetCategoryByNameResponse>> Handle(GetCategoryByNameQuery request, CancellationToken cancellationToken)
    {
        GetCategoryByNameResponse? categoryResponse = await categoriesRepo
        .Find(category => category.Name == request.Name)
        .Include(category => category.CategoryDetails).Select(category => new GetCategoryByNameResponse()
        {
            Name = category.Name,
            HasParent = category.HasParent,
            ParentName = category.ParentName,
            CategoryDetails = category.CategoryDetails,
            Activation = category.Activation

        }).FirstOrDefaultAsync(cancellationToken: cancellationToken);


        if (categoryResponse == null) return Result.NotFound();

        return Result.Success(categoryResponse);
    }
}
