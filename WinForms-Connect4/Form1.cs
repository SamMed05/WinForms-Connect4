/* 
 * MIT License
 * 
 * Copyright (c) 2022 Samuel Mediani
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms_Connect4
{
    public partial class Form1 : Form
    {
        Game g;
        int theme;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            theme = 0;
            btn1.Enabled = false;
            btn2.Enabled = false;
            btn3.Enabled = false;
            btn4.Enabled = false;
            btn5.Enabled = false;
            btn6.Enabled = false;
            btn7.Enabled = false;
            resetToolStripMenuItem.Enabled = false;
        }


        private void btn1_Click(object sender, EventArgs e)
        {
            string colour = turnColour(g.count());

            int row = g.checkValidSlot(0);
            int win = g.victory();

            if (row == 5)
            {
                cell00.Image = new Bitmap(colour);
                btn1.Enabled = false;
            }
            else if (row == 4)
                cell10.Image = new Bitmap(colour);
            else if (row == 3)
                cell20.Image = new Bitmap(colour);
            else if (row == 2)
                cell30.Image = new Bitmap(colour);
            else if (row == 1)
                cell40.Image = new Bitmap(colour);
            else if (row == 0)
                cell50.Image = new Bitmap(colour);

            displayVictoryMessage(win);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            string colour = turnColour(g.count());

            int row = g.checkValidSlot(1);
            int win = g.victory();

            if (row == 5)
            {
                cell01.Image = new Bitmap(colour);
                btn2.Enabled = false;
            }
            else if (row == 4)
                cell11.Image = new Bitmap(colour);
            else if (row == 3)
                cell21.Image = new Bitmap(colour);
            else if (row == 2)
                cell31.Image = new Bitmap(colour);
            else if (row == 1)
                cell41.Image = new Bitmap(colour);
            else if (row == 0)
                cell51.Image = new Bitmap(colour);

            displayVictoryMessage(win);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            string colour = turnColour(g.count());

            int row = g.checkValidSlot(2);
            int win = g.victory();

            if (row == 5)
            {
                cell02.Image = new Bitmap(colour);
                btn3.Enabled = false;
            }
            else if (row == 4)
                cell12.Image = new Bitmap(colour);
            else if (row == 3)
                cell22.Image = new Bitmap(colour);
            else if (row == 2)
                cell32.Image = new Bitmap(colour);
            else if (row == 1)
                cell42.Image = new Bitmap(colour);
            else if (row == 0)
                cell52.Image = new Bitmap(colour);

            displayVictoryMessage(win);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            string colour = turnColour(g.count());

            int row = g.checkValidSlot(3);
            int win = g.victory();

            if (row == 5)
            {
                cell03.Image = new Bitmap(colour);
                btn4.Enabled = false;
            }
            else if (row == 4)
                cell13.Image = new Bitmap(colour);
            else if (row == 3)
                cell23.Image = new Bitmap(colour);
            else if (row == 2)
                cell33.Image = new Bitmap(colour);
            else if (row == 1)
                cell43.Image = new Bitmap(colour);
            else if (row == 0)
                cell53.Image = new Bitmap(colour);

            displayVictoryMessage(win);
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            string colour = turnColour(g.count());

            int row = g.checkValidSlot(4);
            int win = g.victory();

            if (row == 5)
            {
                cell04.Image = new Bitmap(colour);
                btn5.Enabled = false;
            }
            else if (row == 4)
                cell14.Image = new Bitmap(colour);
            else if (row == 3)
                cell24.Image = new Bitmap(colour);
            else if (row == 2)
                cell34.Image = new Bitmap(colour);
            else if (row == 1)
                cell44.Image = new Bitmap(colour);
            else if (row == 0)
                cell54.Image = new Bitmap(colour);

            displayVictoryMessage(win);
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            string colour = turnColour(g.count());

            int row = g.checkValidSlot(5);
            int win = g.victory();

            if (row == 5)
            {
                cell05.Image = new Bitmap(colour);
                btn6.Enabled = false;
            }
            else if (row == 4)
                cell15.Image = new Bitmap(colour);
            else if (row == 3)
                cell25.Image = new Bitmap(colour);
            else if (row == 2)
                cell35.Image = new Bitmap(colour);
            else if (row == 1)
                cell45.Image = new Bitmap(colour);
            else if (row == 0)
                cell55.Image = new Bitmap(colour);

            displayVictoryMessage(win);
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            string colour = turnColour(g.count());

            int row = g.checkValidSlot(6);
            int win = g.victory();

            if (row == 5)
            {
                cell06.Image = new Bitmap(colour);
                btn7.Enabled = false;
            }
            else if (row == 4)
                cell16.Image = new Bitmap(colour);
            else if (row == 3)
                cell26.Image = new Bitmap(colour);
            else if (row == 2)
                cell36.Image = new Bitmap(colour);
            else if (row == 1)
                cell46.Image = new Bitmap(colour);
            else if (row == 0)
                cell56.Image = new Bitmap(colour);

            displayVictoryMessage(win);
        }

        public string selectTheme(int t, int player)
        {
            // images are in the "WinForms-Connect4\bin\Debug" directory
            if (theme == 0)
            {
                if (player == 0)
                    return "blue.png";
                else
                    return "red.png";
            }
            else if (theme == 1)
            {
                if (player == 0)
                    return "dark-blue.png";
                else
                    return "garnet-red.png";
            }
            else if (theme == 2)
            {
                if (player == 0)
                    return "turquoise.png";
                else
                    return "yellow.png";
            }
            else if (theme == 3)
            {
                if (player == 0)
                    return "lilac.png";
                else
                    return "orange.png";
            }
            return "error.png";
        }

        public string turnColour(int k) // k is the value returned by the count function for the turn
        {
            string fileName;
            if(k%2==0)
            {
                btn1.BackColor = Color.Wheat;
                btn2.BackColor = Color.Wheat;
                btn3.BackColor = Color.Wheat;
                btn4.BackColor = Color.Wheat;
                btn5.BackColor = Color.Wheat;
                btn6.BackColor = Color.Wheat;
                btn7.BackColor = Color.Wheat;

                fileName = selectTheme(theme, 0);
                return fileName;
            }
            else
            {
                btn1.BackColor = Color.Tan;
                btn2.BackColor = Color.Tan;
                btn3.BackColor = Color.Tan;
                btn4.BackColor = Color.Tan;
                btn5.BackColor = Color.Tan;
                btn6.BackColor = Color.Tan;
                btn7.BackColor = Color.Tan;

                fileName = selectTheme(theme, 1);
                return fileName;
            }
        }

        // menu buttons
        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            g = new Game();
            btn1.Enabled = true;
            btn2.Enabled = true;
            btn3.Enabled = true;
            btn4.Enabled = true;
            btn5.Enabled = true;
            btn6.Enabled = true;
            btn7.Enabled = true;
            themesToolStripMenuItem.Enabled = false;
            startToolStripMenuItem.Enabled = false;
            resetToolStripMenuItem.Enabled = true;
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart(); // simply restart the application to reset everything
            Environment.Exit(0); // clean shutdown
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Game developed by Samuel Mediani and other students during an extracurricular school course on C#. \n\nTechnologies used: Windows Forms, Visual Studio. \n\nYear: 2022", this.Text);
        }

        // themes
        private void defaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            theme = 0;
        }
        private void darkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            theme = 1;
        }
        private void summerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            theme = 2;
        }
        private void fallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            theme = 3;
        }

        // show the outcome of the game (according to win)
        private void displayVictoryMessage(int win)
        {
            if (win == 1)
            {
                MessageBox.Show("Player 1 won the match!", this.Text);
                this.Close();
            }
            else if (win == 2)
            {
                MessageBox.Show("Player 2 won the match!", this.Text);
                this.Close();
            }
            else if (win == 3)
            {
                MessageBox.Show("Draw!", this.Text);
                this.Close();
            }
        }
    }
}
