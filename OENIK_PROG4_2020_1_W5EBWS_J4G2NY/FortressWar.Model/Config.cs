// <copyright file="Config.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace FortressWar.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Media;

    /// <summary>
    /// Config of the game.
    /// </summary>
    public static class Config
    {
        /// <summary>
        /// Minimum coin for the random bonus.
        /// </summary>
        public const int MinCoin = 10;

        /// <summary>
        /// Maximum coin for the random bonus.
        /// </summary>
        public const int MaxCoin = 500;

        public const int KnightBasePower = 10;
        public const int KnightLVLPower = 5;
        //TODO: Power,speed, life...

        /// <summary>
        /// Main text colour.
        /// </summary>
        public static Brush textLineColour = Brushes.White;

        /// <summary>
        /// Darker text colour.
        /// </summary>
        public static Brush darkTextLineColour = Brushes.Sienna;

        /// <summary>
        /// Gold text colour.
        /// </summary>
        public static Brush goldTextLineColour = Brushes.Gold;

        /// <summary>
        /// Base background colour.
        /// </summary>
        public static Brush baseBrownBg = Brushes.SaddleBrown;

        /// <summary>
        /// Road background colour.
        /// </summary>
        public static Brush roadBg = Brushes.AntiqueWhite;

        /// <summary>
        /// Road chooser icon background colour.
        /// </summary>
        public static Brush roadChooseIconBg = Brushes.DarkSalmon;

        /// <summary>
        /// Character chooser icon background colour.
        /// </summary>
        public static Brush characterIconBg = Brushes.Sienna;

        /// <summary>
        /// Character chooser icon line colour.
        /// </summary>
        public static Brush characterIconLine = Brushes.SandyBrown;

        /// <summary>
        /// Active icon background colour.
        /// </summary>
        public static Brush activeBg = Brushes.LightCoral;

        /// <summary>
        /// Full width of the game.
        /// </summary>
        public const int fullWidht = 1600;

        /// <summary>
        /// Full height of the game.
        /// </summary>
        public static int fullHeight = 900;

        /// <summary>
        /// Top area width of the game.
        /// </summary>
        public static int topWidth = 1600;

        /// <summary>
        /// Top area height of the game.
        /// </summary>
        public static int topHeight = 200;

        /// <summary>
        /// Field area width of the game.
        /// </summary>
        public static int fieldWidht = 800;

        /// <summary>
        /// Field area height of the game.
        /// </summary>
        public static int fieldHeight = 700;

        /// <summary>
        /// Side areas width of the game.
        /// </summary>
        public static int sideWidht = 400;

        /// <summary>
        /// Side area height of the game.
        /// </summary>
        public static int sideHeight = 700;
    }
}
