﻿using Framework.Application;
using MusicManagement.Application.Contracts.ViewModels.BandViewModels;

namespace MusicManagement.Application.Contracts.Contracts;

public interface IBandApplication
{
    Task<OperationResult> Add(CreateBandViewModel? band);
    Task<EditBandViewModel> Edit(string slug);
    Task<OperationResult> Edit(EditBandViewModel? band);
    Task<List<BandViewModel>> ToList();
    Task<OperationResult> ChangeState(string slug);
}