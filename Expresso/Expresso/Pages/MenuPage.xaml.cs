﻿using Expresso.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Menu = Expresso.Models.Menu;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Expresso.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        public ObservableCollection<Menu> Menus;
        public static bool First = true;
        public MenuPage()
        {

            InitializeComponent();
            Menus = new ObservableCollection<Menu>();

        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (First)
            {
                ApiServices apiServices = new ApiServices();
                var menus = await apiServices.GetMenu();

                foreach (var menu in menus)
                {
                    Menus.Add(menu);
                }

                LvMenu.ItemsSource = Menus;
            }

            First = false;
        }

        private void LvMenu_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedMenu =  e.SelectedItem as Menu;
            Navigation.PushAsync(new SubMenuPage(selectedMenu));


        }
    }
}