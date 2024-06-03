namespace Services.DTO
{
    public class PhysicalEmployeeDetailDTO
    {
        public int? Id { get; set; }

        public int Employee { get; set; }

        public bool? Available { get; set; }

        public int? NumPlaces { get; set; }

        public decimal Latitudes { get; set; }

        public decimal Longitudes { get; set; }

    }
}
