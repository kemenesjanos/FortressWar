// <copyright file="FinishedGameEventArgs.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace FortressWar.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Event for the finished game. Return the winner name.
    /// </summary>
    public class FinishedGameEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets a winnerName.
        /// </summary>
        public string WinnerName { get; set; }
    }
}
