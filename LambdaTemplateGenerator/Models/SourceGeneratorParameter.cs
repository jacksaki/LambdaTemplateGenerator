using Livet;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace LambdaTemplateGenerator.Models
{
    public class SourceGeneratorParameter : NotificationObject
    {
        public SourceGeneratorParameter()
        {
            this.AppSyncRequestParameters = new ObservableCollection<AppSyncRequestParameter>();
            this.AppSyncRequestParameters.CollectionChanged += (sender, e) =>
            {
                if (e.OldItems != null)
                {
                    foreach (AppSyncRequestParameter item in e.OldItems)
                    {
                        item.PropertyChanged -= Item_PropertyChanged;
                    }
                }
                if (e.NewItems != null)
                {
                    foreach (AppSyncRequestParameter item in e.NewItems)
                    {
                        item.PropertyChanged += Item_PropertyChanged;
                    }
                }
                RaisePropertyChanged(nameof(AppSyncRequestParameters));
            };
            this.AppSyncResponseParameter = AppSyncResponseParameter.CreateRoot();
            this.LambdaInfo = new LambdaInfo();
        }

        private void Item_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            RaisePropertyChanged(nameof(AppSyncRequestParameters));
        }

        public ObservableCollection<AppSyncRequestParameter> AppSyncRequestParameters
        {
            get;
        }
        public AppSyncResponseParameter AppSyncResponseParameter
        {
            get;
        }
        public LambdaInfo LambdaInfo
        {
            get;
        }
    }
}
