using Microsoft.EntityFrameworkCore;
using NoticeApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;  
using Microsoft.IdentityModel.Tokens;   
using System.Text; 

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication();

// Add services to the container.

builder.Services.AddCors(options =>  
{  
    options.AddPolicy("AllowSpecificOrigin",  
        builder =>  
        {  
            builder.WithOrigins("http://localhost:4200") // URL вашего Angular приложения  
                   .AllowAnyHeader()  
                   .AllowAnyMethod();  
        });  
});

var jwtSection = builder.Configuration.GetSection("Jwt");  
builder.Services.AddAuthentication(x =>  
{  
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;  
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;  
})  
.AddJwtBearer(x =>  
{  
    x.TokenValidationParameters = new TokenValidationParameters  
    {  
        ValidateIssuer = true,  
        ValidateAudience = true,  
        ValidateLifetime = true,  
        ValidateIssuerSigningKey = true,  
        ValidIssuer = jwtSection["Issuer"],  
        ValidAudience = jwtSection["Audience"],  
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSection["Key"]))  
    };  
});  

builder.Services.AddControllers();
builder.Services.AddDbContext<NoticeContext>( o => o.UseNpgsql(builder.Configuration.GetConnectionString("example")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowSpecificOrigin");

app.UseAuthentication();  
app.UseAuthorization();

app.MapControllers();

app.Run();
