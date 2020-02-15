namespace Application.Interfaces
{
    public interface ITokenService
    {
        string GenerateJwtToken(string username);
    }
}
