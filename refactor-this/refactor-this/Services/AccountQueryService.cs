using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using refactor_this.Models;

namespace refactor_this.Services
{
    public class AccountQueryService : QueryService
    {
        public Account Get(Guid id)
        {
            using (_connection)
            {
                SqlCommand command = new SqlCommand($"select * from Accounts where Id = '{id}'", _connection);
                _connection.Open();
                var reader = command.ExecuteReader();
                if (!reader.Read())
                    throw new ArgumentException();

                var account = new Account(id);
                account.Name = reader["Name"].ToString();
                account.Number = reader["Number"].ToString();
                account.Amount = float.Parse(reader["Amount"].ToString());
                _connection.Close();
                return account;
            }
        }

        public List<Guid> GetAccountIds()
        {
            using (_connection)
            {
                SqlCommand command = new SqlCommand($"select Id from Accounts", _connection);
                _connection.Open();
                var ids = new List<Guid>();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ids.Add(Guid.Parse(reader["Id"].ToString()));
                }
                _connection.Close();
                return ids;
            }
        }

        public void Save(Account account)
        {
            using (_connection)
            {
                SqlCommand command;
                if (account.IsNew())
                    command = new SqlCommand($"insert into Accounts (Id, Name, Number, Amount) values ('{Guid.NewGuid()}', '{account.Name}', {account.Number}, 0)", _connection);
                else
                    command = new SqlCommand($"update Accounts set Name = '{account.Name}' where Id = '{account.Id}'", _connection);

                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();
            }
        }

        public void DeleteById(Guid id)
        {
            using (_connection)
            {
                SqlCommand command = new SqlCommand($"delete from Accounts where Id = '{id}'", _connection);
                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();
            }
        }
    }
}
