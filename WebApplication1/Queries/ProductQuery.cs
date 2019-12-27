using GraphQL.Types;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Repositories;
using WebApplication1.Repositories.Models;

namespace WebApplication1.Queries
{
    public class ProductQuery : ObjectGraphType
    {
        private readonly IDataDac<ManaDbSchema> schemaDac;
        private readonly IDataDac<ManaDbProduct> productDac;

        public ProductQuery(
            IDataDac<ManaDbSchema> schemaDac,
            IDataDac<ManaDbProduct> productDac
            )
        {
            this.productDac = productDac;
            this.schemaDac = schemaDac;
        }

        public ProductQuery Build()
        {
            var queryArguments = new List<QueryArgument>();

            var schema = schemaDac.Get(x => true).Result;
            foreach (var field in schema.CollectionSchemas.First(x => x.IsProductCollection).Fields)
            {
                var fieldType = Helper.TypeHelper.GetGraphQlFieldType(field.Type);
                queryArguments.Add(new QueryArgument(fieldType) { Name = field.Name });
            }

            Field<ListGraphType<ManaDbProductType>>(
                name: "Query",
                arguments: new QueryArguments(queryArguments),
                resolve: context =>
                {
                    var builder = Builders<ManaDbProduct>.Filter;
                    FilterDefinition<ManaDbProduct> filter = builder.Empty;
                    foreach (var key in context.Arguments.Keys)
                    {
                        var field = schema.CollectionSchemas.First(x => x.IsProductCollection).Fields.FirstOrDefault(f => string.Equals(f.Name, key, StringComparison.OrdinalIgnoreCase));
                        if (field != null)
                        {
                            var fieldType = Helper.TypeHelper.GetFieldType(field.Type);
                            var value = context.GetArgument(fieldType, key);
                            filter &= builder.Eq(field.Name, value);
                        }
                    }

                    return productDac.Collection.Find(filter).ToList();
                }
            );
            Field<ManaDbProductType>(
                name: "QueryOne",
                arguments: new QueryArguments(queryArguments),
                resolve: context =>
                {
                    var id = context.GetArgument<string>("_id");
                    return productDac.Get(x => x._id == id);
                }
            );

            return this;
        }
    }
}
