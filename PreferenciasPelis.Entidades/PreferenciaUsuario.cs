using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenciaPeli.Entidades
{
    public partial class PreferenciaUsuario
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdCategoriaPeli { get; set; }
        public virtual CategoriaPeli IdCategoriaPeliNav { get; set; } = null!;
        public virtual User IdUserNav { get; set; } = null!;
    }
}
