using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Game
{
    public enum LastMoveStatus
    {
        Accepted,
        InvalidCordinates,
        PositionOccupied,
        NoPlay,  
        Skipped
    }
}
