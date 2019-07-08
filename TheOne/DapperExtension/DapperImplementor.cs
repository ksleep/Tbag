using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DapperExtension
{
    public interface IDapperImplementor
    {
        ISqlGenerator SqlGenerator { get; }
        T GetSQL<T>(IDbConnection connection, string sql, object dynamicParameters, IDbTransaction transaction, int? commandTimeout) where T : class;
        bool ExecuteSQL(IDbConnection connection, string sql, object dynamicParameters, IDbTransaction transaction, int? commandTimeout, CommandType commandType = CommandType.Text);
        IEnumerable<T> GetListSQL<T>(IDbConnection connection, string sql, object dynamicParameters, IDbTransaction transaction, int? commandTimeout, bool buffered) where T : class;

        T GetSQLField<T>(IDbConnection connection, string sql, object dynamicParameters, IDbTransaction transaction, int? commandTimeout);

        dynamic GetSQLDynamic(IDbConnection connection, string sql, object dynamicParameters, IDbTransaction transaction, int? commandTimeout);
        Page<T> GetPagesSQL<T>(IDbConnection connection, string sql, string sqlCount, object dynamicParameters, int page, int resultsPerPage, IDbTransaction transaction, int? commandTimeout, bool buffered) where T : class;

        IEnumerable<dynamic> GetListSQLDynamic(IDbConnection connection, string sql, object dynamicParameters, IDbTransaction transaction, int? commandTimeout, bool buffered);

        //dynamic Insert<T>(IDbConnection connection, T entity, IDbTransaction transaction, int? commandTimeout, string tableName, string schemaName) where T : class;
        ///
        ///
        ///
        /// 
        string GetPagingSql(string sql, int page, int resultsPerPage, IDictionary<string, object> parameters);
    }

    /// <summary>
    /// 数据库操作的实现
    /// </summary>
    public class DapperImplementor : IDapperImplementor
    {
      
        public DapperImplementor(ISqlGenerator sqlGenerator)
        {
            SqlGenerator = sqlGenerator;
        }
        public ISqlGenerator SqlGenerator { get; }

        public T GetSQL<T>(IDbConnection connection, string sql, object dynamicParameters, IDbTransaction transaction, int? commandTimeout) where T : class
        {

            var result = GetSQLQuery<T>(connection, sql, dynamicParameters, transaction, commandTimeout, false).SingleOrDefault();
            return result;
        }
        protected IEnumerable<T> GetSQLQuery<T>(IDbConnection connection, string sql, object dynamicParameters, IDbTransaction transaction, int? commandTimeout, bool buffered) where T : class
        {
            return connection.Query<T>(sql, dynamicParameters, transaction, buffered, commandTimeout, CommandType.Text);
        }
        public bool ExecuteSQL(IDbConnection connection, string sql, object dynamicParameters, IDbTransaction transaction, int? commandTimeout, CommandType commandType = CommandType.Text)
        {
            var result = connection.Execute(sql, dynamicParameters, transaction, commandTimeout, commandType) > 0;
            return result;
        }

        public IEnumerable<T> GetListSQL<T>(IDbConnection connection, string sql, object dynamicParameters, IDbTransaction transaction, int? commandTimeout, bool buffered) where T : class
        {
            var result = GetSQLQuery<T>(connection, sql, dynamicParameters, transaction, commandTimeout, buffered);
            return result;
        }
        public T GetSQLField<T>(IDbConnection connection, string sql, object dynamicParameters, IDbTransaction transaction, int? commandTimeout)
        {
            var value = connection.ExecuteScalar<T>(sql, dynamicParameters, transaction, commandTimeout, CommandType.Text);
            return value;
        }
        public dynamic GetSQLDynamic(IDbConnection connection, string sql, object dynamicParameters, IDbTransaction transaction, int? commandTimeout)
        {
            var result = GetSQLQuery<dynamic>(connection, sql, dynamicParameters, transaction, commandTimeout, false).SingleOrDefault();
            return result;
        }
        public Page<T> GetPagesSQL<T>(IDbConnection connection, string sql, string sqlCount, object dynamicParameters, int page, int resultsPerPage, IDbTransaction transaction, int? commandTimeout, bool buffered) where T : class
        {
            var total = connection.ExecuteScalar(sqlCount, dynamicParameters, transaction, commandTimeout,
                CommandType.Text);
            var PageResult = new Page<T>
            {
                CurrentPage = page,
                ItemsPerPage = resultsPerPage,
                TotalItems = (long?)total ?? 0
            };
            //sql = SqlGenerator.GetPagingSql(sql, page, resultsPerPage, null);
            sql = GetPagingSql(sql, page, resultsPerPage, null);

            PageResult.Items = connection.Query<T>(sql, dynamicParameters, transaction, buffered, commandTimeout, CommandType.Text);
            return PageResult;
        }

        public IEnumerable<dynamic> GetListSQLDynamic(IDbConnection connection, string sql, object dynamicParameters, IDbTransaction transaction, int? commandTimeout, bool buffered)
        {
            var result = GetSQLQuery<dynamic>(connection, sql, dynamicParameters, transaction, commandTimeout, buffered);
            return result;
        }

        public string GetPagingSql(string sql, int page, int resultsPerPage, IDictionary<string, object> parameters)
        {
            var startValue = page * resultsPerPage;
            var sqlstring = GetSetSql(sql, startValue, resultsPerPage, parameters);
            //sql = Configuration.Dialect.GetPagingSql(sql.ToString(), page, resultsPerPage, parameters);
            return sqlstring;
        }

        /// <summary>
        /// sql LIMIT的凭拼接
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="firstResult"></param>
        /// <param name="maxResults"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public  string GetSetSql(string sql, int firstResult, int maxResults, IDictionary<string, object> parameters)
        {
            //DOING
            if (parameters == null)
                return string.Format("{0} LIMIT {1}, {2}", sql, firstResult, maxResults);

            var result = string.Format("{0} LIMIT @firstResult, @maxResults", sql);
            parameters.Add("@firstResult", firstResult);
            parameters.Add("@maxResults", maxResults);
            return result;
        }
    }
}
