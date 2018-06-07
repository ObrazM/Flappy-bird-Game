using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird
{
    public partial class Form1 : Form
    {
        bool jumping = false;
        int pipeSpeed = 0;
        int gravity = 0;
        int Inscore = 0;
        
        public Form1()
        {
            InitializeComponent();
            pipeBottom.Left = 200;
            pipeTop.Left = 250;
            pipeBottom.Top = -300;
            pipeTop.Top = 300;
            flappyBird.Top = 150;

            endText1.Visible = false;
            endText2.Visible = false;
            gameCreated.Visible = false;
            
        }

        

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            flappyBird.Top += gravity;

            if (flappyBird.Bounds.IntersectsWith(ground.Bounds))
            {
                endGame();
            }

            else if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds))
            {
                endGame();
            }

            else if (flappyBird.Bounds.IntersectsWith(pipeTop.Bounds))
            {
                endGame();
            }

            else if (flappyBird.Top <= 0)
            {
                endGame();
            }

            if (pipeBottom.Left < -80)
            {
                pipeBottom.Left = 1000;
                Inscore += 1;
                pipeBottom.Top += 10;
                pipeTop.Top -= 10;

                if (pipeTop.Top < 250)
                {
                    pipeTop.Top += 10;
                    pipeBottom.Top = pipeBottom.Top - 10;
                }

                if (pipeBottom.Top > -150)
                {
                    pipeTop.Top += 10;
                    pipeBottom.Top = pipeBottom.Top - 10;
                }
            }

            else if (pipeTop.Left < -95)
            {
                pipeTop.Left = 1100;
                Inscore += 1;
                pipeSpeed += 1;
                pipeTop.Top = pipeTop.Top - 10;
                pipeBottom.Top = pipeBottom.Top + 10;
                if (pipeTop.Top < 250)
                {
                    pipeTop.Top += 20;
                    pipeBottom.Top -= 20;
                }

                if (pipeBottom.Top > -150)
                {
                    pipeTop.Top += 20;
                    pipeBottom.Top -= 20;
                }

                if (pipeTop.Top > 400)
                {
                    pipeTop.Top -= 20;
                    pipeBottom.Top += 10;
                }

                if (pipeBottom.Top < -400)
                {
                    pipeTop.Top -= 10;
                    pipeBottom.Top += 10;
                }
            }
        }

        private void inGameKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                jumping = true;
                gravity = -5 ;
            }
        }

        private void inGameKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                jumping = false;
                gravity = 5;
            }
        }

        private void endGame()
        {
            gameTimer.Stop();
            endText2.Text = "Your total score is: " + Inscore;
            endText1.Visible = true;
            endText2.Visible = true;
            gameCreated.Visible = true;
            Start.Visible = true;
            Start.Enabled = true;
        }

        private void Start_Click(object sender, EventArgs e)
        {
            endText1.Visible = false;
            endText2.Visible = false;
            gameCreated.Visible = false;
            pipeBottom.Left = 200;
            pipeTop.Left = 250;
            pipeBottom.Top = -300;
            pipeTop.Top = 300;
            flappyBird.Top = 150;
            pipeSpeed = 5;
            gravity = 5;
            Inscore = 0;
            Start.Enabled = false;
            Start.Visible = false;
            gameTimer.Start();
        }
    }
}
