using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PocApi.Aplicacao.Servicos;
using PocApi.Data.Contexto;
using PocApi.Data.Interfaces;
using PocApi.Data.Repositorios;
using PocApi.Negocios;
using PocApi.Negocios.Interfaces;

namespace PocApi.API
{
    public static class ExtensoesDeServicos
    {
           public static IServiceCollection AdicionaBancoDeDados(this IServiceCollection services, IConfiguration iConfiguration)
        {
            services.AddDbContext<AppDbContext>(x => x.UseSqlServer(iConfiguration.GetConnectionString("DefaultConnection")));
            
            return services;
        }
        public static IServiceCollection AdicionarServicos(this IServiceCollection services)
        {
            services.AddScoped<IClienteServicos, ClienteServicos>();
            return services;
        }
        public static IServiceCollection AdicionarNegocios(this IServiceCollection services)
        {
            services.AddScoped<IClienteNegocios, ClienteNegocios>();
            return services;
        }
        public static IServiceCollection AdicionarRepositorios(this IServiceCollection services)
        {
            services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
            return services;
        }
    }
}
