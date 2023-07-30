using PreferenciaPeli.Entidades;
using PreferenciaPeli.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenciaPeli.LogicaNegocio
{
    public class LogicaPelis
    {
        private readonly IPeliculaRep _pelicularepository;

        public LogicaPelis(IPeliculaRep pelicularepository)
        {
            _pelicularepository = pelicularepository;
        }

        public Tuple<List<TextoDesplegableDS>, string> GetCategoriasPelis()
        {
            var DBresponse = Task.Run(async () => await _pelicularepository.GetCategoriaPeliculas()).Result;
            return DBresponse;
        }

        public Tuple<List<PeliDS>, string> GetPelis()
        {
            var DBresponse = Task.Run(async () => await _pelicularepository.GetPeliculas()).Result;
            return DBresponse;
        }

        public Tuple<List<PeliDS>, string> GetPelisRecomendadas(string UserName)
        {
            var DBresponse = Task.Run(async () => await _pelicularepository.GetPelisRecomendadas(UserName)).Result;
            return DBresponse;
        }
    }
}
