using System.Messaging;
using Caliburn.Micro;
using MyQs.Core.Extensions;

namespace MyQs.Wpf.ViewModels
{
    public class MessageQueueListItemViewModel : PropertyChangedBase
    {
        private readonly MessageQueue _messageQueue;

        public MessageQueueListItemViewModel(MessageQueue messageQueue)
        {
            _messageQueue = messageQueue;
        }

        public MessageQueue MessageQueue { get { return _messageQueue; } }

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