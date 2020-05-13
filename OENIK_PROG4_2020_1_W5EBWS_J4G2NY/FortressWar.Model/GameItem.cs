// <copyright file="GameItem.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace FortressWar.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Media;
    using System.Xml.Serialization;

    /// <summary>
    /// Describing the general game item.
    /// </summary>
    public abstract class GameItem
    {
        /// <summary>
        /// The (0;0) centered geometry.
        /// </summary>
        public Geometry area;

        /// <summary>
        /// Rotation in degree.
        /// </summary>
        protected double rotDegree = 0;

        private double cx;

        /// <summary>
        /// Gets or sets the X coordinate from the center.
        /// </summary>
        public double CX
        {
            get { return this.cx + (Config.FieldWidht / 2); }
            set { this.cx = value; }
        }

        /// <summary>
        /// Gets or set the Y coordinate from the center in tile.
        /// </summary>
        public double CY
        {
            get
            {
                if (this is Selector)
                {
                    if (!(this as Selector).IsPutACharacter)
                    {
                        return Math.Floor((this.Y_Tile - 2) * 1.0 * Config.SelectorHeight)
                    + (Config.FieldHeight / 2) + (Config.SelectorHeight / 2) - 160;
                    }
                    else
                    {
                        return Math.Floor((this.Y_Tile - 2) * 2.8 * Config.CharacterTileHeight)
                    + (Config.FieldHeight / 2) + (Config.CharacterTileHeight / 2) - 90;
                    }
                }
                else if(this is Fortress)
                {
                    return 150;
                }
                else if (this is Potion || this is Coin)
                {
                    return Math.Floor((this.Y_Tile - 2) * 1.4 * Config.CharacterTileHeight)
                    + (Config.FieldHeight / 2) + (Config.CharacterTileHeight / 2) - 90;
                }

                return Math.Floor((this.Y_Tile - 2) * 2.8 * Config.CharacterTileHeight)
                    + (Config.FieldHeight / 2) + (Config.CharacterTileHeight / 2) - 25;
            }
        }

        /// <summary>
        /// Gets or sets the Y coordinate in tile.
        /// </summary>
        public int Y_Tile { get; set; }

        /// <summary>
        /// Gets or sets the game item's rotation in Rad.
        /// </summary>
        public double Rad
        {
            get
            {
                return this.rotDegree * Math.PI / 180;
            }

            set
            {
                this.rotDegree = 180 * value / Math.PI;
            }
        }

        /// <summary>
        /// Gets the real area of the game item.
        /// </summary>
        public Geometry RealArea
        {
            get
            {
                TransformGroup tg = new TransformGroup();
                tg.Children.Add(new TranslateTransform(this.CX, this.CY));
                tg.Children.Add(new RotateTransform(this.rotDegree, this.CX, this.CY));
                this.area.Transform = tg;
                return this.area.GetFlattenedPathGeometry();
            }
        }

        /// <summary>
        /// Says if the two game item are conflict.
        /// </summary>
        /// <param name="other">The other game item.</param>
        /// <returns>Is this game item is collision with the other one.</returns>
        public bool IsCollision(GameItem other)
        {
            return Geometry.Combine(
                this.RealArea,
                other.RealArea,
                GeometryCombineMode.Intersect,
                null).GetArea() > 0;
        }
    }
}
