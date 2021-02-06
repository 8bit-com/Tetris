using System.Drawing;
using System.Windows.Forms;
using static Tetris.Consts;

namespace Tetris
{
    public partial class Form1 : Form
    {
        bool CheckOverFlow()
        {
            for (int i = 0; i < field.GetLength(1); i++)
            {
                if(field[0, i] == 2)
                {
                    return true;
                }
            }
            return false;
        }
        void Push(int advice)
        {
            for (int Y = 0; Y < shape.arr.GetLength(0); Y++)
            {
                for (int X = 0; X < shape.arr.GetLength(1); X++)
                {
                    if (shape.arr[Y, X] == 1)
                    {
                        field[Y + shape.Y, X + shape.X] = advice;
                    }
                }
            }
        }
        void Pop()
        {
            for (int Y = 0; Y < field.GetLength(0); Y++)
            {
                for (int X = 0; X < field.GetLength(1); X++)
                {
                    if (field[Y, X] == 1)
                    {
                        field[Y, X] = 0;
                    }
                }
            }
        }
        bool check(int x)
        {
            for (int Y = 0; Y < shape.arr.GetLength(0); Y++)
            {
                for (int X = 0; X < shape.arr.GetLength(1); X++)
                {
                    if ((shape.X == 0) & (x == -1))
                    {
                        return false;
                    }
                    if ((shape.X == WIDTH - shape.arr.GetLength(1)) & (x == 1))
                    {
                        return false;
                    }
                    if ((field[Y + shape.Y + (x==0?1:0), X + shape.X + x] == 2) & (shape.arr[Y, X] == 1))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        int ChkStr()
        {
            bool a = true;

            for (int Y = 0; Y < field.GetLength(0); Y++)
            {
                for (int X = 0; X < field.GetLength(1); X++)
                {
                    if(field[Y, X] != 2 && field[Y, X] != 3)
                    {
                        a = false;
                        break;
                    }
                }
                if (a)
                {
                    return Y;
                }
                else a = true;
            }
            return -1;
        }

        void CutStr(int str)
        {
            for (int Y = str; Y > 0; Y--)
            {
                for (int X = 0; X < field.GetLength(1); X++)
                {
                    field[Y, X] = field[Y - 1, X];
                }
            }
            if (!gameOv)
            {
                score += 10;
                DELAY -= 50;
                timer1.Interval -= 50;
            }
        }
        void FillStr(int str)
        {
            for (int X = 0; X < field.GetLength(1); X++)
            {
                field[str, X] = 3;
            }
        }
        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            for (int Y = 0; Y < shape.arrNext.GetLength(0); Y++)
            {
                for (int X = 0; X < shape.arrNext.GetLength(1); X++)
                {
                    if (shape.arrNext[Y, X] == 1)
                    {
                        e.Graphics.FillRectangle(Brushes.Green, new Rectangle(X * S_RECT + 40, Y * S_RECT + 40, S_RECT, S_RECT));
                    }
                }
            }
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            for (int Y = 0; Y < field.GetLength(0); Y++)
            {
                for (int X = 0; X < field.GetLength(1); X++)
                {
                    if (field[Y, X] == 1)
                    {                        
                        e.Graphics.FillRectangle(Brushes.MediumSeaGreen, new Rectangle(X * S_RECT, Y * S_RECT, S_RECT, S_RECT));
                    }
                    if (field[Y, X] == 2)
                    {
                        e.Graphics.FillRectangle(Brushes.ForestGreen, new Rectangle(X * S_RECT, Y * S_RECT, S_RECT, S_RECT));
                    }
                    if (field[Y, X] == 3)
                    {
                        e.Graphics.FillRectangle(Brushes.Red, new Rectangle(X * S_RECT, Y * S_RECT, S_RECT, S_RECT));
                    }
                    if (!gameOv)
                    {
                        e.Graphics.DrawRectangle(Pens.LightSkyBlue, new Rectangle(X * S_RECT, Y * S_RECT, S_RECT, S_RECT));
                    }
                }
            }
            if (gameOv)
            {
                label1.Parent = pictureBox1;

                label1.BackColor = Color.Transparent;

                label1.Visible = true;
            }
            label3.Text = "Score: " + score.ToString();
            label5.Text = "Delay: " + DELAY.ToString();
        }
    }
}