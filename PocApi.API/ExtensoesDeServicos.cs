using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PocApi.Aplicacao.Interfaces;
using PocApi.Aplicacao.Servicos;
using PocApi.Data.Contexto;
using PocApi.Data.Interfaces;
using PocApi.Data.Repositorios;
using PocApi.Data.UnidadeDeTrabalho;
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
            services.AddScoped<IPedidoServicos, PedidoServicos>();
            services.AddScoped<IUsuarioServicos, UsuarioServicos>();
            return services;
        }

        public static IServiceCollection AdicionarNegocios(this IServiceCollection services)
        {
            services.AddScoped<IClienteNegocios, ClienteNegocios>();
            services.AddScoped<IPedidoNegocios, PedidoNegocios>();
            services.AddScoped<IUsuarioNegocios, UsuarioNegocios>();
            return services;
        }

        public static IServiceCollection AdicionarRepositorios(this IServiceCollection services)
        {
            services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
            services.AddScoped<IPedidoRepositorio, PedidoRepositorio>();
            services.AddScoped<IUsuarioRepositorio, UsuarioRositorio>();
            return services;
        }

        public static IServiceCollection UnidadeDeTrabalho(this IServiceCollection services)
        {
            services.AddScoped<IUnidadeDeTrabalho, UnidadeDeTrabalho>();
            return services;
        }
    }
}
