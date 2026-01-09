using System;
using System.Collections.Generic;

namespace MVCProject.Models;

public partial class Teacher
{
    public int TeacherId { get; set; }

    public string? Name { get; set; }

    public DateOnly? Dob { get; set; }

    public string? Gender { get; set; }

    public long? Mobile { get; set; }

    public string? Email { get; set; }

    public string? Adderss { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; } = new List<TeacherSubject>();
}
