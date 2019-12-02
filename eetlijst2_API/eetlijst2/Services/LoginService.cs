using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using eetlijst2.Services.Interfaces;
using Logic;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Model;

namespace eetlijst2.Services
{
    public class LoginService :ILoginService
    {
        private readonly IOptions<JwtConfiguration> _jwtConfig;
        //private readonly JwtConfiguration _jwtConfig;
        private readonly IAccountLogic _accountLogic;
        
        public LoginService(IOptions<JwtConfiguration> jwtConfig,IAccountLogic accountLogic)
        { 
                //            _jwtConfig = new JwtConfiguration()
                //            {
                //                Issuer = "Mauro",
                //                SecretKey = "Eetlijst2"
                //            };
                _jwtConfig = jwtConfig;
            _accountLogic = accountLogic;
        }
        
        public string Login(Account useraccount)
        {
            var account = _accountLogic.Authenticate(useraccount);
            if (account != null)
            {
                var key = Encoding.ASCII.GetBytes(_jwtConfig.Value.SecretKey);
                            var jwt = new JwtSecurityToken(
                                issuer: _jwtConfig.Value.Issuer,
                                audience: _jwtConfig.Value.Issuer,
                                claims: GetAccountClaims(useraccount),
                                notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                                expires: new DateTimeOffset(DateTime.Now.AddDays(1)).DateTime,
                                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key),
                                    SecurityAlgorithms.HmacSha256Signature)
                            );
                            var token = new JwtSecurityTokenHandler().WriteToken(jwt);
                            return token;
            }
            
            return null;
        }
        
        private static IEnumerable<Claim> GetAccountClaims(Account account)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, account.Firstname),
                new Claim(ClaimTypes.Role, "User")
            };
            return claims;
        }
    }
}