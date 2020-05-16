﻿// <copyright file="EscPage.xaml.cs" company="PlaceholderCompany">
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

    /// <summary>
    /// Interaction logic for EscPage.xaml.
    /// </summary>
    public partial class EscPage : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EscPage"/> class.
        /// </summary>
        public EscPage()
        {
            this.InitializeComponent();
        }

        private void Button_Resume(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new LoadGamePage());
        }

        private void Button_Menu(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MenuPage());
        }
    }
}
