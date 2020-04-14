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
        /// Calling if the character is dead.
        /// </summary>
        public abstract void Dead();
    }
}
