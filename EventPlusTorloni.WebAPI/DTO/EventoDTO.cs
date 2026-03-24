using System.ComponentModel.DataAnnotations;

namespace EventPlusTorloni.WebAPI.DTO;

public class EventoDTO
{
    [Required(ErrorMessage = "O titulo do tipo de evento é obrigatório!")]
    public Guid? IdTipoEvento { get; set; } = null!;
    public string? Nome { get; set; } = null!;
    public DateTime DataEvento { get; set; }
    public string? Descricao { get; set; } = null!;
    public Guid? IdInstituição { get; set; } = null!;
}
