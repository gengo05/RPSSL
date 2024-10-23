using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RockPaperScissorsSpockLizard.Core.Interfaces;
using RockPaperScissorsSpockLizard.Core.Services;
using RockPaperScissorsSpockLizard.Infrastructure.Interfaces;
using RockPaperScissorsSpockLizard.Infrastructure.Services;
using System.Text;

namespace RockPaperScissorsSpockLizard.API
{
    public class Startup(IConfiguration configuration)
    {
        public void ConfigureServices(IServiceCollection services)
        {
            _ = services.AddScoped<IGameService, GameService>();
            _ = services.AddScoped<IChoiceService, ChoiceService>();
            _ = services.AddScoped<IGameDecisionMaker, GameDecisionMaker>();
            _ = services.AddScoped<IOpponentMoveService, OpponentMoveService>();
            _ = services.AddScoped<IUserService, UserService>();

            _ = services.AddSingleton<IScoreboardRepository, ScoreboardRepository>();

            _ = services.AddLogging(builder => builder.AddConsole());

            _ = services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Rock Paper Scissors Spock Lizard API", Version = "v1" });

                    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        In = ParameterLocation.Header,
                        Description = "Please enter token",
                        Name = "Authorization",
                        Type = SecuritySchemeType.ApiKey,
                    });

                    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new() {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" } },
                            Array.Empty<string>()
                        }
                    });
                });

            byte[] key = Encoding.ASCII.GetBytes(configuration["Jwt:Key"]!);
            _ = services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });

            _ = services.AddAuthorization(options => options.DefaultPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build());

            _ = services.AddControllers();
            _ = services.AddAutoMapper(typeof(Startup));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                _ = app.UseDeveloperExceptionPage();
            }

            _ = app.UseSwagger();

            _ = app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rock Paper Scissors Spock Lizard API V1");
                c.RoutePrefix = string.Empty;
            });

            _ = app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            _ = app.UseRouting();
            _ = app.UseAuthentication();
            _ = app.UseAuthorization();
            _ = app.UseEndpoints(endpoints =>
            {
                _ = endpoints.MapControllers();
            });
        }
    }
}
