using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortressWar.Model
{
    public class Player
    {
        public string Name { get; set; }
        public int Money { get; set; }
        public Fortress Fortress { get; set; }
        public int RiderLVL { get; set; }
        public int KnightLVL { get; set; }
        public int BarricadeLVL { get; set; }
    }
}
