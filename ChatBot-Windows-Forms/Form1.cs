using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatBot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            textBox2.KeyDown += textBox2_KeyDown; // Attach KeyDown event
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ActiveControl = textBox2; // ✅ Best method
            textBox2.Focus();              // (extra safety)
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Optional: Auto scroll to bottom if text is added
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.ScrollToCaret();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userInput = textBox2.Text.Trim();
            if (string.IsNullOrEmpty(userInput))
            {
                return;
            }

            textBox1.AppendText("You: " + userInput + Environment.NewLine);

            string botreply = GetBotReply(userInput);

            textBox1.AppendText("Bot: " + botreply + Environment.NewLine);
            textBox2.Text = "";
        }

        private string GetBotReply(string userMessage)
        {
            userMessage = userMessage.ToLower();

            if (userMessage.Contains("55") || userMessage.Contains("60"))
            {
                return "91/-!";
            }
            else if (userMessage.Contains("how are you"))
            {
                return "I am doing fine, what about you?";
            }
            else if (userMessage.Contains("what is your name"))
            {
                return "I am a superBot, here to help you!";
            }
            else if (userMessage.Contains("how much is your age"))
            {
                return "I am as young as technology!";
            }
            else if (userMessage.Contains("i miss you"))
            {
                return "I miss you too!";
            }
            else if (userMessage.Contains("bye"))
            {
                return "Bye bye, have a great day!";
            }

            // Default random replies
            string[] responses = new string[]
            {
                "That's interesting!",
                "Tell me more.",
                "I'm here to listen.",
                "Could you explain that?",
                "Wow, really?",
                "Sounds cool!",
                "I'm thinking about it... 🤔",
                "Hmm, that's deep!"
            };

            Random randi = new Random();
            int index = randi.Next(responses.Length);
            return responses[index];
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
                e.SuppressKeyPress = true; // prevent beep sound
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // Optional: live validation or placeholder handling
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
                e.SuppressKeyPress = true; // prevent beep sound
            }
        }

        
    }
}
