using ChessTheoryNavigator.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace ChessTheoryNavigator
{
    public class MoveBook
    {
        private const string DEFAULT_FILE = @"..\..\..\..\book.json";

        public BookInfo BookInfo { get; set; }
        public Dictionary<Guid, MoveOptions> PlayerWhite { get; set; }
        public Dictionary<Guid, MoveOptions> PlayerBlack { get; set; }

        public MoveBook()
        {
            BookInfo = new BookInfo();
            PlayerWhite = new Dictionary<Guid, MoveOptions>();
            PlayerBlack = new Dictionary<Guid, MoveOptions>();
        }

        public void Load()
        {
            var json = File.ReadAllText(DEFAULT_FILE);

            var savedBook = new SavedBook(json);

            this.BookInfo = savedBook.BookInfo;

            foreach (var move in savedBook.WhiteGameMoves)
            {
                this.PlayerWhite[move.Board] = move;
            }
            foreach (var move in savedBook.BlackGameMoves)
            {
                this.PlayerBlack[move.Board] = move;
            }
        }

        public void Save()
        {
            var savedBook = new SavedBook(this);

            File.WriteAllText(DEFAULT_FILE, savedBook.ToString());
        }
    }
}