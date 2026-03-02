using System;
using System.Collections.Generic;

namespace it_comp.Modeks;

public partial class ProjectType
{
    public int Id { get; set; }

    public string TypeName { get; set; } = null!;

    public virtual ICollection<ProjectEmploye> ProjectEmployes { get; set; } = new List<ProjectEmploye>();
}
