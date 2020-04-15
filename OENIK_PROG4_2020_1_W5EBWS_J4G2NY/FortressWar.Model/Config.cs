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

        /// <summary>
        /// The base power of the knight.
        /// </summary>
        public const int KnightBasePower = 20;

        /// <summary>
        /// The knight get that much power when do a level up.
        /// </summary>
        public const int KnightLVLPower = 5;

        /// <summary>
        /// The base power of the rider.
        /// </summary>
        public const int RiderBasePower = 50;

        /// <summary>
        /// The rider get that much power when do a level up.
        /// </summary>
        public const int RiderLVLPower = 6;

        /// <summary>
        /// The base Speed of the knight.
        /// </summary>
        public const int KnightBaseSpeed = 1;

        /// <summary>
        /// The knight get that much Speed when do a level up.
        /// </summary>
        public const int KnightLVLSpeed = 0;

        /// <summary>
        /// The base Speed of the rider.
        /// </summary>
        public const int RiderBaseSpeed = 2;

        /// <summary>
        /// The rider get that much Speed when do a level up.
        /// </summary>
        public const int RiderLVLSpeed = 0;

        /// <summary>
        /// The base Life of the knight.
        /// </summary>
        public const int KnightBaseLife = 100;

        /// <summary>
        /// The knight get that much Life when do a level up.
        /// </summary>
        public const int KnightLVLLife = 10;

        /// <summary>
        /// The base Life of the rider.
        /// </summary>
        public const int RiderBaseLife = 150;

        /// <summary>
        /// The rider get that much Life when do a level up.
        /// </summary>
        public const int RiderLVLLife = 15;

        /// <summary>
        /// The base Life of the Barricade.
        /// </summary>
        public const int BarricadeBaseLife = 150;

        /// <summary>
        /// The Barricade get that much Life when do a level up.
        /// </summary>
        public const int BarricadeLVLLife = 10;

        /// <summary>
        /// The base Life of the Castle.
        /// </summary>
        public const int CastleBaseLife = 1000;

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
