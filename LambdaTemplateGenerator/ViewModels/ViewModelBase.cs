using Livet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaTemplateGenerator.ViewModels
{
    public abstract class ViewModelBase:ViewModel
    {
        public event EventHandler<ErrorOccurredEventArgs> Error = delegate { };
        public event EventHandler<MessageEventArgs> Message = delegate { };
        public ViewModelBase(MainWindowViewModel parent) : base()
        {
            this.Parent = parent;
        }
        protected void OnError(string message)
        {
            this.Error(this, new ErrorOccurredEventArgs(message));
        }
        protected void OnMessage(string message)
        {
            this.Message(this, new MessageEventArgs(message));
        }
        public MainWindowViewModel Parent
        {
            get;
        }
    }
}
