﻿// <copyright file="EndGamePage.xaml.cs" company="PlaceholderCompany">
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
    /// Interaction logic for EndGamePage.xaml.
    /// </summary>
    public partial class EndGamePage : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EndGamePage"/> class.
        /// </summary>
        public EndGamePage()
        {
            this.InitializeComponent();

            Control.Control control = new Control.Control();
        }

        private void Button_Start(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new GamePage());
        }

        private void Button_Menu(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MenuPage());
        }
    }
}
