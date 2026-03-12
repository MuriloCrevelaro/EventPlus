using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EventPlusTorloni.WebAPI.Models;

[Table("Presenca")]
public partial class Presenca
{
    [Key]
    [Column("idPresenca")]
    public Guid IdPresenca { get; set; }

    [Column("Presenca")]
    public bool Presenca1 { get; set; }

    [Column("idTipoUsuario")]
    public Guid? IdTipoUsuario { get; set; }

    [Column("idTipoEvento")]
    public Guid? IdTipoEvento { get; set; }

    [ForeignKey("IdTipoEvento")]
    [InverseProperty("Presencas")]
    public virtual TipoEvento? IdTipoEventoNavigation { get; set; }

    [ForeignKey("IdTipoUsuario")]
    [InverseProperty("Presencas")]
    public virtual TipoUsuario? IdTipoUsuarioNavigation { get; set; }
}
