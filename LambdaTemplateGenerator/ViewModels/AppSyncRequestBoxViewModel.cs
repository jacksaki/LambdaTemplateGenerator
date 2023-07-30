using LambdaTemplateGenerator.Models;
using Livet;
using Livet.Commands;
using Livet.EventListeners;
using Livet.Messaging;
using Livet.Messaging.IO;
using Livet.Messaging.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace LambdaTemplateGenerator.ViewModels
{
    public class AppSyncRequestBoxViewModel : ViewModelBase
    {
        public AppSyncRequestBoxViewModel(MainWindowViewModel parent) : base(parent)
        {
        }
        public ObservableCollection<AppSyncRequestParameter> Parameters
        {
            get
            {
                return this.Parent.Parameter.AppSyncRequestParameters;
            }
        }

        private AppSyncRequestParameter _SelectedParameter;

        public AppSyncRequestParameter SelectedParameter
        {
            get
            {
                return _SelectedParameter;
            }
            set
            { 
                if (_SelectedParameter == value)
                {
                    return;
                }
                _SelectedParameter = value;
                RemoveSelectedCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged();
            }
        }

        private ViewModelCommand _AddCommand;

        public ViewModelCommand AddCommand
        {
            get
            {
                if (_AddCommand == null)
                {
                    _AddCommand = new ViewModelCommand(Add);
                }
                return _AddCommand;
            }
        }

        public void Add()
        {
            this.Parameters.Add(new AppSyncRequestParameter() { Name = "******" }); 
        }


        private ViewModelCommand _RemoveSelectedCommand;

        public ViewModelCommand RemoveSelectedCommand
        {
            get
            {
                if (_RemoveSelectedCommand == null)
                {
                    _RemoveSelectedCommand = new ViewModelCommand(RemoveSelected, CanRemoveSelected);
                }
                return _RemoveSelectedCommand;
            }
        }

        public bool CanRemoveSelected()
        {
            return this.SelectedParameter != null;
        }

        public void RemoveSelected()
        {
            this.Parameters.Remove(this.SelectedParameter);
        }


    }
}
