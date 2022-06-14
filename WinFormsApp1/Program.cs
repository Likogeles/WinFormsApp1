using System;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;
using ClassLibraryListImplement.Implements;
using ClassLibraryContracts.StoragesContracts;
using ClassLibraryContracts.BusinesLogicContracts;
using ClassLibraryBusinessLogic.BusinessLogics;

namespace WinFormsApp1
{
    internal static class Program
    {
        private static IUnityContainer container = null;
        public static IUnityContainer Container
        {
            get
            {
                if (container == null)
                {
                    container = BuildUnityContainer();
                }
                return container;
            }
        }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(Container.Resolve<Form1>());
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();

            currentContainer.RegisterType<IUserStorage, UserStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IUserLogic, UserLogic>(new HierarchicalLifetimeManager());

            return currentContainer;
        }
    }
}
