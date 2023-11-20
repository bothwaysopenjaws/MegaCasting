using System;
using System.Collections.Generic;

namespace MegaCasting.DBLib.Class;

public partial class CustomerContact
{
    public long Identifier { get; set; }

    public long IdentifierCustomer { get; set; }

    public virtual Customer IdentifierCustomerNavigation { get; set; } = null!;

    public virtual Mcuser IdentifierNavigation { get; set; } = null!;
}
