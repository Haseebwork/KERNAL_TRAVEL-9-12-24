using System;
using System.Collections.Generic;

namespace Kernal_Travel_Guide.Models;

public partial class Reservation
{
    public int ReservationId { get; set; }

    public int UserId { get; set; }

    public int? TouristSpotId { get; set; }

    public int? HotelId { get; set; }

    public int? RestaurantId { get; set; }

    public int? ResortId { get; set; }

    public int? TravelInfoId { get; set; }

    public DateTime? ReservationDate { get; set; }

    public int? NumberOfPeople { get; set; }

    public string? SpecialRequests { get; set; }

    public virtual Hotel? Hotel { get; set; }

    public virtual Resort? Resort { get; set; }

    public virtual Restaurant? Restaurant { get; set; }

    public virtual TouristSpot? TouristSpot { get; set; }

    public virtual TravelInfo? TravelInfo { get; set; }

    public virtual User User { get; set; } = null!;
}
