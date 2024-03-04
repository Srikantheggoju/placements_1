using System;
using System.Collections.Generic;

namespace newcsa.Models;

public partial class Meassage
{
    public int MsgId { get; set; }

    public string? MsgData { get; set; }

    public int? StdId { get; set; }

    public virtual Student? Std { get; set; }
}