using data;
using data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace api.Controllers;

[Route("api/")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly UserRepository repository;
    public AuthController(Context context)
    {
        repository = new UserRepository(context);
    }

    [HttpPost]
    [Route("login")]
    public IActionResult Login(LoginDto dto)
    {
        if (!repository.Login(dto)) return Unauthorized();

        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("YourVeryLongSecretKeyHere1234567890"));
        var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
        var jwtSecurityToken = new JwtSecurityToken(
                                issuer: "issuer",
                                audience: "audience",
                                claims: new List<Claim>(),
                                expires: DateTime.Now.AddMinutes(10),
                                signingCredentials: signinCredentials
                            );
        return Ok(new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken));
    }
}