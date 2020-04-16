// <copyright file="Bonus.cs" company="PlaceholderCompany">
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
    /// Describing the star and the potion.
    /// </summary>
    public class Bonus : GameItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Bonus"/> class.
        /// Bonus.
        /// </summary>
        public Bonus()
        {
            Random r = new Random();
            this.Y_Tile = r.Next(0, 5);
            this.CX = r.Next(-Config.fullWidht / 2, Config.fullWidht / 2);
        }
    }
}
