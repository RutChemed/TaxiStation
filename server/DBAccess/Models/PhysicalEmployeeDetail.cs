namespace DBAccess.Models;

public partial class PhysicalEmployeeDetail
{
    public int Id { get; set; }

    public int Employee { get; set; }

    public bool? Available { get; set; }

    public int? NumPlaces { get; set; }

    public decimal Latitudes { get; set; }

    public decimal Longitudes { get; set; }

    public virtual ICollection<DriverTemporaryLocation> DriverTemporaryLocations { get; } = new List<DriverTemporaryLocation>();

    public virtual TechnicalEmployeeDetail EmployeeNavigation { get; set; } = null!;

    public virtual ICollection<HistoryTravel> HistoryTravels { get; } = new List<HistoryTravel>();

    public virtual ICollection<OrderingTravel> OrderingTravels { get; } = new List<OrderingTravel>();
}
