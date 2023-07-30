using PreferenciaPeli.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenciaPeli.IRepositorios
{
    public interface IPeliculaRep
    {
        Task<Tuple<List<TextoDesplegableDS>, string>> GetCategoriaPeliculas();
        Task<Tuple<List<PeliDS>, string>> GetPeliculas();
        Task<Tuple<List<PeliDS>, string>> GetPelisRecomendadas(string User);
    }
}
