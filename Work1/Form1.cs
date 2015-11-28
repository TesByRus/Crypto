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
        private Cipher _currentCipher;
        public Form1()
        {
            InitializeComponent();
            textBox_shift.Text = 0.ToString();
            comboBox_currentCipher.Items.Add("Шифр Цезаря");
            comboBox_currentCipher.Items.Add("Шифр Виженера");
            comboBox_currentCipher.SelectedIndex = 0;
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
            var cipherText = cypher.Encrypt(sourceText, GetShift());
            richTextBox_Сipher.Text = cipherText;

        }

        private void StartDecrypt()
        {
            var cypherText = richTextBox_Сipher.Text;
            Cipher cypher;
            cypher = new CaesarCipher();
            var sourceText = cypher.Decrypt(cypherText, GetShift());
            richTextBox_Decripted.Text = sourceText;
        }

        private void StartHacking()
        {
            var cypherText = richTextBox_Сipher.Text;
            Cipher cypher;
            cypher = new CaesarCipher();
            var sourceText = cypher.Hack(cypherText);
            richTextBox_Hacked.Text = sourceText;
            textBox_shift.Text = cypher.HackerShift.ToString();
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    richTextBox_Сipher.ReadOnly = true;
                    richTextBox_Сipher.BackColor = Color.FromArgb(240, 240, 240);
                    textBox_shift.Enabled = true;
                    StartEncrypt();
                    break;
                case 1:
                    richTextBox_Сipher.ReadOnly = false;
                    richTextBox_Сipher.BackColor = Color.White;
                    textBox_shift.Enabled = true;
                    StartDecrypt();
                    break;
                case 2:
                    richTextBox_Сipher.ReadOnly = false;
                    richTextBox_Сipher.BackColor = Color.White;
                    textBox_shift.Enabled = false;
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

        private void textBox_shift_TextChanged(object sender, EventArgs e)
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

        private int GetShift()
        {
            try
            {
                if (textBox_shift.Text.Length == 0 || textBox_shift.Text == "-")
                {
                    return 0;
                }
                return Convert.ToInt32(textBox_shift.Text);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Смещение должно быть равно целому числу!");

                var text = textBox_shift.Text;
                while (text != "")
                {
                    try
                    {
                        var res = Convert.ToInt32(text);
                        textBox_shift.Text = text;
                        return res;
                    }
                    catch (FormatException)
                    {
                        text = text.Remove(text.Length - 1);
                    }
                }

                textBox_shift.Text = text;
                return 0;
            }
            catch (OverflowException ex)
            {
                MessageBox.Show("Число должно быть в пределах размерности типа Int!");
                var text = textBox_shift.Text;
                while (text != "")
                {
                    try
                    {
                        var res = Convert.ToInt32(text);
                        textBox_shift.Text = text;
                        return res;
                    }
                    catch (OverflowException)
                    {
                        text = text.Remove(text.Length - 1);
                    }
                }

                textBox_shift.Text = text;
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                textBox_shift.Text = "";
                return 0;
            }
        }

        private void button_ClearCipher_Click_1(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    richTextBox_Source.Clear();
                    break;
                case 1:
                    richTextBox_Сipher.Clear();
                    break;
                case 2:
                    richTextBox_Сipher.Clear();
                    break;
            }
        }

        private void comboBox_currentCipher_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox_currentCipher.SelectedIndex)
            {
                case 0:
                    _currentCipher = new CaesarCipher();
                    break;
                case 1:
                    break;
            }
        }
}
}
