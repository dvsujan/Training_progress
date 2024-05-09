using System;
using System.Collections.Generic;

namespace ClinicDALLibrary.Model;

public partial class Appointment
{
    public int Id { get; set; }

    public DateTime? Date { get; set; }

    public string? Reason { get; set; }

    public int? DocId { get; set; }

    public int? PatId { get; set; }

    public virtual Doctor? Doc { get; set; }

    public virtual Patient? Pat { get; set; }
}
