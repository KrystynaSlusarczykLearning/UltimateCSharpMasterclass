namespace FirstWinFormsApp
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
            this.CounterLabel = new System.Windows.Forms.Label();
            this.IncreaseCounterButton = new System.Windows.Forms.Button();
            this.HideButtonCheckbox = new System.Windows.Forms.CheckBox();
            this.YearOfBirthTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // CounterLabel
            // 
            this.CounterLabel.AutoSize = true;
            this.CounterLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CounterLabel.Location = new System.Drawing.Point(63, 95);
            this.CounterLabel.Name = "CounterLabel";
            this.CounterLabel.Size = new System.Drawing.Size(33, 37);
            this.CounterLabel.TabIndex = 0;
            this.CounterLabel.Text = "0";
            // 
            // IncreaseCounterButton
            // 
            this.IncreaseCounterButton.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.IncreaseCounterButton.Location = new System.Drawing.Point(126, 95);
            this.IncreaseCounterButton.Name = "IncreaseCounterButton";
            this.IncreaseCounterButton.Size = new System.Drawing.Size(176, 49);
            this.IncreaseCounterButton.TabIndex = 1;
            this.IncreaseCounterButton.Text = "Click me";
            this.IncreaseCounterButton.UseVisualStyleBackColor = true;
            this.IncreaseCounterButton.Click += new System.EventHandler(this.IncreaseCounterButton_Click);
            // 
            // HideButtonCheckbox
            // 
            this.HideButtonCheckbox.AutoSize = true;
            this.HideButtonCheckbox.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.HideButtonCheckbox.Location = new System.Drawing.Point(123, 195);
            this.HideButtonCheckbox.Name = "HideButtonCheckbox";
            this.HideButtonCheckbox.Size = new System.Drawing.Size(179, 41);
            this.HideButtonCheckbox.TabIndex = 2;
            this.HideButtonCheckbox.Text = "Hide button";
            this.HideButtonCheckbox.UseVisualStyleBackColor = true;
            this.HideButtonCheckbox.CheckedChanged += new System.EventHandler(this.HideButtonCheckbox_CheckedChanged);
            // 
            // YearOfBirthTextBox
            // 
            this.YearOfBirthTextBox.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.YearOfBirthTextBox.Location = new System.Drawing.Point(123, 264);
            this.YearOfBirthTextBox.Name = "YearOfBirthTextBox";
            this.YearOfBirthTextBox.Size = new System.Drawing.Size(127, 43);
            this.YearOfBirthTextBox.TabIndex = 3;
            this.YearOfBirthTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.YearOfBirthTextBox_KeyPress);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.YearOfBirthTextBox);
            this.Controls.Add(this.HideButtonCheckbox);
            this.Controls.Add(this.IncreaseCounterButton);
            this.Controls.Add(this.CounterLabel);
            this.Name = "MainForm";
            this.Text = "Our first app";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label CounterLabel;
        private Button IncreaseCounterButton;
        private CheckBox HideButtonCheckbox;
        private TextBox YearOfBirthTextBox;
    }
}