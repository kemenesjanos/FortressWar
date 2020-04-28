// <copyright file="ILogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace FortressWar.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using FortressWar.Model;

    /// <summary>
    /// The characters of the game.
    /// </summary>
    public enum Characters
    {
        /// <summary>
        /// Knight.
        /// </summary>
        Knight,

        /// <summary>
        /// Rider.
        /// </summary>
        Rider,

        /// <summary>
        /// Barricade.
        /// </summary>
        Barricade,
    }

    /// <summary>
    /// Extras.
    /// </summary>
    public enum Extras
    {
        /// <summary>
        /// Coin.
        /// </summary>
        Coin,

        /// <summary>
        /// Potion.
        /// </summary>
        Potion,
    }

    /// <summary>
    /// Interface of the logic.
    /// </summary>
    public interface ILogic
    {

        /// <summary>
        /// Move Soldier ahead.
        /// </summary>
        void MoveSoldier();

        /// <summary>
        /// Decrease the character's life with a Demage.
        /// </summary>
        /// <param name="attackedCharacter">The attacked Character.</param>
        /// <param name="damage">The quantity of the attack.</param>
        /// <returns>If the attacked character is dead.</returns>
        bool Attack(Character attackedCharacter, int damage);

        /// <summary>
        /// Move the selector.
        /// </summary>
        /// <param name="dy">The y directon to move.</param>
        void MoveSelector(int dy);

        /// <summary>
        /// Create a new character.
        /// </summary>
        /// <param name="character">The type of the character.</param>
        /// <param name="player">The owner of the new character.</param>
        /// <param name="y">The y coord.</param>
        void NewCharacter(Characters character, Player player, int y);

        /// <summary>
        /// Create new extra.
        /// </summary>
        /// <param name="extra">The type of the extra.</param>
        void NewExtra(Extras extra);

        /// <summary>
        /// If the character is dead.
        /// </summary>
        /// <param name="character">The dead charackter.</param>
        void Die(Character character);

        /// <summary>
        /// Start the game.
        /// </summary>
        void StartGame();

        /// <summary>
        /// End of the game.
        /// </summary>
        void EndGame();

        /// <summary>
        /// If a soldier get a bonus.
        /// </summary>
        /// <param name="soldier">The soldier who got the bonus.</param>
        void GetPotion(Soldier soldier);

        /// <summary>
        /// Update a character type.
        /// </summary>
        /// <param name="character">The character type to update.</param>
        /// <param name="player">The player.</param>
        void UpdateCharacter(Characters character, Player player);

        /// <summary>
        /// Save the current state of the game.
        /// </summary>
        void SaveGameState();

        /// <summary>
        /// Load the previous game state.
        /// </summary>
        void LoadGameState();
    }
}
