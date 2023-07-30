using PreferenciaPeli.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenciaPeli.IRepositorios
{
    public interface IUserRep
    {
        Task<string> SetUser(string user, string pwd);
        Task<Tuple<List<UserRegistradoDS>, string>> GetUsersRegistrados();
        Task<Tuple<DataSet, string>> GetUsersRegistradosDS();
    }
}
