namespace DBAccess.Models;

public partial class DriverTemporaryLocation
{
    public int Id { get; set; }

    public int Driver { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public virtual PhysicalEmployeeDetail DriverNavigation { get; set; } = null!;
}
