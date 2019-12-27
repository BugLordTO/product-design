using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebApplication1.Repositories
{
    public interface IDataDac<T>
    {
        IMongoCollection<T> Collection { get; set; }
        Task<T> Get(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> Gets(Expression<Func<T, bool>> expression);
    }
}
