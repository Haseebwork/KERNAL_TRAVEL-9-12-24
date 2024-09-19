using System;
using System.Collections.Generic;

namespace Kernal_Travel_Guide.Models;

public partial class Hotel
{
    public int HotelId { get; set; }

    public string Name { get; set; } = null!;

    public string? Location { get; set; }

    public string? Description { get; set; }

    public string? PriceRange { get; set; }

    public double? Rating { get; set; }

    public string? ImageUrl { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
