using System;

namespace ChessTheoryNavigator.Models
{
    public class MoveState
    {
        public Guid StartBoard { get; set; }
        public string Move { get; set; }
        public Guid EndBoard { get; set; }
    }
}