using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EventPlusTorloni.WebAPI.Models;

[Table("Usuario")]
[Index("EMail", Name = "UQ__Usuario__3166044232C4CDFA", IsUnique = true)]
public partial class Usuario
{
    [Key]
    [Column("id_Usuario")]
    public Guid IdUsuario { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Nome { get; set; } = null!;

    [Column("E_mail")]
    [StringLength(264)]
    [Unicode(false)]
    public string EMail { get; set; } = null!;

    [StringLength(60)]
    [Unicode(false)]
    public string Senha { get; set; } = null!;

    [Column("id_Tipo_Usuario")]
    public Guid? IdTipoUsuario { get; set; }

    [ForeignKey("IdTipoUsuario")]
    [InverseProperty("Usuarios")]
    public virtual TipoEventos? IdTipoUsuarioNavigation { get; set; }
}
