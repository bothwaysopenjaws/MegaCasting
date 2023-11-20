using System;
using System.Collections.Generic;

namespace MegaCasting.DBLib.Class;

public partial class Mcuser
{
    public long Identifier { get; set; }

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual CustomerContact? CustomerContact { get; set; }

    public virtual SalaryMan? SalaryMan { get; set; }
}
