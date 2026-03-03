using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace drawing
{
    public class ShapeDrawer
    {
        public sMainWindow mw;
        public ShapeDrawer() { }

        public bool WaitingForAnotherClick;
        public List<Point> positions = new List<Point>(); 
        public void DrawShape(string shape, SolidColorBrush brush, Point position)
        {
            if(shape == "Rectangle")
            {
                if(positions.Count == 0)
                {
                    positions.Add(position);
                } else
                {
                    positions.Add(position);

                    CreateRectagle(brush);

                    positions.Clear();
                }
            } else if(shape == "Circle")
            {

            } else if(shape == "Line")
            {

            }

        }

        public void CreateRectagle(SolidColorBrush brush)
        {
            System.Windows.Shapes.Rectangle rect = new System.Windows.Shapes.Rectangle();
            rect.Width = Math.Abs(positions[0].X - positions[1].X);
            rect.Height = Math.Abs(positions[0].Y - positions[1].Y); 
            /*
            rect.X = (positions[0].X < positions[1].X) ? positions[0].X : positions[1].X;
            rect.Y = (positions[0].Y < positions[1].Y) ? positions[0].Y : positions[1].Y; 
            */

            rect.Fill = brush;
            rect.Stroke = brush;
            

            Canvas.SetLeft(rect, 50);
            Canvas.SetTop(rect, 50);

            
        }
    }
}
