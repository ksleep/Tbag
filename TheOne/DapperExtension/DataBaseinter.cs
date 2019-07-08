using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DapperExtension
{
    public partial interface IDatabase
    {


        #region SQL

        /// <summary>
        /// 返回单条查询数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="dynamicParameters"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        T GetSQL<T>(string sql, object dynamicParameters = null, int? commandTimeout = null) where T : class;

        /// <summary>
        /// 返回list集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="dynamicParameters"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="buffered"></param>
        /// <returns></returns>
        IEnumerable<T> GetListSQL<T>(string sql, object dynamicParameters = null, int? commandTimeout = null, bool buffered = true) where T : class;

        /// <summary>
        /// 返回一个类型的T 
        /// </summary>
        /// <typeparam name="T">int string</typeparam>
        /// <param name="sql"></param>
        /// <param name="dynamicParameters"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        T GetSQLField<T>(string sql, object dynamicParameters = null, int? commandTimeout = null);

        /// <summary>
        /// 增删改 返回bool类型
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="dynamicParameters"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        bool ExecuteSQL(string sql, object dynamicParameters = null, int? commandTimeout = null, CommandType commandType = CommandType.Text);

        /// <summary>
        /// sql 查询返回动态dynamic
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="dynamicParameters"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        dynamic GetSQLDynamic(string sql, object dynamicParameters = null, int? commandTimeout = null);

        /// <summary>
        /// 返回含分页的数据
        /// </summary>
        /// <typeparam name="T">Model</typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="sqlCount">总数</param>
        /// <param name="page">页数</param>
        /// <param name="resultsPerPage">每页的数量</param>
        /// <param name="dynamicParameters"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="buffered"></param>
        /// <returns></returns>
        Page<T> GetPagesSQL<T>(string sql, string sqlCount, int page, int resultsPerPage, object dynamicParameters = null, int? commandTimeout = null, bool buffered = true) where T : class;

        /// <summary>
        /// 根据字段动态生成list
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="dynamicParameters"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="buffered"></param>
        /// <returns></returns>
        IEnumerable<dynamic> GetListSQLDynamic(string sql, object dynamicParameters = null, int? commandTimeout = null, bool buffered = true);
        #endregion
        // dynamic Insert<T>(T entity, int? commandTimeout = null) where T : class;
    }


    /// <summary>
    /// dapper的映射
    /// </summary>
    public partial class Database
    {


        public T GetSQL<T>(string sql, object dynamicParameters, int? commandTimeout) where T : class
        {
            return _dapper.GetSQL<T>(Connection, sql, dynamicParameters, _transaction, commandTimeout);
        }
        public IEnumerable<T> GetListSQL<T>(string sql, object dynamicParameters, int? commandTimeout, bool buffered = true) where T : class
            => _dapper.GetListSQL<T>(Connection, sql, dynamicParameters, _transaction, commandTimeout, buffered);
        public T GetSQLField<T>(string sql, object dynamicParameters, int? commandTimeout)
            => _dapper.GetSQLField<T>(Connection, sql, dynamicParameters, _transaction, commandTimeout);
        public bool ExecuteSQL(string sql, object dynamicParameters, int? commandTimeout, CommandType commandType = CommandType.Text)
            => _dapper.ExecuteSQL(Connection, sql, dynamicParameters, _transaction, commandTimeout, commandType);
        public dynamic GetSQLDynamic(string sql, object dynamicParameters, int? commandTimeout)
            => _dapper.GetSQLDynamic(Connection, sql, dynamicParameters, _transaction, commandTimeout);
        public Page<T> GetPagesSQL<T>(string sql, string sqlCount, int page, int resultsPerPage, object dynamicParameters = null, int? commandTimeout = null, bool buffered = true) where T : class
            => _dapper.GetPagesSQL<T>(Connection, sql, sqlCount, dynamicParameters, page, resultsPerPage, _transaction, commandTimeout, buffered);
        public IEnumerable<dynamic> GetListSQLDynamic(string sql, object dynamicParameters = null, int? commandTimeout = null, bool buffered = true)
            => _dapper.GetListSQLDynamic(Connection, sql, dynamicParameters, _transaction, commandTimeout, buffered);

        //public dynamic Insert<T>(T entity, int? commandTimeout = null) where T : class
        //    => Insert(null, entity, commandTimeout);
    }

    /// <summary>
    /// 分页查询
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Page<T>
    {

        /// <summary>
        /// 总条目数
        /// </summary>
        public long TotalItems { get; set; }

        /// <summary>
        /// 每页条目数
        /// </summary>
        public long ItemsPerPage { get; set; }

        /// <summary>
        /// 当前页码
        /// </summary>
        public long CurrentPage { get; set; }

        public IEnumerable<T> Items { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public long TotalPages => (long)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
    }
}
