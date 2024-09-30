using Fabiola_Prism.Services;
using Fabiola_Prism.ViewModels;
using Fabiola_Prism.Views;
using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Navigation;
using Syncfusion.Licensing;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace Fabiola_Prism
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            //colocar aqui a chave do syncfusion
            SyncfusionLicenseProvider.RegisterLicense("MzUwMzg2M0AzMjM3MmUzMDJlMzBqc2VBZVU0OE5XQlFYeG9VL3BFSHY5cDJ3Wk1McnAxRDNGMDlYSHFPSFNRPQ==");

            InitializeComponent();

            await NavigationService.NavigateAsync
                ($"/{nameof(FabiolaMasterDetailPage)}/NavigationPage/{nameof(ProductsPage)}");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();
            containerRegistry.Register<IApiService, ApiService>();
            containerRegistry.RegisterForNavigation<NavigationPage>();            
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<ProductsPage, ProductsPageViewModel>();
            containerRegistry.RegisterForNavigation<ProductDetailPage, ProductDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<FabiolaMasterDetailPage, FabiolaMasterDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<ShowHistoryPage, ShowHistoryPageViewModel>();
            containerRegistry.RegisterForNavigation<ModifyUserPage, ModifyUserPageViewModel>();
            containerRegistry.RegisterForNavigation<ShowCarPage, ShowCarPageViewModel>();
        }
    }
}
