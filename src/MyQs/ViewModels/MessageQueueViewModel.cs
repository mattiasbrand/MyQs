using System;
using System.Messaging;
using MyQs.Core.Extensions;

namespace MyQs.Wpf.ViewModels
{
    public class MessageQueueViewModel
    {
        private readonly MessageQueue _messageQueue;

        public MessageQueueViewModel(MessageQueue messageQueue)
        {
            _messageQueue = messageQueue;
        }

        public string Name
        {
            get
            {
                return _messageQueue.QueueName.Substring(_messageQueue.QueueName.LastIndexOf("\\") + 1);
            }
        }

        public int CountMessages
        {
            get { return _messageQueue.CountMessages(); }
        }
    }
}