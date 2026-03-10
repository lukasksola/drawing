using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
namespace drawing
{
    public class SaveFormat
    {
        public string shape { get; set; }
        public double width { get; set; }
        public double height { get; set; }
        public int thickness { get; set; }

        public string fill { get; set; }

        public int[] pos { get; set; }


        public SaveFormat Convert(System.Windows.Shapes.Rectangle rect, int X, int Y)
        {
            shape = "Rectangle";
            width = rect.Width;
            height = rect.Height;
            thickness = 0;
            fill = rect.Fill.ToString();
            pos = new int[2];
            pos[0] = X;
            pos[1] = Y;

            return this;
        }

        public SaveFormat Convert(Line line) {
            shape = "Line";

            thickness = (int)line.StrokeThickness;
            fill = line.Stroke.ToString();

            pos = new int[4];
            pos[0] = (int)line.X1;
            pos[1] = (int)line.Y1;

            pos[2] = (int)line.X2;
            pos[3] = (int)line.Y2;
            return this;
        }
    }
}
