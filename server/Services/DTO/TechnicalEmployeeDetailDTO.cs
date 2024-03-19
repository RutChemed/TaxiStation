namespace Services.DTO
{
    public class TechnicalEmployeeDetailDTO
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public DateTime? DepartureDate { get; set; }

        public int Id { get; set; }

        public string? Role { get; set; }

        public decimal AddressLatitudes { get; set; }

        public decimal AddressLongitudes { get; set; }

        public virtual ICollection<PhysicalEmployeeDetailDTO> PhysicalEmployeeDetails { get; } = new List<PhysicalEmployeeDetailDTO>();
    }
}
