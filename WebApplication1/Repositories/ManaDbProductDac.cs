using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebApplication1.Repositories.Models;

namespace WebApplication1.Repositories
{
    public class ManaDbProductDac : IDataDac<ManaDbProduct>
    {
        public IMongoCollection<ManaDbProduct> Collection { get; set; }

        public ManaDbProductDac()
        {
            var client = new MongoClient(WebConfig.DbConn);
            var database = client.GetDatabase(WebConfig.DbName);

            Collection = database.GetCollection<ManaDbProduct>("Product");
        }

        public async Task<ManaDbProduct> Get(Expression<Func<ManaDbProduct, bool>> expression)
            => await Collection.Find(expression).FirstOrDefaultAsync();
        public async Task<IEnumerable<ManaDbProduct>> Gets(Expression<Func<ManaDbProduct, bool>> expression)
            => await Collection.Find(expression).ToListAsync();
    }
}
