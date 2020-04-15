// <copyright file="Soldier.cs" company="PlaceholderCompany">
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
    /// Describing the Soldiers.
    /// </summary>
    public abstract class Soldier : Character
    {
        /// <summary>
        /// Gets level of the soldier.
        /// </summary>
        public int LVL { get; private set; }

        /// <summary>
        /// Gets power of the soldier.
        /// </summary>
        public int Power { get; private set; }

        /// <summary>
        /// Gets speed of the soldier.
        /// </summary>
        public int Speed { get; private set; }

        /// <summary>
        /// Gets or sets the enemy to attack.
        /// </summary>
        public Character Enemy { get; set; }

        /// <summary>
        /// Level up method.
        /// </summary>
        public virtual void LVLUp()
        {
        }
    }
}
