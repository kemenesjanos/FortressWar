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
                    ib.Viewport = new Rect(0, 0, Config.CharacterTileWidth, Config.CharacterTileHeight);
                    ib.ViewportUnits = BrushMappingMode.Absolute;
                }

                this.brushes.Add(fname, ib);
            }

            return this.brushes[fname];
        }

        /// <summary>
        /// Gets make field brush.
        /// </summary>
        Brush FieldBrush { get { return this.GetBrush("FortressWar.Model.Images.grass.png", true); } }

        /// <summary>
        /// Gets make Knight1 brush.
        /// </summary>
        Brush Knight1Brush { get { return this.GetBrush("FortressWar.Model.Images.1walk1.png", false); } }

        /// <summary>
        /// Gets make Knight2 brush.
        /// </summary>
        Brush Knight2Brush { get { return this.GetBrush("FortressWar.Model.Images.2walk1.png", false); } }

        /// <summary>
        /// Gets make Rider1 brush.
        /// </summary>
        Brush Rider1Brush { get { return this.GetBrush("FortressWar.Model.Images.1hwalk1.png", false); } }

        /// <summary>
        /// Gets make Rider2 brush.
        /// </summary>
        Brush Rider2Brush { get { return this.GetBrush("FortressWar.Model.Images.2hwalk1.png", false); } }

        /// <summary>
        /// Gets make Barricade1 brush.
        /// </summary>
        Brush Barricade1Brush { get { return this.GetBrush("FortressWar.Model.Images.1barricade.png", false); } }

        /// <summary>
        /// Gets make Barricade2 brush.
        /// </summary>
        Brush Barricade2Brush { get { return this.GetBrush("FortressWar.Model.Images.2barricade.png", false); } }

        /// <summary>
        /// Build of the drawing.
        /// </summary>
        /// <returns>The game elements.</returns>
        public Drawing BuildDrawing()
        {
            DrawingGroup dg = new DrawingGroup();

            dg.Children.Add(this.GetBackground());
            dg.Children.Add(this.GetTopArea());
            dg.Children.Add(this.GetRoad());
            dg.Children.Add(this.GetRoadChoose());
            dg.Children.Add(this.GetCharacterChoose());
            dg.Children.Add(this.GetFortress());

            dg.Children.Add(this.GetKnight());
            dg.Children.Add(this.GetRider());
            dg.Children.Add(this.GetBarricade());

            return dg;
        }

        private Drawing GetBarricade()
        {
            throw new NotImplementedException();
        }

        private Drawing GetRider()
        {
            throw new NotImplementedException();
        }

        private Drawing GetKnight()
        {
            throw new NotImplementedException();
        }

        private Drawing GetTopArea()
        {
            throw new NotImplementedException();
        }

        private Drawing GetFortress()
        {
            throw new NotImplementedException();
        }

        private Drawing GetCharacterChoose()
        {
            throw new NotImplementedException();
        }

        private Drawing GetRoadChoose()
        {
            throw new NotImplementedException();
        }

        private Drawing GetRoad()
        {
            throw new NotImplementedException();
        }

        private Drawing GetBackground()
        {
            throw new NotImplementedException();
        }
    }
}
