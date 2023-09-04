using SenorBarbero.Data.Dtos;

namespace SenorBarbero.IServices
{
    public interface IUserService
    {
        public Task Register(CreateUserDto createUserDto);
        public Task<string> Login(LoginUserDto loginUserDto);
        public void LogOut();
    }
}
