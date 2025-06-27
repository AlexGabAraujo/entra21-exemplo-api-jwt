using APIESTUDOPROVA.Contracts.InfraStructure;
using APIESTUDOPROVA.Contracts.Repository;
using APIESTUDOPROVA.DTO;
using APIESTUDOPROVA.Entities;
using Dapper;
using MySql.Data.MySqlClient;

namespace APIESTUDOPROVA.Repository
{
    public class PessoaRepository : IPessoaRepository
    {

        private IConnection _connection;

        public PessoaRepository(IConnection connection)
        {
            _connection = connection;
        }

        public async Task Delete(int id)
        {
            string sql = "DELETE FROM PESSOA WHERE ID = @id";
            await _connection.Execute(sql, new { id });
        }

        public async Task<IEnumerable<PessoaEntity>> GetAll()
        {
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                    SELECT ID AS {nameof(PessoaEntity.Id)},
                           NOME AS {nameof(PessoaEntity.Nome)},
                           EMAIL AS {nameof(PessoaEntity.Email)}
                      FROM PESSOA
                ";

                return await con.QueryAsync<PessoaEntity>(sql);
            }
        }

        public async Task<PessoaEntity> GetById(int id)
        {
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                    SELECT ID AS {nameof(PessoaEntity.Id)},
                           NOME AS {nameof(PessoaEntity.Nome)},
                           EMAIL AS {nameof(PessoaEntity.Email)}
                      FROM PESSOA 
                     WHERE ID = @id
                ";

                return await con.QueryFirstAsync<PessoaEntity>(sql, new { id }); ;
            }

        }

        public async Task Insert(PessoaInsertDTO user)
        {
            string sql = @$"
                INSERT INTO PESSOA (NOME, EMAIL, SENHA)
                               VALUE (@Name, @Email, @Senha)            
            ";

            await _connection.Execute(sql, user);
        }

        public async Task<PessoaEntity> Login(PessoaLoginDTO user)
        {
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                    SELECT ID AS {nameof(PessoaEntity.Id)},
                           NOME AS {nameof(PessoaEntity.Nome)},
                           EMAIL AS {nameof(PessoaEntity.Email)}
                      FROM PESSOA 
                     WHERE EMAIL = @Email AND SENHA = @Senha
                ";

                return await con.QueryFirstAsync<PessoaEntity>(sql, user);
            }

        }

        public async Task Update(PessoaEntity user)
        {
            string sql = @"
                UPDATE PESSOA
                   SET NOME = @Nome,
                       EMAIL = @Email,
                       SENHA = @Senha
                 WHERE ID = @Id
            ";

            await _connection.Execute(sql, user);
        }
    }
}
