using AutoMapper;
using FluentValidation.AspNetCore;
using LeagueDraft_API.Mappings;
using LeagueDraft_API.Models;
using LeagueDraft_API.Repositories;
using LeagueDraft_API.Repositories.Interfaces;
using LeagueDraft_API.Services;
using LeagueDraft_API.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace LeagueDraft_API.AppConfiguration
{
    public static class AppSetup
    {
        public static void ConfigureAppByDefault(this IServiceCollection services, IConfiguration configuration)
        {
            AddDatabaseAndIdentity(services, configuration);
            AddAuthenticationWithJwt(services);
            AddDI(services, configuration);
            AddSwagger(services);
            services
                .AddControllers()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());
        }

        private static void AddDatabaseAndIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DockerMssqlConnection")));
            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
        }

        private static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo {Title = "League Draft", Version = "v1"});
                var securitySchema = new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };
                s.AddSecurityDefinition("Bearer", securitySchema);

                var securityRequirement = new OpenApiSecurityRequirement();
                securityRequirement.Add(securitySchema, new[] {"Bearer"});
                //s.AddSecurityRequirement(securityRequirement);
                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //s.IncludeXmlComments(xmlPath);
            });
        }

        private static void AddDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IChampionService, ChampionService>();
            services.AddScoped<IChampionRepository, ChampionRepository>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddHttpClient<ISummonerService, SummonerService>(c =>
                c.DefaultRequestHeaders.Add("X-Riot-Token", configuration.GetValue<string>("X-Riot-Token")));
            services.AddAutoMapper(typeof(MappingProfile));
        }

        private static void AddAuthenticationWithJwt(this IServiceCollection services)
        {
            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidAudience = "http://dotnetdetail.net",
                        ValidIssuer = "http://dotnetdetail.net",
                        IssuerSigningKey =
                            new SymmetricSecurityKey(
                                Encoding.UTF8.GetBytes("This is my custom Secret key for authentication"))
                    };
                });
        }
    }
}

