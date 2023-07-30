using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaTemplateGenerator.Models
{
    public enum GraphQLTypes
    {
        [EnumText("query")]
        Query,
        [EnumText("mutation")]
        Mutation,
    }
}
