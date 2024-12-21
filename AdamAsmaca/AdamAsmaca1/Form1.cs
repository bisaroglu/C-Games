using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdamAsmaca1
{
    public partial class Form1 : Form
    {
        #region Veriables
        List<string> words = new List<string>
        {
            "kars",
            "bursa",
            "amasya",
            "antalya",
            "mardin",
            "diyarbekir",
            "hatay",
            "kilis",
            "izmir",
            "yalova",
            "izmit"
        };
        int incorrectGuess;
        Random random;
        string selectedWord;
        char[] displayWord;
        #endregion
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            incorrectGuess = 0;
            random = new Random();
            selectedWord = words[random.Next(words.Count)];
            displayWord = new string('_', selectedWord.Length).ToCharArray();
            string formattedDisplayWord = string.Join(" ", displayWord);
            lblWordDisplay.Text = formattedDisplayWord;
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            char guess = tbGuess.Text.ToLower()[0];
            bool correctGuess = false;
            for (int i = 0; i < selectedWord.Length; i++)
            {
                if (selectedWord[i] == guess)
                {
                    displayWord[i] = guess;
                    correctGuess = true;
                }
            }
            lblWordDisplay.Text = string.Join(" ", displayWord);
            if (!correctGuess)
            {
                UpdateHangmanImage();
            }
            if (lblWordDisplay.Text.Contains('_'))
            {
                
            }
        }

        private void UpdateHangmanImage()
        {
            incorrectGuess++;
            switch (incorrectGuess)
            {
                case 1:
                    pictureBox1.Image = Properties.Resources.hangman_1;
                    break;
                case 2:
                    pictureBox1.Image = Properties.Resources.hangman_2;
                    break;
                case 3:
                    pictureBox1.Image = Properties.Resources.hangman_3;
                    break;
                case 4:
                    pictureBox1.Image = Properties.Resources.hangman_4;
                    break;
                case 5:
                    pictureBox1.Image = Properties.Resources.hangman_5;
                    MessageBox.Show("Bilemediniz! Seçilen Kelime: " + selectedWord);
                    Application.Restart();
                    break;
            }
        }
    }
}
