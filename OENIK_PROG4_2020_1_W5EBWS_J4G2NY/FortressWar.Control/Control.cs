﻿// <copyright file="Control.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace FortressWar.Control
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Threading;
    using FortressWar.Logic;
    using FortressWar.Model;
    using FortressWar.Renderer;

    /// <summary>
    /// Controls of the game.
    /// </summary>
    public class Control : FrameworkElement
    {
        private Logic logic;
        private Renderer renderer;
        private Model model;

        /// <summary>
        /// Responsible for moving items.
        /// </summary>
        private DispatcherTimer tickTimer;

        /// <summary>
        /// Initializes a new instance of the <see cref="Control"/> class.
        /// Contructor of the control class. Just use for the event.
        /// </summary>
        public Control()
        {
            this.Loaded += this.Control_Loaded;
        }

        private void Control_Loaded(object sender, RoutedEventArgs e)
        {
            //TODO: model, logic, renderer

            Window win = Window.GetWindow(this);
            if (win != null)
            {
                this.tickTimer = new DispatcherTimer();
                this.tickTimer.Interval = TimeSpan.FromMilliseconds(40);
                this.tickTimer.Tick += this.TickTimer_Tick;
                this.tickTimer.Start();

                win.KeyDown += this.Win_KeyDown;
            }

            //TODO: logic.refreshscreen, és utána invalidateVisual
        }

        /// <summary>
        /// The visualization.
        /// </summary>
        /// <param name="drawingContext">Drawing board upload.</param>
        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
        }

        private void Win_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            throw new NotImplementedException();
            //TODO: logic.moveselector meghívása!
        }

        private void TickTimer_Tick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
            //TODO: mozgatás események meghívása.
        }
    }
}
