using ArticleManagement.Application.Contracts.ViewModels.TagViewModels;
using Framework.Application;

namespace ArticleManagement.Application.Contracts.Contracts;

public interface ITagApplication
{
    Task<OperationResult> Add(CreateTagViewModel? tag);
    Task<OperationResult> Edit(EditTagViewModel? tag);
    Task<EditTagViewModel?> Edit(long id);
    Task<List<TagViewModel>> ToList();
}