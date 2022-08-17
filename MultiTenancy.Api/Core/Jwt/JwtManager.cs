using Microsoft.IdentityModel.Tokens;
using MultiTenancy.Application.Enums;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MultiTenancy.Api.Core.Jwt
{
    public class JwtManager
    {
        private readonly JwtSettings _settings;

        public JwtManager(JwtSettings settings)
        {
            _settings = settings;
        }

        public string MakeToken(string email, string password)
        {
            // var user = _context.Users.Include(x => x.UseCases).FirstOrDefault(x => x.Email == email);

            //if (user == null)
            //{
            //    throw new UnauthorizedAccessException("User with those credentials doesn't exist.");
            //}

            //var valid = BCrypt.Net.BCrypt.Verify(password, user.Password);

            //if (!valid)
            //{
            //    throw new UnauthorizedAccessException("User with those credentials doesn't exist.");
            //}

            //if (!user.IsActive.Value)
            //{
            //    throw new UnauthorizedAccessException("Your account is deactivated, please contact us for more info.");
            //}

            var appUser = new ApplicationUser
            {
                UserId = 1,
                TenantId = 1,
                Identity = "User1",
                Email = "u1@gmail.com",
                Role = UserRole.SuperUserGlobal,
                UseCaseIds = new List<int>()
            };

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iss, _settings.Issuer),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64, _settings.Issuer),
                new Claim("UserId", appUser.UserId.ToString(), ClaimValueTypes.String, _settings.Issuer),
                new Claim("TenantId", appUser.TenantId.ToString(), ClaimValueTypes.String, _settings.Issuer),
                new Claim("Identity", appUser.Identity, ClaimValueTypes.String, _settings.Issuer),
                new Claim("Email", appUser.Email, ClaimValueTypes.String, _settings.Issuer),
                new Claim("Role", appUser.Role.ToString(), ClaimValueTypes.String, _settings.Issuer),
                new Claim("UseCases", JsonConvert.SerializeObject(appUser.UseCaseIds), ClaimValueTypes.String, _settings.Issuer)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.SecretKey));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var now = DateTime.UtcNow;
            var token = new JwtSecurityToken(
                issuer: _settings.Issuer,
                audience: "Any",
                claims: claims,
                notBefore: now,
                expires: now.AddMinutes(_settings.Minutes),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
