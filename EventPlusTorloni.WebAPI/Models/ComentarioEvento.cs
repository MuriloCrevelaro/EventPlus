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

    [Column("idUsuario")]
    public Guid? IdUsuario { get; set; }

    [Column("idEvento")]
    public Guid? IdEvento { get; set; }

    [ForeignKey("IdEvento")]
    [InverseProperty("ComentarioEventos")]
    public virtual Evento? IdEventoNavigation { get; set; }

    [ForeignKey("IdUsuario")]
    [InverseProperty("ComentarioEventos")]
    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
