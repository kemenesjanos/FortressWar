// <copyright file="MenuPage.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace FortressWar
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using FortressWar.Control;

    /// <summary>
    /// Interaction logic for MenuPage.xaml.
    /// </summary>
    public partial class MenuPage : Page
    {
        private Control.Control control = new Control.Control();

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuPage"/> class.
        /// </summary>
        public MenuPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new GamePage());
        }

        private void Button_Close(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Load(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new LoadGamePage());
        }

        private void Button_Help(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new DescriptionPage());
        }
    }
}
