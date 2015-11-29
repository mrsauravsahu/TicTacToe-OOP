using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    interface Input
    {
        int Input();
        void Input(ref Board board, int position, Player player);
    }
}
