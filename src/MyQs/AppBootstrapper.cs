using Caliburn.Micro.Autofac;
using MyQs.Wpf.ViewModels;

namespace MyQs.Wpf
{

	public class AppBootstrapper : AutofacBootstrapper<ShellViewModel>
	{
        protected override void ConfigureBootstrapper()
        {
            base.ConfigureBootstrapper();
			//batch.AddExportedValue<IWindowManager>(new WindowManager());
			//batch.AddExportedValue<IEventAggregator>(new EventAggregator());
		}

	}
}
