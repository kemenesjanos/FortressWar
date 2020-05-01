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
            this.model = new Model();
            this.logic = new Logic(this.model);
            this.renderer = new Renderer(this.model);

            Window win = Window.GetWindow(this);
            if (win != null)
            {
                this.tickTimer = new DispatcherTimer();
                this.tickTimer.Interval = TimeSpan.FromMilliseconds(100);
                this.tickTimer.Tick += this.TickTimer_Tick;
                this.tickTimer.Start();

                win.KeyDown += this.Win_KeyDown;
            }
            logic.RefreshScreen += (obj, args) => InvalidateVisual();

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
            //TODO: logic.moveselector meghívása!
            //TODO: gombok Dy-át beállítani + a W S és a Fel Le-nek nem Dx mozgatás kell? távábbá az enter és space??
            switch (e.Key)
            {
                //1-es játékos
                case Key.W: logic.MoveSelector(model.Player_1, 1); break;
                case Key.S: logic.MoveSelector(model.Player_1, 1); break;
                case Key.D: logic.MoveSelector(model.Player_1, 1); break;
                case Key.A: logic.MoveSelector(model.Player_1, 1); break;
                case Key.Space: logic.MoveSelector(model.Player_1, 1); break;
                //2-es játékos
                case Key.Up: logic.MoveSelector(model.Player_2, 1); break;
                case Key.Down: logic.MoveSelector(model.Player_2, 1); break;
                case Key.Right: logic.MoveSelector(model.Player_2, 1); break;
                case Key.Left: logic.MoveSelector(model.Player_2, 1); break;
                case Key.Enter: logic.MoveSelector(model.Player_2, 1); break;
            }
            //TODO: játék vége vizsgálat a várakra és azzal akár kiírás
        }

        private void TickTimer_Tick(object sender, EventArgs e)
        {
            //TODO: mozgatás események meghívása.
            logic.MoveSoldier();
        }
    }
}
