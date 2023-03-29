namespace NumericTypesSuggester
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
            this.MaxValueTextBox = new System.Windows.Forms.TextBox();
            this.MinValueTextBox = new System.Windows.Forms.TextBox();
            this.SuggestedTypeResult = new System.Windows.Forms.Label();
            this.SuggestedTypeLabel = new System.Windows.Forms.Label();
            this.MustBePreciseCheckbox = new System.Windows.Forms.CheckBox();
            this.IntegralOnlyCheckBox = new System.Windows.Forms.CheckBox();
            this.MaxValueLabel = new System.Windows.Forms.Label();
            this.MinValueLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // MaxValueTextBox
            // 
            this.MaxValueTextBox.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MaxValueTextBox.Location = new System.Drawing.Point(225, 66);
            this.MaxValueTextBox.Name = "MaxValueTextBox";
            this.MaxValueTextBox.Size = new System.Drawing.Size(679, 43);
            this.MaxValueTextBox.TabIndex = 29;
            this.MaxValueTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.MaxValueTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // MinValueTextBox
            // 
            this.MinValueTextBox.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MinValueTextBox.Location = new System.Drawing.Point(225, 12);
            this.MinValueTextBox.Name = "MinValueTextBox";
            this.MinValueTextBox.Size = new System.Drawing.Size(679, 43);
            this.MinValueTextBox.TabIndex = 28;
            this.MinValueTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.MinValueTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // SuggestedTypeResult
            // 
            this.SuggestedTypeResult.AutoSize = true;
            this.SuggestedTypeResult.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SuggestedTypeResult.Location = new System.Drawing.Point(225, 216);
            this.SuggestedTypeResult.Name = "SuggestedTypeResult";
            this.SuggestedTypeResult.Size = new System.Drawing.Size(230, 37);
            this.SuggestedTypeResult.TabIndex = 27;
            this.SuggestedTypeResult.Text = "not enough data";
            // 
            // SuggestedTypeLabel
            // 
            this.SuggestedTypeLabel.AutoSize = true;
            this.SuggestedTypeLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SuggestedTypeLabel.Location = new System.Drawing.Point(5, 216);
            this.SuggestedTypeLabel.Name = "SuggestedTypeLabel";
            this.SuggestedTypeLabel.Size = new System.Drawing.Size(224, 37);
            this.SuggestedTypeLabel.TabIndex = 26;
            this.SuggestedTypeLabel.Text = "Suggested type:";
            // 
            // MustBePreciseCheckbox
            // 
            this.MustBePreciseCheckbox.AutoSize = true;
            this.MustBePreciseCheckbox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.MustBePreciseCheckbox.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MustBePreciseCheckbox.Location = new System.Drawing.Point(5, 172);
            this.MustBePreciseCheckbox.Name = "MustBePreciseCheckbox";
            this.MustBePreciseCheckbox.Size = new System.Drawing.Size(234, 41);
            this.MustBePreciseCheckbox.TabIndex = 25;
            this.MustBePreciseCheckbox.Text = "Must be precise?";
            this.MustBePreciseCheckbox.UseVisualStyleBackColor = true;
            this.MustBePreciseCheckbox.Visible = false;
            this.MustBePreciseCheckbox.CheckedChanged += new System.EventHandler(this.MustBePreciseCheckbox_CheckedChanged);
            // 
            // IntegralOnlyCheckBox
            // 
            this.IntegralOnlyCheckBox.AutoSize = true;
            this.IntegralOnlyCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.IntegralOnlyCheckBox.Checked = true;
            this.IntegralOnlyCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IntegralOnlyCheckBox.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.IntegralOnlyCheckBox.Location = new System.Drawing.Point(42, 125);
            this.IntegralOnlyCheckBox.Name = "IntegralOnlyCheckBox";
            this.IntegralOnlyCheckBox.Size = new System.Drawing.Size(197, 41);
            this.IntegralOnlyCheckBox.TabIndex = 24;
            this.IntegralOnlyCheckBox.Text = "Integral only?";
            this.IntegralOnlyCheckBox.UseVisualStyleBackColor = true;
            this.IntegralOnlyCheckBox.CheckedChanged += new System.EventHandler(this.IntegralOnlyCheckBox_CheckedChanged);
            // 
            // MaxValueLabel
            // 
            this.MaxValueLabel.AutoSize = true;
            this.MaxValueLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MaxValueLabel.Location = new System.Drawing.Point(76, 69);
            this.MaxValueLabel.Name = "MaxValueLabel";
            this.MaxValueLabel.Size = new System.Drawing.Size(143, 37);
            this.MaxValueLabel.TabIndex = 23;
            this.MaxValueLabel.Text = "Max value:";
            // 
            // MinValueLabel
            // 
            this.MinValueLabel.AutoSize = true;
            this.MinValueLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MinValueLabel.Location = new System.Drawing.Point(80, 15);
            this.MinValueLabel.Name = "MinValueLabel";
            this.MinValueLabel.Size = new System.Drawing.Size(139, 37);
            this.MinValueLabel.TabIndex = 22;
            this.MinValueLabel.Text = "Min value:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(916, 272);
            this.Controls.Add(this.MaxValueTextBox);
            this.Controls.Add(this.MinValueTextBox);
            this.Controls.Add(this.SuggestedTypeResult);
            this.Controls.Add(this.SuggestedTypeLabel);
            this.Controls.Add(this.MustBePreciseCheckbox);
            this.Controls.Add(this.IntegralOnlyCheckBox);
            this.Controls.Add(this.MaxValueLabel);
            this.Controls.Add(this.MinValueLabel);
            this.Name = "MainForm";
            this.Text = "C# Numeric types";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox MaxValueTextBox;
        private TextBox MinValueTextBox;
        private Label SuggestedTypeResult;
        private Label SuggestedTypeLabel;
        private CheckBox MustBePreciseCheckbox;
        private CheckBox IntegralOnlyCheckBox;
        private Label MaxValueLabel;
        private Label MinValueLabel;
    }
}