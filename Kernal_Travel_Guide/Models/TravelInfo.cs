using System;
using System.Collections.Generic;

namespace Kernal_Travel_Guide.Models;

public partial class TravelInfo
{
    public int TravelInfoId { get; set; }

    public string ModeOfTransport { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Availability { get; set; } = null!;

    public string PriceRange { get; set; } = null!;

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
