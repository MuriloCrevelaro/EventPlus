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
    [Column("id_Presenca")]
    public Guid IdPresenca { get; set; }

    [Column("Presenca")]
    public bool Presenca1 { get; set; }

    [Column("id_Tipo_Usuario")]
    public Guid? IdTipoUsuario { get; set; }

    [Column("id_Tipo_Evento")]
    public Guid? IdTipoEvento { get; set; }

    [ForeignKey("IdTipoEvento")]
    [InverseProperty("Presencas")]
    public virtual TipoEvento? IdTipoEventoNavigation { get; set; }

    [ForeignKey("IdTipoUsuario")]
    [InverseProperty("Presencas")]
    public virtual TipoEventos? IdTipoUsuarioNavigation { get; set; }
}
