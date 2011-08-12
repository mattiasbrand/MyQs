using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Messaging;

namespace MyQs.Wpf.ViewModels
{
    public class MessageQueueListViewModel
    {
        public MessageQueueListViewModel()
        {
            SelectedMachineName = Environment.MachineName;
        }

        public ObservableCollection<MessageQueueViewModel> MessageQueues
        {
            get
            {
                return new ObservableCollection<MessageQueueViewModel>(MessageQueue.GetPrivateQueuesByMachine(SelectedMachineName).Select(x => new MessageQueueViewModel(x)));
            }
        }

        public string SelectedMachineName { get; set; }
    }
}