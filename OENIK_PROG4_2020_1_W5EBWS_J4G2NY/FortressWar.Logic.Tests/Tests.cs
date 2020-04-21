// <copyright file="Tests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FortressWar.Logic.Tests
{
    using FortressWar.Model;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Tests for the logic.
    /// </summary>
    [TestFixture]
    public class Tests
    {
        Model model;
        Logic logic;

        [OneTimeSetUp]
        public void Init()
        {
            this.model = new Model();
            this.logic = new Logic(this.model);
        }

        [Test]
        public void TestAttack()
        {

            

        }

        public void TestDie()
        {
            throw new NotImplementedException();
        }

        public void TestEndGame()
        {
            throw new NotImplementedException();
        }

        public void TestGetPotion()
        {
            throw new NotImplementedException();
        }

        public void TestLoadGameState()
        {
            throw new NotImplementedException();
        }

        public void TestMoveSelector()
        {
            throw new NotImplementedException();
        }

        public void TestMoveSoldier()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void TestNewCharacter()
        {
            this.logic.NewCharacter(Characters.Knight, this.model.Player_1, 6);
            Assert.IsEmpty(this.model.Player_1.Soldiers);
            this.logic.NewCharacter(Characters.Knight, this.model.Player_1, 4);
            Assert.IsNotEmpty(this.model.Player_1.Soldiers);
            Assert.That(this.model.Player_1.Soldiers.FirstOrDefault().LVL ==
                this.model.Player_1.KnightLVL);
            Assert.IsNull(this.model.Player_1.Soldiers.FirstOrDefault().Enemy);

            this.logic.NewCharacter(Characters.Rider, this.model.Player_1, 3);
            Assert.That(this.model.Player_1.Soldiers.Count == 2);

            this.logic.NewCharacter(Characters.Barricade, this.model.Player_1, 0);
            Assert.IsNotNull(this.model.Player_1.Barricades.FirstOrDefault());
            double tx = this.model.Player_1.Barricades.LastOrDefault().CX;
            this.logic.NewCharacter(Characters.Barricade, this.model.Player_1, 0);
            Assert.That(this.model.Player_1.Barricades.LastOrDefault().CX != tx);
            Assert.That(this.model.Player_1.Barricades.LastOrDefault().CX ==
                tx + Config.CharacterTileWidth);

            for (int i = 0; i < 10; i++)
            {
                this.logic.NewCharacter(Characters.Barricade, this.model.Player_1, 0);
                Assert.That(this.model.Player_1.Barricades.LastOrDefault().CX < Config.FieldWidht / 2);
                tx = this.model.Player_1.Barricades.LastOrDefault().CX;
            }
        }

        [Test]
        public void TestNewExtra()
        {
            this.logic.NewExtra(Extras.Coin);

            Assert.IsNotEmpty(this.model.Coins);
            Assert.That(this.model.Coins.FirstOrDefault().Bounty != 0);
            Assert.That(this.model.Coins.FirstOrDefault().Life == 1);

            this.logic.NewExtra(Extras.Potion);
            Assert.IsNotEmpty(this.model.Potions);
        }

        public void TestSaveGameState()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void TestStartGame()
        {
            this.logic.StartGame();
            Assert.NotNull(this.model.Player_1.Fortress);
            Assert.NotNull(this.model.Player_2.Fortress);

            Assert.That(this.model.Player_1.Fortress.CX == -Config.FieldWidht / 2);
            Assert.That(this.model.Player_1.Fortress.Owner == this.model.Player_1);
            Assert.That(this.model.Player_1.Fortress.Life == Config.FortressBaseLife);
        }

        public void TestUpdateCharacter()
        {
            throw new NotImplementedException();
        }
    }
}
