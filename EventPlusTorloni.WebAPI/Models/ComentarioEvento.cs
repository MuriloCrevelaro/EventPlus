using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EventPlusTorloni.WebAPI.Models;

[Table("ComentarioEvento")]
public partial class ComentarioEvento
{
    [Key]
    [Column("idComentarioEvento")]
    public Guid IdComentarioEvento { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string Descricao { get; set; } = null!;

    public bool Exibe { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime DataComentario { get; set; }

    [Column("idTipoUsuario")]
    public Guid? IdTipoUsuario { get; set; }

    [Column("idTipoEvento")]
    public Guid? IdTipoEvento { get; set; }

    [ForeignKey("IdTipoEvento")]
    [InverseProperty("ComentarioEventos")]
    public virtual TipoEvento? IdTipoEventoNavigation { get; set; }

    [ForeignKey("IdTipoUsuario")]
    [InverseProperty("ComentarioEventos")]
    public virtual TipoUsuario? IdTipoUsuarioNavigation { get; set; }
}
