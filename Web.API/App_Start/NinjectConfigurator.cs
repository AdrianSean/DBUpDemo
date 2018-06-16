using Ninject;
using Ninject.Web.Common;
using Repository;
using Repository.Concrete;

namespace Web.API.App_Start
{
    public class NinjectConfigurator
    {
        public void Configure(IKernel container)
        {
            container.Bind<IConfigRepository>().To<ConfigSqlRepository>().InRequestScope();
        }
    }
}