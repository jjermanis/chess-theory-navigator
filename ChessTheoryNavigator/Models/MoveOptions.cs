using ChessTheoryNavigator.Enums;
using System;
using System.Collections.Generic;

namespace ChessTheoryNavigator.Models
{
    public class MoveOptions
    {
        public Guid Board { get; set; }
        public Color Color { get; set; }
        public List<MoveState> Moves { get; set; }
    }
}