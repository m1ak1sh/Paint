using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;


namespace WindowsFormsApp1
{
    class Line : Figure
    {

        Point p1, p2;

        public Line(SelectFigure FigureTipe, Pen Pen, int x1, int y1, int x2, int y2) : base(FigureTipe, Pen)
        {

            p1.X = x1;
            p1.Y = y1;
            p2.X = x2;
            p2.Y = y2;
            base.Points = new List<Point>(new List<Point>() { p1, p2 });

        }
        public Line(SelectFigure FigureTipe, Pen Pen, Point p1, Point p2) : base(FigureTipe, Pen)
        {
            this.p1 = p1;
            this.p2 = p2;
            base.Points = new List<Point>(new List<Point>() { p1, p2 });
        }
        public Line(SelectFigure FigureTipe, Pen Pen, List<Point> listPoints) : base(FigureTipe, Pen, listPoints)
        {


            this.p1 = listPoints[0];
            this.p2 = listPoints[1];

      
        
        }
        public override void Draw(Graphics graphics)
        {
            graphics.DrawLine(Pen, p1, p2);
        }
    }  
}
