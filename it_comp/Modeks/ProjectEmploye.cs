using System;
using System.Collections.Generic;

namespace it_comp.Modeks;

public partial class ProjectEmploye
{
    public int Id { get; set; }

    public int ProjectTypesId { get; set; }

    public string Eployee { get; set; } = null!;

    public int RoleId { get; set; }

    public virtual ProjectType ProjectTypes { get; set; } = null!;

    public virtual Role Role { get; set; } = null!;
}
