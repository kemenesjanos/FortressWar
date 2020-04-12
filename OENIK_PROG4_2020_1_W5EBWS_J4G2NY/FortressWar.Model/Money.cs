// <copyright file="Money.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace FortressWar.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Describing the Money.
    /// </summary>
    public class Money : GameItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Money"/> class.
        /// Set a random value to value.
        /// </summary>
        public Money()
        {
            Random r = new Random();
            this.Value = r.Next(Config.MinCoin, Config.MaxCoin + 1);
        }

        /// <summary>
        /// Gets the money value.
        /// </summary>
        public int Value { get; }
    }
}
