using Caliburn.Micro;

namespace MyQs.Wpf.ViewModels
{
    public class ShellViewModel : PropertyChangedBase, IShell
    {
        public ShellViewModel(IEventAggregator eventAggregator, ISettings settings)
        {
            MessageQueueList = new MessageQueueListViewModel(eventAggregator);
            MessageQueueContent = new MessageQueueContentViewModel(eventAggregator);
            MessageContent = new MessageContentViewModel(eventAggregator);
            MachineNameSelector = new MachineNameSelectorViewModel(eventAggregator, settings);
        }


        public MachineNameSelectorViewModel MachineNameSelector { get; set; }
        public MessageContentViewModel MessageContent { get; set; }
        public MessageQueueContentViewModel MessageQueueContent { get; set; }
        public MessageQueueListViewModel MessageQueueList { get; set; }
    }
}
