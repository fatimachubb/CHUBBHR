using System;
using System.Collections.Generic;

namespace CHUBBHR.Models;

public partial class Posicion
{
    public int Id { get; set; }

    public string? Posicion1 { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
