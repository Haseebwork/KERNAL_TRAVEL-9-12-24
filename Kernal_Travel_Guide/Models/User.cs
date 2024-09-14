using System;
using System.Collections.Generic;

namespace Kernal_Travel_Guide.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
 