using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Ulugbekivich.Domain.Entities;
using Ulugbekivich.Service.Interfaces;

namespace Ulugbekivich.Service.Security;

public class AuthManager : IAuthManager
{
    private readonly IConfiguration _config;

    public AuthManager(IConfiguration configuration)
    {
        _config = configuration.GetSection("Jwt");
    }
    public string GenerateToken(Admin admin)
    {
        var claims = new[]
        {
            new Claim("Id", admin.Id.ToString()),
            new Claim("FullName", admin.FullName),
            new Claim("Email", admin.Email)
        };

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["SecretKey"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

        var tokenDescriptor = new JwtSecurityToken(_config["Issuer"], _config["Audience"], claims,
            expires: DateTime.Now.AddDays(int.Parse(_config["Lifetime"])),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
    }

}
