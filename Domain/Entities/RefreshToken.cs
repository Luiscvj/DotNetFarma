
namespace Domain.Entities;

public class RefreshToken
{
    public int TokenId { get; set; }
    public string Token { get; set; }
    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; }
    public DateTime FechaCreacion { get; set; } = DateTime.Now;
    public DateTime FechaExpiracion { get; set; }
    public bool Revocado { get; set; }
}
