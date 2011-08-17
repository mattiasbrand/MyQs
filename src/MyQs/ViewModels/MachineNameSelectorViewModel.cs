using System;
using System.Collections.ObjectModel;
using System.Linq;
using Caliburn.Micro;
using MyQs.Wpf.Events;

namespace MyQs.Wpf.ViewModels
{
    public class MachineNameSelectorViewModel : PropertyChangedBase, IHandle<QueueNotFound>
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly ISettings _settings;

        public MachineNameSelectorViewModel(IEventAggregator eventAggregator, ISettings settings)
        {
            _eventAggregator = eventAggregator;
            _settings = settings;

            MachineNames = new ObservableCollection<string>(_settings.MachineNames);
            if (MachineNames.Count == 1) SelectedMachineName = MachineNames.First();

            _eventAggregator.Subscribe(this);
        }

        public string NewMachineName { get; set; }
        public void AddMachine()
        {
            MachineNames.Add(NewMachineName);
            _settings.AddMachineName(NewMachineName);

            NewMachineName = string.Empty;
            NotifyOfPropertyChange(() => NewMachineName);
        }
        public void RemoveSelectedMachine()
        {
            if (string.IsNullOrEmpty(SelectedMachineName)) return;

            var machineNameToRemove = SelectedMachineName;
            MachineNames.Remove(machineNameToRemove);
            _settings.RemoveMachineName(machineNameToRemove);

            NotifyOfPropertyChange(SelectedMachineName);
        }

        public ObservableCollection<string> MachineNames { get; set; }
        private string _selectedMachineName;
        public string SelectedMachineName
        {
            get { return _selectedMachineName; }
            set
            {
                _selectedMachineName = value;
                SelectedMachineNameErrorText = "";
                NotifyOfPropertyChange(() => SelectedMachineNameErrorText);

                _eventAggregator.Publish(new MachineSelected(value));
            }
        }

        public string SelectedMachineNameErrorText { get; set; }

        public void Handle(QueueNotFound message)
        {
            SelectedMachineNameErrorText = "Queue not found. ";
            NotifyOfPropertyChange(() => SelectedMachineNameErrorText);
        }
    }
}