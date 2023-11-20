using System;
using System.Collections.Generic;

namespace MegaCasting.DBLib.Class;

public partial class SalaryMan
{
    public long Identifier { get; set; }

    public virtual Mcuser IdentifierNavigation { get; set; } = null!;
}
