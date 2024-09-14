using System;
using System.Collections.Generic;

namespace Kernal_Travel_Guide.Models;

public partial class TouristSpot
{
    public int TouristSpotId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Location { get; set; } = null!;

    public string Category { get; set; } = null!;

    public string ImageUrl { get; set; } = null!;

    public int PriceRange { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
