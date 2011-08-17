using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Messaging;
using Caliburn.Micro;
using MyQs.Wpf.Events;

namespace MyQs.Wpf.ViewModels
{
    public class MessageQueueListViewModel : PropertyChangedBase, IHandle<MachineSelected>
    {
        private readonly IEventAggregator _eventAggregator;

        public MessageQueueListViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
        }


        public string SelectedMachineName { get; set; }

        public ObservableCollection<MessageQueueListItemViewModel> MessageQueues
        {
            get
            {
                if (string.IsNullOrEmpty(SelectedMachineName)) return null;
                try
                {
                    return new ObservableCollection<MessageQueueListItemViewModel>(MessageQueue.GetPrivateQueuesByMachine(SelectedMachineName).Select(x => new MessageQueueListItemViewModel(x)));
                }
                catch (MessageQueueException)
                {
                    _eventAggregator.Publish(new QueueNotFound());
                    return null;
                }
            }
        }
        private MessageQueueListItemViewModel _selectedMessageQueue;
        public MessageQueueListItemViewModel SelectedMessageQueue
        {
            get { return _selectedMessageQueue; }
            set
            {
                _selectedMessageQueue = value;
                _eventAggregator.Publish(new MessageQueueSelected(value.MessageQueue));
            }
        }

        public void Handle(MachineSelected message)
        {
            SelectedMachineName = message.MachineName;
            NotifyOfPropertyChange(() => MessageQueues);
        }
    }
}