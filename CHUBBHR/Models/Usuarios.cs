using CHUBBHR.Migrations;
using System;
using System.Collections.Generic;

namespace CHUBBHR.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public DateTime? Fecha { get; set; }

    public int? PosicionFk { get; set; }

    public virtual Posicion? PosicionFkNavigation { get; set; }

    public virtual ICollection<Competencias> Competencias { get; set; } = new List<Competencias>();


}
