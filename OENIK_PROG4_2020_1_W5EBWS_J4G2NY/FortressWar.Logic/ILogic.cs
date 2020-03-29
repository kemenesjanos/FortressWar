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
    /// Interface of the logic.
    /// </summary>
    public interface ILogic
    {
        enum Characters { Warrior, Rider, Barricade, Fortress }

        enum Players { player1, player2 }

        event EventHandler RefreshScreen;

        /// <summary> LEIRAS.</summary>
        void MoveSoldier(Soldier soldier);

        /// <summary> LEIRAS.</summary>
        bool Attack(Character AttackedCharacter, int Damage);

        /// <summary> LEIRAS.</summary>
        void MoveSelector(int y);

        /// <summary> LEIRAS.</summary>
        void NewCharacter(Characters character, Players player, int y);

        /// <summary> LEIRAS.</summary>
        void Die(Character character);

        /// <summary> LEIRAS.</summary>
        void StartGame();

        /// <summary> LEIRAS.</summary>
        void EndGame();

        /// <summary> LEIRAS.</summary>
        void GetExtra(Soldier soldier);

        /// <summary> LEIRAS.</summary>
        void GetCoin(Players player);

        /// <summary> LEIRAS.</summary>
        void UpdateCharacter(Characters character);
    }
}
