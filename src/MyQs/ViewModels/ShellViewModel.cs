using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Caliburn.Micro;
using MyQs.Wpf.Events;

namespace MyQs.Wpf.ViewModels
{
    public class ShellViewModel : PropertyChangedBase, IShell
    {
        private readonly IEventAggregator _eventAggregator;

        public ShellViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            MessageQueueList = new MessageQueueListViewModel(eventAggregator);
            MessageQueueContent = new MessageQueueContentViewModel(eventAggregator);
            MessageContent = new MessageContentViewModel(eventAggregator);

            var machineNames = new List<string> { Environment.MachineName };
            MachineNames = new ObservableCollection<string>(machineNames);
            if (machineNames.Count == 1) SelectedMachineName = MachineNames.First();
        }

        public ObservableCollection<string> MachineNames { get; set; }
        private string _selectedMachineName;
        public string SelectedMachineName
        {
            get { return _selectedMachineName; }
            set
            {
                _selectedMachineName = value;
                _eventAggregator.Publish(new MachineSelected(value));
            }
        }

        public MessageContentViewModel MessageContent { get; set; }
        public MessageQueueContentViewModel MessageQueueContent { get; set; }
        public MessageQueueListViewModel MessageQueueList { get; set; }
    }
}
