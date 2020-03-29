// <copyright file="IRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace FortressWar.Repository
{
    using FortressWar.Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface of the Repository.
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Load the saved game.
        /// </summary>
        /// <returns>A IList of models.</returns>
        IList<MyShape> LoadSavedGame();

        /// <summary>
        /// Save the current game. 
        /// </summary>
        /// <param name="models">The models to be saved.</param>
        void SaveCurrentGame(IList<MyShape> models);
    }
}
