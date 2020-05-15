// <copyright file="Control.cs" company="PlaceholderCompany">
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
    using System.Windows.Input;
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

        private string winner;

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
            this.model = new Model();
            this.logic = new Logic(this.model);
            this.renderer = new Renderer(this.model);

            this.logic.FinishedGame += this.Logic_FinishedGame;

            Window win = Window.GetWindow(this);
            if (win != null)
            {
                this.tickTimer = new DispatcherTimer();
                this.tickTimer.Interval = TimeSpan.FromMilliseconds(200);
                this.tickTimer.Tick += this.TickTimer_Tick;
                this.tickTimer.Start();

                win.KeyDown += this.Win_KeyDown;
            }

            this.logic.RefreshScreen += (obj, args) => this.InvalidateVisual();

            this.InvalidateVisual();
        }

        /// <summary>
        /// The visualization.
        /// </summary>
        /// <param name="drawingContext">Drawing board upload.</param>
        protected override void OnRender(DrawingContext drawingContext)
        {
            if (this.renderer != null)
            {
                this.renderer.BuildDrawing(drawingContext);
            }
        }

        private void Win_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.W: this.logic.MoveSelector(this.model.Player_1, -1); break;
                case Key.S: this.logic.MoveSelector(this.model.Player_1, 1); break;
                case Key.Space: this.logic.SelectorSelect(this.model.Player_1); break;

                case Key.Up: this.logic.MoveSelector(this.model.Player_2, -1); break;
                case Key.Down: this.logic.MoveSelector(this.model.Player_2, 1); break;
                case Key.Enter: this.logic.SelectorSelect(this.model.Player_2); break;

                case Key.Escape: this.tickTimer.Stop(); this.logic.SaveGameState(); break;
            }

            this.InvalidateVisual();
        }

        private void TickTimer_Tick(object sender, EventArgs e)
        {
            //if (this.logic.model != this.renderer.model)
            //{
            //    this.renderer.model = this.logic.model;
            //    this.model = this.logic.model;
            //}
            this.logic.MoveSoldier();
        }

        private void Logic_FinishedGame(object sender, EventArgs e)
        {
            this.tickTimer.Stop();
            this.winner = (e as FinishedGameEventArgs).WinnerName;
            MessageBox.Show($"The game is and!\n The winner is {this.winner}!");
        }
    }
}
