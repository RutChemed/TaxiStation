using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Services.ServicesImplementation
{
    public class AuthService : IAuthService
    {
        private readonly ILoginRepository _loginRepository;
        //private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AuthService(IMapper mapper, ILoginRepository loginRepository
            //, IConfiguration configuration
            )
        {
            _mapper = mapper;
            _loginRepository = loginRepository;
            //_configuration = configuration;
        }

        public async Task<string> LoginAsync(string email, string password)
        {
            var user = await _loginRepository.GetUserByEmailAsync(email);
            var userDTO = _mapper.Map<TechnicalEmployeeDetailDTO>(user);

            if (user == null || !VerifyPassword(userDTO, password))
            {
                throw new UnauthorizedAccessException("Invalid credentials");
            }

            // יצירת טוקן
            var token = GenerateJwtToken(userDTO);
            return token;
        }

        private bool VerifyPassword(TechnicalEmployeeDetailDTO userDTO, string password)
        {
            // השוואת הסיסמה (במידת הצורך יש להשתמש באלגוריתם Hash מתאים)
            return userDTO.Password == password;
        }

        private string GenerateJwtToken(TechnicalEmployeeDetailDTO user)
        {

            var claims = new List<Claim>
        {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Role),
                    new Claim(ClaimTypes.Role, user.Role),
                    new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}")
                // Add additional claims as needed (e.g., roles, etc.)
            };

            // Create a JWT
            var token = new JwtSecurityToken(
                issuer: "MyAwesomeAppUsers",
                audience: "MyAwesomeApp",
                claims: claims,
                expires: DateTime.UtcNow.AddDays(7), // Token expiration time
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mySuperSecretKey123456789012345678"))
                 ,   SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}