namespace Work1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox_Сipher = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.richTextBox_Decripted = new System.Windows.Forms.RichTextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.richTextBox_Source = new System.Windows.Forms.RichTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.richTextBox_Hacked = new System.Windows.Forms.RichTextBox();
            this.button_ClearCipher = new System.Windows.Forms.Button();
            this.textBox_shift = new System.Windows.Forms.TextBox();
            this.comboBox_currentCipher = new System.Windows.Forms.ComboBox();
            this.textBox_keyWord = new System.Windows.Forms.TextBox();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Введите тескт для зашифровки";
            // 
            // richTextBox_Сipher
            // 
            this.richTextBox_Сipher.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox_Сipher.Location = new System.Drawing.Point(387, 34);
            this.richTextBox_Сipher.Name = "richTextBox_Сipher";
            this.richTextBox_Сipher.ReadOnly = true;
            this.richTextBox_Сipher.Size = new System.Drawing.Size(384, 359);
            this.richTextBox_Сipher.TabIndex = 3;
            this.richTextBox_Сipher.Text = "";
            this.richTextBox_Сipher.TextChanged += new System.EventHandler(this.richTextBox_Сipher_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(392, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Шифр";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(391, 404);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Смещение";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.richTextBox_Decripted);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(365, 394);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Расшифровка";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // richTextBox_Decripted
            // 
            this.richTextBox_Decripted.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.richTextBox_Decripted.Location = new System.Drawing.Point(6, 6);
            this.richTextBox_Decripted.Name = "richTextBox_Decripted";
            this.richTextBox_Decripted.ReadOnly = true;
            this.richTextBox_Decripted.Size = new System.Drawing.Size(353, 382);
            this.richTextBox_Decripted.TabIndex = 0;
            this.richTextBox_Decripted.Text = "";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.richTextBox_Source);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(365, 394);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Зашифровка";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // richTextBox_Source
            // 
            this.richTextBox_Source.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox_Source.Location = new System.Drawing.Point(6, 6);
            this.richTextBox_Source.Name = "richTextBox_Source";
            this.richTextBox_Source.Size = new System.Drawing.Size(353, 382);
            this.richTextBox_Source.TabIndex = 2;
            this.richTextBox_Source.Text = "";
            this.richTextBox_Source.TextChanged += new System.EventHandler(this.richTextBox_Source_TextChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(373, 420);
            this.tabControl1.TabIndex = 2;
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.richTextBox_Hacked);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(365, 394);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Взлом";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // richTextBox_Hacked
            // 
            this.richTextBox_Hacked.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox_Hacked.Location = new System.Drawing.Point(6, 6);
            this.richTextBox_Hacked.Name = "richTextBox_Hacked";
            this.richTextBox_Hacked.ReadOnly = true;
            this.richTextBox_Hacked.Size = new System.Drawing.Size(353, 382);
            this.richTextBox_Hacked.TabIndex = 0;
            this.richTextBox_Hacked.Text = "";
            // 
            // button_ClearCipher
            // 
            this.button_ClearCipher.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ClearCipher.Location = new System.Drawing.Point(698, 404);
            this.button_ClearCipher.Name = "button_ClearCipher";
            this.button_ClearCipher.Size = new System.Drawing.Size(73, 23);
            this.button_ClearCipher.TabIndex = 7;
            this.button_ClearCipher.Text = "Очистить";
            this.button_ClearCipher.UseVisualStyleBackColor = true;
            this.button_ClearCipher.Click += new System.EventHandler(this.button_ClearCipher_Click_1);
            // 
            // textBox_shift
            // 
            this.textBox_shift.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_shift.Location = new System.Drawing.Point(458, 404);
            this.textBox_shift.Name = "textBox_shift";
            this.textBox_shift.Size = new System.Drawing.Size(84, 20);
            this.textBox_shift.TabIndex = 8;
            this.textBox_shift.TextChanged += new System.EventHandler(this.textBox_shift_TextChanged);
            // 
            // comboBox_currentCipher
            // 
            this.comboBox_currentCipher.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_currentCipher.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_currentCipher.FormattingEnabled = true;
            this.comboBox_currentCipher.Location = new System.Drawing.Point(650, 5);
            this.comboBox_currentCipher.Name = "comboBox_currentCipher";
            this.comboBox_currentCipher.Size = new System.Drawing.Size(121, 21);
            this.comboBox_currentCipher.TabIndex = 9;
            this.comboBox_currentCipher.SelectedIndexChanged += new System.EventHandler(this.comboBox_currentCipher_SelectedIndexChanged);
            // 
            // textBox_keyWord
            // 
            this.textBox_keyWord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_keyWord.Location = new System.Drawing.Point(592, 404);
            this.textBox_keyWord.Name = "textBox_keyWord";
            this.textBox_keyWord.Size = new System.Drawing.Size(100, 20);
            this.textBox_keyWord.TabIndex = 10;
            this.textBox_keyWord.TextChanged += new System.EventHandler(this.textBox_keyWord_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 444);
            this.Controls.Add(this.textBox_keyWord);
            this.Controls.Add(this.comboBox_currentCipher);
            this.Controls.Add(this.textBox_shift);
            this.Controls.Add(this.button_ClearCipher);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.richTextBox_Сipher);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.tabPage2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox_Сipher;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.RichTextBox richTextBox_Source;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.RichTextBox richTextBox_Decripted;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.RichTextBox richTextBox_Hacked;
        private System.Windows.Forms.Button button_ClearCipher;
        private System.Windows.Forms.TextBox textBox_shift;
        private System.Windows.Forms.ComboBox comboBox_currentCipher;
        private System.Windows.Forms.TextBox textBox_keyWord;
    }
}

