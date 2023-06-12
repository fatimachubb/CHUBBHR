using CHUBBHR.Migrations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CHUBBHR.Models;

public partial class Competencias
{
    [Key]
    public int IdCompetencia { get; set; }
    public int UsuarioId { get; set; }

    public string? Situacion { get; set; }

    public string? Tarea { get; set; }

    public string? Accion { get; set; }

    public string? Resultado { get; set; }

    public string? Comentario { get; set; }

    public int Puntaje { get; set; }

    public virtual Usuario? Usuario { get; set; }


  


}
