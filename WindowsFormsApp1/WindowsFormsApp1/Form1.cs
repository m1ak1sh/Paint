using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Bitmap bitmapMain;
        Graphics graphicsMain;
        Pen penMain;
        SelectFigure activeButton = SelectFigure.None;
        List<Point> activePoints;
        List<Figure> figureList = new List<Figure>();


        public Form1()
        {
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            bitmapMain = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphicsMain = Graphics.FromImage(bitmapMain);
            penMain = new Pen(Color.Black);
            activePoints = new List<Point>();
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lable1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = "X: " + e.X;
            label2.Text = "Y: " + e.Y;

        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }
        private void ClearSelect()
        {
            activePoints.Clear();

            foreach (Button button in panel1.Controls.OfType<Button>())
            {
                button.Font = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Regular);

            }
        }

        private void SelectingButton(object button)
        {
            (button as Button).Font = new Font("GenericSanSerif ", 8, FontStyle.Bold);

        }


        private void button1_Click(object sender, EventArgs e)
        {
            activeButton = SelectFigure.Line;
            ClearSelect();
            SelectingButton(sender);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            activeButton = SelectFigure.Rectangle;
            ClearSelect();
            SelectingButton(sender);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            activeButton = SelectFigure.Ellipse;
            ClearSelect();
            SelectingButton(sender);
        }

        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {


        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            activePoints.Add(new Point(e.X, e.Y));
            if (activePoints.Count > 1)
            {
                switch (activeButton)
                {
                    case SelectFigure.Line:
                        Figure Line = new Line(SelectFigure.Line, penMain, activePoints);
                        Line.Draw(graphicsMain);
                        activePoints.Clear();
                        figureList.Add(Line);
                        listBox1.Items.Add(Line.ToString() + String.Format("({0},{1},{2},{3});", Line.Points[0].X, Line.Points[0].Y, Line.Points[1].X, Line.Points[1].Y));
                        break;
                    case SelectFigure.Rectangle:
                        Figure Rectangle = new Rectangle(SelectFigure.Rectangle, penMain, activePoints);
                        Rectangle.Draw(graphicsMain);
                        activePoints.Clear();
                        figureList.Add(Rectangle);
                        listBox1.Items.Add(Rectangle.ToString() + String.Format("({0},{1},{2},{3});", Rectangle.Points[0].X, Rectangle.Points[0].Y, Rectangle.Points[1].X, Rectangle.Points[1].Y));
                        break;
                    case SelectFigure.Ellipse:
                        Figure Ellipse = new Ellipse(SelectFigure.Ellipse, penMain, activePoints);
                        Ellipse.Draw(graphicsMain);
                        activePoints.Clear();
                        figureList.Add(Ellipse);
                        listBox1.Items.Add(Ellipse.ToString() + String.Format("({0},{1},{2},{3});", Ellipse.Points[0].X, Ellipse.Points[0].Y, Ellipse.Points[1].X, Ellipse.Points[1].Y));
                        break;

                }

                pictureBox1.Image = bitmapMain;
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            if (index > -1)
            {
                listBox1.Items.RemoveAt(index);
                figureList.RemoveAt(index);
                ReDrow();
            }
            else
            {
                MessageBox.Show("Не выбрана фигура на удаление");
            }
        }
        private void ReDrow()
        {
            activePoints.Clear();
            graphicsMain.Clear(Color.White);

            foreach (Figure figure in figureList)
            {
                figure.Draw(graphicsMain);
            }
            pictureBox1.Image = bitmapMain;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ButtonUp_Click(object sender, EventArgs e)
        {
            activePoints.Add(new Point(e.X, e.Y));
            if (activePoints.Count > 1)
            {
                switch (activeButton)
                {
                    case SelectFigure.Line:
                        Figure Line = new Line(SelectFigure.Line, penMain, activePoints);
                        Line.Draw(graphicsMain);
                        activePoints.Clear();
                        figureList.Add(Line);
                        listBox1.Items.Add(Line.ToString() + String.Format("({0},{1},{2},{3});", Line.Points[0].X, Line.Points[0].Y, Line.Points[1].X, Line.Points[1].Y));
                        break;
                    case SelectFigure.Rectangle:
                        Figure Rectangle = new Rectangle(SelectFigure.Rectangle, penMain, activePoints);
                        Rectangle.Draw(graphicsMain);
                        activePoints.Clear();
                        figureList.Add(Rectangle);
                        listBox1.Items.Add(Rectangle.ToString() + String.Format("({0},{1},{2},{3});", Rectangle.Points[0].X, Rectangle.Points[0].Y, Rectangle.Points[1].X, Rectangle.Points[1].Y));
                        break;
                    case SelectFigure.Ellipse:
                        Figure Ellipse = new Ellipse(SelectFigure.Ellipse, penMain, activePoints);
                        Ellipse.Draw(graphicsMain);
                        activePoints.Clear();
                        figureList.Add(Ellipse);
                        listBox1.Items.Add(Ellipse.ToString() + String.Format("({0},{1},{2},{3});", Ellipse.Points[0].X, Ellipse.Points[0].Y, Ellipse.Points[1].X, Ellipse.Points[1].Y));
                        break;

                }

                pictureBox1.Image = bitmapMain;
            }
        }
             int index = listBox1.SelectedIndex;
            int Y1 = new Y(index + 5);
            figureList[index].Points[0].X=listBox1.Items.RemoveAt.Point[Y1.X];
            ReDrow();

        private void ButtonLeft_Click(object sender, EventArgs e)
        {

        }

        private void ButtonDown_Click(object sender, EventArgs e)
        {

        }
    }
    }
    enum SelectFigure : byte
    {
        None,
        Line,
        Rectangle,
        Ellipse
    }
}
