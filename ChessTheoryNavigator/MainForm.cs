﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ChessTheoryNavigator.Models;

namespace ChessTheoryNavigator
{
    public partial class MainForm : Form
    { 
        public MoveBook MoveBook { get; set; }
        public Enums.Color PlayerColor { get; set; }
        public Guid CurrentBoard { get; set; }
        public Enums.Color CurrentTurn { get; set; }
        public List<string> Moves { get; set; }

        public List<string> ImportedGame { get; set; }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            MoveBook = new MoveBook();
            MoveBook.Load();
            SetWhiteActive(false);
            SetBlackActive(false);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MoveBook.IsDirty && 
                Prompt("Save?", "Changes have been made to the book. Would like to save?"))
                MoveBook.Save();
        }

        private void buttonWhite_Click(object sender, EventArgs e)
        {
            PlayerColor = Enums.Color.White;
            ResetGame();
        }

        private void buttonBlack_Click(object sender, EventArgs e)
        {
            PlayerColor = Enums.Color.Black;
            ResetGame();
        }

        private void ResetGame()
        {
            notesText.Text = "";
            listBoxWhite.Items.Clear();
            listBoxBlack.Items.Clear();
            addWhiteText.Text = "";
            addBlackText.Text = "";
            labelGame.Text = "";

            CurrentTurn = Enums.Color.White;
            CurrentBoard = MoveBook.START_BOARD;
            Moves = new List<string>();
            UpdateAfterMove();
        }

        private void UpdateAfterMove()
        {
            notesText.AppendText($"{CurrentBoard}\r\n");
            var isWhiteEnabled = CurrentTurn == Enums.Color.White;

            SetWhiteActive(isWhiteEnabled);
            SetBlackActive(!isWhiteEnabled);

            var movesList = isWhiteEnabled ? listBoxWhite : listBoxBlack;
            movesList.Items.Clear();

            var legalMoves = MoveBook.GetLegalMoves(CurrentBoard, PlayerColor);
            if (legalMoves.Any())
            {
                foreach (var legalMove in legalMoves)
                    movesList.Items.Add(legalMove);
            }
            else
            {
                notesText.AppendText("End of book\r\n");
            }
        }

        private void SetWhiteActive(bool isActive)
        {
            this.listBoxWhite.Enabled = isActive;
            this.moveWhite.Enabled = false;
            this.addWhiteButton.Enabled = isActive;
            this.addWhiteText.Enabled = isActive;
        }

        private void SetBlackActive(bool isActive)
        {
            this.listBoxBlack.Enabled = isActive;
            this.moveBlack.Enabled = false;
            this.addBlackButton.Enabled = isActive;
            this.addBlackText.Enabled = isActive;
        }

        private void saveBookButton_Click(object sender, EventArgs e)
        {
            MoveBook.Save();
        }

        private void addWhiteButton_Click(object sender, EventArgs e)
        {
            AddMove(addWhiteText.Text);
        }

        private void AddMove(string text)
        {
            var move = text.Trim();
            if (String.IsNullOrEmpty(move))
            {
                AlertEmptyMove();
                return;
            }
            if (MoveBook.DoesMoveExist(move, CurrentBoard, PlayerColor))
            {
                AlertDuplicateMove();
                return;
            }

            MoveBook.AddMove(move, CurrentBoard, PlayerColor);

            var textField = CurrentTurn == Enums.Color.White ? addWhiteText : addBlackText;
            textField.Text = "";
            var listBox = CurrentTurn == Enums.Color.White ? listBoxWhite : listBoxBlack;
            listBox.Items.Add(move);
        }

        private static void AlertEmptyMove() =>
            Alert("Error", "No move entered");

        private static void AlertDuplicateMove() =>
            Alert("Error", "Move already in book");

        private static void Alert(string caption, string message)
        {
            var buttons = MessageBoxButtons.OK;
            MessageBox.Show(message, caption, buttons);
        }

        private static bool Prompt(string caption, string message)
        {
            var buttons = MessageBoxButtons.YesNo;
            var result = MessageBox.Show(message, caption, buttons);

            return result switch
            {
                DialogResult.Yes => true,
                DialogResult.No => false,
                _ => throw new Exception($"Unexpected dialog result: {result}")
            };
        }

        private void addBlackButton_Click(object sender, EventArgs e)
        {
            AddMove(addBlackText.Text);
        }

        private void moveWhite_Click(object sender, EventArgs e)
        {
            if (listBoxWhite.SelectedItem != null)
                MakeMove(listBoxWhite.SelectedItem.ToString());
        }

        private void listBoxWhite_DoubleClick(object sender, EventArgs e)
        {
            if (listBoxWhite.SelectedItem != null)
                MakeMove(listBoxWhite.SelectedItem.ToString());
        }

        private void moveBlack_Click(object sender, EventArgs e)
        {
            if (listBoxBlack.SelectedItem != null)
                MakeMove(listBoxBlack.SelectedItem.ToString());
        }

        private void listBoxBlack_DoubleClick(object sender, EventArgs e)
        {
            if (listBoxBlack.SelectedItem != null)
                MakeMove(listBoxBlack.SelectedItem.ToString());
        }

        private void MakeMove(string move)
        {
            UpdateGameHistory(move);

            var nextBoard = MoveBook.MakeMove(move, CurrentBoard, PlayerColor);

            CurrentBoard = nextBoard;
            CurrentTurn = CurrentTurn == Enums.Color.White ? Enums.Color.Black : Enums.Color.White;

            UpdateAfterMove();
        }

        private void UpdateGameHistory(string move)
        {
            Moves.Add(move);

            var sb = new StringBuilder();
            for (int i=0; i<Moves.Count; i+= 2)
            {
                sb.Append($"{(i/2)+1}.");
                sb.Append($"{Moves[i]} ");
                if (i + 1 < Moves.Count)
                    sb.Append($"{Moves[i + 1]} ");
            }
            labelGame.Text = sb.ToString();
        }

        private void listBoxWhite_SelectedIndexChanged(object sender, EventArgs e)
        {
            moveWhite.Enabled = true;
        }

        private void listBoxBlack_SelectedIndexChanged(object sender, EventArgs e)
        {
            moveBlack.Enabled = true;
        }

        private void buttonPreviewAN_Click(object sender, EventArgs e)
        {
            ImportedGame = MoveBook.ImportAlegbraicNotation(textAlgebraicNotation.Text);

            notesText.Text += "Algebraic Notation:\r\n";
            for (var x=0; x < ImportedGame.Count; x+=2)
            {
                notesText.Text += $"{ImportedGame[x]}, {ImportedGame[x + 1]}\r\n";
            }

            buttonImportAN.Enabled = true;
        }

        private void buttonImportAN_Click(object sender, EventArgs e)
        {
            var result = MoveBook.ApplyImportedGame(ImportedGame, PlayerColor);
            notesText.Text += $"Import complete.  {result.Moves} moves, {result.NewMoves} moves added\r\n";
            buttonPreviewAN.Enabled = false;
            buttonImportAN.Enabled = false;
            textAlgebraicNotation.Text = "";
        }

        private void textAlgebraicNotation_TextChanged(object sender, EventArgs e)
        {
            buttonPreviewAN.Enabled = !String.IsNullOrWhiteSpace(textAlgebraicNotation.Text);
        }
    }
}