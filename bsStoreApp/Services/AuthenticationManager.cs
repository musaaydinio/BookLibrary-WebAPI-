using AutoMapper;
using Entities.DataTranferObjcets;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AuthenticationManager : IAuthenticationService
    {
        private readonly ILoggerService _loggerService;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _config;

        private User? _user;

        public AuthenticationManager(ILoggerService loggerService, IMapper mapper,
            UserManager<User> userManager,
            IConfiguration config)
        {
            _loggerService = loggerService;
            _mapper = mapper;
            _userManager = userManager;
            _config = config;
        }

        public async Task<string> CreateToken()
        {
            var signinCredentials = GetSiginCredentials();
            var claims = await GetClaims();
            var tokenOpstions = GenerateTokenOpstions(signinCredentials, claims);
            return new JwtSecurityTokenHandler().WriteToken(tokenOpstions);
        }

        public async Task<IdentityResult> Register(UserForResgistrationDto userForRegistrationDto)
        {
            var user=_mapper.Map<User>(userForRegistrationDto);

            var result=await _userManager.CreateAsync(user,userForRegistrationDto.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRolesAsync(user, userForRegistrationDto.Roles);
            }
            return result;
        }

        public async Task<bool> ValidateUser(UserForAuthenticationDto userForAuthDto)
        {
            _user=await _userManager.FindByNameAsync(userForAuthDto.UserName);
            var result=(_user !=null && await _userManager.CheckPasswordAsync(_user,userForAuthDto.Password));

            if (!result)
            {
                _loggerService.LogWarning($"{nameof(ValidateUser)} : Authentication failed.Wrog username pssword.");
            }
            return result;
        }

        private SigningCredentials GetSiginCredentials()
        {
            var jwtsettings = _config.GetSection("JwtSetting");
            var key = Encoding.UTF8.GetBytes(jwtsettings["secretKey"]);
            var secret=new SymmetricSecurityKey(key);
            return new SigningCredentials(secret,SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,_user.UserName)
            };
            var roles =await _userManager.GetRolesAsync(_user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role)); 
            }
            return claims;
        }

        private JwtSecurityToken GenerateTokenOpstions(SigningCredentials signinCredentials, List<Claim> claims)
        {
            var jwtsettings = _config.GetSection("JwtSetting");
            var tokenOpt = new JwtSecurityToken(
                issuer: jwtsettings["validIssuer"],
                audience: jwtsettings["validAudience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtsettings["expires"])),
                signingCredentials: signinCredentials);
            return tokenOpt;
        }
    }
}
