using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using CateringManagementPlatform.Auth.API.Models;
using CateringManagementPlatform.Auth.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CateringManagementPlatform.Auth.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IOptions<AuthOptions> authOptions;

        public AuthController(IOptions<AuthOptions> authOptions)
        {
            this.authOptions = authOptions;
        }

        private List<Account> Accounts => new List<Account>
        {
            new Account()
            {
                Id=1,
                Email="user1@mail.com",
                Password="user1",
                Roles=new Role[] { Role.Admin }
            },
            new Account()
            {
                Id=2,
                Email="user2@mail.com",
                Password="user2",
                Roles=new Role[] { Role.User }
            },
            new Account()
            {
                Id=3,
                Email="user3@mail.com",
                Password="user3",
                Roles=new Role[] { Role.Barman }
            },
            new Account()
            {
                Id=4,
                Email="user4@mail.com",
                Password="user4",
                Roles=new Role[] { Role.Chef }
            },
            new Account()
            {
                Id=5,
                Email="user5@mail.com",
                Password="user5",
                Roles=new Role[] { Role.Waiter }
            }
        };

        [Route("login")]
        [HttpPost]
        public IActionResult Login([FromBody] Login request)
        {
            var user = AuthenticateUser(request.Email, request.Password);

            if (user != null)
            {
                var token = GenerateJWT(user);
                return Ok(new
                {
                    access_token = token
                });
            }
            return Unauthorized();
        }

        private Account AuthenticateUser(string email, string password)
        {
            return Accounts.SingleOrDefault(u => u.Email == email && u.Password == password);
        }

        private string GenerateJWT(Account user)
        {
            var authParams = authOptions.Value;

            var securityKey = authParams.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString())
            };

            foreach (var role in user.Roles)
            {
                claims.Add(new Claim("role", role.ToString()));
            }

            var token = new JwtSecurityToken(
                authParams.Issuer,
                authParams.Audience,
                claims,
                expires: DateTime.Now.AddSeconds(authParams.TokenLifetime),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
