using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortressWar.Model
{
    public class Player
    {
        /// <summary>
        /// Gets or sets the name of the player.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the money of the character.
        /// </summary>
        public int Money { get; set; }

        /// <summary>
        /// Gets or sets the fortress of this fortress.
        /// </summary>
        public Fortress Fortress { get; set; }

        /// <summary>
        /// Gets or sets the level of the rider.
        /// </summary>
        public int RiderLVL { get; set; }

        /// <summary>
        /// Gets or sets the level of the Knight.
        /// </summary>
        public int KnightLVL { get; set; }

        /// <summary>
        /// Gets or sets the level of the barricade.
        /// </summary>
        public int BarricadeLVL { get; set; }

        /// <summary>
        /// Gets or sets the barricade list.
        /// </summary>
        public List<Barricade> Barricades { get; set; }

        /// <summary>
        /// Gets or sets the soldier list.
        /// </summary>
        public List<Soldier> Soldiers { get; set; }
    }
}
