using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EventPlusTorloni.WebAPI.Models;

[Table("Instituicao")]
public partial class Instituicao
{
    [Key]
    [Column("id_Instituição")]
    public Guid IdInstituição { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string NomeFantasia { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string Endereço { get; set; } = null!;

    [Column("CNPJ")]
    [StringLength(14)]
    [Unicode(false)]
    public string Cnpj { get; set; } = null!;

    [InverseProperty("IdInstituiçãoNavigation")]
    [JsonIgnore]
    public virtual ICollection<Evento> Eventos { get; set; } = new List<Evento>();
}
