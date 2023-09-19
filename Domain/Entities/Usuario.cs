namespace Domain.Entities;


public class Usuario
{
    public int UsuarioId { get; set; }
    public string Username   { get; set; }
    public string email  { get; set; }
    public string Password { get; set; }
    public int RolId { get; set; }
    public Rol  Rol { get; set; }
    public ICollection<RefreshToken> RefreshTokens { get; set; }
}