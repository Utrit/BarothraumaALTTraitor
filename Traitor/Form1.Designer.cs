namespace Traitor
{
    partial class Window
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.PlayersCheckList = new System.Windows.Forms.CheckedListBox();
            this.SelectedLabel = new System.Windows.Forms.Label();
            this.PlayerNameInput = new System.Windows.Forms.TextBox();
            this.RandomButton = new System.Windows.Forms.Button();
            this.SeedTextBox = new System.Windows.Forms.TextBox();
            this.RandomSeed = new System.Windows.Forms.Button();
            this.QuestRichTextBox = new System.Windows.Forms.RichTextBox();
            this.VersionLabel = new System.Windows.Forms.Label();
            this.InsertRandom = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PlayersCheckList
            // 
            this.PlayersCheckList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PlayersCheckList.FormattingEnabled = true;
            this.PlayersCheckList.Location = new System.Drawing.Point(2, 28);
            this.PlayersCheckList.Name = "PlayersCheckList";
            this.PlayersCheckList.Size = new System.Drawing.Size(117, 169);
            this.PlayersCheckList.TabIndex = 0;
            this.PlayersCheckList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Checklist_MouseUp);
            // 
            // SelectedLabel
            // 
            this.SelectedLabel.AutoSize = true;
            this.SelectedLabel.Location = new System.Drawing.Point(125, 12);
            this.SelectedLabel.Name = "SelectedLabel";
            this.SelectedLabel.Size = new System.Drawing.Size(33, 13);
            this.SelectedLabel.TabIndex = 1;
            this.SelectedLabel.Text = "None";
            // 
            // PlayerNameInput
            // 
            this.PlayerNameInput.Location = new System.Drawing.Point(2, 9);
            this.PlayerNameInput.Name = "PlayerNameInput";
            this.PlayerNameInput.Size = new System.Drawing.Size(117, 20);
            this.PlayerNameInput.TabIndex = 2;
            this.PlayerNameInput.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBox1_KeyUp);
            // 
            // RandomButton
            // 
            this.RandomButton.Location = new System.Drawing.Point(196, 4);
            this.RandomButton.Name = "RandomButton";
            this.RandomButton.Size = new System.Drawing.Size(75, 23);
            this.RandomButton.TabIndex = 3;
            this.RandomButton.Text = "Рандомить";
            this.RandomButton.UseVisualStyleBackColor = true;
            this.RandomButton.Click += new System.EventHandler(this.RandomButton_Click);
            // 
            // SeedTextBox
            // 
            this.SeedTextBox.Location = new System.Drawing.Point(277, 6);
            this.SeedTextBox.Name = "SeedTextBox";
            this.SeedTextBox.Size = new System.Drawing.Size(100, 20);
            this.SeedTextBox.TabIndex = 4;
            this.SeedTextBox.Text = "Seed";
            // 
            // RandomSeed
            // 
            this.RandomSeed.Location = new System.Drawing.Point(383, 4);
            this.RandomSeed.Name = "RandomSeed";
            this.RandomSeed.Size = new System.Drawing.Size(21, 21);
            this.RandomSeed.TabIndex = 5;
            this.RandomSeed.Text = "R";
            this.RandomSeed.UseVisualStyleBackColor = true;
            this.RandomSeed.Click += new System.EventHandler(this.RandomSeed_Click);
            // 
            // QuestRichTextBox
            // 
            this.QuestRichTextBox.BackColor = System.Drawing.Color.LightGray;
            this.QuestRichTextBox.DetectUrls = false;
            this.QuestRichTextBox.Location = new System.Drawing.Point(196, 33);
            this.QuestRichTextBox.Name = "QuestRichTextBox";
            this.QuestRichTextBox.ReadOnly = true;
            this.QuestRichTextBox.Size = new System.Drawing.Size(350, 160);
            this.QuestRichTextBox.TabIndex = 6;
            this.QuestRichTextBox.Text = "";
            // 
            // VersionLabel
            // 
            this.VersionLabel.AutoSize = true;
            this.VersionLabel.Location = new System.Drawing.Point(437, 12);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(42, 13);
            this.VersionLabel.TabIndex = 7;
            this.VersionLabel.Text = "Version";
            // 
            // InsertRandom
            // 
            this.InsertRandom.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InsertRandom.Location = new System.Drawing.Point(410, 4);
            this.InsertRandom.Name = "InsertRandom";
            this.InsertRandom.Size = new System.Drawing.Size(21, 21);
            this.InsertRandom.TabIndex = 8;
            this.InsertRandom.Text = "I";
            this.InsertRandom.UseVisualStyleBackColor = true;
            this.InsertRandom.Click += new System.EventHandler(this.InsertRandom_Click);
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 200);
            this.Controls.Add(this.InsertRandom);
            this.Controls.Add(this.VersionLabel);
            this.Controls.Add(this.QuestRichTextBox);
            this.Controls.Add(this.RandomSeed);
            this.Controls.Add(this.SeedTextBox);
            this.Controls.Add(this.RandomButton);
            this.Controls.Add(this.PlayerNameInput);
            this.Controls.Add(this.SelectedLabel);
            this.Controls.Add(this.PlayersCheckList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Window";
            this.Text = "Traitor";
            this.Load += new System.EventHandler(this.Window_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox PlayersCheckList;
        private System.Windows.Forms.Label SelectedLabel;
        private System.Windows.Forms.TextBox PlayerNameInput;
        private System.Windows.Forms.Button RandomButton;
        private System.Windows.Forms.TextBox SeedTextBox;
        private System.Windows.Forms.Button RandomSeed;
        private System.Windows.Forms.RichTextBox QuestRichTextBox;
        private System.Windows.Forms.Label VersionLabel;
        private System.Windows.Forms.Button InsertRandom;
    }
}

