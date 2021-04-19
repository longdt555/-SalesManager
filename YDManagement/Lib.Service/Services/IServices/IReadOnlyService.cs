using System.Collections.Generic;
using System.Linq;

namespace Lib.Service.Services.IServices
{
    public interface IReadOnlyService<out TEntity>
    {

        /// <summary>Gets the entity with the specified unique identifier</summary>
        /// <param name="id">The unique identifier of the entity to be retrieved</param>
        /// <returns>The entity with the specified unique identifier or null</returns>
        TEntity GetById(int id);


        /// <summary>Gets all entities in the res</summary>
        /// <returns>All entities in the repository</returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>Gets a queryable list of all entities in the repository</summary>
        /// <returns>A queryable list of all entities in the repository</returns>
        IQueryable<TEntity> Query();

    }
}
