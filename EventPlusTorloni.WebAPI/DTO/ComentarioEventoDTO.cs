using System.ComponentModel.DataAnnotations;

namespace EventPlusTorloni.WebAPI.DTO;

public class ComentarioEventoDTO
{
    [Required(ErrorMessage = "O titulo do comentario é obrigatório!")]
    public string? Descricao { get; set; } = null!;
    public Guid? IdUsuario { get; set; } = null!;
    public Guid? IdEvento { get; set; } = null!;
}
