using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Massenger.Core.Data;
using Massenger.Core.Repository;
using Massenger.Core.Service;
using Microsoft.IdentityModel.Tokens;

namespace Massenger.Infra.Service
{
    public class JwtService : IJwtService
    {
        private readonly IJwtRepository repo;
        public JwtService(IJwtRepository repo)
        {
            this.repo = repo;
        }

        public string Auth(Mass_Login login)
        {
            var result = repo.Auth(login);
            if (result == null)
            {
                return null;
            }
            else
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenkey = Encoding.ASCII.GetBytes("[SECRET Used To Sign And Verify Jwt Token,It can be any string]");
                var tokenDescirptor = new SecurityTokenDescriptor
                {
                    Subject = new System.Security.Claims.ClaimsIdentity(
                    new Claim[]
                    {
                    new Claim(ClaimTypes.Name,result.username),
                    new Claim(ClaimTypes.Role, result.rolename),


                    }
                    ),
                    Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey),
                    SecurityAlgorithms.HmacSha256Signature)


                };

                var token = tokenHandler.CreateToken(tokenDescirptor);
                return tokenHandler.WriteToken(token);
            }
        }
    }
}
