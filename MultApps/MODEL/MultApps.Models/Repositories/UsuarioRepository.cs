using System;
using System.Data;
using System.Linq;
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

        public bool EmailExistente(string email)
        {
            using(IDbConnection db = new MySqlConnection(ConnectionString))
            {
                var comandoSql = @"SELECT COUNT(*) FROM usuario WHERE email = @Email";
                var parametros = new DynamicParameters();
                parametros.Add("@Email", email);
                var resultado = db.ExecuteScalar<int>(comandoSql, parametros);
                return resultado > 0;
            }
        }

        public DataTable ListarUsuarios()
        {
            using (IDbConnection db = new MySqlConnection(ConnectionString))
            {
                var comandoSql = @"SELECT id AS Id, 
                                          nome AS Nome, 
                                          cpf AS Cpf, 
                                          email AS Email, 
                                          data_cadastro AS DataCadastro,
                                          data_alteracao AS DataAlteracao,
                                          data_ultimo_acesso AS DataUltimoAcesso     
                                   FROM usuario"; 
                var usuarios = db.Query<Usuario>(comandoSql).ToList();
                // Converte a lista de usuários para um DataTable
                var dataTable = new DataTable();
                dataTable.Columns.Add("Id", typeof(int));
                dataTable.Columns.Add("Nome", typeof(string));
                dataTable.Columns.Add("Cpf", typeof(string));
                dataTable.Columns.Add("Email", typeof(string));
                dataTable.Columns.Add("Data Cadastro", typeof(DateTime));
                dataTable.Columns.Add("Data Alteracao", typeof(DateTime));
                dataTable.Columns.Add("Data Ultimo Acesso", typeof(DateTime));
                foreach (var usuario in usuarios)
                {
                    dataTable.Rows.Add(usuario.Id,
                        usuario.Nome,
                        usuario.Cpf,
                        usuario.Email,
                        usuario.DataCriacao,
                        usuario.DataAlteracao,
                        usuario.DataUltimoAcesso);
                }
                return dataTable;
            }
        }

        public DataTable ListarUsuariosPorStatus(int status)
        {
            using (IDbConnection db = new MySqlConnection(ConnectionString))
            {
                var comandoSql = @"SELECT id AS Id, 
                                          nome AS Nome, 
                                          cpf AS Cpf, 
                                          email AS Email, 
                                          data_cadastro AS DataCadastro,
                                          data_alteracao AS DataAlteracao,
                                          data_ultimo_acesso AS DataUltimoAcesso     
                                   FROM usuario
                                   WHERE status = @Status";

                var parametros = new DynamicParameters();
                parametros.Add("@Status", status);

                var usuarios = db.Query<Usuario>(comandoSql, parametros).ToList();
                
                // Converte a lista de usuários para um DataTable
                var dataTable = new DataTable();
                dataTable.Columns.Add("Id", typeof(int));
                dataTable.Columns.Add("Nome", typeof(string));
                dataTable.Columns.Add("Cpf", typeof(string));
                dataTable.Columns.Add("Email", typeof(string));
                dataTable.Columns.Add("Data Cadastro", typeof(DateTime));
                dataTable.Columns.Add("Data Alteracao", typeof(DateTime));
                dataTable.Columns.Add("Data Ultimo Acesso", typeof(DateTime));
                foreach (var usuario in usuarios)
                {
                    dataTable.Rows.Add(usuario.Id,
                        usuario.Nome,
                        usuario.Cpf,
                        usuario.Email,
                        usuario.DataCriacao,
                        usuario.DataAlteracao,
                        usuario.DataUltimoAcesso);
                }
                return dataTable;
            }
        }

        public Usuario ObterUsuarioPorId(int id)
        {
            using (IDbConnection db = new MySqlConnection(ConnectionString))
            {
                var comandoSql = @"SELECT 
                                    id AS Id, 
                                    nome AS Nome,
                                    cpf AS Cpf, 
                                    email AS Email,
                                    data_cadastro AS DataCriacao,
                                    data_ultimo_acesso AS DataUltimoAcesso, 
                                    status AS Status
                                   FROM usuario 
                                   WHERE id = @Id";
                var parametros = new DynamicParameters();
                parametros.Add("@Id", id);
                var resultado = db.Query<Usuario>(comandoSql, parametros).FirstOrDefault();
                return resultado;
            }
        }

        public Usuario ObterUsuarioPorEmail(string email)
        {
            using (IDbConnection db = new MySqlConnection(ConnectionString))
            {
                var comandoSql = @"SELECT 
                                    id AS Id, 
                                    nome AS Nome,
                                    email AS Email,
                                    senha AS Senha,
                                    status AS Status
                                   FROM usuario 
                                   WHERE email = @Email";
                var parametros = new DynamicParameters();
                parametros.Add("@Email", email);
                var resultado = db.Query<Usuario>(comandoSql, parametros).FirstOrDefault();
                return resultado;
            }
        }

        public bool AtualizarSenha(string novaSenha, string email)
        {
            using (IDbConnection db = new MySqlConnection(ConnectionString))
            {
                var comandoSql = @"UPDATE usuario
                                   SET senha = @Senha
                                   WHERE email = @Email";

                var parametros = new DynamicParameters();
                parametros.Add("@Senha", novaSenha);
                parametros.Add("@Email", email);

                var resposta = db.Execute(comandoSql, parametros);
                return resposta > 0;
            }
        }
    }
}
