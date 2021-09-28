using System;
using System.Collections.Generic;
using System.IO;
using ChessTheoryNavigator.Enums;
using ChessTheoryNavigator.Models;

namespace ChessTheoryNavigator
{
    public class MoveBook
    {
        public readonly Guid START_BOARD = Guid.Empty;

        private const string DEFAULT_FILE = @"..\..\..\..\book.json";

        public bool IsDirty { get; set; }
        private BookInfo BookInfo { get; set; }
        private Dictionary<Guid, MoveOptions> PlayerWhite { get; set; }
        private Dictionary<Guid, MoveOptions> PlayerBlack { get; set; }

        public MoveBook()
        {
            IsDirty = false;
            BookInfo = new BookInfo();
            PlayerWhite = new Dictionary<Guid, MoveOptions>();
            PlayerBlack = new Dictionary<Guid, MoveOptions>();
        }

        public void Load()
        {
            IsDirty = false;

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
            var savedBook = new SavedBook(PlayerWhite, PlayerBlack);

            File.WriteAllText(DEFAULT_FILE, savedBook.ToString());

            IsDirty = false;
        }

        public void AddMove(
            string move,
            Guid board,
            Color playerColor)
        {
            var moveDictionary = GetMoveDictionary(playerColor);

            // Make sure board exists in dictionary
            if (!moveDictionary.ContainsKey(board))
            {
                var newOption = new MoveOptions()
                {
                    Board = board,
                    Color = playerColor,
                    Moves = new List<MoveState>()
                };
                moveDictionary[board] = newOption;
            }

            // Add the move
            var options = moveDictionary[board];
            var newMove = new MoveState()
            {
                StartBoard = board,
                Move = move.Trim(),
                EndBoard = Guid.NewGuid()
            };
            options.Moves.Add(newMove);
            IsDirty = true;
        }

        public List<string> GetLegalMoves(
            Guid board,
            Color playerColor)
        {
            var result = new List<string>();
            var moveDictionary = GetMoveDictionary(playerColor);
            if (moveDictionary.ContainsKey(board))
            {
                foreach (var move in moveDictionary[board].Moves)
                    result.Add(move.Move);

                result.Sort();
            }

            return result;
        }

        public bool DoesMoveExist(
            string move,
            Guid board,
            Color playerColor)
        {
            var processedMove = move.Trim();
            var legalMoves = GetLegalMoves(board, playerColor);
            foreach (var option in legalMoves)
                if (option.Equals(processedMove, StringComparison.OrdinalIgnoreCase))
                    return true;
            return false;
        }

        public Guid MakeMove(
            string move,
            Guid board,
            Color playerColor)
        {
            var moveDictionary = GetMoveDictionary(playerColor);
            var options = moveDictionary[board];

            foreach (var option in options.Moves)
                if (option.Move.Equals(move))
                    return option.EndBoard;
            throw new Exception($"Internal error: move {move} not found");
        }

        public List<string> ImportAlegbraicNotation(string game)
        {
            if (string.IsNullOrWhiteSpace(game))
                throw new Exception("No game specified");

            var result = new List<string>();

            var rawMoves = game.Split(null);
            foreach (var rawMove in rawMoves)
            {
                var currMoveTokens = rawMove.Split('.');
                var curr = currMoveTokens[currMoveTokens.Length - 1].Trim();
                if (!string.IsNullOrWhiteSpace(curr))
                    result.Add(curr);
            }
            return result;
        }

        public ApplyImportedGameResults ApplyImportedGame(
            List<string> moves,
            Color playerColor)
        {
            var result = new ApplyImportedGameResults();
            var board = START_BOARD;

            foreach(var move in moves)
            {
                if (!DoesMoveExist(move, board, playerColor))
                {
                    result.NewMoves++;
                    AddMove(move, board, playerColor);
                }
                result.Moves++;
                board = MakeMove(move, board, playerColor);
            }
            return result;
        }

        private Dictionary<Guid, MoveOptions> GetMoveDictionary(Color playerColor)
            => playerColor == Color.White ? PlayerWhite : PlayerBlack;
    }
}