using System;
using System.Collections.ObjectModel;
using System.Messaging;

namespace MyQs.Wpf.ViewModels
{
    public class MsmqQueueListViewModel
    {
        public MsmqQueueListViewModel()
        {
            SelectedMachineName = Environment.MachineName;
        }

        public ObservableCollection<MessageQueue> MessageQueues { get { return new ObservableCollection<MessageQueue>(MessageQueue.GetPrivateQueuesByMachine(SelectedMachineName)); } }

        public string SelectedMachineName { get; set; }
    }
}