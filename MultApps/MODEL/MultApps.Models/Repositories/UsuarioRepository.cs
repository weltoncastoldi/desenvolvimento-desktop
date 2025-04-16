using System.Data;
using Dapper;
using MultApps.Models.Entities;
using MySql.Data.MySqlClient;

namespace MultApps.Models.Repositories
{
    public class UsuarioRepository
    {
        public string ConnectionString = "Server=localhost;Database=multapps_dev; Uid=root;Pwd=SuperSenha@10";

        public bool CadastrarUsuario(Usuario usuario)
        {
            using (IDbConnection db = new MySqlConnection(ConnectionString))
            {
                var comandoSql = @"INSERT INTO usuario (nome, cpf, email, senha, status)
                                   VALUES(@Nome,@Cpf, @Email, @Senha, @Status )";

                var parametros = new DynamicParameters();
                parametros.Add("@Nome", usuario.Nome);
                parametros.Add("@Cpf", usuario.Cpf);
                parametros.Add("@Email", usuario.Email);
                parametros.Add("@Senha", usuario.Senha);
                parametros.Add("@Status", usuario.Status);

                var resultado = db.Execute(comandoSql, parametros);
                return resultado > 0;
            }
        }
    }
}
