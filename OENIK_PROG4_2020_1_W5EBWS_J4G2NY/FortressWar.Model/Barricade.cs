﻿// <copyright file="Barricade.cs" company="PlaceholderCompany">
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
    /// Describing the barricade.
    /// </summary>
    public class Barricade : Character
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Barricade"/> class.
        /// Ctor.
        /// </summary>
        /// <param name="player">The owner.</param>
        public Barricade(Player player)
        {
            this.LVL = player.BarricadeLVL;
            this.Owner = player;
            this.CountBasics();
        }

        /// <summary>
        /// Gets or sets level.
        /// </summary>
        public int LVL { get; set; }

        private void CountBasics()
        {
            this.Bounty = this.LVL * Config.BarricadeBaseBounty;
            this.Life = Config.BarricadeBaseLife + (this.LVL * Config.BarricadeLVLLife);
        }
    }
}
