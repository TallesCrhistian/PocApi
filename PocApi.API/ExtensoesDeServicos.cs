using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PocApi.Aplicacao.Interfaces;
using PocApi.Aplicacao.Servicos;
using PocApi.Data.Contexto;
using PocApi.Data.Interfaces;
using PocApi.Data.Repositorios;
using PocApi.Data.UnidadeDeTrabalho;
using PocApi.Negocios;
using PocApi.Negocios.Interfaces;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

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
            services.AddScoped<IProdutoServicos, ProdutoServicos>();
            services.AddScoped<IPagamentoServicos, PagamentoServicos>();
            return services;
        }

        public static IServiceCollection AdicionarNegocios(this IServiceCollection services)
        {
            services.AddScoped<IClienteNegocios, ClienteNegocios>();
            services.AddScoped<IPedidoNegocios, PedidoNegocios>();
            services.AddScoped<IUsuarioNegocios, UsuarioNegocios>();
            services.AddScoped<IProdrutoNegocios, ProdutoNegocios>();
            services.AddScoped<IPagamentoNegocios, PagamentoNegocios>();
            services.AddScoped<IPedidoPagamentoNegocios, PedidoPagamentoNegocios>();
            return services;
        }

        public static IServiceCollection AdicionarRepositorios(this IServiceCollection services)
        {
            services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
            services.AddScoped<IPedidoRepositorio, PedidoRepositorio>();
            services.AddScoped<IUsuarioRepositorio, UsuarioRositorio>();
            services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
            services.AddScoped<IPagamentoRepositorio, PagamentoRepositorio>();
            services.AddScoped<IPedidoPagamentoRepositorio, PedidoPagamentoRepositorio>();
            return services;
        }

        public static IServiceCollection UnidadeDeTrabalho(this IServiceCollection services)
        {
            services.AddScoped<IUnidadeDeTrabalho, UnidadeDeTrabalho>();
            return services;
        }
        public static IServiceCollection AdicionarAutorizacao(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("AppSettings:Token").Value)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
            return services;
        }
        public static IServiceCollection AdicionarSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PocApi.API", Version = "v1" });
                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "Header padrão de autorização usando schemma Bearer. Exemplo: \"bearer {token}\"",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.OperationFilter<SecurityRequirementsOperationFilter>();
            });
            return services;
        }
    }
}
