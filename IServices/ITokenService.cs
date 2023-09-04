using SenorBarbero.Model;

namespace SenorBarbero.IServices
{
    public interface ITokenService
    {
        public string GenerateToken(User user);
    }
}
