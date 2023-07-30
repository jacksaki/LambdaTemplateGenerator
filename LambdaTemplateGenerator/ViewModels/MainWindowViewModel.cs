using LambdaTemplateGenerator.Models;
using Livet;
using Livet.Commands;
using Livet.EventListeners;
using Livet.Messaging;
using Livet.Messaging.IO;
using Livet.Messaging.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace LambdaTemplateGenerator.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        public void Initialize()
        {
        }
        public MahApps.Metro.Controls.Dialogs.IDialogCoordinator DialogCoordinator
        {
            get;
            set;
        }

        public MainWindowViewModel()
        {
            this.DialogCoordinator = MahApps.Metro.Controls.Dialogs.DialogCoordinator.Instance;
            this.Parameter = new SourceGeneratorParameter();
            this.LambdaInfoBoxViewModel = new LambdaInfoBoxViewModel(this);
            this.LambdaInfoBoxViewModel.Error += (sender, e) =>
            {
                DialogCoordinator.ShowMessageAsync(this, "エラー", e.Message, MahApps.Metro.Controls.Dialogs.MessageDialogStyle.Affirmative);
            };

            this.AppSyncRequestBoxViewModel = new AppSyncRequestBoxViewModel(this);
            this.AppSyncRequestBoxViewModel.Error += (sender, e) =>
            {
                DialogCoordinator.ShowMessageAsync(this, "エラー", e.Message, MahApps.Metro.Controls.Dialogs.MessageDialogStyle.Affirmative);
            };
            this.AppSyncResponseBoxViewModel = new AppSyncResponseBoxViewModel(this);
            this.AppSyncResponseBoxViewModel.Error += (sender, e) =>
            {
                DialogCoordinator.ShowMessageAsync(this, "エラー", e.Message, MahApps.Metro.Controls.Dialogs.MessageDialogStyle.Affirmative);
            };
        }
        public SourceGeneratorParameter Parameter
        {
            get;
        }
        public LambdaInfoBoxViewModel LambdaInfoBoxViewModel
        {
            get;
        }
        public AppSyncRequestBoxViewModel AppSyncRequestBoxViewModel
        {
            get;
        }
        public AppSyncResponseBoxViewModel AppSyncResponseBoxViewModel
        {
            get;
        }
    }
}
