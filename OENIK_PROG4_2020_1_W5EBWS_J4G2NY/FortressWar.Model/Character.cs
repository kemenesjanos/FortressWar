// <copyright file="Character.cs" company="PlaceholderCompany">
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
    /// Describing the general characters.
    /// </summary>
    public abstract class Character : GameItem
    {
        /// <summary>
        /// Gets or sets the life of the character.
        /// </summary>
        public int Life { get; set; }

        /// <summary>
        /// Gets or sets the money what the enemy got if this character dies.
        /// </summary>
        public int Bounty { get; set; }

        /// <summary>
        /// Gets or sets the player who owns this character.
        /// </summary>
        public Player Owner { get; set; }

    }
}
