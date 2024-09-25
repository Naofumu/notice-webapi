using Microsoft.AspNetCore.Mvc;  
using Microsoft.EntityFrameworkCore;  
using Microsoft.IdentityModel.Tokens;  
using System.IdentityModel.Tokens.Jwt; 
using System.Security.Claims; 
using System.Text;  
using NoticeApi.Models;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly NoticeContext _context;
    private readonly IConfiguration _configuration;
    public AuthController(NoticeContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }
    [HttpPost("register")]  
    public async Task<IActionResult> Register([FromBody] User user)  
    {  
        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);  
        await _context.Users.AddAsync(user);  
        await _context.SaveChangesAsync();  
        return Ok("User registered successfully.");  
    }  

    [HttpPost("login")]  
    public async Task<IActionResult> Login([FromBody] User user)  
    {  
        var existingUser = await _context.Users.FindAsync(user.Username);  
        if (existingUser == null || !BCrypt.Net.BCrypt.Verify(user.PasswordHash, existingUser.PasswordHash))  
        {  
            return Unauthorized();  
        }  

        var token = GenerateJwtToken(existingUser);  
        return Ok(new { token });  
    }
    
    private string GenerateJwtToken(User user)  
    {  
        var claims = new[]  
        {  
            new Claim(JwtRegisteredClaimNames.Sub, user.Username),  
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())  
        };  

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));  
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);  

        var token = new JwtSecurityToken(  
            issuer: _configuration["Jwt:Issuer"],  
            audience: _configuration["Jwt:Audience"],  
            claims: claims,  
            expires: DateTime.Now.AddMinutes(60),  
            signingCredentials: creds);  

        return new JwtSecurityTokenHandler().WriteToken(token);  
    }
}