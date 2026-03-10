using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Shapes;
using Point = System.Drawing.Point;

namespace drawing
{
    public class ShapeDrawer
    {
        public MainWindow mw;
        public ShapeDrawer() { }

        public bool WaitingForAnotherClick;
        public List<Point> positions = new List<Point>();
        public List<SaveFormat> savedShapes = new List<SaveFormat>();

        public List<String> serializedShapes = new List<String>();

        public void DrawShape(string shape, SolidColorBrush brush, Point position)
        {
            if(shape == "Rectangle" || shape == "Circle" || shape == "Line")
            {
                if(positions.Count == 0)
                {
                    positions.Add(position);
                } else
                {
                    positions.Add(position);

                    if(shape == "Rectangle")
                    {
                        CreateRectagle(brush);
                    } else if(shape == "Line")
                    {
                        CreateLine(brush);

                    } else if(shape == "Circle")
                    {

                    }


                    positions.Clear();
                }
            } else
            {

            }

        }

        public void CreateRectagle(SolidColorBrush brush)
        {
            System.Windows.Shapes.Rectangle rect = new System.Windows.Shapes.Rectangle();
            rect.Width = Math.Abs(positions[0].X - positions[1].X);
            rect.Height = Math.Abs(positions[0].Y - positions[1].Y); 
            
            int X = (positions[0].X < positions[1].X) ? positions[0].X : positions[1].X;
            int Y = (positions[0].Y < positions[1].Y) ? positions[0].Y : positions[1].Y; 
            

            rect.Fill = brush;
            rect.Stroke = brush;
            

            Canvas.SetLeft(rect, X);
            Canvas.SetTop(rect, Y);

            mw.AddShapeToCanvas(rect);
            savedShapes.Add(new SaveFormat().Convert(rect, X, Y));
        }

        public void CreateLine(SolidColorBrush brush)
        {
            var myLine = new Line();
            myLine.Stroke = brush;
            myLine.StrokeThickness = 2;
            myLine.Fill = brush;

            myLine.X1 = positions[0].X;
            myLine.Y1 = positions[0].Y;
            myLine.X2 = positions[1].X;
            myLine.Y2 = positions[1].Y;


            mw.AddShapeToCanvas(myLine);
            savedShapes.Add(new SaveFormat().Convert(myLine));
        }

        public string SaveFile()
        {
            return JsonSerializer.Serialize(savedShapes.ToArray());

        }

        public void LoadedFile(List<SaveFormat> loaded)
        {
            savedShapes = loaded;
            foreach (SaveFormat saveFormat in savedShapes) {
                if(saveFormat.shape == "Rectangle")
                {
                    System.Windows.Shapes.Rectangle rect = new System.Windows.Shapes.Rectangle();
                    rect.Width = saveFormat.width;
                    rect.Height = saveFormat.height;

                    int X = saveFormat.pos[0];
                    int Y = saveFormat.pos[1];

                    SolidColorBrush brush = (SolidColorBrush)new BrushConverter().ConvertFromString(saveFormat.fill);
                    rect.Fill = brush;
                    rect.Stroke = brush;


                    Canvas.SetLeft(rect, X);
                    Canvas.SetTop(rect, Y);

                    mw.AddShapeToCanvas(rect);
                }
            
            }
        }
    }
}
