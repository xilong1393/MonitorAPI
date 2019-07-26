using System;
using System.Data.SqlClient;
using System.Transactions;

namespace MonitorAPI.Dao.framework
{
    public class PersistenceContext : IDisposable
    {
        private SqlConnection connection;
        private TransactionScope transactionScope;

        /// <summary>
        /// default transaction timeout span：300s.
        /// </summary>
        public static readonly TimeSpan DEFAULT_TRANSCATION_TIMEOUT = TimeSpan.FromSeconds(300);

        /// <summary>
        /// default isolationLevel：Read Committed
        /// </summary>
        public const IsolationLevel DEFAULT_ISOLATION_LEVEL = IsolationLevel.ReadCommitted;

        public SqlConnection Connection
        {
            get
            {
                if (connection == null)
                {
                    connection = SqlHelper.GetConnection();
                    connection.Open();
                }

                return connection;
            }

            set
            {
                connection = value;
            }
        }

        public PersistenceContext()
        {
        }

        /// <summary>
        /// create a persistence context with a designated database
        /// </summary>
        /// <param name="conn"></param>
        public PersistenceContext(SqlConnection conn)
        {
            connection = conn;
        }

        public PersistenceContext(IsolationLevel isolationLevel)
           : this(isolationLevel, DEFAULT_TRANSCATION_TIMEOUT) { }

        /// <summary>
        /// create a transaction with isolationLevel and transactionTimeout
        /// </summary>
        /// <param name="isolationLevel"></param>
        /// <param name="transactionTimeout"></param>
        public PersistenceContext(IsolationLevel isolationLevel, TimeSpan transactionTimeout)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = isolationLevel;
            options.Timeout = transactionTimeout;

            transactionScope = new TransactionScope(TransactionScopeOption.Required, options);
        }

        public void Commit()
        {
            if (transactionScope != null)
            {
                transactionScope.Complete();
            }
        }


        public void Dispose()
        {
            if (connection != null)
            {
                connection.Dispose();
                connection = null;
            }

            if (transactionScope != null)
            {
                transactionScope.Dispose();
                transactionScope = null;
            }
        }
    }
}
