using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenciaPeli.Entidades
{
    public partial class CategoriaPeli
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public virtual ICollection<PelisRecomendadas> PelisRecomendadas { get; set; } = new List<PelisRecomendadas>();
        public virtual ICollection<PreferenciaUsuario> PreferenciaUsuarios { get; set; } = new List<PreferenciaUsuario>();

    }
}
