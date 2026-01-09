using System;
using System.Collections.Generic;

namespace MVCProject.Models;

public partial class Fee
{
    public int FeeId { get; set; }

    public int? ClassId { get; set; }

    public int? FeesAmount { get; set; }

    public virtual Class? Class { get; set; }
}
