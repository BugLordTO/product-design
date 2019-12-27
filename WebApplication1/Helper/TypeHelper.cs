using GraphQL.Types;
using System;
using WebApplication1.Repositories.Models;

namespace WebApplication1.Helper
{
    public class TypeHelper
    {
        public static Type GetGraphQlFieldType(string type)
        {
            switch (type)
            {
                case PossibleFieldType.Int: return typeof(IntGraphType);
                case PossibleFieldType.Decimal: return typeof(DecimalGraphType);
                case PossibleFieldType.Bool: return typeof(BooleanGraphType);
                case PossibleFieldType.DateTime: return typeof(DateTimeGraphType);
                case PossibleFieldType.Object: return typeof(ObjectGraphType);
                case PossibleFieldType.String: return typeof(StringGraphType);
                default: return typeof(StringGraphType);
            }
        }

        public static Type GetFieldType(string type)
        {
            switch (type)
            {
                case PossibleFieldType.Int: return typeof(int);
                case PossibleFieldType.Decimal: return typeof(decimal);
                case PossibleFieldType.Bool: return typeof(bool);
                case PossibleFieldType.DateTime: return typeof(DateTime);
                case PossibleFieldType.Object: return typeof(object);
                case PossibleFieldType.String: return typeof(string);
                default: return typeof(string);
            }
        }
    }
}
