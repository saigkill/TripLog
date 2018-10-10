using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TripLog.Views;
using TripLog.ViewModels;
using TripLog.Modules;
using TripLog.Services;
using Ninject;
using Ninject.Modules;


[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace TripLog
{
	public partial class App : Application
	{
        public IKernel Kernel { get; set; }

        public App (params INinjectModule[] platformModules)
		{
			InitializeComponent();

			var mainPage = new NavigationPage(new MainPage());
            var navService = DependencyService.Get<INavService>() as XamarinFormsNavService;

            // Register core services
            Kernel = new StandardKernel(new TripLogCoreModule(), new TripLogNavModule(mainPage.Navigation));

            // Register platform specific services
            Kernel.Load(platformModules);

            // Get the MainViewModel from the IoC
            mainPage.BindingContext = Kernel.Get<MainViewModel>();

            navService.XamarinFormsNav = mainPage.Navigation;

            MainPage = mainPage;
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
