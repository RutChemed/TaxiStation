namespace Services.DTO
{
    public class PhysicalEmployeeDetailDTO
    {
        public int Id { get; set; }

        public int Employee { get; set; }

        public bool? Available { get; set; }

        public int? NumPlaces { get; set; }

        public decimal Latitudes { get; set; }

        public decimal Longitudes { get; set; }

        public virtual ICollection<DriverTemporaryLocationDTO> DriverTemporaryLocations { get; } = new List<DriverTemporaryLocationDTO>();

        public virtual TechnicalEmployeeDetail EmployeeNavigation { get; set; } = null!;

        public virtual ICollection<HistoryTravelDTO> HistoryTravels { get; } = new List<HistoryTravelDTO>();

        public virtual ICollection<OrderingTravelDTO> OrderingTravels { get; } = new List<OrderingTravelDTO>();
    }
}
