using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Messaging;
using Caliburn.Micro;
using MyQs.Core.Extensions;
using MyQs.Wpf.Events;

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

        public IList<string> Messages { get
        {
            return new List<string>(_queue.ListMessageNames());
        } }
    }
}