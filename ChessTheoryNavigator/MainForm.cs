using ChessTheoryNavigator.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ChessTheoryNavigator
{
    public partial class MainForm : Form
    {
        private readonly Guid START_BOARD = Guid.Empty;

        public MoveBook MoveBook { get; set; }
        public Dictionary<Guid, MoveOptions> MoveDictionary { get; set; }
        public Enums.Color PlayerColor { get; set; }

        public Guid CurrentBoard { get; set; }
        public Enums.Color CurrentTurn { get; set; }

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

        private void buttonWhite_Click(object sender, EventArgs e)
        {
            PlayerColor = Enums.Color.White;
            MoveDictionary = MoveBook.PlayerWhite;
            ResetGame();
        }

        private void buttonBlack_Click(object sender, EventArgs e)
        {
            PlayerColor = Enums.Color.Black;
            MoveDictionary = MoveBook.PlayerBlack;
            ResetGame();
        }

        private void ResetGame()
        {
            notesText.Text = "";
            listBoxWhite.Items.Clear();
            listBoxBlack.Items.Clear();
            addWhiteText.Text = "";
            addBlackText.Text = "";

            CurrentTurn = Enums.Color.White;
            CurrentBoard = START_BOARD;
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

            if (MoveDictionary.ContainsKey(CurrentBoard))
            {
                var tempList = new List<string>();
                foreach (var move in MoveDictionary[CurrentBoard].Moves)
                {
                    tempList.Add(move.Move);
                }
                tempList.Sort();
                foreach (var entry in tempList)
                    movesList.Items.Add(entry);
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
            if (MoveDictionary.ContainsKey(CurrentBoard))
            {
                var options = MoveDictionary[CurrentBoard];
                foreach (var existingMove in options.Moves)
                {
                    if (existingMove.Move.Equals(move))
                    {
                        AlertDuplicateMove();
                        return;
                    }
                }
            }

            AddNewMove(move);
            var textField = CurrentTurn == Enums.Color.White ? addWhiteText : addBlackText;
            textField.Text = "";
            var listBox = CurrentTurn == Enums.Color.White ? listBoxWhite : listBoxBlack;
            listBox.Items.Add(move);
        }

        private void AlertEmptyMove() =>
            Alert("Error", "No move entered");

        private void AlertDuplicateMove() =>
            Alert("Error", "Move already in book");

        private void Alert(string caption, string message)
        {
            var buttons = MessageBoxButtons.OK;
            MessageBox.Show(message, caption, buttons);
        }

        private void addBlackButton_Click(object sender, EventArgs e)
        {
            AddMove(addBlackText.Text);
        }

        private void AddNewMove(string move)
        {
            if (!MoveDictionary.ContainsKey(CurrentBoard))
            {
                var newOption = new MoveOptions()
                {
                    Board = CurrentBoard,
                    Color = PlayerColor,
                    Moves = new List<MoveState>()
                };
                MoveDictionary[CurrentBoard] = newOption;
            }

            var options = MoveDictionary[CurrentBoard];
            var newMove = new MoveState()
            {
                StartBoard = CurrentBoard,
                Move = move,
                EndBoard = Guid.NewGuid()
            };
            options.Moves.Add(newMove);
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
            var nextBoard = NextBoard(MoveDictionary[CurrentBoard], move);

            CurrentBoard = nextBoard;
            CurrentTurn = CurrentTurn == Enums.Color.White ? Enums.Color.Black : Enums.Color.White;

            UpdateAfterMove();
        }

        private Guid NextBoard(MoveOptions options, string selectedMove)
        {
            foreach (var move in options.Moves)
                if (move.Move.Equals(selectedMove))
                    return move.EndBoard;
            throw new Exception("Internal error: move not found");
        }

        private void listBoxWhite_SelectedIndexChanged(object sender, EventArgs e)
        {
            moveWhite.Enabled = true;
        }

        private void listBoxBlack_SelectedIndexChanged(object sender, EventArgs e)
        {
            moveBlack.Enabled = true;
        }
    }
}