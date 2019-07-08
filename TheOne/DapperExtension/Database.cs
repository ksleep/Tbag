using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DapperExtension
{
    public partial interface IDatabase : IDisposable
    {
        void Commit();
        void Rollback();
        void RunInTransaction(Action action);
        //void RunInTransaction(Action<IDatabase> action);
        IDbConnection Connection { get; }
    }

    public partial class Database : IDatabase
    {
        private readonly IDapperImplementor _dapper;
        private readonly ISqlGenerator _sqlGenerator;

        private IDbTransaction _transaction;

        public Database(IDbConnection connection)
        {
            _dapper = new DapperImplementor(_sqlGenerator);
            Connection = connection;
            Connection.Close();
            if (Connection.State != ConnectionState.Open)
            {
                Connection.Open();
            }
        }
        public Database(IOptions<DataBaseOptions> options)
        {
            //_dapper = new DapperImplementor(new SqlGeneratorImpl(Configuration));
            Connection = options.Value.DbConnection();

            if (Connection.State != ConnectionState.Open)
            {
                Connection.Open();
            }
        }
        public bool HasActiveTransaction => _transaction != null;
        public IDbConnection Connection { get; }

        public void Dispose()
        {
            if (Connection.State != ConnectionState.Closed)
            {
                _transaction?.Rollback();
                Connection.Close();
            }
        }

        /// <summary>
        /// 事务
        /// </summary>

        public void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            _transaction = Connection.BeginTransaction(isolationLevel);
        }
        public void Commit()
        {
            _transaction?.Commit();
            _transaction = null;
        }

        public void Rollback()
        {
            _transaction.Rollback();
            _transaction = null;
        }

        public void RunInTransaction(Action action)
        {
            BeginTransaction();
            try
            {
                action();
                Commit();
            }
            catch (Exception ex)
            {
                if (HasActiveTransaction)
                {
                    Rollback();
                }

                throw ex;
            }
        }

    }
    public class DataBaseOptions
    {
       // public ISqlDialect sqlDialect { get; set; }

        public Func<IDbConnection> DbConnection { get; set; }
    }
}
