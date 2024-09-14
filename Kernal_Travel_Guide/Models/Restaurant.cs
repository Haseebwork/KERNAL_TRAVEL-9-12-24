using System;
using System.Collections.Generic;

namespace Kernal_Travel_Guide.Models;

public partial class Restaurant
{
    public int RestaurantId { get; set; }

    public string Name { get; set; } = null!;

    public string Location { get; set; } = null!;

    public string CuisineType { get; set; } = null!;

    public string Description { get; set; } = null!;

    public double Rating { get; set; }

    public string ImageUrl { get; set; } = null!;

    public int PriceRange { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
