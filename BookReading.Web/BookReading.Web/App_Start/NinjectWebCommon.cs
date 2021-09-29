[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(BookReading.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(BookReading.Web.App_Start.NinjectWebCommon), "Stop")]

namespace BookReading.Web.App_Start
{
    using System;
    using System.Web;
    using BookReading.Business;
    using BookReading.Data;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application.
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                kernel.Bind<IBookReadingOperation>().To<BookReadingOperation>();
                kernel.Bind<IUserOperation>().To<UserOperation>();
                kernel.Bind<IInvitedUserOperation>().To<InvitedUserOperation>();
                kernel.Bind < IEmailValidityCheck>().To<EmailValidityCheck>();
 
                kernel.Bind<IMyEvents>().To<MyEvents>();
                kernel.Bind<IInvitedEvents>().To<InvitedEvents>();
                kernel.Bind<IUserRoleOperation>().To<UserRoleOperation>(); 
                

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
        }
    }
}