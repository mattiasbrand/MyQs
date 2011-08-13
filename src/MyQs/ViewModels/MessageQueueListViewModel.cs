using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Messaging;
using Caliburn.Micro;
using MyQs.Wpf.Events;

namespace MyQs.Wpf.ViewModels
{
    public class MessageQueueListViewModel : PropertyChangedBase
    {
        private readonly IEventAggregator _eventAggregator;

        public MessageQueueListViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            SelectedMachineName = Environment.MachineName;
        }

        public ObservableCollection<MessageQueueListItemViewModel> MessageQueues
        {
            get
            {
                return new ObservableCollection<MessageQueueListItemViewModel>(MessageQueue.GetPrivateQueuesByMachine(SelectedMachineName).Select(x => new MessageQueueListItemViewModel(x)));
            }
        }

        public string SelectedMachineName { get; set; }

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
    }
}