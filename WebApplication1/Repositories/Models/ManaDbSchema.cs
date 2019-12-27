using System;
using System.Collections.Generic;

namespace WebApplication1.Repositories.Models
{
    public class ManaDbSchema
    {
        public string _id { get; set; }
        public string ServiceId { get; set; }
        public DateTime CreatedDate { get; set; }
        public IEnumerable<CollectionSchema> CollectionSchemas { get; set; }
    }

    public class CollectionSchema
    {
        public string Name { get; set; }
        public string DataPrefixId { get; set; }
        public bool AutoGenerateId { get; set; }
        public bool IsProductCollection { get; set; }
        public DateTime CreatedDate { get; set; }
        public IEnumerable<Field> Fields { get; set; }
    }

    public class Field
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }

    public class PossibleFieldType
    {
        public const string String = "string";
        public const string Int = "int";
        public const string Decimal = "decimal";
        public const string Bool = "bool";
        public const string DateTime = "DateTime";
        public const string Object = "object";
    }
}
