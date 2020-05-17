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
    using System.Xml.Serialization;

    /// <summary>
    /// Describing the Soldiers.
    /// </summary>
    public abstract class Soldier : Character
    {
        /// <summary>
        /// Gets or sets level of the soldier.
        /// </summary>
        public int LVL { get; set; }

        /// <summary>
        /// Gets or sets power of the soldier.
        /// </summary>
        public int Power { get; set; }

        /// <summary>
        /// Gets or sets speed of the soldier.
        /// </summary>
        public int Speed { get; set; }

        /// <summary>
        /// Gets or sets the enemy to attack.
        /// </summary>
        [XmlIgnore]
        public Character Enemy { get; set; }

        /// <summary>
        /// Level up method.
        /// </summary>
        public virtual void LVLUp()
        {
        }
    }
}
