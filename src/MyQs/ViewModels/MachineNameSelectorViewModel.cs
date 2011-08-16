using System.Collections.ObjectModel;
using System.Linq;
using Caliburn.Micro;
using MyQs.Wpf.Events;

namespace MyQs.Wpf.ViewModels
{
    public class MachineNameSelectorViewModel : PropertyChangedBase
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly ISettings _settings;

        public MachineNameSelectorViewModel(IEventAggregator eventAggregator, ISettings settings)
        {
            _eventAggregator = eventAggregator;
            _settings = settings;

            MachineNames = new ObservableCollection<string>(_settings.MachineNames);
            if (MachineNames.Count == 1) SelectedMachineName = MachineNames.First();
        }

        public string NewMachineName { get; set; }
        public void AddMachine()
        {
            MachineNames.Add(NewMachineName);
            _settings.AddMachineName(NewMachineName);

            NewMachineName = string.Empty;
            NotifyOfPropertyChange(() => NewMachineName);
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
    }
}