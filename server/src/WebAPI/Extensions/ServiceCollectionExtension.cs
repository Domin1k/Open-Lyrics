namespace WebAPI.Extensions
{
    using Application.Interfaces;
    using Application.Interfaces.Repositories;
    using Application.UseCases.Lyrics.Create;
    using Application.UseCases.Lyrics.Delete;
    using Application.UseCases.Lyrics.Details;
    using Application.UseCases.Lyrics.Edit;
    using Application.UseCases.Lyrics.GetAll;
    using Application.UseCases.User.Login;
    using Application.UseCases.User.Register;
    using Foundation;
    using Foundation.Services;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Distributed;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;
    using Persistence.Repositories;
    using System.Text;
    using System.Threading.Tasks;
    using WebAPI.Features.Lyric.Presenters;
    using WebAPI.Features.User.Presenters;
    using WebAPI.Shared;

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
            services.AddScoped(typeof(IAllLyricsInputHandler<>), typeof(AllLyricsUseCase<>));
            services.AddScoped(typeof(ICreateLyricInputHandler<>), typeof(CreateLyricUseCase<>));
            services.AddScoped(typeof(IEditLyricInputHandler<>), typeof(EditLyricUseCase<>));
            services.AddScoped(typeof(IDeleteLyricInputHandler<>), typeof(DeleteLyricUseCase<>));
            services.AddScoped(typeof(IRegisterInputHandler<>), typeof(RegisterUseCase<>));
            services.AddScoped(typeof(IDetailsLyricsInputHandler<>), typeof(DetailsLyricsUseCase<>));
            services.AddScoped(typeof(IAuthenticateInputHandler<>), typeof(AuthenticateUseCase<>));

            // Presenters:
            services.AddScoped<IAllLyricsOutputHandler<IActionResult>, AllLyricsPresenter>();
            services.AddScoped<ICreateLyricOutputHandler<IActionResult>, CreateLyricPresenter>();
            services.AddScoped<IEditLyricOutputHandler<IActionResult>, EditLyricPresenter>();
            services.AddScoped<IDeleteLyricOutputHandler<IActionResult>, DeleteLyricPresenter>();
            services.AddScoped<IRegisterOutputHandler<IActionResult>, RegisterUserPresenter>();
            services.AddScoped<IDetailsLyricsOutputHandler<IActionResult>, DetailsLyricsPresenter>();
            services.AddScoped<IAuthenticateOutputHandler<IActionResult>, AuthenticateUserPresenter>();



            return services;
        }

        public static IServiceCollection AddJwtAuthorization(this IServiceCollection services, IConfiguration configuration)
        {
            var appSettingsSection = configuration.GetSection("TokenSettings");
            services.Configure<TokenSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<TokenSettings>();
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
                        var cacheService = context.HttpContext.RequestServices.GetRequiredService<IDistributedCache>();
                        var userToken = cacheService.GetString($"{Constants.JwtTokenKey}{context.Principal.Identity.Name}");
                        
                        if (userToken != null)
                        {
                            // if userToken is not null it means token is blacklisted. Return unauthorized
                            // format of Authorization header should be Bearer xxxxxx
                            // TODO this needs to be refactored
                            if (context.Request.Headers["Authorization"][0].Equals($"Bearer {userToken}"))
                            {
                                context.Fail("Unauthorized");
                            }
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
