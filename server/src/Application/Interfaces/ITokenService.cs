namespace Application.Interfaces
{
    using System.Threading.Tasks;

    public interface ITokenService
    {
        string GenerateJwtToken(string userId);
    }
}
