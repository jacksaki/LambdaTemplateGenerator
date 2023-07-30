using ControlzEx.Standard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LambdaTemplateGenerator.Models
{
    public static class AppSyncTypesExtension
    {
        private static Dictionary<AppSyncTypes, AppSyncTypeAttribute> _dict = null;
        static AppSyncTypesExtension()
        {
            _dict = Enum.GetValues<AppSyncTypes>().ToDictionary(
                x => x,
                y => y.GetType().GetCustomAttribute<AppSyncTypeAttribute>()
                );

        }
        public static AppSyncTypes ToAppSyncType(this string value)
        {
            
            if(_dict.Where(x => x.Key.ToString().Equals(value)).Any())
            {
                return _dict.Where(x => x.Key.ToString().Equals(value)).FirstOrDefault().Key;
            }
            else
            {
                return AppSyncTypes.Custom;
            }
        }
    }
    public enum AppSyncTypes
    {
        [AppSyncType(typeof(string))]
        String,
        [AppSyncType(typeof(int))]
        Int,
        [AppSyncType(typeof(float))]
        Float,
        [AppSyncType(typeof(bool))]
        Boolean,
        [AppSyncType(typeof(DateOnly))]
        AWSDate,
        [AppSyncType(typeof(TimeOnly))]
        AWSTime,
        [AppSyncType(typeof(DateTime))]
        AWSDateTime,
        [AppSyncType(typeof(DateTime))]
        AWSTimestamp,
        [AppSyncType(typeof(string))]
        AWSEmail,
        [AppSyncType(typeof(string))]
        AWSJson,
        [AppSyncType(typeof(string))]
        AWSURL,
        [AppSyncType(typeof(string))]
        AWSIPAddress,
        [AppSyncType(typeof(Object))]
        Custom,
    }
}
