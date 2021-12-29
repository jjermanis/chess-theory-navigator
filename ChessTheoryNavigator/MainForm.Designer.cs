namespace ChessTheoryNavigator
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonWhite = new System.Windows.Forms.Button();
            this.buttonBlack = new System.Windows.Forms.Button();
            this.groupBoxWhite = new System.Windows.Forms.GroupBox();
            this.addWhiteText = new System.Windows.Forms.TextBox();
            this.addWhiteButton = new System.Windows.Forms.Button();
            this.moveWhite = new System.Windows.Forms.Button();
            this.listBoxWhite = new System.Windows.Forms.ListBox();
            this.groupBoxBlack = new System.Windows.Forms.GroupBox();
            this.addBlackText = new System.Windows.Forms.TextBox();
            this.addBlackButton = new System.Windows.Forms.Button();
            this.moveBlack = new System.Windows.Forms.Button();
            this.listBoxBlack = new System.Windows.Forms.ListBox();
            this.saveBookButton = new System.Windows.Forms.Button();
            this.notesText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textAlgebraicNotation = new System.Windows.Forms.TextBox();
            this.buttonPreviewAN = new System.Windows.Forms.Button();
            this.buttonImportAN = new System.Windows.Forms.Button();
            this.labelGame = new System.Windows.Forms.Label();
            this.groupBoxWhite.SuspendLayout();
            this.groupBoxBlack.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonWhite
            // 
            this.buttonWhite.Location = new System.Drawing.Point(13, 13);
            this.buttonWhite.Name = "buttonWhite";
            this.buttonWhite.Size = new System.Drawing.Size(75, 23);
            this.buttonWhite.TabIndex = 0;
            this.buttonWhite.Text = "White";
            this.buttonWhite.UseVisualStyleBackColor = true;
            this.buttonWhite.Click += new System.EventHandler(this.buttonWhite_Click);
            // 
            // buttonBlack
            // 
            this.buttonBlack.Location = new System.Drawing.Point(95, 12);
            this.buttonBlack.Name = "buttonBlack";
            this.buttonBlack.Size = new System.Drawing.Size(75, 23);
            this.buttonBlack.TabIndex = 1;
            this.buttonBlack.Text = "Black";
            this.buttonBlack.UseVisualStyleBackColor = true;
            this.buttonBlack.Click += new System.EventHandler(this.buttonBlack_Click);
            // 
            // groupBoxWhite
            // 
            this.groupBoxWhite.Controls.Add(this.addWhiteText);
            this.groupBoxWhite.Controls.Add(this.addWhiteButton);
            this.groupBoxWhite.Controls.Add(this.moveWhite);
            this.groupBoxWhite.Controls.Add(this.listBoxWhite);
            this.groupBoxWhite.Location = new System.Drawing.Point(16, 54);
            this.groupBoxWhite.Name = "groupBoxWhite";
            this.groupBoxWhite.Size = new System.Drawing.Size(247, 324);
            this.groupBoxWhite.TabIndex = 2;
            this.groupBoxWhite.TabStop = false;
            this.groupBoxWhite.Text = "White";
            // 
            // addWhiteText
            // 
            this.addWhiteText.Location = new System.Drawing.Point(99, 291);
            this.addWhiteText.Name = "addWhiteText";
            this.addWhiteText.Size = new System.Drawing.Size(137, 23);
            this.addWhiteText.TabIndex = 5;
            // 
            // addWhiteButton
            // 
            this.addWhiteButton.Enabled = false;
            this.addWhiteButton.Location = new System.Drawing.Point(11, 292);
            this.addWhiteButton.Name = "addWhiteButton";
            this.addWhiteButton.Size = new System.Drawing.Size(75, 23);
            this.addWhiteButton.TabIndex = 4;
            this.addWhiteButton.Text = "Add";
            this.addWhiteButton.UseVisualStyleBackColor = true;
            this.addWhiteButton.Click += new System.EventHandler(this.addWhiteButton_Click);
            // 
            // moveWhite
            // 
            this.moveWhite.Enabled = false;
            this.moveWhite.Location = new System.Drawing.Point(11, 263);
            this.moveWhite.Name = "moveWhite";
            this.moveWhite.Size = new System.Drawing.Size(75, 23);
            this.moveWhite.TabIndex = 3;
            this.moveWhite.Text = "Move";
            this.moveWhite.UseVisualStyleBackColor = true;
            this.moveWhite.Click += new System.EventHandler(this.moveWhite_Click);
            // 
            // listBoxWhite
            // 
            this.listBoxWhite.Enabled = false;
            this.listBoxWhite.FormattingEnabled = true;
            this.listBoxWhite.ItemHeight = 15;
            this.listBoxWhite.Location = new System.Drawing.Point(11, 27);
            this.listBoxWhite.Name = "listBoxWhite";
            this.listBoxWhite.Size = new System.Drawing.Size(226, 214);
            this.listBoxWhite.TabIndex = 0;
            this.listBoxWhite.SelectedIndexChanged += new System.EventHandler(this.listBoxWhite_SelectedIndexChanged);
            this.listBoxWhite.DoubleClick += new System.EventHandler(this.listBoxWhite_DoubleClick);
            // 
            // groupBoxBlack
            // 
            this.groupBoxBlack.Controls.Add(this.addBlackText);
            this.groupBoxBlack.Controls.Add(this.addBlackButton);
            this.groupBoxBlack.Controls.Add(this.moveBlack);
            this.groupBoxBlack.Controls.Add(this.listBoxBlack);
            this.groupBoxBlack.Location = new System.Drawing.Point(281, 54);
            this.groupBoxBlack.Name = "groupBoxBlack";
            this.groupBoxBlack.Size = new System.Drawing.Size(247, 324);
            this.groupBoxBlack.TabIndex = 3;
            this.groupBoxBlack.TabStop = false;
            this.groupBoxBlack.Text = "Black";
            // 
            // addBlackText
            // 
            this.addBlackText.Location = new System.Drawing.Point(100, 291);
            this.addBlackText.Name = "addBlackText";
            this.addBlackText.Size = new System.Drawing.Size(137, 23);
            this.addBlackText.TabIndex = 6;
            // 
            // addBlackButton
            // 
            this.addBlackButton.Enabled = false;
            this.addBlackButton.Location = new System.Drawing.Point(11, 292);
            this.addBlackButton.Name = "addBlackButton";
            this.addBlackButton.Size = new System.Drawing.Size(75, 23);
            this.addBlackButton.TabIndex = 6;
            this.addBlackButton.Text = "Add";
            this.addBlackButton.UseVisualStyleBackColor = true;
            this.addBlackButton.Click += new System.EventHandler(this.addBlackButton_Click);
            // 
            // moveBlack
            // 
            this.moveBlack.Enabled = false;
            this.moveBlack.Location = new System.Drawing.Point(11, 263);
            this.moveBlack.Name = "moveBlack";
            this.moveBlack.Size = new System.Drawing.Size(75, 23);
            this.moveBlack.TabIndex = 3;
            this.moveBlack.Text = "Move";
            this.moveBlack.UseVisualStyleBackColor = true;
            this.moveBlack.Click += new System.EventHandler(this.moveBlack_Click);
            // 
            // listBoxBlack
            // 
            this.listBoxBlack.Enabled = false;
            this.listBoxBlack.FormattingEnabled = true;
            this.listBoxBlack.ItemHeight = 15;
            this.listBoxBlack.Location = new System.Drawing.Point(11, 27);
            this.listBoxBlack.Name = "listBoxBlack";
            this.listBoxBlack.Size = new System.Drawing.Size(226, 214);
            this.listBoxBlack.TabIndex = 0;
            this.listBoxBlack.SelectedIndexChanged += new System.EventHandler(this.listBoxBlack_SelectedIndexChanged);
            this.listBoxBlack.DoubleClick += new System.EventHandler(this.listBoxBlack_DoubleClick);
            // 
            // saveBookButton
            // 
            this.saveBookButton.Location = new System.Drawing.Point(779, 490);
            this.saveBookButton.Name = "saveBookButton";
            this.saveBookButton.Size = new System.Drawing.Size(75, 23);
            this.saveBookButton.TabIndex = 4;
            this.saveBookButton.Text = "Save Book";
            this.saveBookButton.UseVisualStyleBackColor = true;
            this.saveBookButton.Click += new System.EventHandler(this.saveBookButton_Click);
            // 
            // notesText
            // 
            this.notesText.Location = new System.Drawing.Point(547, 81);
            this.notesText.Multiline = true;
            this.notesText.Name = "notesText";
            this.notesText.ReadOnly = true;
            this.notesText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.notesText.Size = new System.Drawing.Size(307, 259);
            this.notesText.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 429);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Game Notation:";
            // 
            // textAlgebraicNotation
            // 
            this.textAlgebraicNotation.Location = new System.Drawing.Point(112, 429);
            this.textAlgebraicNotation.Name = "textAlgebraicNotation";
            this.textAlgebraicNotation.Size = new System.Drawing.Size(415, 23);
            this.textAlgebraicNotation.TabIndex = 7;
            this.textAlgebraicNotation.TextChanged += new System.EventHandler(this.textAlgebraicNotation_TextChanged);
            // 
            // buttonPreviewAN
            // 
            this.buttonPreviewAN.Enabled = false;
            this.buttonPreviewAN.Location = new System.Drawing.Point(22, 472);
            this.buttonPreviewAN.Name = "buttonPreviewAN";
            this.buttonPreviewAN.Size = new System.Drawing.Size(93, 29);
            this.buttonPreviewAN.TabIndex = 8;
            this.buttonPreviewAN.Text = "Preview AN";
            this.buttonPreviewAN.UseVisualStyleBackColor = true;
            this.buttonPreviewAN.Click += new System.EventHandler(this.buttonPreviewAN_Click);
            // 
            // buttonImportAN
            // 
            this.buttonImportAN.Enabled = false;
            this.buttonImportAN.Location = new System.Drawing.Point(121, 472);
            this.buttonImportAN.Name = "buttonImportAN";
            this.buttonImportAN.Size = new System.Drawing.Size(93, 29);
            this.buttonImportAN.TabIndex = 9;
            this.buttonImportAN.Text = "Import AN";
            this.buttonImportAN.UseVisualStyleBackColor = true;
            this.buttonImportAN.Click += new System.EventHandler(this.buttonImportAN_Click);
            // 
            // labelGame
            // 
            this.labelGame.AutoSize = true;
            this.labelGame.Location = new System.Drawing.Point(17, 388);
            this.labelGame.Name = "labelGame";
            this.labelGame.Size = new System.Drawing.Size(0, 15);
            this.labelGame.TabIndex = 10;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 525);
            this.Controls.Add(this.labelGame);
            this.Controls.Add(this.buttonImportAN);
            this.Controls.Add(this.buttonPreviewAN);
            this.Controls.Add(this.textAlgebraicNotation);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.notesText);
            this.Controls.Add(this.saveBookButton);
            this.Controls.Add(this.groupBoxBlack);
            this.Controls.Add(this.groupBoxWhite);
            this.Controls.Add(this.buttonBlack);
            this.Controls.Add(this.buttonWhite);
            this.Name = "MainForm";
            this.Text = "Chess Theory Navigator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBoxWhite.ResumeLayout(false);
            this.groupBoxWhite.PerformLayout();
            this.groupBoxBlack.ResumeLayout(false);
            this.groupBoxBlack.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonWhite;
        private System.Windows.Forms.Button buttonBlack;
        private System.Windows.Forms.GroupBox groupBoxWhite;
        private System.Windows.Forms.Button moveWhite;
        private System.Windows.Forms.ListBox listBoxWhite;
        private System.Windows.Forms.GroupBox groupBoxBlack;
        private System.Windows.Forms.Button moveBlack;
        private System.Windows.Forms.ListBox listBoxBlack;
        private System.Windows.Forms.Button saveBookButton;
        private System.Windows.Forms.TextBox addWhiteText;
        private System.Windows.Forms.Button addWhiteButton;
        private System.Windows.Forms.TextBox addBlackText;
        private System.Windows.Forms.Button addBlackButton;
        private System.Windows.Forms.TextBox notesText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textAlgebraicNotation;
        private System.Windows.Forms.Button buttonPreviewAN;
        private System.Windows.Forms.Button buttonImportAN;
        private System.Windows.Forms.Label labelGame;
    }
}

