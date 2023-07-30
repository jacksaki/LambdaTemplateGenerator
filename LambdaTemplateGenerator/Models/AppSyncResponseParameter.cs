using ICSharpCode.AvalonEdit.Editing;
using Livet;
using Markdig.Syntax.Inlines;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LambdaTemplateGenerator.Models
{
    public class AppSyncResponseParameter:NotificationObject
    {
        /// <summary>
        /// 	<AppSyncResponse>
		/// <Parameter Name = "Result" >
        ///   < Parameter Name="ErrorCode" Type="String" IsNullable="Y"/>
		///   <Parameter Name = "Type" Type="String"/>
		///   <Parameter Name = "Message" Type="String" IsNullable="Y"/>
		/// </Parameter>
	    /// </AppSyncResponse>
        /// </summary>
        /// <returns></returns>
        internal static AppSyncResponseParameter CreateRoot()
        {
            var root = new AppSyncResponseParameter(null);
            var path = System.IO.Path.Combine(
                            System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location),
                            "Templates",
                            "AppSyncResponse.xml");
            var doc = XDocument.Load(path);
            foreach(var p in doc.Element("AppSyncResponse").Elements("Parameter"))
            {
                root.Children.Add(AppSyncResponseParameter.Create(root, p));
            }
            return root;
        }
        private static AppSyncResponseParameter Create(AppSyncResponseParameter parent, XElement element)
        {
            if (element.HasElements)
            {
                var rp = new AppSyncResponseParameter(parent)
                {
                    Name = element.Attribute("Name").Value,
                    Type = AppSyncTypes.Custom,
                };

                foreach(var e in element.Elements("Parameter"))
                {
                    rp.Children.Add(AppSyncResponseParameter.Create(rp, e));
                }
                return rp;
            }
            else
            {
                return new AppSyncResponseParameter(parent)
                {
                    Name = element.Attribute("Name").Value,
                    Type = element.Attribute("Type").Value.ToAppSyncType(),
                    IsNullable = "Y".Equals(element.Attribute("IsNullable")?.Value),
                };
            }
        }
        public AppSyncResponseParameter(AppSyncResponseParameter parent)
        {
            this.Parent = parent;
            this.Children.CollectionChanged += (sender, e) =>
            {
                if (e.OldItems != null)
                {
                    foreach (AppSyncResponseParameter item in e.OldItems)
                    {
                        item.PropertyChanged += Item_PropertyChanged;
                    }
                }
                if (e.NewItems != null)
                {
                    foreach (AppSyncResponseParameter item in e.NewItems)
                    {
                        item.PropertyChanged += Item_PropertyChanged;
                    }
                }
            };
        }
        
        public AppSyncResponseParameter Parent
        {
            get;
            private set;
        }
        public bool IsLeaf
        {
            get
            {
                return this.Type != AppSyncTypes.Custom;
            }
        }

        private void Item_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            RaisePropertyChanged(nameof(IsLeaf));
            RaisePropertyChanged(nameof(Children));
        }

        public AppSyncResponseParameter AddItem()
        {
            var newParam = new AppSyncResponseParameter(this);
            this.Children.Add(newParam);
            return newParam;
        }
        public ObservableCollection<AppSyncResponseParameter> Children
        {
            get;
        } = new ObservableCollection<AppSyncResponseParameter>();

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

    }
}
