using BroCode.BlogTemplate.Application.Contracts;
using BroCode.BlogTemplate.Application.Services;
using BroCode.BlogTemplate.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BroCode.BlogTemplate.IoC
{
    public static class DependencyResolver
    {

        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IUserService, UserService>();
        }
    }
}
