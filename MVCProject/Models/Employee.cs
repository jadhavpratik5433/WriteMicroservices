using System;
using System.Collections.Generic;

namespace MVCProject.Models;

public partial class Employee
{
    public int Empid { get; set; }

    public string? Empname { get; set; }

    public string? Gender { get; set; }

    public int? Salary { get; set; }

    public string? City { get; set; }

    public string? Depart { get; set; }

    public string? Email { get; set; }
}
