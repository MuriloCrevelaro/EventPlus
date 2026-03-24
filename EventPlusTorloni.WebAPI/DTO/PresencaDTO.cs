using System.ComponentModel.DataAnnotations;

namespace EventPlusTorloni.WebAPI.DTO;

public class PresencaDTO
{
    [Required(ErrorMessage = "O titulo do tipo de evento é obrigatório!")]
    public bool Situacao { get; set; }
    public Guid? IdUsuario { get; set; } = null!;
    public Guid? IdEvento { get; set; } = null!;
}
