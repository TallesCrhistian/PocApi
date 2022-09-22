using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PocApi.Data.Contexto;

namespace PocApi.API
{
    public static class ExtensoesDeServicos
    {
           public static IServiceCollection AdicionaBancoDeDados(this IServiceCollection services, IConfiguration iConfiguration)
        {
            services.AddDbContext<AppDbContext>(x => x.UseSqlServer(iConfiguration.GetConnectionString("DefaultConnection")));
            
            return services;
        }
    }
}
