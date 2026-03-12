using System.ComponentModel.DataAnnotations;

namespace EventPlusTorloni.WebAPI.DTO;

public class InstituicaoDTO
{
    [Required(ErrorMessage = "O titulo do tipo de evento é obrigatório!")]
    public string? NomeFantasia { get; set; } = null!;
    public string? Endereço { get; set; } = null!;
    public string? Cnpj { get; set; } = null!;
}
