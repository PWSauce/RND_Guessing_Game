using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RND_Guessing_Game
{
    public partial class Form1 : Form
    {
        int randNum;
        int numOfGuesses = 0;
        Random random = new Random();
        public Form1()
        {
            InitializeComponent();
            NewNumber();
        }

        public void NewNumber()
        {
            randNum = random.Next(1, 101);
            numOfGuesses = 0;
        }
        public void CheckGuess(string guessStr)
        {
            int guess = int.Parse(guessStr);
            numOfGuesses++;
            if (guess == randNum)
            {
                Output.Lines = new string[]
                {
                  "Correct guess",
                  $"Your guess: {guess}",
                  $"Num of guesses: {numOfGuesses}",
                  "Guess a new number to play",
                };
                NewNumber();
            }
            else if (guess < randNum)
            {
                Output.Text = "Too low";
            }
            else if (guess > randNum)
            {
                Output.Text = "Too high";
            }
        }
        private void ReFocus()
        {
            textBox1.SelectionStart = 0;
            textBox1.SelectionLength = textBox1.Text.Length;
        }
        private void Return_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                e.SuppressKeyPress = true;
                CheckGuess(textBox1.Text);
                ReFocus();
            }
        }

        private void Submit_Button(object sender, EventArgs e)
        {
            CheckGuess(textBox1.Text);
            ReFocus();
        }
    }
}