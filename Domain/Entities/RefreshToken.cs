
namespace Domain.Entities;

public class RefreshToken
{
    public int TokenId { get; set; }
    public string Token { get; set; }
    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; }
    public bool  IsExpired =>DateTime.UtcNow >= FechaExpiracion;
    public DateTime FechaCreacion { get; set; } = DateTime.Now;
    public DateTime FechaExpiracion { get; set; }
    public DateTime ? Revocado { get; set; }
    public bool  IsActive => Revocado == null && !IsExpired;

}
