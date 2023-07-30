using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaTemplateGenerator.Models
{
    public class AppSyncTypeAttribute:Attribute
    {
        public AppSyncTypeAttribute(Type clrType)
        {
            this.ClrType = clrType;
        }
        public string TypeName
        {
            get;
        }
        public Type ClrType
        {
            get;
        }
    }
}
