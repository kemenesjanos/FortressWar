using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortressWar.Logic
{
    interface ILogic
    {
        enum characters { Infantry, Rider, Barricade, Fortress }
        enum players { player1, player2 }

        event EventHandler RefreshScreen;

        //movement
        void MoveSoldier(Soldier soldier);
        bool Attack(Character AttackedCharacter, int Damage);
        void MoveSelector(int y);

        //Create Character
        void NewCharacter(characters character, players player, int y);
        void Die(Character character);

        //Window things
        void StartGame();
        void EndGame();

        //extras
        void GetExtra(Soldier soldier);

        //Money
        void GetCoin(players player);

        //Update
        void UpdateCharacter(characters character);
    }
}
