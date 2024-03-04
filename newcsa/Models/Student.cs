using System;
using System.Collections.Generic;

namespace newcsa.Models;

public partial class Student
{
    public int StdId { get; set; }

    public string? Password { get; set; }

    public string? Name { get; set; }

    public string? Gender { get; set; }

    public int? YOP { get; set; }

    public string? Branch { get; set; }

    public int? Marks { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Meassage> Meassages { get; set; } = new List<Meassage>();
}
