using System;
using System.Collections.Generic;
using System.Text.Json;

namespace ChessTheoryNavigator.Models
{
    internal class SavedBook
    {
        public BookInfo BookInfo { get; set; }
        public List<MoveOptions> WhiteGameMoves { get; set; }
        public List<MoveOptions> BlackGameMoves { get; set; }

        public SavedBook()
        {
        }

        public SavedBook(MoveBook book)
        {
            BookInfo = new BookInfo()
            {
                Version = "1"
            };

            WhiteGameMoves = BuildListFromBook(book.PlayerWhite);
            BlackGameMoves = BuildListFromBook(book.PlayerBlack);
        }

        public SavedBook(string bookJson)
        {
            var fromJson = JsonSerializer.Deserialize<SavedBook>(bookJson);
            this.BookInfo = fromJson.BookInfo;
            this.WhiteGameMoves = fromJson.WhiteGameMoves;
            this.BlackGameMoves = fromJson.BlackGameMoves;
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }

        private List<MoveOptions> BuildListFromBook(
            IDictionary<Guid, MoveOptions> book)
        {
            var result = new List<MoveOptions>();

            foreach (var board in book.Values)
            {
                result.Add(board);
            }
            return result;
        }
    }
}