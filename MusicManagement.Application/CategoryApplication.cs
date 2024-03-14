using Framework.Application;
using Framework.Infrastructure;
using MusicManagement.Application.Contracts.Contracts;
using MusicManagement.Application.Contracts.ViewModels.CategoryViewModels;
using MusicManagement.Domain.Entity;
using MusicManagement.Domain.IRepository;

namespace MusicManagement.Application;

public class CategoryApplication : ICategoryApplication
{

    private readonly ICategoryRepository _categoryRepository;

    public CategoryApplication(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<OperationResult> Add(CreateCategoryViewModel? category)
    {
        if (category is not null)
            return new OperationResult().Failed(OperationMessage.Null);

        if (await _categoryRepository.AnyEntityAsync(e => e.Slug.Contains(category.Slug)))
            return new OperationResult().Failed(OperationMessage.DuplicatedSlug);

        var model = new Category(category.Title, category.Slug);
        var add = _categoryRepository.AddEntity(model);

        if (add != DbState.Added)
            return new OperationResult().Failed(OperationMessage.FailedAdd);

        return (await _categoryRepository.SaveChangesAsync()).Parse(OperationMessage.Add);
    }

    public async Task<EditCategoryViewModel> Edit(string slug)
    {
        if (string.IsNullOrWhiteSpace(slug))
            return new EditCategoryViewModel();

        if (!await _categoryRepository.AnyEntityAsync(e => e.Slug.Contains(slug)))
            return new EditCategoryViewModel();

        var find = await _categoryRepository
            .FindAsync<EditCategoryViewModel>(e => e.Slug.Contains(slug),
            e => new EditCategoryViewModel()
            {
                Id = e.Id,
                Slug = e.Slug,
                Title = e.Title
            }, null);

        if (find is null)
            return new EditCategoryViewModel();

        return find;
    }

    public async Task<OperationResult> Edit(EditCategoryViewModel? category)
    {
        if (category is null)
            return new OperationResult().Failed(OperationMessage.Null);

        if (!await _categoryRepository.AnyEntityAsync(e => e.Slug.Contains(category.Slug)))
            return new OperationResult().Failed(OperationMessage.NotFound);

        var find = await _categoryRepository.FindAsync(e => e.Id == category.Id);

        find?.Edit(category.Title, category.Slug);

        return new OperationResult().Succeeded(OperationMessage.Edit);
    }

    public async Task<List<CategoryViewModel>> ToList()
    {
        CancellationToken token = new CancellationToken();
        var list = await _categoryRepository.ToViewsAsync(null, e => new CategoryViewModel()
        {
            Id = e.Id,
            Title = e.Title
        }, token);
        return list ?? new List<CategoryViewModel>(0);
    }

    public Dictionary<long, string> Categories()
    {
        Dictionary<long,string>? categories = _categoryRepository?.Categories();
        if (categories is null)
            return new Dictionary<long, string>()
            {
                {-1,"Null"}
            };
        return categories;
    }

    public async Task<OperationResult> ChangeState(string slug)
    {
        if (string.IsNullOrWhiteSpace(slug))
            return new OperationResult().Failed(OperationMessage.Null);

        if (!await _categoryRepository.AnyEntityAsync(e => e.Slug.Contains(slug)))
            return new OperationResult().Failed(OperationMessage.NotFound);

        var find = await _categoryRepository.FindAsync(e => e.Slug == slug);
        find?
            .ChangeStatus();

        return new OperationResult().Succeeded(OperationMessage.Done);
    }
}