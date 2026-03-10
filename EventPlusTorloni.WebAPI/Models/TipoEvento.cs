using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EventPlusTorloni.WebAPI.Models;

[Table("Tipo_Evento")]
public partial class TipoEvento
{
    [Key]
    [Column("id_Tipo_Evento")]
    public Guid IdTipoEvento { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Titulo { get; set; } = null!;

    [InverseProperty("IdTipoEventoNavigation")]
    public virtual ICollection<ComentarioEvento> ComentarioEventos { get; set; } = new List<ComentarioEvento>();

    [InverseProperty("IdTipoEventoNavigation")]
    public virtual ICollection<Evento> Eventos { get; set; } = new List<Evento>();

    [InverseProperty("IdTipoEventoNavigation")]
    public virtual ICollection<Presenca> Presencas { get; set; } = new List<Presenca>();
}
