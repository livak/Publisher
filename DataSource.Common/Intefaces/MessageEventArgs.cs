using System;

namespace PowerMonitoring.DataSource.Common.Intefaces
{
    public class MessageEventArgs : EventArgs
    {
        public string Message { get; set; }

        public MessageEventArgs(string message)
        {
            Message = message;
        }
    }
}