using System;
using System.Drawing;
using System.Windows.Forms;
using static Tetris.Consts;

namespace Tetris
{
    public partial class Form1 : Form
    {
        int[,] field;

        Shape shape;
        public Form1()
        {
            InitializeComponent();

            Init();
        }
        void Init()
        {
            shape = new Shape(0, 4);

            field = new int[HIGHT, WIDTH];

            this.KeyUp += new KeyEventHandler(keyfunc);

            timer1.Interval = DELAY;

            timer1.Tick += new EventHandler(update);

            timer1.Start();
        }

        private void keyfunc(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                    if (check(1))
                    {
                        shape.MoveRight();
                    }
                    break;
                case Keys.Left:
                    if (check(-1))
                    {
                        shape.MoveLeft();
                    }
                    break;
                case Keys.Down:
                    if (check(0))
                    {
                        shape.MoveDown();
                    }
                    break;
                case Keys.Space:
                    if (check(1))
                    {
                        shape.Rotate();
                    }
                    break;
                default:
                    break;
            }

            RePlace(false);
        }

        private void update(object sender, EventArgs e)
        {
            if (CheckOverFlow()) gameOv = true;

            RePlace(true);
        }
        void RePlace(bool down)
        {
            int str = ChkStr();

            if (str != -1)
            {
                if (fill)
                {
                    CutStr(str);
                    fill = false;
                }
                else
                {
                    FillStr(str);
                    fill = true;
                }
            }
            else
            {
                Pop();

                if (shape.Y >= HIGHT - shape.arr.GetLength(0))
                {
                    Freez();
                }
                if (check(0))
                {
                    if (down) shape.MoveDown();

                    Push(1);
                }
                else
                {
                    Freez();
                }
            }
            
            pictureBox1.Invalidate();
        }
        void Freez()
        {
            Push(2);

            shape.Y = 0;

            shape.X = 4;

            pictureBox2.Invalidate();

            shape.Init();
        }
    }
}