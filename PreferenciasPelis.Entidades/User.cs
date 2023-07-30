using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenciaPeli.Entidades
{
    public partial class User
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Pwd { get; set; }
        public virtual ICollection<PreferenciaUsuario> PreferenciaUsuarios { get; set; } = new List<PreferenciaUsuario>();
    }
}
