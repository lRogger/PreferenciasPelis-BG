using Microsoft.EntityFrameworkCore;
using PreferenciaPeli.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenciaPeli.Datos
{
    public partial class PelisContext
    {
        public virtual DbSet<UserRegistradoDS> GetUserRegistradoDs { get; set; }
        public virtual DbSet<TextoDesplegableDS> GetTextoDesplegableDs { get; set; }
        public virtual DbSet<PeliDS> GetPeliDs { get; set; }
        public virtual DbSet<DataSet> GetUsersRegistradosDS { get; set; }
    }
}
