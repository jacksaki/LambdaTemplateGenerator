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
    public class AppSyncResponseBoxViewModel : ViewModelBase
    {
        public AppSyncResponseBoxViewModel(MainWindowViewModel parent) : base(parent)
        {
        }
        public AppSyncResponseParameter Parameter
        {
            get
            {
                return this.Parent.Parameter.AppSyncResponseParameter;
            }
        }


        private AppSyncResponseParameter _SelectedItem;

        public AppSyncResponseParameter SelectedItem
        {
            get
            {
                return _SelectedItem;
            }
            set
            { 
                if (_SelectedItem == value)
                {
                    return;
                }
                _SelectedItem = value;
                AddCommand.RaiseCanExecuteChanged();
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
                    _AddCommand = new ViewModelCommand(Add, CanAdd);
                }
                return _AddCommand;
            }
        }

        public bool CanAdd()
        {
            return this.SelectedItem != null;
        }

        public void Add()
        {
            this.SelectedItem.Parent.AddItem(); 
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
            return this.SelectedItem != null;
        }

        public void RemoveSelected()
        {
            this.SelectedItem.Parent.Children.Remove(this.SelectedItem);
        }

        private ViewModelCommand _AddRootCommand;

        public ViewModelCommand AddRootCommand
        {
            get
            {
                if (_AddRootCommand == null)
                {
                    _AddRootCommand = new ViewModelCommand(AddRoot);
                }
                return _AddRootCommand;
            }
        }

        public void AddRoot()
        {
            this.Parameter.AddItem(); 
        }

    }
}

