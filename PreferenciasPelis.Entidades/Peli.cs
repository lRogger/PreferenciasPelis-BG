using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenciaPeli.Entidades
{
    public partial class Peli
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public virtual ICollection<PelisRecomendadas> PelisRecomendadas { get; set; } = new List<PelisRecomendadas>();
    }
}
