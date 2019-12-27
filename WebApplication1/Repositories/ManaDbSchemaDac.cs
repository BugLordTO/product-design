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
    public class ManaDbSchemaDac : IDataDac<ManaDbSchema>
    {
        public IMongoCollection<ManaDbSchema> Collection { get; set; }

        public ManaDbSchemaDac()
        {
            var client = new MongoClient("mongodb://thesdev:Pa$$w0rd5@thes-dev-db.onmana.app:27017/infinity-pants-dev");
            var database = client.GetDatabase("infinity-pants-dev");

            Collection = database.GetCollection<ManaDbSchema>("DbSchema");
        }

        public async Task<ManaDbSchema> Get(Expression<Func<ManaDbSchema, bool>> expression)
            => await Collection.Find(expression).FirstOrDefaultAsync();
        public async Task<IEnumerable<ManaDbSchema>> Gets(Expression<Func<ManaDbSchema, bool>> expression)
            => await Collection.Find(expression).ToListAsync();
    }
}
