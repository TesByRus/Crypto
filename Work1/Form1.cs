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
        private CaesarCipher _cypher;

        private int _curLocale;

        public Form1()
        {
            InitializeComponent();
            _cypher = new CaesarCipher();

            foreach (var lang in Locales.LocalesDictionary.Values)
            {
                comboBox_Locale.Items.Add(lang.Name);
            }
            comboBox_Locale.SelectedIndex = 0;
        }

        private void button_Cipher_Click(object sender, EventArgs e)
        {


        }


        private string AddSeparator(string text)
        {
            var resText = "";
            for (int i = 0; i < text.Length; i++)
            {
                resText += text[i];
                if (i % 5 == 4)
                {
                    resText += " ";
                }
            }
            return resText;
        }

        private void comboBox_Locale_SelectedIndexChanged(object sender, EventArgs e)
        {
            _curLocale = comboBox_Locale.SelectedIndex;
            StartConvert();
        }

        private void numericUpDown_Shift_ValueChanged(object sender, EventArgs e)
        {
            StartConvert();
        }

        private void richTextBox_Source_TextChanged(object sender, EventArgs e)
        {
            StartConvert();
        }

        private void StartConvert()
        {
            var sourceText = richTextBox_Source.Text;
            _cypher.CurrentLocale = Locales.LocalesDictionary[_curLocale];
            _cypher.Shift = (int)numericUpDown_Shift.Value;
            _cypher.SourceText = sourceText;
            _cypher.Run();
            richTextBox_Сipher.Text = AddSeparator(_cypher.CurrentCipher);

        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                richTextBox_Сipher.ReadOnly = true;
                StartConvert();
            }
            else
            {
                richTextBox_Сipher.ReadOnly = false;
            }
        }
    }
}
