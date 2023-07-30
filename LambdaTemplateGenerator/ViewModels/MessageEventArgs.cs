﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaTemplateGenerator.ViewModels
{
    public class MessageEventArgs : EventArgs
    {
        public MessageEventArgs(string message)
        {
            this.Message = message;
        }
        public string Message
        {
            get;
        }
    }
}
