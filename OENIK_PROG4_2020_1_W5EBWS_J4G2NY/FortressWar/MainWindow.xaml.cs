// <copyright file="MainWindow.xaml.cs" company="PlaceholderCompany">
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();

            this.Loaded += this.MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.frame.NavigationService.Navigate(new MenuPage());
            this.KeyDown += this.MainWindow_KeyDown;
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {

            Control.Control control = new Control.Control();
            switch (e.Key)
            {
                case Key.Escape:
                        this.frame.NavigationService.Navigate(new EscPage()); break;
                    //TODO: talán az lenne a praktikusabb, ha a controlban is szerepelne egy Escape, ami meg menti (meghívja a SAVE-t) a játékot a lenyomásra
                    //TODO: ha Resume-t nyom a játékos, akkor lényegében egy LOAD történne
                    //TODO: nem biztos, hogy érdemes lenne piszkálni azzal a programot, hogy megállítgatjuk a TicTimer-t
                    //TODO: főleg ha már amúgy is meg kell valósítani a Save/Load dolgot
            }
        }
    }
}
