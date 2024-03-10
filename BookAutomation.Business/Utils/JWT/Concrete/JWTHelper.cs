using BookAutomation.Business.Utils.JWT.Abstract;
using BookAutomation.Entity.Concrete;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookAutomation.Business.Utils.JWT.Concrete
{
    public class JWTHelper : ITokenHelper
    {
        public string CreateToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mysupersecretkeymysupersecretkey"));
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var jwt = CreateJwtSecurityToken( user, signingCredentials);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            return jwtSecurityTokenHandler.WriteToken(jwt);
        }


        public JwtSecurityToken CreateJwtSecurityToken(User user,
            SigningCredentials signingCredentials)
        {
            var jwt = new JwtSecurityToken(
                issuer: "your_issuer",
                audience: "your_audience",
                expires: DateTime.Now.AddHours(3),
                notBefore: DateTime.Now,
                claims: SetClaims(user),
                signingCredentials: signingCredentials
            );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.Username.ToString()),
            };
            return claims;
        }
    }
}
