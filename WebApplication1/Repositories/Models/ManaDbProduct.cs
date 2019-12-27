using GraphQL.Types;
using MongoDB.Bson;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Repositories.Models
{
    public class ManaDbProduct
    {
        public string _id { get; set; }
        public string Name { get; set; }
        public string NameExtension { get; set; }
        public string Logo { get; set; }
        public string RefId { get; set; }
        public string Details { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public IEnumerable<string> Tags { get; set; }
    }

    public class ManaDbProductType : ObjectGraphType<ManaDbProduct>
    {
        public ManaDbProductType()
        {
            IDataDac<ManaDbSchema> schemaDac = new ManaDbSchemaDac();
            var schema = schemaDac.Get(x => true).Result;
            foreach (var field in schema.CollectionSchemas.First(x => x.IsProductCollection).Fields)
            {
                var fieldype = Helper.TypeHelper.GetGraphQlFieldType(field.Type);
                Field(fieldype, field.Name);
            }
        }
    }
}
