using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlidingPuzzle
{
    public partial class Form1 : Form
    {
        Point mouseDown;
        Point mouseUp;
        Image[] images = new Image[9];
        int[,] board = new int[3, 3];


        public Form1()
        {
            InitializeComponent();
            LoadImages();
            InitializeBoard();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown.X = e.X / 100;
            mouseDown.Y = e.Y / 100;
            
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseUp.X = e.X / 100;
            mouseUp.Y = e.Y / 100;
            if (IsValidMove())
            {
                SwitchSquare();
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    // get val of current cell
                    int imgNum = board[i, j];
                    // draw its image
                    e.Graphics.DrawImage(images[imgNum], i * 100, j * 100);
                }
            }
        }

        void LoadImages()
        {
            for (int i = 0; i < 9; i++)
            {
                images[i] = (Image)Properties.Resources.ResourceManager.GetObject("Tile" + i);
            }
            
        }

        void InitializeBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = i * 3 + j;
                }
            }
        }

        bool IsValidMove()
        {
            int dx = mouseDown.X - mouseUp.X;
            int dy = mouseDown.Y - mouseUp.Y;

            if (mouseUp.X < 0 || mouseUp.Y < 0 || mouseUp.X > 2 || mouseUp.Y > 2)
                return false;

            //target square isn't empty
            if (board[mouseUp.X, mouseUp.Y] != 0)
                return false;

            if (Math.Abs(dx) == 1 && dy == 0)
                return true;

            if (Math.Abs(dy) == 1 && dx == 0)
                return true;

            return false;
        }

        void SwitchSquare()
        {
            //switch squares
            int temp=board[mouseDown.X,mouseDown.Y]; //save square 1
            board[mouseDown.X, mouseDown.Y] = board[mouseUp.X, mouseUp.Y]; //overwrite sq1 
            board[mouseUp.X, mouseUp.Y] = temp; //copy temp to cell 2

            pictureBox1.Invalidate();

        }

    }
}
