using System;
using System.Collections.Generic;

namespace Checkers.Models
{
    public partial class Board
    {
        public int Id { get; set; }
        public string? Boardspaces { get; set; }

        //Default constructor must be left in place to avoid entity framework errors
        public Board()
        { }

        public Board(int id, string boardSpaces)
        {
            Id = id;
            Boardspaces = boardSpaces;
        }
    }
}
