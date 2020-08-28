using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LeagueDraft_API.DTO;
using LeagueDraft_API.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace LeagueDraft_API.Services
{
    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthService(IMapper mapper, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _mapper = mapper;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<JwtToken> SignUpUserAsync(SignUpUser signUpUser)
        {
            var user = _mapper.Map<IdentityUser>(signUpUser);
            if (await _userManager.FindByNameAsync(user.UserName) != null)
                throw new Exception("Such a user already exist");
            if ((await _userManager.CreateAsync(user, signUpUser.Password)).Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return await GetTokenForSignedInUser(user);
            } 
            throw new Exception("Can't create user, username, email or password are invalid");

        }

        public async Task<JwtToken> SignInUserAsync(SignInUser signInUser) => await _userManager.FindByNameAsync(signInUser.UserName) is IdentityUser user ?
            (await _signInManager.PasswordSignInAsync(signInUser.UserName, signInUser.Password, false, true)).Succeeded ?
                await GetTokenForSignedInUser(user) :
                throw new Exception("Password is incorrect") :
            throw new Exception("Such a user with this username doesn't exist");

        public async Task LogoutAsync() => await _signInManager.SignOutAsync();

        private async Task<JwtToken> GetTokenForSignedInUser(IdentityUser user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                new Claim("role", userRoles.Count != 0 ? userRoles.FirstOrDefault() : "standard"), 
            };

            var authSigningKey =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes("This is my custom Secret key for authentication"));

            var token = new JwtSecurityToken(
                issuer: "http://dotnetdetail.net",
                audience: "http://dotnetdetail.net",
                expires: DateTime.Now.AddHours(3),
                claims: claims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtToken
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expires = token.ValidTo
            };
        }

    }
}
