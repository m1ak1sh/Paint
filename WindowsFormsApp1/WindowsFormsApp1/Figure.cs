using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace WindowsFormsApp1
{
    abstract class Figure
    {
        public SelectFigure FigureTipe { get; }

        public System.Drawing.Pen Pen { get; set; }

        public List<Point> Points { get; set; }


        public Figure(SelectFigure FigureTipe, Pen pen)
        {
            this.FigureTipe = FigureTipe;
            this.Pen = pen;
        }
            
        public Figure(SelectFigure FigureTipe, Pen pen, List<Point>points) 
        {
            this.FigureTipe = FigureTipe;
            this.Pen = pen;
            this.Points = new List<Point>(points);
        }

        public abstract void Draw(Graphics graphics);

        public override string ToString()
        {
            switch (FigureTipe)
            {
                case SelectFigure.Line:
                    return "Линия";
                case SelectFigure.Rectangle:
                    return "Прямоугольник";
                case SelectFigure.Ellipse:
                    return "Эллипс";

            }
            return "None";
        }

    }




}     

