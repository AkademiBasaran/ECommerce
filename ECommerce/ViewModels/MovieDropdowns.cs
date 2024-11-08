﻿using ECommerce.Models;

namespace ECommerce.ViewModels;

public class MovieDropdowns
{
    public MovieDropdowns()
    {
        Producers = new List<Producer>();
        Cinemas = new List<Cinema>();
        Actors = new List<Actor>();
    }
    public List<Producer> Producers { get; set; }
    public List<Actor> Actors { get; set; }
    public List<Cinema> Cinemas { get; set; }
}