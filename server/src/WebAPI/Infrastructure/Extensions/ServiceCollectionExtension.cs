namespace WebAPI.Infrastructure.Extensions
{
    using Application.Interfaces;
    using Application.Interfaces.Repositories;
    using Application.UseCases.User.Login;
    using Application.UseCases.User.Register;
    using global::Infrastructure;
    using Infrastructure;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;
    using Persistence.Repositories;
    using System.Text;
    using System.Threading.Tasks;
    using WebAPI.Features.User.Presenters;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterDependencies(this IServiceCollection services)
        {
            // Infrastructure:
            services.AddTransient<ITokenService, JwtTokenService>();

            // Repositories
            services.AddScoped<IUserRepository, UserEfRepository>();
            services.AddScoped<ILyricRepository, LyricEfRepository>();

            // Use cases:
            services.AddScoped(typeof(IRegisterInputHandler<>), typeof(RegisterUseCase<>));
            services.AddScoped(typeof(IAuthenticateInputHandler<>), typeof(AuthenticateUseCase<>));

            // Presenters:
            services.AddScoped<IRegisterOutputHandler<IActionResult>, RegisterUserPresenter>();
            services.AddScoped<IAuthenticateOutputHandler<IActionResult>, AuthenticateUserPresenter>();



            return services;
        }

        public static IServiceCollection AddJwtAuthorization(this IServiceCollection services, IConfiguration configuration)
        {
            var appSettingsSection = configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        var userService = context.HttpContext.RequestServices.GetRequiredService<IUserRepository>();
                        var userId = int.Parse(context.Principal.Identity.Name);
                        // TODO
                        var user = userService.GetAsync(userId).GetAwaiter().GetResult();
                        if (user == null)
                        {
                            // return unauthorized if user no longer exists
                            context.Fail("Unauthorized");
                        }
                        return Task.CompletedTask;
                    }
                };
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            return services;
        }
    }
}
