using System.ComponentModel.DataAnnotations;

namespace EventPlusTorloni.WebAPI.DTO;

public class UsuarioDTO
{
    [Required(ErrorMessage = "O Nome, Email e Senha do Usuario é obrigatório!")]
    public string? Nome { get; set; } = null!;
    public string? Email { get; set; } = null!;
    public string? senha { get; set; } = null!;
    public Guid? IdTipoUsuario { get; set; } = null!;
}