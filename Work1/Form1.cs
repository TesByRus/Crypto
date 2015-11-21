using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Work1.Caesar;

namespace Work1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void numericUpDown_Shift_ValueChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    StartEncrypt();
                    break;
                case 1:
                    StartDecrypt();
                    break;
            }
        }

        private void richTextBox_Source_TextChanged(object sender, EventArgs e)
        {
            StartEncrypt();
        }

        private void StartEncrypt()
        {
            var sourceText = richTextBox_Source.Text;
            Cipher cypher;
            cypher = new CaesarCipher();
            var cipherText = cypher.Encrypt(sourceText, (int)numericUpDown_Shift.Value);
            richTextBox_Сipher.Text = cipherText;

        }

        private void StartDecrypt()
        {
            var cypherText = richTextBox_Сipher.Text;
            Cipher cypher;
            cypher = new CaesarCipher();
            var sourceText = cypher.Decrypt(cypherText, (int)numericUpDown_Shift.Value);
            richTextBox_Decripted.Text = sourceText;
        }

        private void StartHacking()
        {
            var cypherText = richTextBox_Сipher.Text;
            Cipher cypher;
            cypher = new CaesarCipher();
            var sourceText = cypher.Hack(cypherText);
            richTextBox_Hacked.Text = sourceText;
            numericUpDown_Shift.Value = cypher.HackerShift;
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    richTextBox_Сipher.ReadOnly = true;
                    richTextBox_Сipher.BackColor = Color.FromArgb(240, 240, 240);
                    numericUpDown_Shift.Enabled = true;
                    StartEncrypt();
                    break;
                case 1:
                    richTextBox_Сipher.ReadOnly = false;
                    richTextBox_Сipher.BackColor = Color.White;
                    numericUpDown_Shift.Enabled = true;
                    StartDecrypt();
                    break;
                case 2:
                    richTextBox_Сipher.ReadOnly = false;
                    richTextBox_Сipher.BackColor = Color.White;
                    numericUpDown_Shift.Enabled = false;
                    StartHacking();
                    break;
            }
            
        }

        private void richTextBox_Сipher_TextChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 1:
                    StartDecrypt();
                    break;
                case 2:
                    StartHacking();
                    break;
            }
        }

        private void button_ClearCipher_Click(object sender, EventArgs e)
        {
            richTextBox_Сipher.Clear();
        }
    }
}
