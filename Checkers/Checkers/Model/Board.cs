using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Checkers.Model
{
    public class Board
    {
        public Player[,] _map;

        public int Width => _map.GetLength(0);
        public int Height => _map.GetLength(1);

        private static readonly string[] defaultBoard = new[]
        {
            "______0______",
            "_____00_____",
            "_____000_____",
            "____0000____",
            "0000000000000",
            "000000000000",
            "_00000000000_",
            "_0000000000_",
            "__000000000__",
            "_0000000000_",
            "_00000000000_",
            "000000000000",
            "0000000000000",
            "____0000____",
            "_____000_____",
            "_____00_____",
            "______0______",
        };

        public Board()
        {
            _map = new Player[13, 17];

            for (int y = 0; y < Height; y++)
            {
                string line = defaultBoard[y];

                using StringReader lineReader = new StringReader(line);

                for (int x = 0; x < Width; x++)
                {
                    int c = lineReader.Read();

                    if(c == -1)
                    {
                        _map[x, y] = Player.Blocked;
                        continue;
                    }

                    char spot = (char)c;

                    _map[x, y] = spot == '0' ? Player.Empty : Player.Blocked;
                }
            }
        }

        private bool IsShiftedRow(int y) => y % 2 == 1;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(_map.GetLength(0) * _map.GetLength(1) * 2);

            for (int y = 0; y < Height; y++)
            {
                if (IsShiftedRow(y))
                    sb.Append(' ');

                for (int x = 0; x < Width; x++)
                {
                    sb.Append(_map[x, y] == Player.Blocked ? '_' : 'O');
                    sb.Append(' ');
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
