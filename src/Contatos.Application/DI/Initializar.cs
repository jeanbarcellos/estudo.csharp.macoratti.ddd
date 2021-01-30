using Microsoft.Extensions.DependencyInjection;
using Contatos.Domain.Interfaces;
using Contatos.Domain.Models;
using Contatos.Infra.Context;
using Contatos.Infra.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Contatos.Application.DI
{
    public class Initializer
    {

        public static void Configure(IServiceCollection services, string conection)
        {
            services.AddDbContext<AppDbContext>(opts => opts.UseNpgsql(conection));
            services.AddScoped<AppDbContext>();

            services.AddScoped(typeof(IRepository<Contato>), typeof(ContatoRepository));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped(typeof(ContatoService));

            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
        }
    }
}