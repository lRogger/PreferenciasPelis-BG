using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PreferenciaPeli.Entidades;
using PreferenciaPeli.IRepositorios;
using PreferenciaPeli.Datos;
using PreferenciaPeli.ModeloVista.DTO;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace PreferenciaPeli.Repositorios
{
    public class PeliculaRep : IPeliculaRep
    {
        private readonly IServiceProvider _serviceProvider;
        public PeliculaRep(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<Tuple<List<TextoDesplegableDS>, string>> GetCategoriaPeliculas()
        {
            string mensajeDb = "";
            List<TextoDesplegableDS> listaTextoD = null!;
            Tuple<List<TextoDesplegableDS>, string> textoD = null!;

            using (var db = _serviceProvider.GetService<Datos.PelisContext>())
            {
                listaTextoD = await db.GetTextoDesplegableDs.FromSqlInterpolated(@$"sp_CategoriaPeliculaSelect").ToListAsync();
            }
            textoD = new Tuple<List<TextoDesplegableDS>, string>(listaTextoD, mensajeDb);
            return textoD;
        }

        public async Task<Tuple<List<PeliDS>, string>> GetPeliculas()
        {
            string? mensajeDb = "";
            List<PeliDS> listare = null!;
            Tuple<List<PeliDS>, string> data = null!;

            using (var db = _serviceProvider.GetService<Datos.PelisContext>())
            {
                listare = await db.GetPeliDs.FromSqlInterpolated(@$"sp_PeliculasSelect").ToListAsync();
            }

            data = new Tuple<List<PeliDS>, string>(listare, mensajeDb);
            return data;
        }

        public async Task<Tuple<List<PeliDS>, string>> GetPelisRecomendadas(string nombre)
        {
            string? mensajeDb = "";
            List<PeliDS> listare = null!;
            Tuple<List<PeliDS>, string> data = null!;


            using (var db = _serviceProvider.GetService<Datos.PelisContext>())
            {
                listare = await db.GetPeliDs.FromSqlInterpolated(@$"sp_PelisRecomendadasSelect 
                          @Nombre= {nombre}").ToListAsync();
            }

            data = new Tuple<List<PeliDS>, string>(listare, mensajeDb);
            return data;

        }
    }
}
