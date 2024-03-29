﻿namespace MusicManagement.Application.Contracts.ViewModels.AudioViewModel;

public class AudioViewModel
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string State { get; set; }
    public string Album { get; set; }
    public string Category { get; set; }
}