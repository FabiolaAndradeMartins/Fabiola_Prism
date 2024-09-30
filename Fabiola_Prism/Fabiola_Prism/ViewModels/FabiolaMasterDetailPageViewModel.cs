using Fabiola_Prism.Helpers;
using Fabiola_Prism.ItemViewModel;
using Fabiola_Prism.Models;
using Fabiola_Prism.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Fabiola_Prism.ViewModels
{
	public class FabiolaMasterDetailPageViewModel : ViewModelBase
	{
        private readonly INavigationService _navigationService;

        public FabiolaMasterDetailPageViewModel(INavigationService navigationService) 
            :base(navigationService) 
        {
            _navigationService = navigationService;
            LoadMenus();
                
        }
        public ObservableCollection<MenuItemViewModel> Menus { get; set; }
        private void LoadMenus()
        {
            List<Menu> menus = new List<Menu>
            {
                new Menu
                {
                  Icon = "ic_card_giftcard",
                  PageName = $"{nameof(ProductsPage)}",
                  Title = Languages.Products
                },

                new Menu
                {
                  Icon = "ic_shopping_cart",
                  PageName = $"{nameof(ShowCarPage)}",
                  Title = Languages.ShowShoppingCar
                },

                new Menu
                {
                  Icon = "ic_history",
                  PageName = $"{nameof(ShowHistoryPage)}",
                  Title = Languages.ShowPurchaseHistory,
                  IsLoginRequired = true
                },

                new Menu
                {
                  Icon = "ic_person",
                  PageName = $"{nameof(ModifyUserPage)}",
                  Title = Languages.ModifyUser,
                  IsLoginRequired = true
                },

                new Menu
                {
                  Icon = "ic_exit_to_app",
                  PageName = $"{nameof(LoginPage)}",
                  Title = Languages.Login
                }
            };

            Menus = new ObservableCollection<MenuItemViewModel>(
                menus.Select(m => new MenuItemViewModel(_navigationService)
                {
                  Icon = m.Icon,
                  PageName = m.PageName,
                  Title = m.Title,
                  IsLoginRequired = m.IsLoginRequired
                }).ToList());            
        }
    }
}
