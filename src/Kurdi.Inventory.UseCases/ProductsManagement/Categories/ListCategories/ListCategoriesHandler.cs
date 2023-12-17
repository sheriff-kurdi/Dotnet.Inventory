using FluentValidation;
using FluentValidation.Results;
using Kurdi.Inventory.Core.Contracts.Repositories;
using Kurdi.Inventory.Core.Entities.CategoryAggregate;
using Kurdi.SharedKernel;
using Kurdi.SharedKernel.Result;
using Microsoft.EntityFrameworkCore;

namespace Kurdi.Inventory.UseCases.ProductsManagement.Categories;

public class ListCategoriesHandler : IQueryHandler<ListCategoriesQuery, Result<IEnumerable<ListCategoriesItemResponse>>>
{
    private readonly ICategoriesRepo _categoriesRepo;
    private readonly IValidator<ListCategoriesRequest> _validator;

    public ListCategoriesHandler(ICategoriesRepo categoriesRepo, IValidator<ListCategoriesRequest> validator)
    {
        _categoriesRepo = categoriesRepo;
        _validator = validator;
    }
    public async Task<Result<IEnumerable<ListCategoriesItemResponse>>> Handle(ListCategoriesQuery request, CancellationToken cancellationToken)
    {
        ValidationResult validationResult = await _validator.ValidateAsync(request.listCategoriesRequest);
        if (!validationResult.IsValid)
        {
            return Result.Error(validationResult.Errors.Select(err => err.ErrorMessage).ToArray());
        }

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
                || category.CategoryDetails.Any(categoryDetails => categoryDetails.CategoryName.Contains(request.listCategoriesRequest.Query))
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
                HasParent = category.HasParent,
                ParentName = category.ParentName,
                CategoryDetails = category.CategoryDetails,
                Activation = category.Activation
            });



        var result = new PagedResult<IEnumerable<ListCategoriesItemResponse>>(pagedInfo, categoriesResponse);
        return await Task.FromResult(result);


    }
}
