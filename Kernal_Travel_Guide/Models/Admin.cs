using System;
using System.Collections.Generic;

namespace Kernal_Travel_Guide.Models;

public partial class Admin
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;
}
