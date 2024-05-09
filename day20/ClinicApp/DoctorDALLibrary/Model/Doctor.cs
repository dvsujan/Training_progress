﻿using System;
using System.Collections.Generic;

namespace ClinicDALLibrary.Model;

public partial class Doctor
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Specialization { get; set; }

    public DateTime? Dob { get; set; }

    public DateTime? Age { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
