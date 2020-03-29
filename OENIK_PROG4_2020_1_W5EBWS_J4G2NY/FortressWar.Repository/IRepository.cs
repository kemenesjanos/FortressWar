// <copyright file="IRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace FortressWar.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using FortressWar.Model;

    /// <summary>
    /// Interface of the Repository.
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Load the saved game.
        /// </summary>
        /// <returns>A IModel of models.</returns>
        IModel LoadSavedGame();

        /// <summary>
        /// Save the current game.
        /// </summary>
        /// <param name="models">The models to be saved.</param>
        void SaveCurrentGame(IModel models);
    }
}
