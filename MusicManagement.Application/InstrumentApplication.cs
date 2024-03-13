using Framework.Application;
using Framework.Infrastructure;
using MusicManagement.Application.Contracts.Contracts;
using MusicManagement.Application.Contracts.ViewModels.InstrumentViewModel;
using MusicManagement.Domain.Entity;
using MusicManagement.Domain.IRepository;
using MusicManagement.Infrastructure.EfCore.Repository;

namespace MusicManagement.Application;

public class InstrumentApplication : IInstrumentApplication
{

    private readonly IInstrumentRepository _instrumentRepository;

    public InstrumentApplication(IInstrumentRepository instrumentRepository)
    {
        _instrumentRepository = instrumentRepository;
    }

    public async Task<OperationResult> Add(CreateInstrumentViewModel? instrument)
    {
        if (instrument is null)
            return new OperationResult().Failed(OperationMessage.Null);

        if (!await _instrumentRepository.AnyEntityAsync(e => e.Title.Contains(instrument.Title)))
            return new OperationResult().Failed(OperationMessage.NotFound);

        var model = new Instrument(instrument.Title);
        var add = _instrumentRepository.AddEntity(model);
        if (add != DbState.Added)
            return new OperationResult().Failed(OperationMessage.FailedAdd);

        return (await _instrumentRepository.SaveChangesAsync()).Parse(OperationMessage.Add);
    }

    public async Task<EditInstrumentViewModel> Edit(long id)
    {
        if (!await _instrumentRepository.AnyEntityAsync(e => e.Id == id))
            return new EditInstrumentViewModel();

        var find = await _instrumentRepository.FindAsync<EditInstrumentViewModel>
            (e => e.Id == id, e => new EditInstrumentViewModel()
            {
                Title = e.Title,
                Id = e.Id,
            }, null);
        return find;
    }

    public async Task<OperationResult> Edit(EditInstrumentViewModel? instrument)
    {
        if (instrument is null)
            return new OperationResult().Failed(OperationMessage.Null);

        if (!await _instrumentRepository.AnyEntityAsync(e => e.Id == instrument.Id))
            return new OperationResult().Failed(OperationMessage.NotFound);

        var find = await _instrumentRepository.FindAsync(e => e.Id == instrument.Id);
        find?.Edit(instrument.Title);
        return new OperationResult().Succeeded(OperationMessage.Edit);
    }

    public async Task<List<InstrumentViewModel>> ToList()
    {
        CancellationToken token = new CancellationToken();
        return  await _instrumentRepository.ToViewsAsync(null,
            instrument => new InstrumentViewModel()
            {
                Id = instrument.Id,
                Title = instrument.Title
            }, token);
    }

    public async Task<OperationResult> ChangeState(long id)
    {
        throw new NotImplementedException();
    }
}