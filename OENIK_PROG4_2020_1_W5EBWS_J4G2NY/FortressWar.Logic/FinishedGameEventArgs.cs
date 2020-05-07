using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortressWar.Logic
{
    public class FinishedGameEventArgs : EventArgs
    {
        public string WinnerName { get; set; }
    }
}
