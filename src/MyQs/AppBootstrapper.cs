using Autofac;
using Caliburn.Micro.Autofac;
using MyQs.Wpf.ViewModels;

namespace MyQs.Wpf
{
	public class AppBootstrapper : AutofacBootstrapper<ShellViewModel>
	{
        protected override void ConfigureContainer(Autofac.ContainerBuilder builder)
        {
            base.ConfigureContainer(builder);
            builder.RegisterType<Settings>().As<ISettings>();
        }
	}
}
