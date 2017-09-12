using System;

namespace DataAccess.Ado.Net
{
    public class DaoFactory : IDaoFactory
    {
        private IConnectionFactory _connectionFactory;

        public DaoFactory(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public IAccountDao AccountDao
        {
            get { return new AccountDao(_connectionFactory); }
        }

    }
}