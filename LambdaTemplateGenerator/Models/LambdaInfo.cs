using Livet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaTemplateGenerator.Models
{
    public class LambdaInfo:NotificationObject
    {

        private GraphQLTypes _Type;

        public GraphQLTypes Type
        {
            get
            {
                return _Type;
            }
            set
            { 
                if (_Type == value)
                {
                    return;
                }
                _Type = value;
                RaisePropertyChanged();
            }
        }

        private string _Name;

        public string Name
        {
            get
            {
                return _Name;
            }
            set
            { 
                if (_Name == value)
                {
                    return;
                }
                _Name = value;
                RaisePropertyChanged();
            }
        }

    }
}
