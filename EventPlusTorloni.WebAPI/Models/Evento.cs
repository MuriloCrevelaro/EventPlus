using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EventPlusTorloni.WebAPI.Models;

[Table("Evento")]
public partial class Evento
{
    [Key]
    [Column("idEvento")]
    public Guid IdEvento { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Nome { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime DataEvento { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Descricao { get; set; } = null!;

    [Column("idTipoEvento")]
    public Guid? IdTipoEvento { get; set; }

    [Column("idInstituição")]
    public Guid? IdInstituição { get; set; }

    [ForeignKey("IdInstituição")]
    [InverseProperty("Eventos")]
    public virtual Instituicao? IdInstituiçãoNavigation { get; set; }

    [ForeignKey("IdTipoEvento")]
    [InverseProperty("Eventos")]
    public virtual TipoEvento? IdTipoEventoNavigation { get; set; }
}
