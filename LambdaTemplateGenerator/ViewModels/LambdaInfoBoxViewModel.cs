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
    public class LambdaInfoBoxViewModel : ViewModelBase
    {
        public LambdaInfoBoxViewModel(MainWindowViewModel parent) : base(parent)
        {
        }
    }
}
