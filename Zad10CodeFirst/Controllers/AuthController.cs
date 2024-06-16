using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Zad10CodeFirst.Dtos;
using Zad10CodeFirst.Entities;
using Zad10CodeFirst.Entities.AppUserEntities;
using Zad10CodeFirst.Helper;
using Zad10CodeFirst.Services;

namespace Zad10CodeFirst.Controllers
{
   
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly PrescriptionDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(PrescriptionDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(RegisterDto registerDto, CancellationToken token)
        {
            var passwordAndSalt = SecurityHelper.GetHashedPasswordAndSalt(registerDto.Password);

            var user = new User
            {
                Login = registerDto.Login,
                Password = passwordAndSalt.Item1,
                Salt = passwordAndSalt.Item2,
                RefreshToken = SecurityHelper.GenerateRefreshToken(),
                RefreshTokenExp = DateTime.Now.AddDays(1)
            };

            await _context.Users.AddAsync(user, token);
            await _context.SaveChangesAsync(token);

            return Ok("User registered");
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> LoginUser(LoginDto loginDto, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Login == loginDto.Login, cancellationToken);

            if (user == null)
            {
                return BadRequest("Invalid login attempt.");
            }

            var password = SecurityHelper.GetHashedPasswordWithSalt(loginDto.Password, user.Salt);

            if (user.Password != password)        
            {
                return BadRequest("Invalid login attempt.");
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.IdUser.ToString()),
                new Claim(ClaimTypes.Name, user.Login),
                new Claim(ClaimTypes.Role, "user"),
                new Claim(ClaimTypes.Role, "admin")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(
                    Convert.ToDouble(_configuration["JwtSettings:TokenExpirationInMinutes"])),
                signingCredentials: creds);

            return Ok(new
            {
                access_token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
        }

        [Authorize(AuthenticationSchemes = "IgnoreTokenExpirationScheme")]
        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh(TokenDto tokenDto, CancellationToken cancellationToken)
        {
            var user = await _context
                .Users
                .Where(u => u.RefreshToken == tokenDto.RefreshToken)
                .FirstOrDefaultAsync(cancellationToken);

            if (user == null)
            {
                throw new SecurityTokenException("Invalid refresh token");
            }

            if (user.RefreshTokenExp < DateTime.Now)
            {
                throw new SecurityTokenException("Refresh token expired");
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.IdUser.ToString()),
                new Claim(ClaimTypes.Name, user.Login),
                new Claim(ClaimTypes.Role, "user"),
                new Claim(ClaimTypes.Role, "admin")
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecretKey"]));
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(
                    Convert.ToDouble(_configuration["JwtSettings:TokenExpirationInMinutes"])),
                signingCredentials: creds);

            user.RefreshToken = SecurityHelper.GenerateRefreshToken();
            user.RefreshTokenExp = DateTime.Now.AddDays(1);
            await _context.SaveChangesAsync(cancellationToken);

            return Ok(new
            {
                accesToken = new JwtSecurityTokenHandler().WriteToken(token),
                refreshToken = user.RefreshToken
            });
        }
    }
}