using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PreferenciaPeli.Entidades;
using PreferenciaPeli.IRepositorios;
using System.Data;

namespace PreferenciaPeli.Repositorios
{
    public class UsuarioRep : IUserRep
    {
        private readonly IServiceProvider _serviceProvider;
        public UsuarioRep(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<string> SetUser(string nombre, string pwd)
        {
            string? DBresult;

            SqlParameter user = new SqlParameter("@Nombre", nombre);
            SqlParameter pass = new SqlParameter("@Pwd", pwd);
            SqlParameter mensaje = new SqlParameter("@Mensaje", DBNull.Value);


            using (var db = _serviceProvider.GetService<Datos.PelisContext>())
            {
                var resultado = db.Set<UsertInDS>().FromSqlRaw(@$"EXEC [dbo].[sp_UsuarioInsert] @Nombre, @Pwd, @Mensaje OUTPUT ", user, pass, mensaje);

                DBresult = mensaje.Value?.ToString();
            }
            return DBresult!;
        }

        public async Task<Tuple<List<UserRegistradoDS>, string>> GetUsersRegistrados()
        {
            string? mensajeDb = "";
            List<UserRegistradoDS> listare = null!;
            Tuple<List<UserRegistradoDS>, string> data = null!;


            using (var db = _serviceProvider.GetService<Datos.PelisContext>())
            {
                listare = await db.GetUserRegistradoDs.FromSqlInterpolated(@$"sp_UserSelect").ToListAsync();
            }

            data = new Tuple<List<UserRegistradoDS>, string>(listare, mensajeDb);
            return data;

        }

        public async Task<Tuple<DataSet, string>> GetUsersRegistradosDS()
        {
            string? mensajeDb = "";
            DataSet listare = null!;
            Tuple<DataSet, string> data = null!;


            using (var db = _serviceProvider.GetService<Datos.PelisContext>())
            {
                listare = (DataSet)db.GetUsersRegistradosDS.FromSqlInterpolated(@$"sp_UserSelect 
                       ");
            }

            data = new Tuple<DataSet, string>(listare, mensajeDb);
            return data;
        }
    }
}
