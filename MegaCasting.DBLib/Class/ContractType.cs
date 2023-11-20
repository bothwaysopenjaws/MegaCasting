using System;
using System.Collections.Generic;

namespace MegaCasting.DBLib.Class;

public partial class ContractType
{
    public long Identifier { get; set; }

    public string Name { get; set; } = null!;

    public string? ShortName { get; set; }

    public virtual ICollection<Offer> Offers { get; set; } = new List<Offer>();
}
