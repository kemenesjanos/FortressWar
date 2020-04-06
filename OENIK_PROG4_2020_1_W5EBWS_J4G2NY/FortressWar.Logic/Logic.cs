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

        Model model;
        Random rnd = new Random();

        public Logic(Model model)
        {
            this.model = model;
        }

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

        /// <summary>
        /// Add random money to a player.
        /// </summary>
        /// <param name="player">The player who gets the money.</param>
        public void GetCoin(Players player)
        {
            int c = this.rnd.Next(Config.MinCoin, Config.MaxCoin + 1);
            if (player == Players.Player1)
            {
                this.model.Money_1 += c;
            }
            else
            {
                this.model.Money_2 += c;
            }
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

        public void UpdateCharacter(Characters character, Players players)
        {
            throw new NotImplementedException();
        }
    }
}
