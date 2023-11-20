using System;
using System.Collections.Generic;

namespace MegaCasting.DBLib.Class;

public partial class Activity
{
    public long Identifier { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<ActivityArtist> ActivityArtists { get; set; } = new List<ActivityArtist>();
}
