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
    using System.Windows.Media;

    /// <summary>
    /// Describing the general game item.
    /// </summary>
    public abstract class GameItem
    {
        /// <summary>
        /// The (0;0) centered geometry.
        /// </summary>
        protected Geometry area;

        /// <summary>
        /// Rotation in degree.
        /// </summary>
        protected double rotDegree = 0;

        /// <summary>
        /// Gets or sets the X coordinate from the center.
        /// </summary>
        public double CX { get; set; }

        /// <summary>
        /// Gets or sets the Y coordinate from the center in tile.
        /// </summary>
        public double CY { get; set; }

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
