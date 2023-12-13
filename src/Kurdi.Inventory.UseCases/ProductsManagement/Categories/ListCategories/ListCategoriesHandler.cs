using Kurdi.Inventory.Core.Contracts.Repositories;
using Kurdi.Inventory.Core.Entities.CategoryAggregate;
using Kurdi.Inventory.Core.Entities.ProductAggregate;
using Kurdi.SharedKernel;
using Kurdi.SharedKernel.Result;
using Microsoft.EntityFrameworkCore;

namespace Kurdi.Inventory.UseCases.ProductsManagement.Categories;

public class ListCategoriesHandler : IQueryHandler<ListCategoriesQuery, Result<IEnumerable<ListCategoriesItemResponse>>>
{
    private readonly ICategoriesRepo _categoriesRepo;

    public ListCategoriesHandler(ICategoriesRepo categoriesRepo)
    {
        _categoriesRepo = categoriesRepo;
    }
    public async Task<Result<IEnumerable<ListCategoriesItemResponse>>> Handle(ListCategoriesQuery request, CancellationToken cancellationToken)
    {

        IQueryable<Category> categories = _categoriesRepo.FindAll();


        categories = categories
            .Include(s => s.CategoryDetails);


        if (request.listCategoriesRequest.Activation)
        {
            categories = categories.Where(category => category.Activation == request.listCategoriesRequest.Activation);
        }
        if (!string.IsNullOrEmpty(request.listCategoriesRequest.Query))
        {

            categories = categories.Where(category =>
                category.Name == request.listCategoriesRequest.Query
                || category.CategoryDetails.Any(categoryDetails => categoryDetails.Name.Contains(request.listCategoriesRequest.Query))
            );
        }

        var pagedInfo = new PagedInfo(
                    request.listCategoriesRequest.PageNumber
                    , request.listCategoriesRequest.PageSize
                    , (int)Math.Ceiling(categories.Count() / (double)request.listCategoriesRequest.PageSize)
                    , categories.Count());


        var categoriesResponse = categories
            .Skip((request.listCategoriesRequest.PageNumber - 1) * request.listCategoriesRequest.PageSize)
            .Take(request.listCategoriesRequest.PageSize)
            .Select(category => new ListCategoriesItemResponse()
            {
                Name = category.Name,
                IsParent = category.IsParent,
                ParentName = category.ParentName,
                CategoryDetails = category.CategoryDetails,
                Activation = category.Activation
            });



        var result = new PagedResult<IEnumerable<ListCategoriesItemResponse>>(pagedInfo, categoriesResponse);
        return await Task.FromResult(result);


    }
}
