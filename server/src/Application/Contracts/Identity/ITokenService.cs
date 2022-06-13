using Domain;

namespace Application.Contracts.Identity
{
    public interface ITokenService
    {
        string GenerateJwtToken(AuthUser user);
    }
}