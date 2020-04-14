// <copyright file="Renderer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace FortressWar.Renderer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using FortressWar.Model;

    /// <summary>
    /// Renderer of the game.
    /// </summary>
    public class Renderer
    {
        private Model model;

        private Dictionary<string, Brush> brushes = new Dictionary<string, Brush>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Renderer"/> class.
        /// </summary>
        /// <param name="model">The parameter.</param>
        public Renderer(Model model)
        {
            this.model = model;
        }

        /// <summary>
        /// Help to add images as brush.
        /// </summary>
        /// <param name="fname">Image name.</param>
        /// <param name="isTiled">Repeating of the image.</param>
        /// <returns>The image as brush.</returns>
        private Brush GetBrush(string fname, bool isTiled)
        {
            if (!this.brushes.ContainsKey(fname))
            {
                BitmapImage bmp = new BitmapImage();

                bmp.BeginInit();
                bmp.StreamSource = Assembly.GetExecutingAssembly().GetManifestResourceStream(fname);
                bmp.EndInit();

                ImageBrush ib = new ImageBrush(bmp);

                if (isTiled)
                {
                    ib.TileMode = TileMode.Tile;
                    //TODO: ib.Viewport = new Rect(0,0,,); ?
                    ib.ViewportUnits = BrushMappingMode.Absolute;
                }

                this.brushes.Add(fname, ib);
            }

            return this.brushes[fname];
        }

        /// <summary>
        /// Gets make filed brush.
        /// </summary>
        private Brush FieldBrush { get { return this.GetBrush("FortressWar.Model.Images.grass.png", true); } }

    }
}
