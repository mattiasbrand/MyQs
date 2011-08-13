using System;
using System.IO;
using System.Messaging;
using Caliburn.Micro;
using MyQs.Wpf.Events;

namespace MyQs.Wpf.ViewModels
{
    public class MessageContentViewModel : PropertyChangedBase, IHandle<MessageSelected>
    {
        private readonly IEventAggregator _eventAggregator;

        public MessageContentViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
        }

        public void Handle(MessageSelected message)
        {
            message.Queue.MessageReadPropertyFilter = AllFilter;
            var content = message.Queue.PeekById(message.Id);

            using (var reader = new StreamReader(content.BodyStream))
            {
                Body = reader.ReadToEnd();
                NotifyOfPropertyChange(() => Body);
            }
        }

        public string Body { get; set; }

        static readonly MessagePropertyFilter AllFilter = new MessagePropertyFilter
        {
            AdministrationQueue = true,
            ArrivedTime = true,
            CorrelationId = true,
            Priority = true,
            ResponseQueue = true,
            SentTime = true,
            Body = true,
            Label = true,
            Id = true
        };
    }
}