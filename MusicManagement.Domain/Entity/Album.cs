﻿using Framework.Domain;
using MusicManagement.Domain.Enums;

namespace MusicManagement.Domain.Entity;

public class Album : EntityBase
{
    public string Title { get; private set; }
    public string Slug { get; private set; }
    public DateTime ReleasedDate { get; private set; }
    public string ImagePath { get; private set; }
    public State State { get; private set; }

    //Relation
    public Category AlbumCategory { get; private set; }
    public long AlbumCategoryId { get; private set; }

    public Band Band { get; private set; }
    public long? BandId { get; set; }

    public ICollection<Audio> Audios { get; set; }

    protected Album()
    {

    }
    public Album(string title, string slug, DateTime releasedDate,
        string imagePath,
        long categoryId, long? bandId)
    {
        Title = title;
        Slug = slug;
        ReleasedDate = releasedDate;
        ImagePath = imagePath;
        AlbumCategoryId = categoryId;
        BandId = bandId;
        State = State.Active;
    }

    public void Edit(string title, DateTime releasedDate, string imagePath,
        long categoryId, long? bandId)
    {
        Title = title;
        ReleasedDate = releasedDate;

        if (!string.IsNullOrWhiteSpace(imagePath))
            ImagePath = imagePath;

        AlbumCategoryId = categoryId;
        BandId = bandId;
    }

    public override void ChangeStatus()
    {
        State = State is State.Active ? State.UnActive : State.Active;
    }
}