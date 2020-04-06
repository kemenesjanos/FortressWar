// <copyright file="IModel.cs" company="PlaceholderCompany">
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
    /// Interface of the Model.
    /// </summary>
    public interface IModel
    {
        /// <summary>
        /// Build the map.
        /// </summary>
        void MapBuild();

        /// <summary>
        /// Gets or sets the Width of the game in pixels.
        /// </summary>
        double GameWidth { get; set; }

        /// <summary>
        /// Gets or sets the Height of the game in pixels.
        /// </summary>
        double GameHeight { get; set; }

        /// <summary>
        /// Gets or sets the tile width in pixels.
        /// </summary>
        double TileWidth { get; set; }

        /// <summary>
        /// Gets or sets the tile height in pixels.
        /// </summary>
        double TileHeight { get; set; }

        /// <summary>
        /// Gets or sets the first player's name.
        /// </summary>
        string Player_1_name { get; set; }

        /// <summary>
        /// Gets or sets the second player's name.
        /// </summary>
        string Player_2_name { get; set; }

        /// <summary>
        /// Gets or sets the first player's money.
        /// </summary>
        int Money_1 { get; set; }

        /// <summary>
        /// Gets or sets the second player's money.
        /// </summary>
        int Money_2 { get; set; }

        /// <summary>
        /// Gets or sets a list of barricades in the game.
        /// </summary>
        List<Barricade> Barricades { get; set; }

        /// <summary>
        /// Gets or sets a list of soldiers in the game.
        /// </summary>
        List<Soldier> Soldiers { get; set; }

        /// <summary>
        /// Gets or sets a list of bonuses in the game.
        /// </summary>
        List<Bonus> Bonuses { get; set; }

        /// <summary>
        /// Gets or sets a list of monies in the game.
        /// </summary>
        List<Money> Monies { get; set; }

        /// <summary>
        /// Gets or sets the first player's fortress.
        /// </summary>
        Fortress Fortress_1 { get; set; }

        /// <summary>
        /// Gets or sets the second player's fortress.
        /// </summary>
        Fortress Fortress_2 { get; set; }

        /// <summary>
        /// Gets or sets the first player's rider level.
        /// </summary>
        int RiderLVL_1 { get; set; }

        /// <summary>
        /// Gets or sets the second player's rider level.
        /// </summary>
        int RiderLVL_2 { get; set; }

        /// <summary>
        /// Gets or sets the first player's knight level.
        /// </summary>
        int KnightLVL_1 { get; set; }

        /// <summary>
        /// Gets or sets the second player's knight level.
        /// </summary>
        int KnightLVL_2 { get; set; }

        /// <summary>
        /// Gets or sets the first player's barricade level.
        /// </summary>
        int BarricadeLVL_1 { get; set; }

        /// <summary>
        /// Gets or sets the second player's barricade level.
        /// </summary>
        int BarricadeLVL_2 { get; set; }
    }
}
