using System;
using System.Collections.Generic;

namespace DBAccess.Models;

public partial class HistoryTravel
{
    public int Id { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public string ExitLatitudes { get; set; } = null!;

    public string ExitLongitudes { get; set; } = null!;

    public string TargetLatitudes { get; set; } = null!;

    public string TargetLongitudes { get; set; } = null!;

    public int? PassengersNum { get; set; }

    public int Driver { get; set; }

    public string ClientPhone { get; set; } = null!;

    public virtual PhysicalEmployeeDetail DriverNavigation { get; set; } = null!;
}
