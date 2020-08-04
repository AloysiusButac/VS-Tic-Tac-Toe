using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        bool is_player_1 = true;
        Button[] tto = new Button[9];
        int x_win = 0;
        int o_win = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("working");
            //
            // Create new Buttons and set name, size
            //
            for(int i = 0; i < tto.Length; i++)
            {
                tto[i] = new Button();
                tto[i].Size = new Size(90, 90);

            }
            for (int i = 0; i < tto.Length; i++)
            {
                tto[i].Click += new EventHandler(button_click);
                string name = $"square{i}";
                tto[i].Name = name;
                tto[i].Font = new Font("Microsoft Sans Serif", 50, FontStyle.Bold);

                flowLayoutPanel1.Controls.Add(tto[i]);
                Console.WriteLine("{0} added", tto[i].Name);
            }
            flowLayoutPanel1.Visible = true;

            // hides button
            Button start_button = (Button)sender;
            start_button.Enabled = false;
            start_button.Visible = false;
            // resets button
            Button reset_button = new Button();
            reset_button.Size = new Size(100, 40);
            reset_button.Text = "RESET";
            reset_button.Click += new EventHandler(button_reset);
            panel1.Controls.Add(reset_button);

            label_turn.Text = "X's Turn";
                       
        }

        private void button_click(object sender, EventArgs e)
        {

            Button b = (Button)sender;

            if (b.Text == "") {
                if (is_player_1)
                {
                    b.Text = "X";
                    label_turn.Text = "O's Turn";
                } else
                {
                    b.Text = "O";
                    label_turn.Text = "X's Turn";
                }

                check_winner();
                check_draw();
                turn_swap();
            } else {
                MessageBox.Show("Invalid square", "Choose an empty square");
            }
        }

        private void button_reset(object sender, EventArgs e)
        {
            for(int i = 0; i < tto.Length; i++)
            {
                tto[i].Enabled = true;
                tto[i].Text = "";
            }
            label_turn.Text = "X's Turn";
        }

        private void check_winner()
        {
            // horizontal
            bool top = (tto[0].Text == tto[1].Text) && (tto[1].Text == tto[2].Text) && tto[1].Text != "";
            bool midh = (tto[3].Text == tto[4].Text) && (tto[4].Text == tto[5].Text) && tto[4].Text != "";
            bool bot = (tto[6].Text == tto[7].Text) && (tto[7].Text == tto[8].Text) && tto[7].Text != "";
            bool horizontal = top || midh || bot;
            // vertical
            bool left = (tto[0].Text == tto[3].Text) && (tto[3].Text == tto[6].Text) && tto[3].Text != "";
            bool midv = (tto[1].Text == tto[4].Text) && (tto[4].Text == tto[7].Text) && tto[4].Text != "";
            bool right = (tto[2].Text == tto[5].Text) && (tto[5].Text == tto[8].Text) && tto[5].Text != "";
            bool vertical = left || midv || right;
            // diagonals
            bool leftd = (tto[0].Text == tto[4].Text) && (tto[4].Text == tto[8].Text) && tto[4].Text != "";
            bool rightd = (tto[2].Text == tto[4].Text) && (tto[4].Text == tto[6].Text) && tto[4].Text != "";
            bool diagonal = leftd || rightd;

            string winner = "";
            if (horizontal || vertical || diagonal)
            {

                if(horizontal)
                {
                    if(top)
                    {
                        winner = tto[1].Text;
                    } else if(midh)
                    {
                        winner = tto[4].Text;
                    } else
                    {
                        winner = tto[7].Text;
                    }
                } 
                else if(vertical)
                {
                    if (left)
                    {
                        winner = tto[3].Text;
                    }
                    else if (midv)
                    {
                        winner = tto[4].Text;
                    }
                    else
                    {
                        winner = tto[5].Text;
                    }
                } 
                else
                {
                    winner = tto[4].Text;
                }

                if(winner == "X")
                {
                    x_win += 1;
                    x_count.Text = $"X: {x_win}";
                } else if (winner == "O")
                {
                    o_win += 1;
                    o_count.Text = $"O: {o_win}";
                }

                foreach (Button b in tto)
                {
                    b.Enabled = false;
                }
                MessageBox.Show($"Congrats {winner}, You Won!", "Winner!");
                is_player_1 = true;
            }
        }

        private void check_draw()
        {
            int count = 0;
            bool draw = false;
            for (int i = 0; i < 9; i++)
            {
                if (tto[i].Text == "")
                {
                    draw = false;
                    continue;
                } else {
                    count++;
                }
            }

            if(draw)
            {
                foreach (Button b in tto)
                {
                    b.Enabled = false;
                }
                MessageBox.Show($"Oh no! A Draw", "Draw");
            }
        }

        private void turn_swap()
        {
            if(is_player_1)
            {
                is_player_1 = false;
            } else
            {
                is_player_1 = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            Button d = (Button)sender;
            System.Windows.Forms.Button[] b = new System.Windows.Forms.Button[2];

                b[0] = new System.Windows.Forms.Button();
                b[1] = new System.Windows.Forms.Button();

            int posy = 10;
            int i = 1;
            foreach(Button a in b)
            {
                a.Size = new Size(30, 30);
                a.Location = new Point(10, posy);
                flowLayoutPanel1.Controls.Add(a);

                posy += 40;
            }

            d.Enabled = false;
            d.Visible = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }
    }
}
