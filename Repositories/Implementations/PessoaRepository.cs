using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Rodrigo_Alves_Coelho_DR2_AT.Models;
using Rodrigo_Alves_Coelho_DR2_AT.Services.Implementations;
using Microsoft.Extensions.Configuration;


namespace Rodrigo_Alves_Coelho_DR2_AT.Repositories.Implementations
{
    public class PessoaRepository : IPessoaRepository
    {
            private readonly string _connectionString;

            public PessoaRepository(
                IConfiguration configuration)
            {
                _connectionString = configuration.GetValue<string>("OneToManyConnectionString");
            }

            public int Add(Pessoa pessoa)
            {
                const string cmdText = "INSERT INTO Pessoa " +
                              "		(Nome) " +
                              " OUTPUT INSERTED.Id " +
                              " VALUES	(@nome) ";

                using (var sqlConnection = new SqlConnection(_connectionString)) //já faz o close e dispose
                using (var sqlCommand = new SqlCommand(cmdText, sqlConnection)) //já faz o close
                {
                    sqlCommand.CommandType = CommandType.Text;

                    sqlCommand.Parameters
                        .Add("@nome", SqlDbType.VarChar).Value = pessoa.Nome;

                    sqlConnection.Open();

                    var resultScalar = sqlCommand.ExecuteScalar();

                    var id = (int)resultScalar;

                    return id;
                }
            }

            public IEnumerable<Pessoa> GetAll()
            {
                const string cmdText = "SELECT * FROM Pessoa;";

                using (var sqlConnection = new SqlConnection(_connectionString)) //já faz o close e dispose
                using (var sqlCommand = new SqlCommand(cmdText, sqlConnection)) //já faz o close
                {
                    sqlCommand.CommandType = CommandType.Text;

                    sqlConnection.Open();

                    var pessoas = new List<Pessoa>();
                    using (var reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            pessoas.Add(new Pessoa
                            {
                                Id = reader.GetFieldValue<int>("Id"),
                                Nome = reader.GetFieldValue<string>("Nome")
                            });
                        }
                    }

                    return pessoas;
                }
            }

            public Pessoa GetById(int id)
            {
                const string cmdText = "SELECT * FROM Pessoa WHERE Id = @id";

                using (var sqlConnection = new SqlConnection(_connectionString))
                using (var sqlCommand = new SqlCommand(cmdText, sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.Text;

                    sqlCommand.Parameters
                        .Add("@id", SqlDbType.Int).Value = id;

                    sqlConnection.Open();
                    return ReadPessoa(sqlCommand);
                }
            }

        private static Pessoa ReadPessoa(SqlCommand sqlCommand)
            {
                using (var reader = sqlCommand.ExecuteReader())
                {
                    if (!reader.Read())
                        return null;

                    return new Pessoa
                    {
                        Id = reader.GetFieldValue<int>("Id"),
                        Nome = reader.GetFieldValue<string>("Nome")
                    };
                }
            }

            public void Update(int id, Pessoa pessoaUpdated)
            {
                const string cmdText = "UPDATE Pessoa " +
                              "SET " +
                              "Nome = (@nome) " +
                              "WHERE Id = @id;";

                using (var sqlConnection = new SqlConnection(_connectionString)) //já faz o close e dispose
                using (var sqlCommand = new SqlCommand(cmdText, sqlConnection)) //já faz o close
                {
                    sqlCommand.CommandType = CommandType.Text;

                    sqlCommand.Parameters
                        .Add("@nome", SqlDbType.VarChar).Value = pessoaUpdated.Nome;
                    sqlCommand.Parameters
                        .Add("@id", SqlDbType.Int).Value = pessoaUpdated.Id;

                    sqlConnection.Open();

                    sqlCommand.ExecuteScalar();
                }
            }

            public void Delete(int id)
            {
                const string cmdText = "DELETE FROM Pessoa " +
                                       "WHERE Id = @id;";

                using (var sqlConnection = new SqlConnection(_connectionString)) //já faz o close e dispose
                using (var sqlCommand = new SqlCommand(cmdText, sqlConnection)) //já faz o close
                {
                    sqlCommand.CommandType = CommandType.Text;

                    sqlCommand.Parameters
                        .Add("@id", SqlDbType.Int).Value = id;

                    sqlConnection.Open();

                    sqlCommand.ExecuteScalar();
                }
            }

        
    }
}
