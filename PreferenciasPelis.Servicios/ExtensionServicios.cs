using Microsoft.Extensions.DependencyInjection;
using PreferenciaPeli.Datos;
using PreferenciaPeli.IRepositorios;
using PreferenciaPeli.IServicios;
using PreferenciaPeli.LogicaNegocio;
using PreferenciaPeli.Repositorios;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenciaPeli.Servicios
{
    public static class ExtensionServicios
    {
        public static IServiceCollection AddUserServices([NotNullAttribute] this IServiceCollection services)
        {
            services.AddScoped<IUserSer, UserSer>();
            services.AddScoped<IUserRep, UsuarioRep>();
            services.AddScoped<LogicaUser, LogicaUser>();

            services.AddDbContext<PelisContext>(ServiceLifetime.Transient);

            return services;
        }

        public static IServiceCollection AddPeliculaServices([NotNullAttribute] this IServiceCollection services)
        {
            services.AddScoped<IPeliculaSer, PeliSer>();
            services.AddScoped<IPeliculaRep, PeliculaRep>();
            services.AddScoped<LogicaPelis, LogicaPelis>();

            services.AddDbContext<PelisContext>(ServiceLifetime.Transient);

            return services;
        }
    }
}
