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
        int numRnd;
        int numOfGuesses = 0;
        public Form1()
        {
            InitializeComponent();
            NumRand();
        }

        public void NumRand()
        {
            numRnd = new Random().Next(1, 101);
            numOfGuesses = 0;
        }
        public void CheckGuess(string guessStr)
        {
            textBox1.SelectionStart = 0;
            textBox1.SelectionLength = textBox1.Text.Length;
            int guess = int.Parse(guessStr);
            numOfGuesses++;
            if (guess == numRnd)
            {
                Output.Lines = new string[]
                {
                  "Correct guess",
                  $"Your guess: {guess}",
                  $"Num of guesses: {numOfGuesses}",
                  "Guess a new number to play",
                };
                NumRand();
            }
            else if (guess < numRnd)
            {
                Output.Text = "Too low";
            }
            else if (guess > numRnd)
            {
                Output.Text = "Too high";
            }
        }
        private void Return_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                e.SuppressKeyPress = true;
                CheckGuess(textBox1.Text);
            }
        }

        private void Submit_Button(object sender, EventArgs e)
        {
            CheckGuess(textBox1.Text);
        }
    }
}