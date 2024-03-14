using Framework.Application;
using MusicManagement.Application.Contracts.ViewModels.CategoryViewModels;

namespace MusicManagement.Application.Contracts.Contracts;

public interface ICategoryApplication
{
    Task<OperationResult> Add(CreateCategoryViewModel? category);
    Task<EditCategoryViewModel> Edit(string slug);
    Task<OperationResult> Edit(EditCategoryViewModel? category);
    Task<List<CategoryViewModel>> ToList();
    Dictionary<long, string> Categories();
    Task<OperationResult> ChangeState(string slug);
}