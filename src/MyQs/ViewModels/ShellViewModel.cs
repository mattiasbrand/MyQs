using Caliburn.Micro;

namespace MyQs.Wpf.ViewModels
{
    public class ShellViewModel : PropertyChangedBase, IShell
    {
        public ShellViewModel(IEventAggregator eventAggregator)
        {
            MessageQueueList = new MessageQueueListViewModel(eventAggregator);
            MessageQueueContent = new MessageQueueContentViewModel(eventAggregator);
            MessageContent = new MessageContentViewModel(eventAggregator);
        }

        public MessageContentViewModel MessageContent { get; set; }
        public MessageQueueContentViewModel MessageQueueContent { get; set; }
        public MessageQueueListViewModel MessageQueueList { get; set; }
    }
}
