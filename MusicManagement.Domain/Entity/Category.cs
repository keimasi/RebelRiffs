﻿using Framework.Domain;

namespace MusicManagement.Domain.Entity;

public class Category : EntityBase
{
    public string Title { get; private set; }
    public string Slug { get; private set; }

    //Relation
    public ICollection<Album> Albums { get; private set; } 
    public ICollection<Band> Bands { get; private set; }

    protected Category() { }
    public Category(string title, string slug)
    {
        Title = title;
        Slug = slug;
    }
    public void Edit(string title)
    {
        Title = title;
    }
}