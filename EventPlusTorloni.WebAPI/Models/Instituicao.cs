using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EventPlusTorloni.WebAPI.Models;

[Table("Instituicao")]
public partial class Instituicao
{
    [Key]
    [Column("idInstituição")]
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
    public virtual ICollection<Evento> Eventos { get; set; } = new List<Evento>();
}
