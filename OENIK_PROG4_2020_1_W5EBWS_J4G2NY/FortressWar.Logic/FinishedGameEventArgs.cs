namespace FortressWar.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class FinishedGameEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets a winnerName.
        /// </summary>
        public string WinnerName { get; set; }
    }
}
