using System;
using System.Collections.Generic;

namespace DBAccess.Models;

public partial class TechnicalEmployeeDetail
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

    public virtual ICollection<PhysicalEmployeeDetail> PhysicalEmployeeDetails { get; } = new List<PhysicalEmployeeDetail>();
}
