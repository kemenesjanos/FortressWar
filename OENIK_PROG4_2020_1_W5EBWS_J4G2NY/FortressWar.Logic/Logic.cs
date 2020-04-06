// <copyright file="Logic.cs" company="PlaceholderCompany">
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
    /// Logic.
    /// </summary>
    public class Logic : ILogic
    {
        public event EventHandler RefreshScreen;

        public bool Attack(Character attackedCharacter, int damage)
        {
            throw new NotImplementedException();
        }

        public void Die(Character character)
        {
            throw new NotImplementedException();
        }

        public void EndGame()
        {
            throw new NotImplementedException();
        }

        public void GetBonus(Soldier soldier)
        {
            throw new NotImplementedException();
        }

        public void GetCoin(Players player)
        {
            throw new NotImplementedException();
        }

        public void LoadGameState()
        {
            throw new NotImplementedException();
        }

        public void MoveSelector(int y)
        {
            throw new NotImplementedException();
        }

        public void MoveSoldier(Soldier soldier)
        {
            throw new NotImplementedException();
        }

        public void NewCharacter(Characters character, Players player, int y)
        {
            throw new NotImplementedException();
        }

        public void SaveGameState()
        {
            throw new NotImplementedException();
        }

        public void StartGame()
        {
            throw new NotImplementedException();
        }

        public void UpdateCharacter(Characters character)
        {
            throw new NotImplementedException();
        }
    }
}
