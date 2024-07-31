using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DemoForNetAPI.Entities;
using DemoForNetAPI.Mocks;
using DemoForNetAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace DemoForNetAPI.Controllers;
[ApiController]
[Route("/api/[controller]")]
[Authorize]
public class AuthenticateController: ApiControllerBase
{
    private IConfiguration _configuration;
    public AuthenticateController(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    [HttpPost]
    [AllowAnonymous]
    public ActionResult Login([FromBody] Login model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var user = UserData
            .GetUsers()
            .FirstOrDefault(e => e.Email == model.Email && e.Password == model.Password);
        if (user == null)
            return Unauthorized();
        
        var token = GenerateJwtToken(user);
        return Ok(new
        {
            token
        });
    }

    [HttpGet("me")]
    public ActionResult Me()
    {
        /*var userIndentity = User.Identity as ClaimsIdentity;
        var userId = userIndentity.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var userEmail = userIndentity.FindFirst(ClaimTypes.Email)?.Value;
        */
        // CurrentUserEmail come from ApiControllerBase
        // Any Controller that inherit from ApiControllerBase can use CurrentUserId, CurrentUserEmail 
        // anywhere, anytime.
        // Plase check data
        var user = UserData.GetUsers()
            .FirstOrDefault(e => e.Email == CurrentUserEmail);
        
        if (user == null) return Unauthorized();
        
        return Ok(user);
    }

    //helper class
    private string GenerateJwtToken(Users user)
    {
        var issuer = _configuration["Jwt:Issuer"];
        var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim("Id", user.Id.ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti,
                    Guid.NewGuid().ToString())
            }),
            Expires = DateTime.UtcNow.AddMinutes(30),
            Issuer = issuer,
            SigningCredentials = new SigningCredentials
            (new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha512Signature)
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var jwtToken = tokenHandler.WriteToken(token);
        return jwtToken;
    }
}