using InfiniteBlog.Core.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using InfiniteBlog.Api.Services;
using InfiniteBlog.Core.SeedWorks.Constants;
using InfiniteBlog.Core.Models.System;
using System.Reflection;
using InfiniteBlog.Api.Extensions;
using System.Text.Json;

namespace InfiniteBlog.Api.Controllers.AdminApi
{
    [Route("api/admin/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly RoleManager<AppRole> _roleManager;

        public AuthController(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ITokenService tokenService,
            RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _roleManager = roleManager;
        }

        [HttpPost]
        public async Task<ActionResult<Core.Models.Auth.AuthenticateResult>> Login([FromBody] Core.Models.Auth.LoginRequest request)
        {
            //Authentication
            if(request == null)
            {
                return BadRequest("Invalid request");
            }

            var user = await _userManager.FindByNameAsync(request.UserName);

            if(user == null || user.IsActive == false || user.LockoutEnabled)
            {
                return Unauthorized();
            }

            var result = await _signInManager.PasswordSignInAsync(request.UserName, request.Password, false, true);

            if (!result.Succeeded)
            {
                return Unauthorized();
            }

            //Authorizetion
            var roles = await _userManager.GetRolesAsync(user);
            var permissons = await this.GetPermissionsByUserIdAsync(user.Id.ToString());

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(UserClaims.Id, user.Id.ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.UserName),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(UserClaims.FirstName, user.FirstName),
                new Claim(UserClaims.Roles, string.Join(";", roles)),
                new Claim(UserClaims.Permissions, JsonSerializer.Serialize(permissons)),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var accessToken = _tokenService.GenerateAccessToken(claims);
            var refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(30);

            await _userManager.UpdateAsync(user);

            return Ok(new Core.Models.Auth.AuthenticateResult() 
            {
                Token = accessToken,
                RefreshToken = refreshToken
            });
        }

        private async Task<List<string>> GetPermissionsByUserIdAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var roles = await _userManager.GetRolesAsync(user);
            var permissons = new List<string>();

            var allPermissons = new List<RoleClaimsDto>();

            if (roles.Contains(Roles.Admin))
            {
                var types = typeof(Permissons).GetTypeInfo().DeclaredNestedTypes;

                foreach (var type in types)
                {
                    allPermissons.GetPermissions(type);
                }

                permissons.AddRange(allPermissons.Select(x => x.Value));
            }
            else
            {
                foreach(var roleName in roles)
                {
                    var role = await _roleManager.FindByNameAsync(roleName);
                    var claims = await _roleManager.GetClaimsAsync(role);
                    var roleClaimValues  = claims.Select(x => x.Value);

                    permissons.AddRange(roleClaimValues);
                }
            }

            return permissons.Distinct().ToList();
        }
    }
}
