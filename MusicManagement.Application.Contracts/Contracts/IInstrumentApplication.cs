using Framework.Application;
using MusicManagement.Application.Contracts.ViewModels.InstrumentViewModel;

namespace MusicManagement.Application.Contracts.Contracts;

public interface IInstrumentApplication
{
    Task<OperationResult> Add(CreateInstrumentViewModel? instrument);
    Task<EditInstrumentViewModel> Edit(long id);
    Task<OperationResult> Edit(EditInstrumentViewModel? instrument);
    Task<List<InstrumentViewModel>> ToList();
    Task<OperationResult> ChangeState(long id);
}