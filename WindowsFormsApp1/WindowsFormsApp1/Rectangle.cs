using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp1
{
    class Rectangle : Figure
    {
        Point p1, p2;
        public Rectangle(SelectFigure FigureTipe, Pen Pen, int x1, int y1, int x2, int y2) : base(FigureTipe, Pen)
        {
            p1.X = y1;
            p1.Y = y1;
            p2.X = x2;
            p2.Y = y2;
            base.Points = new List<Point>(new List<Point>() { p1, p2 });
        }

        public Rectangle(SelectFigure FigureTipe, Pen Pen, Point p1, Point p2) : base(FigureTipe, Pen)
        {
            this.p1 = p1;
            this.p2 = p2;
            base.Points = new List<Point>(new List<Point>() { p1, p2 });
        }

        public Rectangle(SelectFigure FigureTipe, Pen Pen, List<Point> listPoints) : base(FigureTipe, Pen, listPoints)
        {
            this.p1 = listPoints[0];
            this.p2 = listPoints[1];
        }
        public override void Draw(Graphics graphics)
        {
            if (p1.X < p2.X && p1.Y < p2.Y)
            {
                graphics.DrawRectangle(Pen, p1.X, p1.Y, p2.X - p1.X, p2.Y - p1.Y);
            }
            else if (p1.X > p2.X && p1.Y > p2.Y)
            {
                graphics.DrawRectangle(Pen, p2.X, p2.Y, p1.X - p2.X, p1.Y - p2.Y);
            }
            else if (p1.X < p2.X && p1.Y > p2.Y)
            {
                graphics.DrawRectangle(Pen, p1.X, p2.Y, p2.X - p1.X, p1.Y - p2.Y);
            }
            else if (p1.X > p2.X && p1.Y < p2.Y)
            {
                graphics.DrawRectangle(Pen, p2.X, p1.Y, p1.X - p2.X, p2.Y - p1.Y);
            }
        }
    }
}