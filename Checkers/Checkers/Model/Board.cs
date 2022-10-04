using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Checkers.Model
{
    public class Board
    {
        public Player[][] _map;

        public int Width => _map[0].Length;
        public int Height => _map.Length;

        private static readonly string[] defaultBoard = new[]
        {
            "______0",
            "_____00",
            "_____000",
            "____0000",
            "0000000000000",
            "000000000000",
            "_00000000000",
            "_0000000000",
            "__000000000",
            "_0000000000",
            "_00000000000",
            "000000000000",
            "0000000000000",
            "____0000",
            "_____000",
            "_____00",
            "______0",
        };

        public Board()
        {
            _map = new Player[17][];
            for (int y = 0; y < _map.Length; y++)
                _map[y] = new Player[13];

            for (int y = 0; y < Height; y++)
            {
                string line = defaultBoard[y];

                using StringReader lineReader = new StringReader(line);

                for (int x = 0; x < Width; x++)
                {
                    int c = lineReader.Read();

                    if (c == -1)
                    {
                        SetPlayer(x, y, Player.Blocked);
                        continue;
                    }

                    char spot = (char)c;

                    SetPlayer(x, y, spot == '0' ? Player.Empty : Player.Blocked);
                }
            }
        }

        private void SetPlayer(int x, int y, Player p) => _map[y][x] = p;

        private Player GetPlayer(int x, int y) => _map[y][x];

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
                    sb.Append(GetPlayer(x, y) == Player.Blocked ? '_' : 'O');
                    sb.Append(' ');
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
