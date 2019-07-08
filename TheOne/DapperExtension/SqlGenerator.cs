using System;
using System.Collections.Generic;

namespace DapperExtension
{
    public interface ISqlGenerator
    {


        //string Select(IClassMapper classMap, IPredicate predicate, IList<ISort> sort, IDictionary<string, object> parameters, string schemaName, string tableName, IList<IJoinPredicate> join = null, IList<IJoinAliasPredicate> alias = null);


        string Insert(IClassMapper classMap, object entity, string schemaName, string tableName);
        string Update(IClassMapper classMap, object entity, IPredicate predicate, IDictionary<string, object> parameters, string schemaName, string tableName);
        string UpdateSet(IClassMapper classMap, object entity, IPredicate predicate, IDictionary<string, object> parameters, string schemaName, string tableName);
        string Delete(IClassMapper classMap, IPredicate predicate, IDictionary<string, object> parameters, string schemaName, string tableName);

        string IdentitySql(IClassMapper classMap, string schemaName, string tableName);

        string GetColumnName(bool prefix, IClassMapper map, IPropertyMap property, bool includeAlias, string schemaName, string tableName, string aliasName = null);
        string GetColumnName(bool prefix, IClassMapper map, string propertyName, bool includeAlias, string schemaName, string tableName);
        bool SupportsMultipleStatements();


        string GetPagingSql(string sql, int page, int resultsPerPage, IDictionary<string, object> parameters);
    }

    public class SqlGeneratorImpl : ISqlGenerator
    {
        //public SqlGeneratorImpl(IDapperExtensionsConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        //public IDapperExtensionsConfiguration Configuration { get; private set; }
        public string Delete(IClassMapper classMap, IPredicate predicate, IDictionary<string, object> parameters, string schemaName, string tableName)
        {
            throw new NotImplementedException();
        }

        public string GetColumnName(bool prefix, IClassMapper map, IPropertyMap property, bool includeAlias, string schemaName, string tableName, string aliasName = null)
        {
            throw new NotImplementedException();
        }

        public string GetColumnName(bool prefix, IClassMapper map, string propertyName, bool includeAlias, string schemaName, string tableName)
        {
            throw new NotImplementedException();
        }

        public string GetPagingSql(string sql, int page, int resultsPerPage, IDictionary<string, object> parameters)
        {
            //sql = Configuration.Dialect.GetPagingSql(sql.ToString(), page, resultsPerPage, parameters);
            var sqlstring = GetSetSql(sql, page, resultsPerPage, parameters);
            return sqlstring;
        }
        /// <summary>
        /// 拼接sql语句
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="firstResult"></param>
        /// <param name="maxResults"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public string GetSetSql(string sql, int firstResult, int maxResults, IDictionary<string, object> parameters)
        {
            //DOING
            if (parameters == null)
                return string.Format("{0} LIMIT {1}, {2}", sql, firstResult, maxResults);

            var result = string.Format("{0} LIMIT @firstResult, @maxResults", sql);
            parameters.Add("@firstResult", firstResult);
            parameters.Add("@maxResults", maxResults);
            return result;
        }
        public string IdentitySql(IClassMapper classMap, string schemaName, string tableName)
        {
            throw new NotImplementedException();
        }

        public string Insert(IClassMapper classMap, object entity, string schemaName, string tableName)
        {
            throw new NotImplementedException();
        }



        public bool SupportsMultipleStatements()
        {
            throw new NotImplementedException();
        }

        public string Update(IClassMapper classMap, object entity, IPredicate predicate, IDictionary<string, object> parameters, string schemaName, string tableName)
        {
            throw new NotImplementedException();
        }

        public string UpdateSet(IClassMapper classMap, object entity, IPredicate predicate, IDictionary<string, object> parameters, string schemaName, string tableName)
        {
            throw new NotImplementedException();
        }
    }
    /// <summary>
    /// 条件
    /// </summary>
    public interface IPredicate
    {
        /// <summary>
        /// 返回条件的类
        /// </summary>
        /// <returns></returns>
        Type GetPredicateType();

        /// <summary>
        /// 返回条件的sql
        /// </summary>
        /// <param name="sqlGenerator"></param>
        /// <param name="parameters"></param>
        /// <param name="schemaName"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        string GetSql(bool prefix, ISqlGenerator sqlGenerator, IDictionary<string, object> parameters, string schemaName, string tableName);
    }

    /// <summary>
    /// 基本条件
    /// </summary>
    public interface IBasePredicate : IPredicate
    {
        /// <summary>
        /// 前缀
        /// </summary>
        string SchemaName { get; set; }
        /// <summary>
        /// 表名
        /// </summary>
        string TableName { get; set; }

        /// <summary>
        /// 条件属性
        /// </summary>
        string PropertyName { get; set; }

    }

    public interface ISort
    {
        string SchemaName { get; set; }
        /// <summary>
        /// 表名
        /// </summary>
        string TableName { get; set; }
        string PropertyName { get; set; }
        bool Ascending { get; set; }
       // string GetSql(bool prefix, ISqlGenerator sqlGenerator, string schemaName, string tableName);
    }

    public class Sort<T> : ISort
    {
        /// <summary>
        /// 前缀
        /// </summary>
        public string SchemaName { get; set; }
        /// <summary>
        /// 表名
        /// </summary>
        public string TableName { get; set; }
        public string PropertyName { get; set; }
        public bool Ascending { get; set; }


    }
}
