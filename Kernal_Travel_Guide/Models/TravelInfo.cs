using System;
using System.Collections.Generic;

namespace Kernal_Travel_Guide.Models;

public partial class TravelInfo
{
    public int TravelInfoId { get; set; }

    public string? ModeOfTransport { get; set; }

    public string? Description { get; set; }

    public string? Availability { get; set; }

    public string? PriceRange { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
