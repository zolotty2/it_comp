using it_comp.Modeks;
using System;
using System.Collections.Generic;

namespace it_comp;

public partial class User
{
    public int Id { get; set; }

    public string Fio { get; set; } = null!;

    public int PositionId { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual Role Position { get; set; } = null!;
}
