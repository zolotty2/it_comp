using System;
using System.Collections.Generic;

namespace it_comp.Modeks;

public partial class Role
{
    public int Id { get; set; }

    public string RoleName { get; set; } = null!;

    public virtual ICollection<ProjectEmploye> ProjectEmployes { get; set; } = new List<ProjectEmploye>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
