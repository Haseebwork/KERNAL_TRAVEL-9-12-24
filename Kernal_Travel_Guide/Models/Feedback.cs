using System;
using System.Collections.Generic;

namespace Kernal_Travel_Guide.Models;

public partial class Feedback
{
    public int FeedbackId { get; set; }

    public int? UserId { get; set; }

    public DateTime? Date { get; set; }

    public string? Message { get; set; }

    public int? Rating { get; set; }

    public virtual User? User { get; set; }
}
