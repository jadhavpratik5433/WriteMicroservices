using System;
using System.Collections.Generic;

namespace MVCProject.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string? Name { get; set; }

    public DateOnly? Dob { get; set; }

    public string? Gender { get; set; }

    public long? Mobile { get; set; }

    public string? RollNo { get; set; }

    public int? ClassId { get; set; }

    public virtual Class? Class { get; set; }
}
