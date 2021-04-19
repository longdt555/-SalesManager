using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Lib.Service.Services.IServices
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Get an object by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Get(object id);

        /// <summary>
        /// Get all
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        IEnumerable<T> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IEnumerable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null
            );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        T GetFirstOrDefault(
            Expression<Func<T, bool>> filter = null,
            string includeProperties = null
            );

        /// <summary>
        /// Add new an object
        /// </summary>
        /// <param name="entity"></param>
        void Add(T entity);
        void Update(T entity);
        //void Remove(T entity);
    }
}
