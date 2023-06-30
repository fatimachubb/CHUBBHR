using CHUBBHR.Migrations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CHUBBHR.Models;

public partial class Archivos
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public byte[]? Contenido { get; set; }

    public int UsuarioId { get; set; }


    public virtual Usuario? Usuario { get; set; }


  


}
