using MyQs.Wpf.ViewModels;

namespace MyQs.Wpf
{
    using System.ComponentModel.Composition;

    [Export(typeof(IShell))]
    public class ShellViewModel : IShell
    {
        public ShellViewModel()
        {
            MessageQueueList = new MsmqQueueListViewModel();
        }

        public MsmqQueueListViewModel MessageQueueList { get; set; }
    }
}
