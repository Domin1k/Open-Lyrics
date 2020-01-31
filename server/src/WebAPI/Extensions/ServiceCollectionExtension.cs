namespace WebAPI.Extensions
{
    using Application.Interfaces;
    using Application.Interfaces.Repositories;
    using Application.UseCases.User.Login;
    using Application.UseCases.User.Register;
    using Infrastructure;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;
    using Persistence.Repositories;
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
    }
}
