using System.Collections.Generic;
using System.Messaging;
using Caliburn.Micro;
using MyQs.Core.Extensions;
using MyQs.Wpf.Events;
using Message = System.Messaging.Message;

namespace MyQs.Wpf.ViewModels
{
    public class MessageQueueContentViewModel : PropertyChangedBase, IHandle<MessageQueueSelected>
    {
        private readonly IEventAggregator _eventAggregator;
        private MessageQueue _queue;

        public MessageQueueContentViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
        }

        public void Handle(MessageQueueSelected message)
        {
            _queue = message.MessageQueue;
            NotifyOfPropertyChange(() => Messages);
        }

        public IList<string> Messages
        {
            get
            {
                return new List<string>(_queue.ListMessageNames());
            }
        }

        private string _selectedMessage;
        public string SelectedMessage
        {
            get { return _selectedMessage; }
            set
            {
                _selectedMessage = value;
                if (string.IsNullOrEmpty(value)) return;

                var firstDelimiter = _selectedMessage.IndexOf(':');
                var id = _selectedMessage;
                if(firstDelimiter > 0) id = _selectedMessage.Substring(0, _selectedMessage.IndexOf(':'));

                _eventAggregator.Publish(new MessageSelected(_queue, id));
            }
        }
    }
}