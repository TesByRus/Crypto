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
        private string _keyWord = "";
        public Form1()
        {
            InitializeComponent();
            textBox_shift.Text = 0.ToString();
            comboBox_currentCipher.Items.Add("Шифр Цезаря");
            comboBox_currentCipher.Items.Add("Шифр Виженера");
            comboBox_currentCipher.SelectedIndex = 0;
            UpdateCipher();
        }


        private void StartAction()
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    StartEncrypt();
                    break;
                case 1:
                    StartDecrypt();
                    break;
                case 2:
                    StartHacking();
                    break;
            }

        }
        private void richTextBox_Source_TextChanged(object sender, EventArgs e)
        {
            StartAction();
        }

        private void StartEncrypt()
        {
            try
            {
                var sourceText = richTextBox_Source.Text;
                Cipher cypher;
                cypher = _currentCipher;
                if (cypher == null) return;
                var cipherText = cypher.Encrypt(sourceText, GetShift(), _keyWord);
                textBox_Cipher.Text = cipherText;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                textBox_keyWord.Text = "";
            }

        }

        private void StartDecrypt()
        {
            try
            {
                var cypherText = textBox_Cipher.Text;
                Cipher cypher;
                cypher = _currentCipher;
                if (cypher != null)
                {
                    var sourceText = cypher.Decrypt(cypherText, GetShift(), _keyWord);
                    richTextBox_Decripted.Text = sourceText;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                textBox_keyWord.Text = "";
            }

        }

        private void StartHacking()
        {
            try
            {
                var cypherText = textBox_Cipher.Text;
                Cipher cypher;
                cypher = _currentCipher;
                var sourceText = cypher.Hack(cypherText);
                richTextBox_Hacked.Text = sourceText;
                textBox_shift.Text = cypher.HackerShift.ToString();
                textBox_keyWord.Text = cypher.HackedKeyWord;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    textBox_Cipher.ReadOnly = true;
                    textBox_Cipher.BackColor = Color.FromArgb(240, 240, 240);
                    if (comboBox_currentCipher.SelectedIndex == 0)
                    {
                        textBox_shift.Enabled = true;
                        textBox_shift.ReadOnly = false;
                        textBox_keyWord.Enabled = false;
                    }
                    else
                    {
                        textBox_shift.Enabled = false;
                        textBox_keyWord.Enabled = true;
                        textBox_keyWord.ReadOnly = false;
                    }
                    StartAction();
                    break;
                case 1:
                    textBox_Cipher.ReadOnly = false;
                    textBox_Cipher.BackColor = Color.White;
                    if (comboBox_currentCipher.SelectedIndex == 0)
                    {
                        textBox_shift.Enabled = true;
                        textBox_shift.ReadOnly = false;
                        textBox_keyWord.Enabled = false;
                    }
                    else
                    {
                        textBox_shift.Enabled = false;
                        textBox_keyWord.Enabled = true;
                        textBox_keyWord.ReadOnly = false;
                    }
                    StartAction();
                    break;
                case 2:
                    textBox_Cipher.ReadOnly = false;
                    textBox_Cipher.BackColor = Color.White;
                    if (comboBox_currentCipher.SelectedIndex == 0)
                    {
                        textBox_shift.Enabled = true;
                        textBox_shift.ReadOnly = true;
                        textBox_keyWord.Enabled = false;
                    }
                    else
                    {
                        textBox_shift.Enabled = false;
                        textBox_keyWord.Enabled = true;
                        textBox_keyWord.ReadOnly = true;
                    }
                    StartAction();
                    break;
            }

        }

        private void textBox_shift_TextChanged(object sender, EventArgs e)
        {
            StartAction();
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
                    textBox_Cipher.Clear();
                    break;
                case 2:
                    textBox_Cipher.Clear();
                    break;
            }
        }

        private void comboBox_currentCipher_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCipher();
        }

        void UpdateCipher()
        {
            switch (comboBox_currentCipher.SelectedIndex)
            {
                case 0:
                    _currentCipher = new CaesarCipher();
                    textBox_shift.Enabled = true;
                    textBox_keyWord.Enabled = false;
                    break;
                case 1:
                    _currentCipher = new VigenerCipher();
                    textBox_shift.Enabled = false;
                    textBox_keyWord.Enabled = true;
                    break;
            }
        }


        private void textBox_keyWord_TextChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex != 2)
            {
                var sourceKeyWord = textBox_keyWord.Text;
                var keyWord = HandleKeyWord(sourceKeyWord);
                textBox_keyWord.Text = keyWord;
                textBox_keyWord.SelectionStart = keyWord.Length;
                _keyWord = keyWord;

                StartAction();
            }

        }

        private string HandleKeyWord(string sourceKeyWord)
        {
            sourceKeyWord = sourceKeyWord.ToUpper();
            sourceKeyWord = Locales.LocalesList.Where(locale => locale.ReplacmentList.Count != 0)
                .Aggregate(sourceKeyWord, (current, locale) => Cipher.Replace(current, locale.ReplacmentList));

            if (!CheckString(sourceKeyWord))
            {
                MessageBox.Show("Ключевое слово должно состоять из букв русского алфавита!");

                while (sourceKeyWord.Length != 0 && !CheckString(sourceKeyWord))
                {
                    sourceKeyWord = sourceKeyWord.Remove(sourceKeyWord.Length - 1);
                }
            }

            return sourceKeyWord;
        }

        private bool CheckString(string text)
        {
            var russianLocale = Locales.LocalesList.Find(x => x.Name == "Русский");
            if (text.Length <= 0) return true;

            //проверяем на левые символы
            foreach (var c in text)
            {
                if (!russianLocale.Alphabet.Contains(c))
                {
                    return false;
                }

            }
            return true;
        }

        private void textBox_Cipher_TextChanged(object sender, EventArgs e)
        {
            StartAction();
        }
    }
}
