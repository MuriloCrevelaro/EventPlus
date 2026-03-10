using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EventPlusTorloni.WebAPI.Models;

[Table("Tipo_Usuario")]
public partial class TipoEventos
{
    [Key]
    [Column("id_Tipo_Usuario")]
    public Guid IdTipoUsuario { get; set; }

    [StringLength(244)]
    public string Titulo { get; set; } = null!;

    [InverseProperty("IdTipoUsuarioNavigation")]
    [JsonIgnore]
    public virtual ICollection<ComentarioEvento> ComentarioEventos { get; set; } = new List<ComentarioEvento>();

    [InverseProperty("IdTipoUsuarioNavigation")]
    [JsonIgnore]
    public virtual ICollection<Presenca> Presencas { get; set; } = new List<Presenca>();

    [InverseProperty("IdTipoUsuarioNavigation")]
    [JsonIgnore]
    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
