using Livet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LambdaTemplateGenerator.Models
{
    public class AppSyncRequestParameter : NotificationObject
    {

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


        private AppSyncTypes _Type;

        public AppSyncTypes Type
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


        private bool _IsNullable;

        public bool IsNullable
        {
            get
            {
                return _IsNullable;
            }
            set
            { 
                if (_IsNullable == value)
                {
                    return;
                }
                _IsNullable = value;
                RaisePropertyChanged();
            }
        }

    }
}
