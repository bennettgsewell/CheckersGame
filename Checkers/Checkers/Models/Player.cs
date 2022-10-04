using System;
using System.Collections.Generic;

namespace Checkers.Models
{
    public partial class Player
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public bool? Isturn { get; set; }

        //Default constructor must be left in place to avoid entity framework errors
        public Player()
        { }

        public Player(int id, string name, bool isTurn)
        {
            Id = id;
            Name = name;
            Isturn = isTurn;
        }
    }
}
