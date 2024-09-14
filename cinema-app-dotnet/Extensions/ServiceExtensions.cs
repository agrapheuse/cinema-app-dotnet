using Contracts;
using LoggerService;
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;
using Repository;
using Service;
using Service.Contracts;

namespace cinemaApp.Extensions;

public static class ServiceExtensions
{
	public static void ConfigureCors(this IServiceCollection services) =>
		services.AddCors(options =>
		{
			options.AddPolicy("CorsPolicy", builder =>
			builder.AllowAnyOrigin()
			.AllowAnyMethod()
			.AllowAnyHeader());
		});

	public static void ConfigureIISIntegration(this IServiceCollection services) =>
		services.Configure<IISOptions>(options =>
		{
		});

    public static void ConfigureLoggerService(this IServiceCollection services) =>
		services.AddSingleton<ILoggerManager, LoggerManager>();

	public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration) =>
        services.AddDbContext<RepositoryContext>(opts =>
			opts.UseMySQL(configuration.GetConnectionString("MySqlConnection")));

    public static void ConfigureRepositoryManager(this IServiceCollection services) =>
		services.AddScoped<IRepositoryManager, RepositoryManager>();

    public static void ConfigureServiceManager(this IServiceCollection services) =>
		services.AddScoped<IServiceManager, ServiceManager>();
}