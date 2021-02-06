using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using refactor_this.Models;

namespace refactor_this.Services
{
    public class TransactionQueryService: QueryService
    {
        public enum TransactionResponse
        {
            Ok,
            UpdateError,
            InsertError,
        }

        public List<Transaction> GetTransactions(Guid id)
        {
            using (_connection)
            {
                SqlCommand command = new SqlCommand($"select Amount, Date from Transactions where AccountId = '{id}'", _connection);
                _connection.Open();
                var reader = command.ExecuteReader();
                var transactions = new List<Transaction>();
                while (reader.Read())
                {
                    var amount = (float)reader.GetDouble(0);
                    var date = reader.GetDateTime(1);
                    transactions.Add(new Transaction(amount, date));
                }
                _connection.Close();
                return transactions;
            }
        }

        public TransactionResponse AddTransaction(Guid id, Transaction transaction)
        {
            using (_connection)
            {
                SqlCommand command = new SqlCommand($"update Accounts set Amount = Amount + {transaction.Amount} where Id = '{id}'", _connection);
                _connection.Open();
                if (command.ExecuteNonQuery() != 1)
                {
                    _connection.Close();
                    return TransactionResponse.UpdateError;
                }

                command = new SqlCommand($"INSERT INTO Transactions (Id, Amount, Date, AccountId) VALUES ('{Guid.NewGuid()}', {transaction.Amount}, '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}', '{id}')", _connection);
                if (command.ExecuteNonQuery() != 1)
                {
                    _connection.Close();
                    return TransactionResponse.InsertError;
                }

                _connection.Close();
                return TransactionResponse.Ok;
            }
        }

    }
}
