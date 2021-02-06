using System;
using System.Data.SqlClient;

namespace refactor_this.Services
{
    public class QueryService
    {
        protected SqlConnection _connection => Helpers.NewConnection();

        public QueryService()
        {
        }
    }
}
