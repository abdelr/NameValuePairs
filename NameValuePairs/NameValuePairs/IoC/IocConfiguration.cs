using NameValuePairs.Core.Constraints;
using NameValuePairs.Models;
using NameValuePairs.Repositories;
using NameValuePairs.ViewModels;
using Ninject.Modules;

namespace NameValuePairs.DI
{
    public class IocConfiguration : NinjectModule
    {
        public override void Load()
        {
            Bind<MainViewModel>().ToSelf().InTransientScope(); // Create new instance every time
            Bind<INameValuePairConstraints>().To<NameValuePairConstraints>().InSingletonScope();
            Bind<INameValuePairRepository>().To<NameValuePairRepository>().InSingletonScope();
            Bind<MainModel>().ToSelf().InSingletonScope(); 
        }
    }
}
