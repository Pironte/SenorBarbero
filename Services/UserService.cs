using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SenorBarbero.Data.Dtos;
using SenorBarbero.IServices;
using SenorBarbero.Model;

namespace SenorBarbero.Services
{
    public class UserService : IUserService
    {
        private IMapper _mapper;
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private ITokenService _tokenService;

        public UserService(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager, ITokenService tokenService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task Register(CreateUserDto createUserDto)
        {
            var user = _mapper.Map<User>(createUserDto);

            if (string.IsNullOrWhiteSpace(createUserDto.Password))
            {
                throw new ApplicationException("Senha não pode ser vazia");
            }

            IdentityResult result = await _userManager.CreateAsync(user, createUserDto.Password);

            if (!result.Succeeded)
            {
                throw new ApplicationException("Falha ao cadastrar usuário");
            }
        }

        public async Task<string> Login(LoginUserDto loginUserDto)
        {
            if (string.IsNullOrWhiteSpace(loginUserDto.UserName) || string.IsNullOrWhiteSpace(loginUserDto.Password))
            {
                throw new ApplicationException("Deve-se informar usuário e senha para entrar no sistema");
            }

            SignInResult result = await _signInManager.PasswordSignInAsync(loginUserDto.UserName, loginUserDto.Password, false, false);

            if (!result.Succeeded)
            {
                throw new ApplicationException("Usuário não autenticado!");
            }

            var user = _signInManager.UserManager.Users.FirstOrDefault(user => user.NormalizedUserName == loginUserDto.UserName.ToUpper());

            if (user == null)
            {
                throw new ApplicationException("Usuário não existe");
            }

            var token = _tokenService.GenerateToken(user);

            return token;
        }

        public async void LogOut()
        {
            await _signInManager.SignOutAsync();
        }
    }
}