using FluentValidation;
using FluentValidation.Results;
using Kurdi.Inventory.Core.Contracts.Repositories;
using Kurdi.Inventory.Core.Entities.CategoryAggregate;
using Kurdi.SharedKernel;
using Kurdi.SharedKernel.Result;
using Microsoft.EntityFrameworkCore;

namespace Kurdi.Inventory.UseCases.ProductsManagement.Categories.ListCategories;

public class ListCategoriesHandler(ICategoriesRepo categoriesRepo, IValidator<ListCategoriesRequest> validator)
    : IQueryHandler<ListCategoriesQuery, Result<IEnumerable<ListCategoriesItemResponse>>>
{
    public async Task<Result<IEnumerable<ListCategoriesItemResponse>>> Handle(ListCategoriesQuery request, CancellationToken cancellationToken)
    {
        ValidationResult validationResult = await validator.ValidateAsync(request.ListCategoriesRequest, cancellationToken);
        if (!validationResult.IsValid)
        {
            return Result.Error(validationResult.Errors.Select(err => err.ErrorMessage).ToArray());
        }

        IQueryable<Category> categories = categoriesRepo.FindAll();


        categories = categories
            .Include(s => s.CategoryDetails);


        if (request.ListCategoriesRequest.Activation)
        {
            categories = categories.Where(category => category.Activation == request.ListCategoriesRequest.Activation);
        }
        if (!string.IsNullOrEmpty(request.ListCategoriesRequest.Query))
        {

            categories = categories.Where(category =>
                category.Name == request.ListCategoriesRequest.Query
                || category.CategoryDetails.Any(categoryDetails => categoryDetails.CategoryName.Contains(request.ListCategoriesRequest.Query))
            );
        }

        var pagedInfo = new PagedInfo(
                    request.ListCategoriesRequest.PageNumber
                    , request.ListCategoriesRequest.PageSize
                    , (int)Math.Ceiling(categories.Count() / (double)request.ListCategoriesRequest.PageSize)
                    , categories.Count());


        var categoriesResponse = categories
            .Skip((request.ListCategoriesRequest.PageNumber - 1) * request.ListCategoriesRequest.PageSize)
            .Take(request.ListCategoriesRequest.PageSize)
            .Select(category => new ListCategoriesItemResponse()
            {
                Name = category.Name,
                HasParent = category.HasParent,
                ParentName = category.ParentName,
                CategoryDetails = category.CategoryDetails,
                Activation = category.Activation
            });



        var result = new PagedResult<IEnumerable<ListCategoriesItemResponse>>(pagedInfo, categoriesResponse);
        return await Task.FromResult(result);


    }
}
