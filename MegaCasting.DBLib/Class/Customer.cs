using System;
using System.Collections.Generic;

namespace MegaCasting.DBLib.Class;

public partial class Customer
{
    public long Identifier { get; set; }

    public string? Name { get; set; }

    public string? AddressRoad { get; set; }

    public string? AddressCity { get; set; }

    public string? AddressZipCode { get; set; }

    public string? AddressComplement { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<CustomerContact> CustomerContacts { get; set; } = new List<CustomerContact>();

    public virtual ICollection<Offer> Offers { get; set; } = new List<Offer>();
}
