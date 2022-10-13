using GroceryStoreBusinessLogic;
using GroceryStoreContracts.BusinessLogicContracts;
using GroceryStoreContracts.StoragesContracts;
using GroceryStoreDatabase.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Unity;
using Unity.Lifetime;

namespace GroceryStore
{
    static class Program
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
            // Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(Container.Resolve<FormMain>());
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<ICategoryStorage, CategoryStorage>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IProductStorage, ProductStorage>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<ICategoryLogic, CategoryLogic>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IProductLogic, ProductLogic>(new
            HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
