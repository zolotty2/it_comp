using System;
using System.Collections.Generic;

namespace it_comp.Modeks;

public partial class Proirite
{
    public int Id { get; set; }

    public string PriorityName { get; set; } = null!;

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
