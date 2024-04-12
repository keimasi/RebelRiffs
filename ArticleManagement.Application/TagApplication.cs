using ArticleManagement.Application.Contracts.Contracts;
using ArticleManagement.Application.Contracts.ViewModels.TagViewModels;
using ArticleManagement.Domain.Entity;
using ArticleManagement.Domain.IRepository;
using Framework.Application;
using Framework.Infrastructure;

namespace ArticleManagement.Application;

public class TagApplication(ITagRepository tagRepository) : ITagApplication
{

    private readonly OperationResult _message;

    public async Task<OperationResult> Add(CreateTagViewModel? tag)
    {
        if (tag is null)
            return _message.Failed(OperationMessage.Null);

        if (!await tagRepository.AnyEntityAsync(e => e.Title.Contains(tag.Title)))
            return _message.Failed(OperationMessage.Duplicated);

        var model = new Tag(tag.Title);
        var result = tagRepository.AddEntity(model);
        if (result != DbState.Added)
            return _message.Failed(OperationMessage.FailedAdd);

        return (await tagRepository.SaveChangesAsync()).Parse();
    }

    public async Task<OperationResult> Edit(EditTagViewModel? tag)
    {
        if (tag is null)
            return _message.Failed(OperationMessage.Null);

        if (!await tagRepository.AnyEntityAsync(e => e.Title.Contains(tag.Title)))
            return _message.Failed(OperationMessage.NotFound);
        var find = await tagRepository.FindAsync(e => e.Id == tag.Id);
        find?.Edit(tag.Title);

        return (await tagRepository.SaveChangesAsync()).Parse();
    }

    public async Task<EditTagViewModel?> Edit(long id)
    {
        if (await tagRepository.AnyEntityAsync(e => e.Id == id))
            return new EditTagViewModel();
        var find = await tagRepository.FindAsync(e => e.Id == id,
            e => new EditTagViewModel()
            {
                Id = e.Id,
                Title = e.Title
            }, null);
        return find;
    }

    public async Task<List<TagViewModel>> ToList()
    {
        CancellationToken? token = new CancellationToken?();
        var list = await tagRepository.ToViewsAsync(null, e => new TagViewModel()
        {
            Id = e.Id,
            Title = e.Title
        }, token);
        return list ?? new List<TagViewModel>();
    }
}